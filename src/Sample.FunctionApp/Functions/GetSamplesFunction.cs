using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

using Aliencube.AzureFunctions.Extensions.DependencyInjection.Abstractions;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using Newtonsoft.Json;

using Sample.FunctionApp.Configurations;
using Sample.FunctionApp.Functions.FunctionOptions;
using Sample.FunctionApp.Models;

namespace Sample.FunctionApp.Functions
{
    /// <summary>
    /// This provides interfaces to <see cref="GetSamplesFunction"/>.
    /// </summary>
    public interface IGetSamplesFunction : IFunction<ILogger>
    {
    }

    /// <summary>
    /// This represents the function entity for the HTTP trigger to get samples.
    /// </summary>
    public class GetSamplesFunction : FunctionBase<ILogger>, IGetSamplesFunction
    {
        private readonly AppSettings _settings;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetSamplesFunction"/> class.
        /// </summary>
        /// <param name="settings"><see cref="AppSettings"/> instance.</param>
        public GetSamplesFunction(AppSettings settings)
        {
            this._settings = settings ?? throw new ArgumentNullException(nameof(settings));
        }

        /// <inheritdoc />
        public override async Task<TOutput> InvokeAsync<TInput, TOutput>(TInput input, FunctionOptionsBase options = null)
        {
            this.Log.LogInformation("C# HTTP trigger function processed a request.");

            var req = input as HttpRequest;
            var request = (SampleRequestModel)null;

            var serialised = await new StreamReader(req.Body).ReadToEndAsync().ConfigureAwait(false);
            if (!string.IsNullOrWhiteSpace(serialised))
            {
                request = JsonConvert.DeserializeObject<SampleRequestModel>(serialised);
            }

            var name = req.Query["name"].ToString();

            var opt = options as GetSamplesFunctionOptions;

            var result = new SampleResponseModel()
                             {
                                 Id = request?.Id,
                                 Name = string.IsNullOrWhiteSpace(name) ? "Sample" : name,
                                 Message = $"Hello {this._settings.Hello} from {opt.Key}"
                             };
            var content = new ContentResult()
                              {
                                  Content = JsonConvert.SerializeObject(result),
                                  ContentType = "application/json",
                                  StatusCode = (int)HttpStatusCode.OK
                              };

            return (TOutput)(IActionResult)content;
        }
    }
}