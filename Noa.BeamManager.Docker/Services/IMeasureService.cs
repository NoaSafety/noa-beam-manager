using Noa.BeamManager.Contract.v1;

namespace Noa.BeamManager.Docker.Services
{
    public interface IMeasureService
    {
        Task<List<Measure>> GetBeamMeasuresAsync(Guid beamId, DateTime from, DateTime to);
        Task AddBeamMeasuresAsync(Guid beamId, List<Measure> measures);
    }
}
