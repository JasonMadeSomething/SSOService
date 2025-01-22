using Microsoft.Extensions.Configuration;

namespace SSOService.Helpers
{
    public static class ConfigurationHelper
    {
        public static IConfiguration BuildConfiguration(string basePath, string environmentName = null)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{environmentName}.json", optional: true)
                .AddEnvironmentVariables();

            return builder.Build();
        }
    }
}
