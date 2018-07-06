﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.SpaServices.Webpack;
using HelloAngularApp.Models;
using Microsoft.EntityFrameworkCore;

namespace HelloAngularApp
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // string connectionString = "Server=(localdb)\\mssqllocaldb;Database=productsdb;Trusted_Connection=True;";

            string connectionString = "Server=127.0.0.1; Database=SQLEXPRESS; Trusted_Connection=False; MultipleActiveResultSets=True; User Id=sa; Password=ghbvf";
            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connectionString));
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
                {
                    HotModuleReplacement = true
                });
            }

            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseMvc();
        }
    }
}