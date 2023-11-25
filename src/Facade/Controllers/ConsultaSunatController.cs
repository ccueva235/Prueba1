using Domain.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Facade.Controllers
{
    [Route("api/ConsultarDNI")]
    [ApiController]
    public class ConsultaSunatController : ControllerBase
    {
        private readonly IConsultaSunatService consultaSunatService;

        public ConsultaSunatController(IConsultaSunatService consultaSunatService)
        {
            this.consultaSunatService = consultaSunatService;
        }
         
        [HttpGet]
        public async Task<IActionResult> BuscarDNI(String DNI)
        {
            try
            {
                var resultado = await consultaSunatService.BuscarDNI(DNI);
                // Aquí podrías manejar la respuesta o devolver algún resultado
                return Ok(resultado); // Cambia el mensaje o el resultado según tu lógica
            }
            catch (Exception ex)
            {
                // Manejo de errores
                return StatusCode(500, $"Error al consultar el DNI: {ex.Message}");
            }
        }
    }
}
