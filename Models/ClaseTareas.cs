using System.Globalization;
using System.Text;
using ua.Models.DataTable;

namespace ua.Models
{
    public class ClaseTareas
    {
        

        public List<ClaseTarea> Data { get; set; }

        public ClaseTareas()
        {
            Data = Todos();
        }
        public int Alta(ClaseTarea tarea)
        {
            tarea.Id = Data.Max(u => u.Id) + 1;
            Data.Add(tarea);

            return tarea.Id;
        }

        public bool Baja(int id)
        {
            var tarea = BuscarxId(id);

            if (tarea == null)
            {
                return false;
            }
            else
            {
                Data.Remove(tarea);
                return true;
            }
        }

        public bool Modificacion(ClaseTarea tarea)
        {
            var tareaamodificar = BuscarxId(tarea.Id);

            if (tareaamodificar == null)
            {
                return false;
            }
            else
            {
                tareaamodificar.Nombre = tarea.Nombre;
                tareaamodificar.Descripcion = tarea.Descripcion;
                tareaamodificar.Activa = tarea.Activa;
                tareaamodificar.FechaInicio = tarea.FechaInicio;
                tareaamodificar.FechaFin = tarea.FechaFin;
                tareaamodificar.CodperPropietario = tarea.CodperPropietario;

                return true;
            }
        }
        public ClaseTarea? BuscarxId(object id)
        {
            return Data.FirstOrDefault(u => u.Id == Int32.Parse(id.ToString()));
        }

        public List<ClaseTarea> Todos()
        {
            var listado = new List<ClaseTarea>
            {
                new ClaseTarea()
                {
                    Id = 1,                    
                    Nombre = "Crear PowerPoint de la 1º Clase",
                    Activa = true,
                    FechaInicio = DateTime.Parse("2023-09-01"),
                    FechaFin = DateTime.Parse("2023-09-15"),
                    Descripcion = "Crear un índice y posteriormente todos los puntos",
                    Categorias = new List<ClaseCategoriaTarea>()
                    {
                        new ClaseCategoriaTarea() { Id = 1, Nombre = "PowerPoint" },
                        new ClaseCategoriaTarea() { Id = 2, Nombre = "Documentación" }
                    }
                },
                new ClaseTarea()
                {
                    Id = 2,
                    Nombre = "Crear PowerPoint de la 2º Clase",
                    Activa = true,
                    FechaInicio = DateTime.Parse("2023-09-10"),
                    FechaFin = DateTime.Parse("2023-09-20"),
                    Descripcion = "Crear un índice y posteriormente todos los puntos",
                    Categorias = new List<ClaseCategoriaTarea>()
                    {
                        new ClaseCategoriaTarea() { Id = 1, Nombre = "PowerPoint" },
                        new ClaseCategoriaTarea() { Id = 2, Nombre = "Documentación" }
                    }
                },
                new ClaseTarea()
                {
                    Id = 3,
                    Nombre = "Crear PowerPoint de la 3º Clase",
                    Activa = true,
                    FechaInicio = DateTime.Parse("2023-09-15"),
                    FechaFin = DateTime.Parse("2023-09-25"),
                    Descripcion = "Crear un índice y posteriormente todos los puntos",
                    Categorias = new List<ClaseCategoriaTarea>()
                    {
                        new ClaseCategoriaTarea() { Id = 1, Nombre = "PowerPoint" },
                        new ClaseCategoriaTarea() { Id = 2, Nombre = "Documentación" }
                    }
                },
                new ClaseTarea()
                {
                    Id = 4,
                    Nombre = "Crear PowerPoint de la 4º Clase",
                    Activa = true,
                    FechaInicio = DateTime.Parse("2023-09-20"),
                    FechaFin = DateTime.Parse("2023-09-30"),
                    Descripcion = "Crear un índice y posteriormente todos los puntos",
                    Categorias = new List<ClaseCategoriaTarea>()
                    {
                        new ClaseCategoriaTarea() { Id = 1, Nombre = "PowerPoint" },
                        new ClaseCategoriaTarea() { Id = 2, Nombre = "Documentación" }
                    }
                },
                new ClaseTarea()
                {
                    Id = 5,
                    Nombre = "Crear ejemplo para todas las clases",
                    Activa = true,
                    FechaInicio = DateTime.Parse("2023-10-01"),
                    FechaFin = DateTime.Parse("2023-10-15"),
                    Descripcion = "Deben ser secuenciales todos los ejemplos",
                    Categorias = new List<ClaseCategoriaTarea>()
                    {
                        new ClaseCategoriaTarea() { Id = 3, Nombre = "Ejemplos" },
                    }
                },
                new ClaseTarea()
                {
                    Id = 6,
                    Nombre = "Crear repositorio GIT para alojar los ejemplos",
                    Activa = true,
                    FechaInicio = DateTime.Parse("2023-10-10"),
                    FechaFin = DateTime.Parse("2023-10-20"),
                    Descripcion = "Crear una rama para cada día",
                    Categorias = new List<ClaseCategoriaTarea>()
                    {
                        new ClaseCategoriaTarea() { Id = 4, Nombre = "Repositorio GIT" },
                    }
                },
            };


            return listado;
        }

       

        public ClaseDataTable Obtener(int primerregistro = 0, int numeroregistros = 50, string campoorden = "", string orden = "ASC", string? filtro = "", 
            string? campofiltro = "ALL", bool cargardatosadicionales = false)
        {
            var salida = new ClaseDataTable();
            var tareas = Data;

            orden = orden.ToUpper();

            if (orden != "ASC" && orden != "DESC")
            {
                orden = "ASC";
            }

            campofiltro ??= "ALL";
            filtro ??= "";
            filtro = filtro.RemoveDiacritics();

            salida.NumeroRegistros = tareas.Count();
            

            if (salida.NumeroRegistros > 0)
            {
                // Todo: Filtrar por el criterio que corresponda

                var filtroNumerico = -1;
                if (campofiltro.ToLower() == "categorias")
                {
                    Int32.TryParse(filtro, out filtroNumerico);
                }

                var tareasfiltrados =
                    campofiltro == "ALL" ? string.IsNullOrEmpty(filtro) ? tareas : tareas.Where(u => u.Nombre.RemoveDiacritics().Contains(filtro, StringComparison.CurrentCultureIgnoreCase) 
                                || u.Descripcion.RemoveDiacritics().Contains(filtro, StringComparison.CurrentCultureIgnoreCase)
                                || u.Categorias.Where(c => c.Nombre.RemoveDiacritics().Contains(filtro, StringComparison.CurrentCultureIgnoreCase)).Count() > 0)
                        : campofiltro.ToLower() == "descripcion" ? tareas.Where(u => u.Descripcion.RemoveDiacritics().Contains(filtro, StringComparison.CurrentCultureIgnoreCase))
                        : campofiltro.ToLower() == "nombre" ? tareas.Where(u => u.Nombre.RemoveDiacritics().Contains(filtro, StringComparison.CurrentCultureIgnoreCase))
                        : campofiltro.ToLower() == "activa" && filtro.ToLower() != "null" ? tareas.Where(u => u.Activa == (filtro.ToLower() == "true" ? true: false))
                        : campofiltro.ToLower() == "categorias" && !string.IsNullOrEmpty(filtro) ? tareas.Where(u => u.Categorias.Where(c => c.Id  == filtroNumerico).Count() > 0)
                        : tareas;

                if (numeroregistros > 0)
                    salida.NumeroRegistrosFiltrados = tareasfiltrados.Take(numeroregistros).Count();
                else
                    salida.NumeroRegistrosFiltrados = tareasfiltrados.Count();

                // Ordenamos
                if (!string.IsNullOrEmpty(campoorden))
                {
                    if (orden == "ASC")
                    {
                        tareasfiltrados = tareasfiltrados.OrderBy(s => s.GetType().GetProperties()
                        .FirstOrDefault(p => string.Equals(p.Name, campoorden, StringComparison.OrdinalIgnoreCase)).GetValue(s));
                    }
                    else
                    {
                        tareasfiltrados = tareasfiltrados.OrderByDescending(s => s.GetType().GetProperties()
                            .FirstOrDefault(p => string.Equals(p.Name, campoorden, StringComparison.OrdinalIgnoreCase)).GetValue(s));
                    }
                }

                // Paginamos
                if (numeroregistros > 0)
                    salida.Registros = tareasfiltrados.Skip(primerregistro).Take(numeroregistros);
                else
                    salida.Registros = tareasfiltrados;
            }
            else
            {
                salida.Registros = new List<ClaseTarea>();
            }

            // Miramos si hay que cargar datos adicionales (para desplegable de los filtros de los campos)
            if (cargardatosadicionales)
            {
                salida.DatosAdicionales = DatosAdicionales();
            }

            return salida;
        }

        public Dictionary<string, List<ClaseDatosAdicionalesDataTable>> DatosAdicionales() {
            var salida = new Dictionary<string, List<ClaseDatosAdicionalesDataTable>>
            {
                { "categorias", new List<ClaseDatosAdicionalesDataTable>() }
            };

            var categorias = Data.SelectMany(u => u.Categorias).Distinct();
            categorias = categorias.GroupBy(u => u.Id).Select(u => u.First());
            salida["categorias"] = categorias.Select(u => new ClaseDatosAdicionalesDataTable() { Id = u.Id.ToString(), Texto = u.Nombre }).ToList();

            return salida;
        }
        

        public List<ClaseTarea> ObtenerSimple(int primerregistro = 0, int numeroregistros = 50, string campoorden = "", string orden = "ASC", string? filtro = "")
        {
            var tareas = Data;

            orden = orden.ToUpper();

            if (orden != "ASC" && orden != "DESC")
            {
                orden = "ASC";
            }

            filtro ??= "";
            filtro = filtro.RemoveDiacritics();

            var tareasfiltrados = string.IsNullOrEmpty(filtro) ? tareas : tareas.Where(u => u.Nombre.RemoveDiacritics().Contains(filtro, StringComparison.CurrentCultureIgnoreCase) || u.Descripcion.RemoveDiacritics().Contains(filtro, StringComparison.CurrentCultureIgnoreCase));

            // Ordenamos
            if (!string.IsNullOrEmpty(campoorden))
            {
                if (orden == "ASC")
                {
                    tareasfiltrados = tareasfiltrados.OrderBy(s => s.GetType().GetProperties()
                    .FirstOrDefault(p => string.Equals(p.Name, campoorden, StringComparison.OrdinalIgnoreCase)).GetValue(s));
                }
                else
                {
                    tareasfiltrados = tareasfiltrados.OrderByDescending(s => s.GetType().GetProperties()
                        .FirstOrDefault(p => string.Equals(p.Name, campoorden, StringComparison.OrdinalIgnoreCase)).GetValue(s));
                }
            }

            return tareasfiltrados.Skip(primerregistro).Take(numeroregistros).ToList();
        }
    }
}
