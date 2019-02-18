using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Castle.Facilities.AspNetCore;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Installer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace WebApplication1
{
    public class Startup
    {
        private static readonly WindsorContainer Container = new WindsorContainer();
        public Startup(IConfiguration configuration)
        {
        }

        public IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            // Setup component model contributors for making windsor services available to IServiceProvider
            Container.AddFacility<AspNetCoreFacility>(f => f.CrossWiresInto(services));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            Container.Install(FromAssembly.Named("configuration.example.Configuration"));
            Configuration = Container.Resolve<IConfigurationBuilder>()    
                            .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ENV")}.json")
                            .AddEnvironmentVariables()                               
                            .Build();
            Container.Register(Component.For<IConfiguration>().Instance(Configuration));
            return services.AddWindsor(Container); 
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
