using Microsoft.AspNetCore.Mvc;
using BancoKRT.Services;
using System.Threading.Tasks;

namespace BancoKRT.Controllers
{
    [ApiController]
    [Route("api/pix")]
    public class PixController : ControllerBase
    {
        private readonly PixService _pixService;

        public PixController(PixService pixService)
        {
            _pixService = pixService;
        }

        [HttpPost]
        public async Task<IActionResult> RealizarPix([FromBody] TransacaoRequest request)
        {
            var resultado = await _pixService.RealizarPix(request.Documento, request.Valor);
            if (!resultado.TransacaoRealizada)
            {
                return BadRequest(resultado.MensagemRetorno);
            }
            return Ok("Transação aprovada");
        }
    }

    public class TransacaoRequest
    {
        public string Documento { get; set; }
        public decimal Valor { get; set; }
    }
}
