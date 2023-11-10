using Microsoft.AspNetCore.Builder;
using Swashbuckle.AspNetCore.Annotations;
using ua;
using ua.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        //var UA = "UA";
        var builder = WebApplication.CreateBuilder(args);
               

        // Add services to the container.
        //builder.Services.AddScoped<ClaseOracleBd>();
        builder.Services.AddSingleton<ClaseUsuarios>();

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(x =>
        {
            x.EnableAnnotations();
        });


        // Activar CORS
        //builder.Services.AddCors(options =>
        //{
        //    options.AddPolicy(name: UA,
        //                      builder =>
        //                      {
        //                          builder
        //                              .AllowAnyOrigin() // Permite cualquier origen
        //                              .AllowAnyHeader()
        //                              .AllowAnyMethod();
        //                      });
        //});

        var app = builder.Build();


        //app.UseCors(UA);

        // Configure the HTTP request pipeline.

        app.UseHttpsRedirection();


        app.MapPost("/usuarios", (ClaseUsuario usuario, ClaseUsuarios usuarios) =>
        {
            return usuarios.Alta(usuario);
        });

        app.MapPut("/usuarios/{id}", (ClaseUsuario usuario, ClaseUsuarios usuarios, int id) =>
        {
            if (usuario.Id != id) return Results.BadRequest();
            return Results.Ok(usuarios.Modificacion(usuario));
        });

        app.MapDelete("/usuarios/{id}", (ClaseUsuarios usuarios, int id) =>
        {
            return usuarios.Baja(id);
        });

        app.MapGet("/usuarios", (string? filtro, int? resultadospagina, int? pagina, string? campoorden, string ?orden, string? campofiltro, ClaseUsuarios usuarios) =>
        {
            var numeroregistrosReales = resultadospagina ?? 50;
            var paginaReales = pagina ?? 0;
            return usuarios.Obtener(paginaReales * numeroregistrosReales, numeroregistrosReales, campoorden ?? "", orden ?? "ASC", filtro ?? "", campofiltro ?? "ALL");
        }).WithMetadata(new SwaggerOperationAttribute("Consulta para DataTables", "Devuelve un listado con las personas que cumplen los criterios de búsquedas")); ;

        app.MapGet("/usuarios/{id}", (int id, ClaseUsuarios usuarios) =>
        {
            var usuario = usuarios.BuscarxId(id);

            if (usuario == null)
            {
                return Results.NoContent();
            }
            else
            {
                return Results.Ok(usuario);
            }
        });

        

        app.UseSwagger();
        app.UseSwaggerUI();

        //

        app.Run();
    }
}

internal record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}