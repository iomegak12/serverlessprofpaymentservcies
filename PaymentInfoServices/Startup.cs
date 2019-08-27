using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.Libraries.Business.Impl;
using Microsoft.Libraries.Business.Interfaces;
using Microsoft.Libraries.DataAccess.Impl;
using Microsoft.Libraries.DataAccess.Interfaces;

namespace PaymentInfoServices
{
    /// <summary>
    /// Startup of Services
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Startup Constructor
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Configuration 
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Configuration of HOST Services
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddDbContext<CreditCardInfoContext>(
                dbContextOptionsBuilder =>
                {
                    var encodedConnectionString = Environment.GetEnvironmentVariable("PaymentsDbConnectionString");

                    if (string.IsNullOrEmpty(encodedConnectionString))
                        throw new ApplicationException("Payments DB Connection String Not Set!");

                    var connectionString = Encoding.ASCII.GetString(
                        Convert.FromBase64String(encodedConnectionString));

                    dbContextOptionsBuilder.UseSqlServer(connectionString);
                });

            services.AddScoped<ICreditCardInfoContext, CreditCardInfoContext>();
            services.AddScoped<ICreditCardInfoRepository, CreditCardInfoRepository>();
            services.AddScoped<ICreditCardBusinessComponent, CreditCardBusinessComponent>();

            services.AddSwaggerGen(
               swaggerGenOptions =>
               {
                   swaggerGenOptions.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info
                   {
                       Title = "Credit Card Info. API",
                       Version = "v1",
                       Contact = new Swashbuckle.AspNetCore.Swagger.Contact { Email = "jd.ramkumar@gmail.com", Name = "Ramkumar JD", Url = @"http://people.intsol.in/jdramkumar" },
                       Description = "Simple Payments Info. System Service",
                       License = new Swashbuckle.AspNetCore.Swagger.License { Name = "MIT", Url = "http://licenses.intsol.in/apis/mit" },
                       TermsOfService = "All Rights Reserved"
                   });

                   swaggerGenOptions.IncludeXmlComments(GetXmlCommentsPath());
               });

        }

        private string GetXmlCommentsPath()
        {
            var app = PlatformServices.Default.Application;

            return Path.Combine(app.ApplicationBasePath, @"PaymentInfoServices.xml");
        }


        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(
                swaggerUIOptions =>
                {
                    swaggerUIOptions.SwaggerEndpoint("/swagger/v1/swagger.json", "Customers API v1");
                });
        }
    }
}
