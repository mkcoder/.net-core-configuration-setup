using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;

namespace configuration.example.Configuration
{
    public class LoadSettingsFromAssemblyConfiguration : ConfigurationProvider
    {
        public LoadSettingsFromAssemblyConfiguration()
        {
            this.Data.Add(new KeyValuePair<string, string>("", ""));
        }
    }
}