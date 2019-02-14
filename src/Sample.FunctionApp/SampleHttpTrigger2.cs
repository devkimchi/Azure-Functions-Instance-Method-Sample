using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

using Sample.FunctionApp.Functions;
using Sample.FunctionApp.Functions.FunctionOptions;

namespace Sample.FunctionApp
{
    /// <summary>
    /// This represents the HTTP trigger entity for sample.
    /// </summary>
    public class SampleHttpTrigger2
    {
        private readonly IGetSamplesFunction _function;

        /// <summary>
        /// Initializes a new instance of the <see cref="SampleHttpTrigger2"/> class.
        /// </summary>
        /// <param name="function"><see cref="IGetSamplesFunction"/> instance.</param>
        public SampleHttpTrigger2(IGetSamplesFunction function)
        {
            this._function = function ?? throw new ArgumentNullException(nameof(function));
        }

        /// <summary>
        /// Gets the sample response.
        /// </summary>
        /// <param name="req"><see cref="HttpRequest"/> instance.</param>
        /// <param name="log"><see cref="ILogger"/> instance.</param>
        /// <returns><see cref="IActionResult"/> instance.</returns>
        [FunctionName(nameof(GetSamples2))]
        public async Task<IActionResult> GetSamples2(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "samples2")] HttpRequest req,
            ILogger log)
        {
            this._function.Log = log;

            var options = new GetSamplesFunctionOptions("sample 2");

            var result = await this._function
                                   .InvokeAsync<HttpRequest, IActionResult>(req, options)
                                   .ConfigureAwait(false);

            return result;
        }
    }
}