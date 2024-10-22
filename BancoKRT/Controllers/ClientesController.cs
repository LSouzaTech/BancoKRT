using BancoKRT.Models;
using BancoKRT.Services;
using Microsoft.AspNetCore.Mvc;

namespace BancoKRT.Controllers
{
    [ApiController]
    [Route("api/clientes")]
    public class ClientesController : ControllerBase
    {
        private readonly ClienteService _service;

        public ClientesController(ClienteService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar([FromBody] Cliente cliente)
        {
            await _service.AddClienteAsync(cliente);
            return CreatedAtAction(nameof(Buscar), new { documento = cliente.Documento }, cliente);
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

        [HttpPost("transacao")]
        public async Task<IActionResult> RealizarTransacao([FromBody] TransacaoRequest request)
        {
            bool sucesso = await _service.ValidarTransacaoAsync(request.Documento, request.Valor);
            if (!sucesso) return BadRequest("Limite insuficiente");
            return Ok("Transação aprovada");
        }
    }

    public class TransacaoRequest
    {
        public string Documento { get; set; }
        public decimal Valor { get; set; }
    }
}
