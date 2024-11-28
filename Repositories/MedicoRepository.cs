using ConsultaService.Entities;
using MongoDB.Driver;

namespace ConsultaService.Repositories
{
    public class MedicoRepository
    {
        private readonly IMongoCollection<MedicoEntity> _medicosCollection;

        public MedicoRepository(IMongoDatabase database)
        {
            _medicosCollection = database.GetCollection<MedicoEntity>("Medicos");
        }

        public async Task<List<MedicoEntity>> GetAllAsync()
        {
            var projection = Builders<MedicoEntity>.Projection.Exclude("_id");
            var medicos = await _medicosCollection.Find(_ => true)
                                                  .Project<MedicoEntity>(projection)
                                                  .ToListAsync();
            return medicos;
        }

        public async Task<MedicoEntity?> GetByIdAsync(int idMedico)
        {
            var projection = Builders<MedicoEntity>.Projection.Exclude("_id");
            var medico = await _medicosCollection.Find(m => m.IdMedico == idMedico)
                                                 .Project<MedicoEntity>(projection)
                                                 .FirstOrDefaultAsync();
            return medico;
        }
    }
}
