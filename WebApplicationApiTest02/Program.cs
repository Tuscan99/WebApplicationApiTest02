using WebApplicationApiTest02.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApplicationApiTest02
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddDbContext<CurrencyDbContext>(options =>
            {
                options.UseNpgsql(builder.Configuration["ConnectionStrings:TestConnection"]);
            }
            );

            //builder.Services.AddScoped<ICurrencyRepository, TestCurrencyRepository>();
            builder.Services.AddScoped<ICurrencyRepository, DbCurrencyRepository>();

            var app = builder.Build();


            // Configure the HTTP request pipeline.

            app.UseAuthorization();

            app.MapControllers();

            Sample.EnsurePopulated(app);

            app.Run();
        }
    }
}