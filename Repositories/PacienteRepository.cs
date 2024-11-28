using ConsultaService.Entities;
using MongoDB.Driver;

namespace ConsultaService.Repositories
{
    public class PacienteRepository
    {
        private readonly IMongoCollection<PacienteEntity> _pacientesCollection;

        public PacienteRepository(IMongoDatabase database)
        {
            _pacientesCollection = database.GetCollection<PacienteEntity>("Pacientes");
        }

        public async Task<List<PacienteEntity>> GetAllAsync()
        {
            var projection = Builders<PacienteEntity>.Projection.Exclude("_id");
            var pacientes = await _pacientesCollection.Find(_ => true)
                                                      .Project<PacienteEntity>(projection)
                                                      .ToListAsync();
            return pacientes;
        }

        public async Task<PacienteEntity?> GetByIdAsync(int idPaciente)
        {
            var projection = Builders<PacienteEntity>.Projection.Exclude("_id");
            var paciente = await _pacientesCollection.Find(p => p.IdPaciente == idPaciente)
                                                     .Project<PacienteEntity>(projection)
                                                     .FirstOrDefaultAsync();
            return paciente;
        }
    }
}
