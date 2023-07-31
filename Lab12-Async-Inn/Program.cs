using Lab12_Async_Inn.Data;
using Microsoft.EntityFrameworkCore;

namespace Lab12_Async_Inn
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //
            builder.Services.AddControllersWithViews();

            /*TODO
             builder.Services.addContext
             */
            builder.Services.AddDbContext<AsyncInnContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.
                    GetConnectionString("DefaultConnection")));

            var app = builder.Build();

            // app.MapGet("/", () => "Hello World!");

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=index}/{id?}");

            //https://localhost:44391/Hotel/CheckIn/1

            /*
             * app.UseHttpReDirection();
             * app.UseStaticFiles();
             * app.UseRouting();
             */
             
            app.Run();
        }
    }
}