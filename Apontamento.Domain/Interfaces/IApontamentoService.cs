using Apontamento.Domain.Entities;

namespace Apontamento.Domain.Interfaces
{
    public interface IApontamentoService
    {
        CustomResult<string> ObtemPreview(DateTime dataSelecionada);
        CustomResult<bool> Salvar(DateTime dataSelecionada, Entities.ApontamentoLinha apontamento);
        CustomResult<Entities.ApontamentoLinha> ObtemApontamento(DateTime dataSelecionada, int linha);
    }
}
