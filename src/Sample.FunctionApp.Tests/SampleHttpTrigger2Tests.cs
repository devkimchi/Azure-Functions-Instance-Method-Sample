using System.Threading.Tasks;

using Aliencube.AzureFunctions.Extensions.DependencyInjection.Abstractions;

using FluentAssertions;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Moq;

using Sample.FunctionApp.Functions;

namespace Sample.FunctionApp.Tests
{
    [TestClass]
    public class SampleHttpTrigger2Tests
    {
        [TestMethod]
        public async Task Given_Request_Response_Should_Return_Result()
        {
            var logger = new Mock<ILogger>();

            var function = new Mock<IGetSamplesFunction>();
            function.SetupProperty(p => p.Log, logger.Object);

            var result = new ObjectResult("hello world");
            function.Setup(p => p.InvokeAsync<HttpRequest, IActionResult>(It.IsAny<HttpRequest>(), It.IsAny<FunctionOptionsBase>())).ReturnsAsync(result);

            var trigger = new SampleHttpTrigger2(function.Object);

            var req = new Mock<HttpRequest>();
            var log = new Mock<ILogger>();

            var response = await trigger.GetSamples2(req.Object, log.Object).ConfigureAwait(false);

            response.Should().BeOfType<ObjectResult>();

            var @return = response as ObjectResult;
            @return.Value.Should().Be("hello world");
        }
    }
}