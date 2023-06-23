using Apontamento.Domain.DTO;
using Apontamento.Domain.Entities;
using Apontamento.Domain.Interfaces;
using System.Globalization;
using System.Text;

namespace Apontamento.Domain.Services
{
    public class ApontamentoService : IApontamentoService
    {
        private readonly ISystemIOWrapper _systemIOWrapper;

        public ApontamentoService(ISystemIOWrapper systemIOWrapper)
        {
            _systemIOWrapper = systemIOWrapper;
        }

        public CustomResult<string> ObtemPreview(DateTime dataSelecionada)
        {
            var customResult = new CustomResult<string>();

            try
            {
                string nomeArquivo = CriarNomeArquivo(dataSelecionada);

                var previewResult = _systemIOWrapper.RecuperarArquivoTexto(nomeArquivo);

                if (previewResult.Invalido)
                {
                    customResult.AdicionarErro(previewResult.Erro);
                    return customResult;
                }

                if (string.IsNullOrWhiteSpace(previewResult.Resultado))
                {
                    var salvarArquivoVazioResponse = SalvarArquivoVazio(dataSelecionada);

                    if (salvarArquivoVazioResponse.Invalido)
                    {
                        customResult.AdicionarErro(salvarArquivoVazioResponse.Erro);
                        return customResult;
                    }
                    else
                        previewResult.AdicionarResultado(salvarArquivoVazioResponse.Resultado);
                }

                customResult.AdicionarResultado(previewResult.Resultado);
            }
            catch (Exception ex)
            {
                string mensagem = $"Falha ao ler arquivo. Retorno: {ex.Message}";
                customResult.AdicionarErro(mensagem);
            }

            return customResult;
        }



        public CustomResult<bool> Salvar(DateTime dataSelecionada, ApontamentoLinha apontamento)
        {
            var customResult = new CustomResult<bool>();

            try
            {
                var preview = ObtemPreview(dataSelecionada);

                if (preview.Invalido)
                {
                    customResult.AdicionarErro(preview.Erro);
                    return customResult;
                }

                var arquivo = TransformarArquivoTextoEmEntidade(preview.Resultado);

                if (apontamento.Linha > 0)
                    arquivo.AtualizarApontamento(apontamento);
                else
                    arquivo.AdicionarApontamento(apontamento);

                string arquivoTexto = TransformarEntidadeEmArquivoTexto(arquivo);

                string nomeArquivo = CriarNomeArquivo(dataSelecionada);

                var arquivoDTO = new ArquivoDTO()
                {
                    ArquivoTexto = arquivoTexto,
                    NomeArquivo = nomeArquivo
                };

                var salvarArquivoResponse = _systemIOWrapper.SalvarArquivoTexto(arquivoDTO);

                if (salvarArquivoResponse.Invalido)
                    customResult.AdicionarErro(salvarArquivoResponse.Erro);
            }
            catch (Exception ex)
            {
                string mensagem = $"Falha ao salvar apontamento. Retorno: {ex.Message}";
                customResult.AdicionarErro(mensagem);
            }

            return customResult;
        }

        public CustomResult<ApontamentoLinha> ObtemApontamento(DateTime dataSelecionada, int linha)
        {
            var customResult = new CustomResult<ApontamentoLinha>();

            try
            {
                var previewResult = ObtemPreview(dataSelecionada);

                if (previewResult.Invalido)
                {
                    customResult.AdicionarErro(previewResult.Erro);
                    return customResult;
                }

                var arquivoDTO = TransformarArquivoTextoEmEntidade(previewResult.Resultado);

                var apontamentoDTO = arquivoDTO.Apontamentos.FirstOrDefault(a => a.Linha == linha);

                customResult.AdicionarResultado(apontamentoDTO);
            }
            catch (Exception ex)
            {
                string mensagem = $"Falha ao obter apontamento. Retorno: {ex.Message}";
                customResult.AdicionarErro(mensagem);
            }

            return customResult;
        }

        private string TransformarEntidadeEmArquivoTexto(ArquivoApontamento arquivoDTO)
        {
            var arquivoTexto = new StringBuilder();

            arquivoTexto.AppendLine($"Dia: {arquivoDTO.Data}");
            arquivoTexto.AppendLine("");

            foreach (var apontamentoDTO in arquivoDTO.Apontamentos)
            {
                string apontamentoTexto = $"{apontamentoDTO.Linha} - #{apontamentoDTO.Tarefa}: {apontamentoDTO.Tempo} {apontamentoDTO.Acao}";
                arquivoTexto.AppendLine(apontamentoTexto);
            }

            return arquivoTexto.ToString().Remove(arquivoTexto.Length - 1);
        }

        private ArquivoApontamento TransformarArquivoTextoEmEntidade(string arquivoTexto)
        {
            var arquivo = new ArquivoApontamento();

            try
            {
                if (string.IsNullOrEmpty(arquivoTexto)) return arquivo;

                var linhasArquivo = arquivoTexto.Split("\n");

                for (int indice = 0; indice < linhasArquivo.Length; indice++)
                {
                    string linhaAtual = linhasArquivo[indice].Replace("\r", "");

                    bool linhaVazia = string.IsNullOrWhiteSpace(linhaAtual);

                    if (linhaVazia) continue;

                    bool primeiraLinha = indice == 0;

                    if (primeiraLinha)
                    {
                        arquivo = ObtemArquivoPelaPrimeiraLinha(linhaAtual);
                        continue;
                    }

                    var apontamento = ObtemApontamentoPelaLinha(linhaAtual);

                    arquivo.AdicionarApontamento(apontamento);
                }
            }
            catch (Exception ex)
            {
                string mensagem = $"Falha ao transformar arquivo texto em objeto. Retorno: {ex.Message}";
                arquivo.AdicionarErro(mensagem);
            }

            return arquivo;
        }

        private CustomResult<string> SalvarArquivoVazio(DateTime dataSelecionada)
        {
            var customResponse = new CustomResult<string>();

            try
            {
                string nomeArquivo = CriarNomeArquivo(dataSelecionada);

                var arquivo = new ArquivoApontamento(nomeArquivo: nomeArquivo, data: dataSelecionada.Date.ToString("dd/MM/yyyy"));

                string arquivoTexto = TransformarEntidadeEmArquivoTexto(arquivo);

                var arquivoDTO = new ArquivoDTO()
                {
                    ArquivoTexto = arquivoTexto,
                    NomeArquivo = nomeArquivo
                };

                var salvarResponse = _systemIOWrapper.SalvarArquivoTexto(arquivoDTO);

                if (salvarResponse.Invalido)
                    customResponse.AdicionarErro(salvarResponse.Erro);
                else
                    customResponse.AdicionarResultado(arquivoTexto);
            }
            catch (Exception ex)
            {
                string mensagem = $"Falha ao salvar arquivo vazio. Retorno: {ex.Message}";
                customResponse.AdicionarErro(mensagem);
            }

            return customResponse;
        }

        private ApontamentoLinha ObtemApontamentoPelaLinha(string linhaArquivo)
        {
            var dadosSeparados = linhaArquivo.Split(" ");

            int.TryParse(dadosSeparados[0], out int linha);

            var apontamentoDTO = new ApontamentoLinha(
                linha: linha,
                tarefa: dadosSeparados[2].Replace(":", "").Replace("#", ""),
                tempo: dadosSeparados[3],
                acao: dadosSeparados[4]);

            return apontamentoDTO;
        }

        private ArquivoApontamento ObtemArquivoPelaPrimeiraLinha(string linhaArquivo)
        {
            string dataTexto = linhaArquivo.Split(" ")[1];

            DateTime.TryParseExact(dataTexto, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime data);

            var arquivoDTO = new ArquivoApontamento(
                nomeArquivo: CriarNomeArquivo(data),
                data: dataTexto);

            return arquivoDTO;
        }

        private string CriarNomeArquivo(DateTime dataSelecionada) => $"Apontamento_{dataSelecionada.Date.ToString("dd-MM-yyyy")}.txt";
    }
}
