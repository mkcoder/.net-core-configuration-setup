﻿using System;
using System.Linq;
using System.Reflection;
using Castle.MicroKernel;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Microsoft.Extensions.Configuration;

namespace configuration.example.Configuration
{
    public class ConfigurationInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                // register all our IConfigurationProviderInitializer
                Classes.FromAssembly(Assembly.GetExecutingAssembly())
                    .BasedOn<IConfigurationProviderInistalizer>()  
                    .If(t =>
                    {
                        var attributes = t.GetCustomAttributes(typeof(ProductionConfigurationAttribute)).FirstOrDefault();
                        if (attributes != null && Environment.GetEnvironmentVariable("PRODUCTION") == null) return false;                                                
                        return true;
                    })
                    .LifestyleTransient().WithServiceFromInterface(),
                // when we rebind it with on create and pass it through the initializer
                Component.For<IConfigurationBuilder>().OnCreate(builder =>
                {
                    var r = container.ResolveAll<IConfigurationProviderInistalizer>();
                    var provider = new ConfigurationBuilderDefaultInitalizer(r);
                    provider.configure(builder);
                }).ImplementedBy<ConfigurationBuilder>().LifestyleTransient()
            );
        }
    }
}