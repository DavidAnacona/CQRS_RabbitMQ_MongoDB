using ConsultaService.Entities;
using ConsultaService.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ConsultaService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly PacienteRepository _pacienteRepository;

        public PacienteController(PacienteRepository pacienteRepository)
        {
            _pacienteRepository = pacienteRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<PacienteEntity>>> GetAll()
        {
            var pacientes = await _pacienteRepository.GetAllAsync();
            return Ok(pacientes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PacienteEntity>> GetById(int id)
        {
            var paciente = await _pacienteRepository.GetByIdAsync(id);

            if (paciente == null)
                return NotFound();

            return Ok(paciente);
        }
    }
}
