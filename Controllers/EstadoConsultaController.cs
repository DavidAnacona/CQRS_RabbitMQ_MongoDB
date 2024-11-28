using ConsultaService.Entities;
using ConsultaService.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ConsultaService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoConsultaController : ControllerBase
    {
        private readonly EstadoConsultaRepository _estadoConsultaRepository;

        public EstadoConsultaController(EstadoConsultaRepository estadoConsultaRepository)
        {
            _estadoConsultaRepository = estadoConsultaRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<EstadoConsultaEntity>>> GetAll()
        {
            var estados = await _estadoConsultaRepository.GetAllAsync();
            return Ok(estados);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EstadoConsultaEntity>> GetById(int id)
        {
            var estado = await _estadoConsultaRepository.GetByIdAsync(id);

            if (estado == null)
                return NotFound();

            return Ok(estado);
        }
    }
}
