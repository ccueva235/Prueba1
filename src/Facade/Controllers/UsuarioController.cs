using Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Facade.Controllers
{
    [Route("api/Usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            this.usuarioService = usuarioService;
        }

        //[NonAction]
        [HttpGet]
        public async Task<IActionResult> BuscarUsuario()
        {
            try
            {
                return Ok(await usuarioService.ListarUsuario());
            }           
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }






    }
}
