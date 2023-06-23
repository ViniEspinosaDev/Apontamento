namespace Apontamento.Domain.Entities
{
    public class ApontamentoLinha : BaseEntity
    {
        public ApontamentoLinha(int linha, string tarefa, string tempo, string acao)
        {
            Linha = linha;
            Tarefa = tarefa;
            Tempo = tempo;
            Acao = acao;
        }

        public int Linha { get; private set; }
        public string Tarefa { get; private set; }
        public string Tempo { get; private set; }
        public string Acao { get; private set; }

        public void AtualizarLinha(ApontamentoLinha apontamentoLinha)
        {
            Tarefa = apontamentoLinha.Tarefa;
            Tempo = apontamentoLinha.Tempo;
            Acao = apontamentoLinha.Acao;
        }

        public void AlterarLinha(int linha)
        {
            if (linha < 0) return;

            Linha = linha;
        }
    }
}
