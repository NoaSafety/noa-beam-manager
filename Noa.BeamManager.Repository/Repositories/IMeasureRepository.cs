using Noa.BeamManager.Repository.Model;

namespace Noa.BeamManager.Repository.Repositories;

public interface IMeasureRepository
{
    Task<List<Measure>> GetBeamMeasures(Guid beamId, DateTime from, DateTime to);
    Task AddBeamMeasuresAsync(List<Measure> modelMeasures);
}
