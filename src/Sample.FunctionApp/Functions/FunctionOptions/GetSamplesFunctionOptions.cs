using Aliencube.AzureFunctions.Extensions.DependencyInjection.Abstractions;

namespace Sample.FunctionApp.Functions.FunctionOptions
{
    /// <summary>
    /// This represents the options entity for functions.
    /// </summary>
    public class GetSamplesFunctionOptions : FunctionOptionsBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetSamplesFunctionOptions"/> class.
        /// </summary>
        /// <param name="key"></param>
        public GetSamplesFunctionOptions(string key)
        {
            this.Key = key;
        }

        /// <summary>
        /// Gets the key.
        /// </summary>
        public virtual string Key { get; }
    }
}
