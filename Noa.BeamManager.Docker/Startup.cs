
using Noa.BeamManager.Docker.Configuration;

namespace Noa.BeamManager.Docker
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var configuration = Configuration.GetSection(ServiceConfiguration.ServiceName).Get<ServiceConfiguration>();

            services.Configure<ServiceConfiguration>(Configuration.GetSection(ServiceConfiguration.ServiceName));

            services.AddControllers();

            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen();

            services.ConfigureNoaServices(configuration);
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseRouting();

            app.UseSwagger();

            app.UseSwaggerUI();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
