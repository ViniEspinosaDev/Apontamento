namespace Apontamento.Domain.Entities
{
    public class ArquivoApontamento : BaseEntity
    {
        private List<ApontamentoLinha> _apontamentos;

        public ArquivoApontamento(string nomeArquivo, string data) : this()
        {
            NomeArquivo = nomeArquivo;
            Data = data;
        }

        public ArquivoApontamento()
        {
            _apontamentos = new List<ApontamentoLinha>();
        }

        public string NomeArquivo { get; private set; }
        public string Data { get; private set; }
        public IReadOnlyList<ApontamentoLinha> Apontamentos { get => _apontamentos; }

        public void AdicionarApontamento(ApontamentoLinha apontamentoLinha)
        {
            if (apontamentoLinha == null) return;

            if (apontamentoLinha.Linha < 0) apontamentoLinha.AlterarLinha(0);

            if (apontamentoLinha.Linha == 0)
            {
                if (_apontamentos.Any())
                    apontamentoLinha.AlterarLinha(_apontamentos.Select(x => x.Linha).Max() + 1);
                else
                    apontamentoLinha.AlterarLinha(1);
            }

            _apontamentos.Add(apontamentoLinha);
        }

        public void AtualizarApontamento(ApontamentoLinha apontamentoLinha)
        {
            if (apontamentoLinha.Linha < 0) apontamentoLinha.AlterarLinha(0);

            if (apontamentoLinha.Linha > 0)
            {
                _apontamentos.FirstOrDefault(a => a.Linha == apontamentoLinha.Linha).AtualizarLinha(apontamentoLinha);
                return;
            }
        }
    }
}
