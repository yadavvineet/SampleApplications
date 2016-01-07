using System.Collections.Generic;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;

namespace HelloMars
{
    public class Startup
    {
        /// <summary>
        /// The configuration Object
        /// Static property as same instance is needed to be returned across the project. The instance will be generated when constructor is called. 
        /// </summary>
        public static IConfiguration ConfigurationProvider;
        public Startup(IApplicationEnvironment appEnv)
        {
            //Sample Dictionary object to use in in memory collection. This could be computed or fetched dynamically
            Dictionary<string, string> someConfigDictionary = new Dictionary<string, string>();
            someConfigDictionary.Add("key1", "value1");
            someConfigDictionary.Add("key2", "value2");
            someConfigDictionary.Add("key3", "value3");

            //Create the configuratonBuilder object
            var configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(appEnv.ApplicationBasePath)
                .AddJsonFile("config.json")
                .AddEnvironmentVariables()
                .AddInMemoryCollection(someConfigDictionary);

            //call the .Build and set the ConfigurationRoot object
            ConfigurationProvider = configurationBuilder.Build();
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
        }

        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
