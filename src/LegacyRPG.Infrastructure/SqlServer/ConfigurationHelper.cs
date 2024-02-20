using Microsoft.Extensions.Configuration;

namespace LegacyRPG.Infrastructure.SqlServer
{
    public class ConfigurationHelper
    {
        public static string GetConnectionString()
        {
            var basePath = Directory.GetCurrentDirectory();
            while (!Directory.Exists(Path.Combine(basePath, "LegacyRPG.Infrastructure")))
            {
                basePath = Directory.GetParent(basePath).FullName;
            }

            string configPath = Path.Combine(basePath, "LegacyRPG.Infrastructure", "appsettings.Development.json");

            IConfigurationRoot configuration = new ConfigurationBuilder()
                .AddJsonFile(configPath)
                .Build();

            return configuration.GetConnectionString("Default");
        }
    }
}
