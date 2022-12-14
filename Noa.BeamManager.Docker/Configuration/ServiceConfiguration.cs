using Noa.BeamManager.Docker.Configuration;

namespace Noa.BeamManager.Docker.Configuration
{
    public class ServiceConfiguration
    {
        public const string ServiceName = "NoaBeamManager";

        public Database Database { get; set; }

        public Api Api { get; set; }
    }
}
