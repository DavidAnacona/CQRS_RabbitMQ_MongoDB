using ConsultaService.Entities;
using ConsultaService.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ConsultaService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecetaController : ControllerBase
    {
        private readonly RecetaRepository _recetaRepository;

        public RecetaController(RecetaRepository recetaRepository)
        {
            _recetaRepository = recetaRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<RecetaEntity>>> GetAll()
        {
            var recetas = await _recetaRepository.GetAllAsync();
            return Ok(recetas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RecetaEntity>> GetById(int id)
        {
            var receta = await _recetaRepository.GetByIdAsync(id);

            if (receta == null)
                return NotFound();

            return Ok(receta);
        }
    }
}
