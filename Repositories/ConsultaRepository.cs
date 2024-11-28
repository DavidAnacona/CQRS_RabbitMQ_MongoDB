using ConsultaService.Entities;
using MongoDB.Driver;
using MongoDB.Bson.Serialization.Attributes;

namespace ConsultaService.Repositories
{
    public class ConsultaRepository
    {
        private readonly IMongoCollection<ConsultaEntity> _consultasCollection;

        public ConsultaRepository(IMongoDatabase database)
        {
            _consultasCollection = database.GetCollection<ConsultaEntity>("Consultas");
        }

        public async Task<List<ConsultaEntity>> GetAllAsync()
        {
            var projection = Builders<ConsultaEntity>.Projection.Exclude("_id");
            var consultas = await _consultasCollection.Find(_ => true)
                                                      .Project<ConsultaEntity>(projection)
                                                      .ToListAsync();
            return consultas;
        }

        public async Task<ConsultaEntity?> GetByIdAsync(int idConsulta)
        {
            var projection = Builders<ConsultaEntity>.Projection.Exclude("_id");
            var consulta = await _consultasCollection.Find(c => c.IdConsulta == idConsulta)
                                                     .Project<ConsultaEntity>(projection)
                                                     .FirstOrDefaultAsync();
            return consulta;
        }

        public async Task<List<ConsultaEntity>> GetByEstadoAsync(int idEstadoConsulta)
        {
            var projection = Builders<ConsultaEntity>.Projection.Exclude("_id");
            var consultas = await _consultasCollection.Find(c => c.IdEstadoConsulta == idEstadoConsulta)
                                                      .Project<ConsultaEntity>(projection)
                                                      .ToListAsync();
            return consultas;
        }
    }
}
