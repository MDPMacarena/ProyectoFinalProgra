using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Models.DTOs;
using ProyectoFinal.Services;

namespace ProyectoFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CodePlaygroundController : ControllerBase
    {
        public CodePlaygroundService Service { get; }

        public CodePlaygroundController(CodePlaygroundService service)
        {
            Service = service;
        }
        [HttpGet("{tipo}")]
        public IActionResult GetEjercicios(string tipo)
        {
            var ejercicios = Service.GetEjerciciosPorTipo(tipo);
            return Ok(ejercicios);
        }
        [HttpPost("validar")]
        public IActionResult ValidarCodigo([FromBody] ValidarCodigoDto validacion)
        {
            var resultado = Service.ValidarCodigo(validacion);
            return Ok(resultado);
        }
    }
}
