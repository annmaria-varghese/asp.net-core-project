using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting; // Correct namespace for IWebHostEnvironment
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting; // Correct namespace for IHostEnvironment.IsDevelopment()
using RazorPagesSimpleCRUD.Data;
using Microsoft.EntityFrameworkCore;

namespace RazorPagesSimpleCRUD
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
            // The EF Core package must be added to your .csproj for this to work.
            services.AddDbContext<SimpleDbContext>(options =>
                options.UseInMemoryDatabase("SimpleDB"));

            // Replaces services.AddMvc() with the Razor Pages specific service
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        // IWebHostEnvironment is the modern replacement for IHostingEnvironment
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // IWebHostEnvironment is used directly, not through an extension method on IHostEnvironment
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // Optional: app.UseHsts();
            }

            app.UseStaticFiles();

            // UseRouting is required for Endpoint Routing
            app.UseRouting();

            // app.UseAuthorization(); (Add this if you need user login/permissions)

            // Replaces app.UseMvc() with modern Endpoint Routing
            app.UseEndpoints(endpoints =>
            {
                // This is essential for Razor Pages applications
                endpoints.MapRazorPages();

                // If the project contained MVC Controllers, you would uncomment this:
                // endpoints.MapControllerRoute(
                //     name: "default",
                //     pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}