using BancoKRT.Models;
using BancoKRT.Repositories;

namespace BancoKRT.Services
{
    public class GestaoLimiteService
    {
        private readonly IClienteRepository _repository;

        public GestaoLimiteService(IClienteRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> ValidarTransacaoAsync(string documento, decimal valorTransacao)
        {
            var cliente = await _repository.GetClienteAsync(documento);
            if (cliente == null || cliente.LimitePIX < valorTransacao)
            {
                return false; // Transação negada
            }

            // Atualiza o limite
            cliente.LimitePIX -= valorTransacao;
            await _repository.UpdateClienteAsync(cliente);
            return true; // Transação aprovada
        }

        public async Task AddClienteAsync(Cliente cliente)
        {
            await _repository.AddClienteAsync(cliente);
        }

        public async Task<Cliente> BuscarClienteAsync(string documento)
        {
            return await _repository.GetClienteAsync(documento);
        }

        public async Task AtualizarClienteAsync(Cliente cliente)
        {
            await _repository.UpdateClienteAsync(cliente);
        }

        public async Task RemoverClienteAsync(string documento)
        {
            await _repository.DeleteClienteAsync(documento);
        }
    }
}
