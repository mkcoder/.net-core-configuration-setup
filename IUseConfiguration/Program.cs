using System;
using System.Reflection;
using Castle.Windsor;
using Castle.Windsor.Installer;
using Microsoft.Extensions.Configuration;

namespace configuration.example.IUseConfiguration
{
    class Program
    {
        static void Main(string[] args)
        {
            var castle = new WindsorContainer();
            castle.Install(FromAssembly.Named("configuration.example.Configuration"));
            var configurationbuilder = castle.Resolve<IConfigurationBuilder>();
            var config = configurationbuilder.Build();
            Console.WriteLine(config["app"]);
        }
    }
}
