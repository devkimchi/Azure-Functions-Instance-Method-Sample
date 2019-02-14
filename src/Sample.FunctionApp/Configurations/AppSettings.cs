using Microsoft.Extensions.Configuration;

namespace Sample.FunctionApp.Configurations
{
    /// <summary>
    /// This represents the app settings entity for environment variables.
    /// </summary>
    public class AppSettings
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AppSettings"/> class.
        /// </summary>
        public AppSettings()
        {
            var config = new ConfigurationBuilder()
                             .AddEnvironmentVariables()
                             .Build();

            this.Hello = config.GetValue<string>("Hello");
        }

        /// <summary>
        /// Gets the hello value.
        /// </summary>
        public virtual string Hello { get; }
    }
}
