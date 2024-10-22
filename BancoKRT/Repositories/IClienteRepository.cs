using System.Threading.Tasks;
using BancoKRT.Models;

namespace BancoKRT.Repositories
{
    public interface IClienteRepository
    {
        Task<Cliente> GetClienteAsync(string documento);
        Task AddClienteAsync(Cliente cliente);
        Task UpdateClienteAsync(Cliente cliente);
        Task DeleteClienteAsync(string documento);
    }
}
