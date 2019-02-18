using System.Collections;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace configuration.example.Configuration
{
    public class ConfigurationBuilderDefaultInitalizer
    {
        private readonly IList<IConfigurationProviderInistalizer> _configuration;

        public ConfigurationBuilderDefaultInitalizer(IConfigurationProviderInistalizer[] configuration)
        {
            _configuration = configuration;
        }

        public void configure(IConfigurationBuilder arg)
        {
            foreach (var provider in _configuration)
            {
                provider.Provide(arg);
            }
        }
    }
}