using ConsultaService.Entities;
using ConsultaService.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ConsultaService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultaController : ControllerBase
    {
        private readonly ConsultaRepository _consultaRepository;

        public ConsultaController(ConsultaRepository consultaRepository)
        {
            _consultaRepository = consultaRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<ConsultaEntity>>> GetAll()
        {
            var consultas = await _consultaRepository.GetAllAsync();
            return Ok(consultas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ConsultaEntity>> GetById(int id)
        {
            var consulta = await _consultaRepository.GetByIdAsync(id);

            if (consulta == null)
                return NotFound();

            return Ok(consulta);
        }

        [HttpGet("estado/{estadoId}")]
        public async Task<ActionResult<List<ConsultaEntity>>> GetByEstado(int estadoId)
        {
            var consultas = await _consultaRepository.GetByEstadoAsync(estadoId);
            return Ok(consultas);
        }
    }
}
