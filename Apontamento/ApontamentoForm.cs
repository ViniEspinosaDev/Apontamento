using Apontamento.Domain.Constantes;
using Apontamento.Domain.Entities;
using Apontamento.Domain.Interfaces;
using System.Text.RegularExpressions;

namespace Apontamento
{
    public partial class ApontamentoForm : Form
    {
        private DateTime _dataSelecionada { get => DatePickerDataApontamento.Value; }
        private int _tick = 0;
        private int _iniciouFormulario = 0;

        private readonly IApontamentoService _apontamentoService;

        public ApontamentoForm(IApontamentoService apontamentoService)
        {
            _apontamentoService = apontamentoService;

            InitializeComponent();
        }

        private void ApontamentoForm_Load(object sender, EventArgs e) { }

        private void ApontamentoForm_Activated(object sender, EventArgs e)
        {
            if (_iniciouFormulario != 0) return;

            RecuperarPreview();
            ConfigurarComboBoxAcao();
            ConfigurarComboBoxLinha();

            _iniciouFormulario = 1;
        }

        private void DatePickerDataApontamento_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                RecuperarPreview();
            }
            catch (Exception ex)
            {
                string mensagem = $"Falha ao selecionar data. Retorno: {ex.Message}";
                AdicionarErro(mensagem);
            }
        }

        private void RecuperarPreview()
        {
            try
            {
                var dataSelecionada = _dataSelecionada;

                var resultPreview = _apontamentoService.ObtemPreview(dataSelecionada);

                labelPreview.Text = resultPreview.Resultado;

                ConfigurarComboBoxLinha();
            }
            catch (Exception ex)
            {
                string mensagem = $"Falha ao recuperar preview. Retorno: {ex.Message}";
                AdicionarErro(mensagem);
            }
        }

        private List<string> RecuperarLinhasValidas()
        {
            var linhasValidas = new List<string>()
            {
                ApontamentoConstantes.NovoApontamento
            };

            int quantidadeLinhas = labelPreview.Text.Split("\n").Length - 2;

            for (int linha = 0; linha < quantidadeLinhas; linha++)
            {
                linhasValidas.Add((linha + 1).ToString());
            }

            return linhasValidas;
        }

        private void ConfigurarComboBoxLinha()
        {
            try
            {
                comboBoxLinha.Items.Clear();

                int quantidadeLinhas = labelPreview.Text.Split("\n").Length - 3;

                comboBoxLinha.Items.Add(ApontamentoConstantes.NovoApontamento);

                for (int linha = 0; linha < quantidadeLinhas; linha++)
                {
                    comboBoxLinha.Items.Add(linha + 1);
                }

                comboBoxLinha.Text = ApontamentoConstantes.NovoApontamento;
            }
            catch (Exception ex)
            {
                string mensagem = $"Falha ao configurar lista 'Linha'. Retorno: {ex.Message}";
                AdicionarErro(mensagem);
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                string linhaTexto = comboBoxLinha.Text;

                var linhasValidas = RecuperarLinhasValidas();

                if (!linhasValidas.Contains(linhaTexto))
                {
                    AdicionarErro("Selecione uma linha válida.");
                    return;
                }

                var acoesValidas = RecuperarAcoesValidas();

                string acao = comboBoxAcao.Text;

                if (!acoesValidas.Contains(acao))
                {
                    AdicionarErro("Selecione uma ação válida.");
                    return;
                }

                if (linhaTexto == ApontamentoConstantes.NovoApontamento) linhaTexto = "0";

                int.TryParse(linhaTexto, out int linha);

                string tarefa = textBoxTarefa.Text.Replace("#", "");

                bool naoContemSoNumeros = !TextoPossuiApenasNumerosInteiros(tarefa);

                if (naoContemSoNumeros)
                {
                    AdicionarErro("Tarefa deve possuir apenas números inteiros.");
                    return;
                }

                var validacaoTempoResult = ValidarTempo();

                if (validacaoTempoResult.Invalido)
                {
                    AdicionarErro(validacaoTempoResult.Erro);
                    return;
                }

                var apontamentoDTO = new ApontamentoLinha(
                    linha: linha,
                    tarefa: tarefa,
                    tempo: maskedTextBoxHoras.Text,
                    acao: acao);

                var resultSalvar = _apontamentoService.Salvar(_dataSelecionada, apontamentoDTO);

                if (resultSalvar.Invalido)
                    AdicionarErro(resultSalvar.Erro);
                else
                {
                    LimparCampos();
                    RecuperarPreview();
                    AdicionarSucesso("Apontamento salvo com sucesso.");
                }
            }
            catch (Exception ex)
            {
                string mensagem = $"Falha ao salvar apontamento. Retorno: {ex.Message}";
                AdicionarErro(mensagem);
            }
        }

        private void LimparCampos()
        {
            try
            {
                comboBoxLinha.Text = ApontamentoConstantes.NovoApontamento;
                textBoxTarefa.Text = string.Empty;
                comboBoxAcao.Text = RecuperarAcoesValidas().FirstOrDefault();
                maskedTextBoxHoras.Text = string.Empty;
            }
            catch (Exception ex)
            {
                string mensagem = $"Falha ao limpar campos. Retorno: {ex.Message}";
                AdicionarErro(mensagem);
            }
        }

        private CustomResult<bool> ValidarTempo()
        {
            var customResult = new CustomResult<bool>();

            string tempo = maskedTextBoxHoras.Text;

            if (string.IsNullOrWhiteSpace(tempo) || !tempo.Contains(":"))
            {
                customResult.AdicionarErro("Tempo não pode estar vazio");
                return customResult;
            }

            var tempoSeparado = maskedTextBoxHoras.Text.Split(":");

            if (string.IsNullOrWhiteSpace(tempoSeparado[0]) || string.IsNullOrWhiteSpace(tempoSeparado[1]))
            {
                customResult.AdicionarErro("Hora(s) e minuto(s) devem estar preenchidos.");
                return customResult;
            }

            if (!TextoPossuiApenasNumerosInteiros(tempoSeparado[0]) || !TextoPossuiApenasNumerosInteiros(tempoSeparado[0]))
            {
                customResult.AdicionarErro("Tempo deve possuir somente números inteiros.");
                return customResult;
            }

            int.TryParse(tempoSeparado[0], out int horas);
            int.TryParse(tempoSeparado[1], out int minutos);

            if (horas == 0 && minutos == 0)
            {
                customResult.AdicionarErro("Tempo não pode estar zerado.");
                return customResult;
            }

            if (minutos > 59)
            {
                customResult.AdicionarErro("O minuto não pode ser maior que 59.");
                return customResult;
            }

            return customResult;
        }

        private static bool TextoPossuiApenasNumerosInteiros(string texto)
        {
            var regex = new Regex(@"^[0-9]+$");
            return regex.IsMatch(texto);
        }

        private void btnCopiar_Click(object sender, EventArgs e)
        {
            try
            {
                string textoPreview = labelPreview.Text;

                if (string.IsNullOrWhiteSpace(textoPreview)) return;

                Clipboard.SetText(textoPreview);

                AdicionarSucesso("Copiado para área de transferência.");
            }
            catch (Exception ex)
            {
                string mensagem = $"Falha ao copiar para área de transferência. Retorno: {ex.Message}";
                AdicionarErro(mensagem);
            }
        }

        private List<string> RecuperarAcoesValidas()
        {
            return new List<string>()
            {
                "Análise", "Development", "Apoio Dev", "Apoio Consultoria", "QA", "Cerimônias"
            };
        }

        private void ConfigurarComboBoxAcao()
        {
            try
            {
                comboBoxAcao.Items.Clear();

                var acoes = RecuperarAcoesValidas();

                foreach (var acao in acoes)
                    comboBoxAcao.Items.Add(acao);

                comboBoxAcao.SelectedItem = acoes.FirstOrDefault();
            }
            catch (Exception ex)
            {
                string mensagem = $"Falha ao configurar lista 'Ação'. Retorno: {ex.Message}";
                AdicionarErro(mensagem);
            }
        }

        private void AdicionarErro(string mensagem)
        {
            labelMensagemLog.ForeColor = Color.Red;
            labelMensagemLog.Text = mensagem;
            _tick = 0;
        }

        private void AdicionarSucesso(string mensagem)
        {
            labelMensagemLog.ForeColor = Color.Green;
            labelMensagemLog.Text = mensagem;
            _tick = 0;
        }

        private void timerMensagemLog_Tick(object sender, EventArgs e)
        {
            _tick++;

            if (_tick == 3)
            {
                labelMensagemLog.Text = string.Empty;
                _tick = 0;
            }
        }

        private void comboBoxLinha_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void comboBoxLinha_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string linhaSelecionada = comboBoxLinha.Text;

                if (string.IsNullOrWhiteSpace(linhaSelecionada)) return;

                if (linhaSelecionada == ApontamentoConstantes.NovoApontamento) return;

                if (!TextoPossuiApenasNumerosInteiros(linhaSelecionada)) return;

                int.TryParse(linhaSelecionada, out int linha);

                var obtemApontamentoResult = _apontamentoService.ObtemApontamento(_dataSelecionada, linha);

                if (obtemApontamentoResult.Invalido)
                {
                    AdicionarErro(obtemApontamentoResult.Erro);
                    return;
                }

                if (obtemApontamentoResult.Resultado == default) return;

                textBoxTarefa.Text = obtemApontamentoResult.Resultado.Tarefa;
                comboBoxAcao.Text = obtemApontamentoResult.Resultado.Acao;
                maskedTextBoxHoras.Text = obtemApontamentoResult.Resultado.Tempo;
            }
            catch (Exception ex)
            {
                string mensagem = $"Falha ao selecionar linha. Retorno: {ex.Message}";
                AdicionarErro(mensagem);
            }
        }
    }
}
