namespace Apontamento.Domain.Entities
{
    public class CustomResult<T>
    {
        public CustomResult()
        {
            Erro = string.Empty;
        }

        public string Erro { get; private set; }
        public T Resultado { get; private set; }
        public bool Valido { get => string.IsNullOrWhiteSpace(Erro); }
        public bool Invalido { get => !Valido; }

        public void AdicionarErro(string erro) => Erro = erro;
        public void AdicionarResultado(T resultado) => Resultado = resultado;
    }
}
