using MongoDB.Driver;
using Noa.BeamManager.Docker.Configuration;
using Noa.BeamManager.Docker.Services;
using Noa.BeamManager.Repository.Repositories;
using Noa.BeamManager.Repository.Utils;

namespace Noa.BeamManager.Docker;

public static class ConfigureServicesExtensions
{
    public static IServiceCollection ConfigureNoaServices(this IServiceCollection serviceCollection, ServiceConfiguration config) =>
        serviceCollection
            .AddSingleton(config)
            .AddSingleton(provider => MgdbDatabaseFactory.Create(config.Database.ConnectionString, config.Database.DatabaseName))
            .AddTransient<IMeasureRepository, MgdbMeasureRepository>()
            .AddTransient<IMeasureService, MeasureService>();
}
