using CorujasDev.DocuSign.Api.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorujasDev.DocuSign.Api
{
    public class Startup
    {
        public Startup(IHostEnvironment environment)
        {
            var builder = new ConfigurationBuilder()
                 .SetBasePath(environment.ContentRootPath)
                 .AddJsonFile("appsettings.json", true, false)
                 .AddJsonFile($"appsettings.{environment.EnvironmentName}.json", true, true)
                 .AddEnvironmentVariables();

            Configuration = builder.Build();

            Environment = environment;
        }

        public IHostEnvironment Environment { get; set; }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "DocuSign",
                    Version = "v1"
                });

            });

            services.ConfigureSwaggerGen(c => c.CustomSchemaIds(x => x.FullName));

            services.AddScoped(d => Configuration.GetSection("DocuSignKeys").Get<DocuSignKeys>());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DocuSign"));

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
