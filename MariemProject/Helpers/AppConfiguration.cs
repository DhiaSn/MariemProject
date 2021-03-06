using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MariemProject.Helpers
{
    public static class AppConfiguration
    {

        private static IConfiguration currentConfig;

        public static void SetConfig(IConfiguration configuration)
        {
            currentConfig = configuration;
        }

        public static string GetValue(string configKey)
        {
            return currentConfig[configKey];
        }
        public static string GetConfiguration(string configKey)
        {
            try
            {
                return currentConfig.GetConnectionString(configKey);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

    }
}
