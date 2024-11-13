using Microsoft.AspNetCore.Mvc;
using ProductsApp.Service;

namespace ProductsApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<IProductService, ProductService>();
            

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseHsts();
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            
            app.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Product}/{action = Index}/{Id?}"
                    //defaults: new {Controller = "Product", action = "Index"}
            );

            app.Run();
        }
    }
}
