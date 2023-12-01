using BusinessLogicLayer;
using DataLayer;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Stored_Procedure
{
    public class Program
    {
        public static void Main(string[] args)
        {   
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddTransient<IDataLayer, DataLayers>();
            builder.Services.AddTransient<ILogicLayer, LogicLayer>();

            builder.Services.AddControllers();
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

            app.UseCors(policy => policy.AllowAnyHeader()
                                       .AllowAnyMethod()
                                       .SetIsOriginAllowed(origin => true)
                                       .AllowCredentials());

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}