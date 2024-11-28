using ConsultaService.Entities;
using MongoDB.Driver;

namespace ConsultaService.Repositories
{
    public class RecetaRepository
    {
        private readonly IMongoCollection<RecetaEntity> _recetasCollection;

        public RecetaRepository(IMongoDatabase database)
        {
            _recetasCollection = database.GetCollection<RecetaEntity>("Recetas");
        }

        public async Task<List<RecetaEntity>> GetAllAsync()
        {
            var projection = Builders<RecetaEntity>.Projection.Exclude("_id");
            var recetas = await _recetasCollection.Find(_ => true)
                                                  .Project<RecetaEntity>(projection)
                                                  .ToListAsync();
            return recetas;
        }

        public async Task<RecetaEntity?> GetByIdAsync(int idReceta)
        {
            var projection = Builders<RecetaEntity>.Projection.Exclude("_id");
            var receta = await _recetasCollection.Find(r => r.IdReceta == idReceta)
                                                 .Project<RecetaEntity>(projection)
                                                 .FirstOrDefaultAsync();
            return receta;
        }
    }
}
