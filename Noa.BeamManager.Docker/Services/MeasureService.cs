using Noa.BeamManager.Contract.v1;
using Noa.BeamManager.Docker.Mappers;
using Noa.BeamManager.Repository.Repositories;

namespace Noa.BeamManager.Docker.Services
{
    public class MeasureService : IMeasureService
    {
        private readonly IMeasureRepository _measureRepository;

        public MeasureService(IMeasureRepository measureRepository)
        {
            _measureRepository = measureRepository;
        }

        public async Task<List<Measure>> GetBeamMeasuresAsync(Guid beamId, DateTime from, DateTime to)
        {
            var measures = await _measureRepository.GetBeamMeasures(beamId, from, to);
            return measures.Select(m => m.ToContract()).ToList();
        }

        public async Task AddBeamMeasuresAsync(Guid beamId, List<Measure> measures)
        {
            var modelMeasures = measures.Select(c => c.ToModel(beamId)).ToList();
            await _measureRepository.AddBeamMeasuresAsync(modelMeasures);
        }
    }
}
