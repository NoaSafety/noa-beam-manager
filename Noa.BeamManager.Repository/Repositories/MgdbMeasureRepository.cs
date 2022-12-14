using MongoDB.Driver;
using Noa.BeamManager.Repository.Model;

namespace Noa.BeamManager.Repository.Repositories;

public class MgdbMeasureRepository : IMeasureRepository
{
    private readonly IMongoCollection<Measure> _measureCollection;

    public MgdbMeasureRepository(IMongoDatabase database)
    {
        _measureCollection = database.GetCollection<Measure>("measures");
    }

    public async Task AddBeamMeasuresAsync(List<Measure> measures)
    {
        await _measureCollection.InsertManyAsync(measures);
    }

    public async Task<List<Measure>> GetBeamMeasures(Guid beamId, DateTime from, DateTime to)
    {
        var measures = await _measureCollection.Find(c => c.BeamId == beamId && from < c.Timestamp && c.Timestamp < to).ToListAsync();
        return measures;
    }
}
