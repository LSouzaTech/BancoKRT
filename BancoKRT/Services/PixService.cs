using System.Threading.Tasks;
using BancoKRT.Repositories;

namespace BancoKRT.Services
{
    public class PixService
    {
        private readonly IClienteRepository _repository;

        public PixService(IClienteRepository repository)
        {
            _repository = repository;
        }

        public async Task<TransacaoResult> RealizarPix(string documento, decimal valor)
        {
            var cliente = await _repository.GetClienteAsync(documento);

            if (cliente == null)
            {
                return new TransacaoResult
                {
                    TransacaoRealizada = false,
                    MensagemRetorno = "A conta informada não existe"
                };
            }

            if (cliente.LimitePIX < valor)
            {
                return new TransacaoResult
                {
                    TransacaoRealizada = false,
                    MensagemRetorno = "Limite insuficiente para realizar a transação"
                };
            }

            // Atualiza o limite
            cliente.LimitePIX -= valor;
            await _repository.UpdateClienteAsync(cliente);

            return new TransacaoResult
            {
                TransacaoRealizada = true,
                MensagemRetorno = "Transação realizada com sucesso"
            };
        }
    }

    public class TransacaoResult
    {
        public bool TransacaoRealizada { get; set; }
        public string MensagemRetorno { get; set; }
    }
}
