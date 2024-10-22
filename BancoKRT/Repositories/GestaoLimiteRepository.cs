using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using BancoKRT.Models;

namespace BancoKRT.Repositories
{
    public class GestaoLimiteRepository : IClienteRepository
    {
        private readonly IDynamoDBContext _context;

        public GestaoLimiteRepository(IAmazonDynamoDB client)
        {
            _context = new DynamoDBContext(client);
        }

        public async Task<Cliente> GetClienteAsync(string documento)
        {
            return await _context.LoadAsync<Cliente>(documento);
        }

        public async Task AddClienteAsync(Cliente cliente)
        {
            await _context.SaveAsync(cliente);
        }

        public async Task UpdateClienteAsync(Cliente cliente)
        {
            await _context.SaveAsync(cliente);
        }

        public async Task DeleteClienteAsync(string documento)
        {
            var cliente = new Cliente { Documento = documento };
            await _context.DeleteAsync(cliente);
        }
    }
}
