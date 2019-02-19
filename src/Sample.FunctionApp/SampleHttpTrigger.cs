using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace Sample.FunctionApp
{
    /// <summary>
    /// This represents the HTTP trigger entity for sample.
    /// </summary>
    public class SampleHttpTrigger
    {
        /// <summary>
        /// Gets the sample response.
        /// </summary>
        /// <param name="req"><see cref="HttpRequest"/> instance.</param>
        /// <param name="log"><see cref="ILogger"/> instance.</param>
        /// <returns><see cref="IActionResult"/> instance.</returns>
        [FunctionName(nameof(GetSamples))]
        public async Task<IActionResult> GetSamples(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "samples")] HttpRequest req,
            ILogger log)
        {
            var name = req.Query["name"];

            return new OkObjectResult($"Hello {name}");
        }
    }
}