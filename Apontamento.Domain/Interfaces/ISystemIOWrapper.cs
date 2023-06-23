using Apontamento.Domain.DTO;
using Apontamento.Domain.Entities;

namespace Apontamento.Domain.Interfaces
{
    public interface ISystemIOWrapper
    {
        CustomResult<string> SalvarArquivoTexto(ArquivoDTO arquivoDTO);
        CustomResult<string> RecuperarArquivoTexto(string nomeArquivo);
    }
}
