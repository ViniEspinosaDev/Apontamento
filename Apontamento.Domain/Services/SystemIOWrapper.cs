using Apontamento.Domain.DTO;
using Apontamento.Domain.Entities;
using Apontamento.Domain.Interfaces;
using System.Text;

namespace Apontamento.Domain.Services
{
    public class SystemIOWrapper : ISystemIOWrapper
    {
        private string _caminhoApontamentosAppData = $@"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\Apontamentos";

        public SystemIOWrapper()
        {
            CriarPastaApontamentosCasoNaoExista();
        }

        public CustomResult<string> RecuperarArquivoTexto(string nomeArquivo)
        {
            var customResult = new CustomResult<string>();

            try
            {
                string caminhoCompleto = Path.Combine(_caminhoApontamentosAppData, nomeArquivo);

                bool arquivoNaoExiste = !File.Exists(caminhoCompleto);

                if (arquivoNaoExiste) return customResult;

                var arquivo = new StringBuilder();

                using (StreamReader reader = new StreamReader(caminhoCompleto))
                {
                    while (!reader.EndOfStream)
                        arquivo.AppendLine(reader.ReadLine());
                }

                var arquivoTexto = arquivo.ToString();

                customResult.AdicionarResultado(arquivoTexto);
            }
            catch (Exception ex)
            {
                string mensagem = $"Falha ao recuperar arquivo texto. Retorno: {ex.Message}";
                customResult.AdicionarErro(mensagem);
            }

            return customResult;
        }

        public CustomResult<string> SalvarArquivoTexto(ArquivoDTO arquivoDTO)
        {
            var customResult = new CustomResult<string>();

            try
            {
                string caminhoCompleto = Path.Combine(_caminhoApontamentosAppData, arquivoDTO.NomeArquivo);

                bool arquivoExiste = File.Exists(caminhoCompleto);

                if (arquivoExiste)
                {
                    File.Delete(caminhoCompleto);
                }

                using (var streamWriter = new StreamWriter(caminhoCompleto))
                {
                    streamWriter.Write(arquivoDTO.ArquivoTexto);
                    streamWriter.Close();
                }
            }
            catch (Exception ex)
            {
                string mensagem = $"Falha ao salvar arquivo texto. Retorno: {ex.Message}";
                customResult.AdicionarErro(mensagem);
            }

            return customResult;
        }

        private void CriarPastaApontamentosCasoNaoExista()
        {
            if (Directory.Exists(_caminhoApontamentosAppData)) return;

            Directory.CreateDirectory(_caminhoApontamentosAppData);
        }
    }
}
