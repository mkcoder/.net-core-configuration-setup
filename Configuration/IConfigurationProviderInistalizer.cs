using Microsoft.Extensions.Configuration;

namespace configuration.example.Configuration
{
    public interface IConfigurationProviderInistalizer
    {
        void Provide(IConfigurationBuilder configurationBuilder);
    }
}