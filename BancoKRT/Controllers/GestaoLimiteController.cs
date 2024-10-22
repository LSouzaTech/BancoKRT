using BancoKRT.Models;
using BancoKRT.Services;
using Microsoft.AspNetCore.Mvc;

namespace BancoKRT.Controllers
{
    [ApiController]
    [Route("api/gestao-limite")]
    public class GestaoLimiteController : ControllerBase
    {
        private readonly GestaoLimiteService _service;

        public GestaoLimiteController(GestaoLimiteService service)
        {
            _service = service;
        }

        [HttpGet("{documento}")]
        public async Task<IActionResult> Buscar(string documento)
        {
            var cliente = await _service.BuscarClienteAsync(documento);
            if (cliente == null) return NotFound();
            return Ok(cliente);
        }

        [HttpPut]
        public async Task<IActionResult> Atualizar([FromBody] Cliente cliente)
        {
            await _service.AtualizarClienteAsync(cliente);
            return NoContent();
        }

        [HttpDelete("{documento}")]
        public async Task<IActionResult> Remover(string documento)
        {
            await _service.RemoverClienteAsync(documento);
            return NoContent();
        }
    }
}
