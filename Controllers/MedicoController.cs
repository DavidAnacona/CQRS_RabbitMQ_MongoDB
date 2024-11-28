using ConsultaService.Entities;
using ConsultaService.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ConsultaService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicoController : ControllerBase
    {
        private readonly MedicoRepository _medicoRepository;

        public MedicoController(MedicoRepository medicoRepository)
        {
            _medicoRepository = medicoRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<MedicoEntity>>> GetAll()
        {
            var medicos = await _medicoRepository.GetAllAsync();
            return Ok(medicos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MedicoEntity>> GetById(int id)
        {
            var medico = await _medicoRepository.GetByIdAsync(id);

            if (medico == null)
                return NotFound();

            return Ok(medico);
        }
    }
}
