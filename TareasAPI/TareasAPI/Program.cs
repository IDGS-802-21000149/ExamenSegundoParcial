
using Microsoft.EntityFrameworkCore;
using TareasAPI.Models;

namespace TareasAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //Obtener la cadena de conexión
            var connectionString = builder.Configuration.GetConnectionString("cadenaSQL");
            //Agregar la configuracion para sql server
            builder.Services.AddDbContext<BdtareasContext>(options => options.UseSqlServer(connectionString));

            //Definimos la politica de CORS para la api
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("NuevaPolitica",app =>
                                       {
                        app.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                    });
            });

            


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();
            //Activar la nueva politica
            app.UseCors("NuevaPolitica");


            app.MapControllers();

            app.Run();
        }
    }
}
