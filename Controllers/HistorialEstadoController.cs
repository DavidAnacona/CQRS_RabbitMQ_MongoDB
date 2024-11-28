using ConsultaService.Entities;
using ConsultaService.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ConsultaService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistorialEstadoController : ControllerBase
    {
        private readonly HistorialEstadoRepository _historialEstadoRepository;

        public HistorialEstadoController(HistorialEstadoRepository historialEstadoRepository)
        {
            _historialEstadoRepository = historialEstadoRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<HistorialEstadoEntity>>> GetAll()
        {
            var historiales = await _historialEstadoRepository.GetAllAsync();
            return Ok(historiales);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<HistorialEstadoEntity>> GetById(int id)
        {
            var historial = await _historialEstadoRepository.GetByIdAsync(id);

            if (historial == null)
                return NotFound();

            return Ok(historial);
        }
    }
}
