using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Memory;

namespace configuration.example.Configuration
{
    [ProductionConfiguration]
    public class SecretKeyConfigurationInitalizer : IConfigurationProviderInistalizer
    {
        public void Provide(IConfigurationBuilder builder)
        {
            builder.AddInMemoryCollection(new Dictionary<string, string>() { { "production_secret", "true" } });
        }
    }
}
