using Noa.BeamManager.Repository.Model;

namespace Noa.BeamManager.Docker.Mappers
{
    public static class MeasureExtensions
    {
        public static Contract.v1.Measure ToContract(this Measure measure) => new()
        {
            Type = measure.Type,
            Value = measure.Value,
            Timestamp = measure.Timestamp
        };

        public static Measure ToModel(this Contract.v1.Measure measure, Guid beamId) => new()
        {
            BeamId = beamId,
            Type = measure.Type,
            Value = measure.Value,
            Timestamp = measure.Timestamp
        };
    }
}
