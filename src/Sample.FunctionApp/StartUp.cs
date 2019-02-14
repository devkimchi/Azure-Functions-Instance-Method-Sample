using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Hosting;
using Microsoft.Extensions.DependencyInjection;

using Sample.FunctionApp;
using Sample.FunctionApp.Configurations;
using Sample.FunctionApp.Functions;

[assembly: WebJobsStartup(typeof(StartUp))]
namespace Sample.FunctionApp
{
    /// <summary>
    /// This represents the startup entity for Azure Functions.
    /// </summary>
    public class StartUp : IWebJobsStartup
    {
        /// <inheritdoc />
        public void Configure(IWebJobsBuilder builder)
        {
            builder.Services.AddSingleton<AppSettings>();

            builder.Services.AddTransient<IGetSamplesFunction, GetSamplesFunction>();
        }
    }
}
