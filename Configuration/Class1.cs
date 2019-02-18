using System;
using System.Collections.Generic;
using System.Text;

namespace configuration.example.Configuration
{
    [AttributeUsage(AttributeTargets.Class)]
    class ProductionConfigurationAttribute : Attribute
    {
    }
}
