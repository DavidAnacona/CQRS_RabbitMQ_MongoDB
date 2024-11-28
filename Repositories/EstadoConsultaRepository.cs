using ConsultaService.Entities;
using MongoDB.Driver;

namespace ConsultaService.Repositories
{
    public class EstadoConsultaRepository
    {
        private readonly IMongoCollection<EstadoConsultaEntity> _estadosCollection;

        public EstadoConsultaRepository(IMongoDatabase database)
        {
            _estadosCollection = database.GetCollection<EstadoConsultaEntity>("EstadoConsulta");
        }

        public async Task<List<EstadoConsultaEntity>> GetAllAsync()
        {
            var projection = Builders<EstadoConsultaEntity>.Projection.Exclude("_id");
            var estados = await _estadosCollection.Find(_ => true)
                                                  .Project<EstadoConsultaEntity>(projection)
                                                  .ToListAsync();
            return estados;
        }

        public async Task<EstadoConsultaEntity?> GetByIdAsync(int idEstadoConsulta)
        {
            var projection = Builders<EstadoConsultaEntity>.Projection.Exclude("_id");
            var estado = await _estadosCollection.Find(e => e.IdEstadoConsulta == idEstadoConsulta)
                                                 .Project<EstadoConsultaEntity>(projection)
                                                 .FirstOrDefaultAsync();
            return estado;
        }
    }
}
