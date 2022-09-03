using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApi.Persistence
{
    static class Configuration
    {
        public static string GetConnectionString
        {
            get
            {
                ConfigurationManager configurationManager = new();
                configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/ECommerceApi.Api"));
                configurationManager.AddJsonFile("appsettings.json");

                return configurationManager["ConnectionString:LocalSqlServerWork"];
            }
        }
    }
}
