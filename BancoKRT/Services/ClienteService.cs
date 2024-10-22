using BancoKRT.Models;
using BancoKRT.Repositories;

namespace BancoKRT.Services
{
    public class ClienteService
    {
        // Armazena uma instância do repositório de clientes
        private readonly IClienteRepository _repository;

        // Construtor que recebe uma instância de IClienteRepository
        public ClienteService(IClienteRepository repository)
        {
            _repository = repository;
        }

        // Método para validar uma transação
        public async Task<bool> ValidarTransacaoAsync(string documento, decimal valorTransacao)
        {
            // Busca o cliente pelo documento
            var cliente = await _repository.GetClienteAsync(documento);

            // Verifica se o cliente existe e se o limite é suficiente
            if (cliente == null || cliente.LimitePIX < valorTransacao)
            {
                return false; // Transação negada
            }

            // Atualiza o limite do cliente
            cliente.LimitePIX -= valorTransacao;
            await _repository.UpdateClienteAsync(cliente);
            return true; // Transação aprovada
        }

        // Método para adicionar um novo cliente
        public async Task AddClienteAsync(Cliente cliente)
        {
            await _repository.AddClienteAsync(cliente);
        }

        // Método para buscar um cliente pelo documento
        public async Task<Cliente> BuscarClienteAsync(string documento)
        {
            return await _repository.GetClienteAsync(documento);
        }

        // Método para atualizar informações de um cliente
        public async Task AtualizarClienteAsync(Cliente cliente)
        {
            await _repository.UpdateClienteAsync(cliente);
        }

        // Método para remover um cliente pelo documento
        public async Task RemoverClienteAsync(string documento)
        {
            await _repository.DeleteClienteAsync(documento);
        }
    }
}
