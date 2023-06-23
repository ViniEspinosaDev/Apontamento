namespace Apontamento.Domain.Entities
{
    public abstract class BaseEntity
    {
        public string Erro { get; private set; }
        public bool Valido { get => string.IsNullOrWhiteSpace(Erro); }
        public bool Invalido { get => !Valido; }

        public void AdicionarErro(string erro)
        {
            if (string.IsNullOrWhiteSpace(erro)) return;

            Erro = erro;
        }
    }
}
