using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace configuration.example.Configuration
{
    public class FileConfiguration : IConfigurationProviderInistalizer
    {
        public void Provide(IConfigurationBuilder builder)
        {
            builder.AddJsonFile("appsettings.json", true, true);
        }
    }
}
