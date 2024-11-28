using ConsultaService.Entities;
using MongoDB.Driver;

namespace ConsultaService.Repositories
{
    public class HistorialEstadoRepository
    {
        private readonly IMongoCollection<HistorialEstadoEntity> _historialCollection;

        public HistorialEstadoRepository(IMongoDatabase database)
        {
            _historialCollection = database.GetCollection<HistorialEstadoEntity>("HistorialEstadoConsulta");
        }

        public async Task<List<HistorialEstadoEntity>> GetAllAsync()
        {
            var projection = Builders<HistorialEstadoEntity>.Projection.Exclude("_id");
            var historiales = await _historialCollection.Find(_ => true)
                                                        .Project<HistorialEstadoEntity>(projection)
                                                        .ToListAsync();
            return historiales;
        }

        public async Task<HistorialEstadoEntity?> GetByIdAsync(int idHistorialEstado)
        {
            var projection = Builders<HistorialEstadoEntity>.Projection.Exclude("_id");
            var historial = await _historialCollection.Find(h => h.IdHistorialEstado == idHistorialEstado)
                                                      .Project<HistorialEstadoEntity>(projection)
                                                      .FirstOrDefaultAsync();
            return historial;
        }
    }
}
