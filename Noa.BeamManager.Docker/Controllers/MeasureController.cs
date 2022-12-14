using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Noa.BeamManager.Contract.v1;
using Noa.BeamManager.Docker.Services;

namespace Noa.BeamManager.Docker.Controllers
{
    [ApiController]
    [Route("measure")]
    public class MeasureController : ControllerBase
    {
        private readonly IMeasureService _measureService;

        public MeasureController(IMeasureService measureService)
        {
            _measureService = measureService;
        }

        [HttpGet("{beamId}")]
        public async Task<List<Measure>> GetBeamMeasures([FromRoute] Guid beamId, [FromQuery] DateTime from, [FromQuery] DateTime to)
        {
            var contacts = await _measureService.GetBeamMeasuresAsync(beamId, from, to);
            return contacts;
        }

        [HttpPost("{beamId}")]
        public async Task UpdateUserContactsAsync([FromRoute] Guid beamId, [FromBody] List<Measure> measures)
        {
            await _measureService.AddBeamMeasuresAsync(beamId, measures);
        }
    }
}
