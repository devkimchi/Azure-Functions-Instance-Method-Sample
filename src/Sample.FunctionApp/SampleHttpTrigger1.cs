using System.Threading.Tasks;

using Aliencube.AzureFunctions.Extensions.DependencyInjection;
using Aliencube.AzureFunctions.Extensions.DependencyInjection.Abstractions;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

using Sample.FunctionApp.Functions;
using Sample.FunctionApp.Functions.FunctionOptions;
using Sample.FunctionApp.Modules;

namespace Sample.FunctionApp
{
    /// <summary>
    /// This represents the HTTP trigger entity for sample.
    /// </summary>
    public static class SampleHttpTrigger1
    {
        public static IFunctionFactory Factory = new FunctionFactory(new AppModule());

        /// <summary>
        /// Gets the sample response.
        /// </summary>
        /// <param name="req"><see cref="HttpRequest"/> instance.</param>
        /// <param name="log"><see cref="ILogger"/> instance.</param>
        /// <returns><see cref="IActionResult"/> instance.</returns>
        [FunctionName(nameof(GetSamples1))]
        public static async Task<IActionResult> GetSamples1(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "samples1")] HttpRequest req,
            ILogger log)
        {
            var options = new GetSamplesFunctionOptions("sample 1");
            var result = await Factory.Create<IGetSamplesFunction, ILogger>(log)
                                      .InvokeAsync<HttpRequest, IActionResult>(req, options)
                                      .ConfigureAwait(false);

            return result;
        }
    }
}