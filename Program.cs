using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace RazorPagesSimpleCRUD
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        // Use the modern IHostBuilder structure
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
