
using Microsoft.EntityFrameworkCore;
using Task_CatProduct.Model.Data;
using Task_CatProduct.Services;
using Category1 = Task_CatProduct.Services.Category1;
using Product1 = Task_CatProduct.Services.Product1;



namespace Task_CatProduct
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddDbContext<CatProcuctDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("Product_Category")));
            builder.Services.AddScoped<ICategory, Category1>();
            builder.Services.AddScoped<IProduct, Product1>();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
