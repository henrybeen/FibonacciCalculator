using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FibonacciCalculator.Business;
using FibonacciCalculator.Experiments;
using GitHub;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FibonacciCalculator
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();

            var resultsPublisher = new ExperimentResultPublisher();
            Scientist.ResultPublisher = resultsPublisher;
            ;

            services
                .AddTransient<IRecursiveFibonacciCalculator, RecursiveFibonacciCalculator>()
                .AddTransient<ILinearFibonacciCalculator, LinearFibonacciCalculator>()
                .AddSingleton<IExperimentResultsGetter>(resultsPublisher);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
