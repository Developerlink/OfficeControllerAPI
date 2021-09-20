using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using OfficeControllerDataLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OfficeControllerDataLibrary.Interfaces;
using OfficeControllerDataLibrary.Repositories;

namespace OfficeControllerAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();

            var connectionString = Configuration["ConnectionStrings:officeControllerConnectionString"];
            services.AddDbContext<OfficeControllerDbContext>(cnn => cnn.UseSqlServer(connectionString));


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "OfficeControllerAPI", Version = "v1" });
            });

            services.AddScoped<ITemperatureRepository, TemperatureRepository>();

            services.AddCors(options =>
            {
                options.AddPolicy(name: "corsPolicy",
                                  builder =>
                                  {
                                      builder.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod();
                                  });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "OfficeControllerAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("corsPolicy");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
