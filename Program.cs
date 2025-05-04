using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors;
using Swashbuckle.AspNetCore.Annotations;
using ua;
using ua.Models;
using WebAPIEjemplos.Models;

internal class Program
{
    public class ClaseEstadoUsuario
    {
        public bool Activo { get; set; }
    }
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
               
        // Add services to the container.
        builder.Services.AddSingleton<ClaseUsuarios>();
        builder.Services.AddSingleton<ClaseTareas>();

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(x =>
        {
            x.EnableAnnotations();
        });

        // Add basic health checks
        builder.Services.AddHealthChecks().AddCheck<SampleHealthCheck>("Sample");
        builder.Services.AddHealthChecksUI().AddInMemoryStorage();


        // Activar CORS
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("UA", policy =>
            {
                policy.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                //.AllowCredentials();
                //.WithHeaders("Access-Control-Expose-Headers", "Content-Disposition");

                //policy.WithOrigins("https://localhost:3000")
                //    .WithMethods("PUT, GET, POST, DELETE")
                //    .WithHeaders("Content-Type", "Authorization");
            });
        });

        var app = builder.Build();

        

        // Configure the HTTP request pipeline.

        app.UseHttpsRedirection();


        app.UseCors("UA");


        //app.Use(async (context, next) =>
        //{
        //    context.Response.OnStarting(() =>
        //    {
        //        context.Response.Headers.Add("Access-Control-Expose-Headers", "Content-Disposition");
        //        return Task.CompletedTask;
        //    });
        //    await next();
        //});


        // USUARIOS
        app.MapPost("/api/usuarios", (ClaseUsuario usuario, ClaseUsuarios usuarios) =>
        {
            return usuarios.Alta(usuario);
        });

        app.MapPut("/api/usuarios/{id}", (ClaseUsuario usuario, ClaseUsuarios usuarios, int id) =>
        {
            if (usuario.Id != id) return Results.BadRequest();
            return Results.Ok(usuarios.Modificacion(usuario));
        });

        app.MapDelete("/api/usuarios/{id}", (ClaseUsuarios usuarios, int id) =>
        {
            return usuarios.Baja(id);
        });

        app.MapGet("/api/usuarios/listado", (string? filtro, int? resultadospagina, int? pagina, string? campoorden, string? orden, ClaseUsuarios usuarios) =>
        {
            var numeroregistrosReales = resultadospagina ?? 50;
            var paginaReales = pagina ?? 0;

            return usuarios.ObtenerSimple(paginaReales * numeroregistrosReales, numeroregistrosReales, campoorden ?? "", orden ?? "ASC", filtro ?? "");
        }).WithMetadata(new SwaggerOperationAttribute("Consulta para listados", "Devuelve un listado completo de los usuarios")); ;


        app.MapGet("/api/usuarios", (string? filtro, int? resultadospagina, int? pagina, string? campoorden, string ?orden, string? campofiltro, ClaseUsuarios usuarios) =>
        {
            var numeroregistrosReales = resultadospagina ?? 50;
            var paginaReales = pagina ?? 0;
            return usuarios.Obtener(paginaReales * numeroregistrosReales, numeroregistrosReales, campoorden ?? "", orden ?? "ASC", filtro ?? "", campofiltro ?? "ALL");
        }).WithMetadata(new SwaggerOperationAttribute("Consulta para DataTables", "Devuelve un listado con las personas que cumplen los criterios de búsquedas")); ;

        app.MapGet("/api/usuarios/{id}", (int id, ClaseUsuarios usuarios) =>
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

        app.MapPut("/api/usuarios/activo/{id}", (int id, ClaseEstadoUsuario estado, ClaseUsuarios usuarios) =>
        {
            var usuario = usuarios.BuscarxId(id);

            if (usuario == null)
            {
                return Results.NoContent();
            }
            else
            {
                usuario.Activo = estado.Activo;
                return Results.Ok(usuario.Activo);
            }
        });


        // Documentos
        app.MapGet("/api/documento/descargar", (HttpContext context) =>
        {
            //var contentDisposition = new System.Net.Mime.ContentDisposition
            //{
            //    FileName = "Curso Accesibilidad.pdf",
            //    Inline = true // Fuerza la descarga
            //};

            //context.Response.Headers.Add("Access-Control-Expose-Headers", "Content-Disposition");
            //context.Response.Headers.Add("Content-Disposition", contentDisposition.ToString());

            var path = Path.Combine(Directory.GetCurrentDirectory(), "Docs", "Curso Accesibilidad.pdf");
            var contenido = File.ReadAllBytes(path);

            return Results.File(contenido, "application/pdf", "Nuevo fichero.pdf");
        });
        

        // TAREAS
        app.MapPost("/api/tareas", (ClaseTarea tarea, ClaseTareas tareas) =>
        {
            return tareas.Alta(tarea);
        });

        app.MapPut("/api/tareas/{id}", (ClaseTarea tarea, ClaseTareas tareas, int id) =>
        {
            if (tarea.Id != id) return Results.BadRequest();
            return Results.Ok(tareas.Modificacion(tarea));
        });

        app.MapDelete("/api/tareas/{id}", (ClaseTareas tareas, int id) =>
        {
            return tareas.Baja(id);
        });

        app.MapGet("/api/tareas/listado", (string? filtro, int? resultadospagina, int? pagina, string? campoorden, string? orden, ClaseTareas tareas) =>
        {
            var numeroregistrosReales = resultadospagina ?? 50;
            var paginaReales = pagina ?? 0;

            return tareas.ObtenerSimple(paginaReales * numeroregistrosReales, numeroregistrosReales, campoorden ?? "", orden ?? "ASC", filtro ?? "");
        }).WithMetadata(new SwaggerOperationAttribute("Consulta para listados", "Devuelve un listado completo de los usuarios")); ;

        app.MapGet("/api/tareas/datosadicionales", (ClaseTareas tareas) =>
        {
            return tareas.DatosAdicionales();
        }).WithMetadata(new SwaggerOperationAttribute("Recupera datos adicionales", "Devuelve un conjunto de listas de valores para campos adicionales")); ;


        app.MapGet("/api/tareas", (string? filtro, int? resultadospagina, int? pagina, string? campoorden, string? orden, string? campofiltro, bool? cargardatosadicionales, ClaseTareas tareas) =>
        {
            var numeroregistrosReales = resultadospagina ?? 50;
            var paginaReales = pagina ?? 0;
            return tareas.Obtener(paginaReales * numeroregistrosReales, numeroregistrosReales, campoorden ?? "", orden ?? "ASC", filtro ?? "", campofiltro ?? "ALL", cargardatosadicionales ?? false);
        }).WithMetadata(new SwaggerOperationAttribute("Consulta para DataTables", "Devuelve un listado con las personas que cumplen los criterios de búsquedas")); ;

        app.MapGet("/api/tareas/{id}", (int id, ClaseTareas tareas) =>
        {
            var usuario = tareas.BuscarxId(id);

            if (usuario == null)
            {
                return Results.NoContent();
            }
            else
            {
                return Results.Ok(usuario);
            }
        });

        app.MapGet("/api/claves", () =>
        {
            var aes = new ClaseAES();

            return Results.Ok(new ClaseClaves()
            {
                Key = Convert.ToBase64String(aes.GenerarNumeroAleatorio(32)),
                Iv = Convert.ToBase64String(aes.GenerarNumeroAleatorio(16))
            });
        });



        app.UseSwagger();
        app.UseSwaggerUI();

        app.MapHealthChecks("/nagios");
        app.MapHealthChecksUI(setup =>
        {
            setup.UIPath = "/nagios-ui";  // Endpoint for the health check UI
        });

        app.Run();
    }
}

internal record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}