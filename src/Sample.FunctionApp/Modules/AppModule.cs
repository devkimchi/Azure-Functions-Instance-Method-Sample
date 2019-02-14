using Aliencube.AzureFunctions.Extensions.DependencyInjection.Abstractions;

using Microsoft.Extensions.DependencyInjection;

using Sample.FunctionApp.Configurations;
using Sample.FunctionApp.Functions;

namespace Sample.FunctionApp.Modules
{
    /// <summary>
    /// This represents the module entity for dependency injection.
    /// </summary>
    public class AppModule : Module
    {
        /// <inheritdoc />
        public override void Load(IServiceCollection services)
        {
            services.AddSingleton<AppSettings>();

            services.AddTransient<IGetSamplesFunction, GetSamplesFunction>();
        }
    }
}
