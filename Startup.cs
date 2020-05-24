using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using StudentManagement.Model;
using StudentManagement.Service;

namespace StudentManagement
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IWelcomeService, WelcomeService>();
            services.AddScoped< IRepository<Student>, InMemoryRepository>();
            services.AddMvc(options => options.EnableEndpointRouting=false);
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IWelcomeService welcomeService,
            ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler();
            }


            //next：RequestDelegate 下一个中间件
            //app.Use(next =>
            //{
            //    logger.LogInformation("app.Use()...");
            //    return async httpContext =>
            //    {
            //        logger.LogInformation("----aysnc httpContext");
            //        if (httpContext.Request.Path.StartsWithSegments("/first"))
            //        {
            //            logger.LogInformation("---first");
            //            await httpContext.Response.WriteAsync("first");
            //        }
            //        else
            //        {
            //            logger.LogInformation("---next()");
            //            await next(httpContext);
            //        }
            //    };

            //});


            //app.UseDefaultFiles();
            app.UseStaticFiles();

            //app.UseFileServer();



            //app.UseWelcomePage(new WelcomePageOptions
            //{
            //    Path = "/welcome"

            //});


            app.UseMvc(bulider =>
            {
                bulider.MapRoute("Default", "{controller=Home}/{action=Index}/{id?}");
            }
            );


            //终端中间件
            app.Run(
            async (context) =>
            {
                var welcome = welcomeService.GetMessage();
                await context.Response.WriteAsync(welcome);
            }
            );
        }
    }
}
