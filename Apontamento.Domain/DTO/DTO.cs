namespace Apontamento.Domain.DTO
{
    public abstract class DTO
    {
        private List<string> _erros;

        public DTO()
        {
            _erros = new List<string>();
        }

        public IReadOnlyList<string> Erros { get => _erros; }
        public bool Invalido { get => _erros.Any(); }
        public bool Valido { get => !Invalido; }

        public void AdicionarErro(string mensagem)
        {
            _erros.Add(mensagem);
        }
    }
}
