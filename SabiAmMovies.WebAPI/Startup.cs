using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SabiAmMovies.WebAPI.Domain.Constants;
using SabiAmMovies.WebAPI.Extensions;
using SabiAmMovies.WebAPI.Infrastructure.Persistence;

namespace SabiAmMovies.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public static IConfiguration Configuration { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container
        public void ConfigureServices(IServiceCollection services)
        {
            var jwtSecret = Configuration["JwtSettings:Secret"];

            var connstr = Configuration.GetConnectionString("sabi.dev");
            //services.AddDbContext<TrackerContext>(options =>
            //    options.UseMySql(connstr, b => b.MigrationsAssembly("Bestaf.FlickPaymentGateway.WebApi.Infrastructure"))
            //);
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 21));

            // Replace 'YourDbContext' with the name of your own DbContext derived class.
            services.AddDbContext<DataContext>(
                dbContextOptions => dbContextOptions
                    .UseMySql(connstr, serverVersion, b => {
                        b.MigrationsAssembly("SabiAmMovies.WebAPI.Infrastructure");
                        b.EnableRetryOnFailure();
                    })
                    .EnableSensitiveDataLogging() // <-- These two calls are optional but help
                    .EnableDetailedErrors()       // <-- with debugging (remove for production).
            );

            services.AddAppAuthentication(jwtSecret);
            services.AddAuthorization(opt =>
            {
                //Just the admin
                opt.AddPolicy(AuthorizedUserTypes.Admin, policy =>

                policy.RequireRole(UserConstants.Admin));

                // Just the user
                opt.AddPolicy(AuthorizedUserTypes.Users, policy =>

                policy.RequireRole(UserConstants.User));
                // user and admin
                opt.AddPolicy(AuthorizedUserTypes.UserAndAdmin, policy =>

                policy.RequireRole(UserConstants.User, UserConstants.Admin));


            });

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddHttpContextAccessor();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Welcome to running ASP.NET Core on AWS Lambda");
                });
            });
        }
    }
}
