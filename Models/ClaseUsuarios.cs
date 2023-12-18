using System.Globalization;
using System.Text;
using ua.Models.DataTable;

namespace ua.Models
{
    public static class Utils
    {
        public static string RemoveDiacritics(this String s)
        {
            String normalizedString = s.Normalize(NormalizationForm.FormD);
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < normalizedString.Length; i++)
            {
                Char c = normalizedString[i];
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                    stringBuilder.Append(c);
            }

            return stringBuilder.ToString();
        }
    }
    
    public class ClaseUsuarios
    {
        

        public List<ClaseUsuario> Data { get; set; }

        public ClaseUsuarios()
        {
            Data = Todos();
        }
        public int Alta(ClaseUsuario usuario)
        {
            usuario.Id = Data.Max(u => u.Id) + 1;
            Data.Add(usuario);

            return usuario.Id;
        }

        public bool Baja(int id)
        {
            var usuario = BuscarxId(id);

            if (usuario == null)
            {
                return false;
            }
            else
            {
                Data.Remove(usuario);
                return true;
            }
        }

        public bool Modificacion(ClaseUsuario usuario)
        {
            var usuarioamodificar = BuscarxId(usuario.Id);

            if (usuarioamodificar == null)
            {
                return false;
            }
            else
            {
                usuarioamodificar.Nombre = usuario.Nombre;
                usuarioamodificar.Email = usuario.Email;
                usuarioamodificar.Activo = usuario.Activo;
                usuarioamodificar.SuperAdmin = usuario.SuperAdmin;
                usuarioamodificar.Codper = usuario.Codper;

                return true;
            }
        }
        public ClaseUsuario? BuscarxId(object id)
        {
            return Data.FirstOrDefault(u => u.Id == Int32.Parse(id.ToString()));
        }

        public List<ClaseUsuario> Todos()
        {
            var listado = new List<ClaseUsuario>
            {
                new ClaseUsuario()
                {
                    Id = 2627,
                    Email = "alejandro@ua.es",
                    Nombre = "Alejandro García López",
                    Codper = null,
                    Activo = true,
                    SuperAdmin = false
                },
                new ClaseUsuario()
                {
                    Id = 2629,
                    Email = "maria@ua.es",
                    Nombre = "María Rodríguez Martínez",
                    Codper = null,
                    Activo = true,
                    SuperAdmin = false,
                    Foto = "https://randomuser.me/api/portraits/women/68.jpg"
                },
                new ClaseUsuario()
                {
                    Id = 2844,
                    Email = "javier@ua.es",
                    Nombre = "Javier Fernández Sánchez",
                    Codper = null,
                    Activo = true,
                    SuperAdmin = true,
                    Foto = "https://randomuser.me/api/portraits/men/43.jpg"
                },
                new ClaseUsuario()
                {
                    Id = 2886,
                    Email = "laura@ua.es",
                    Nombre = "Laura López González",
                    Codper = null,
                    Activo = true,
                    SuperAdmin = false
                },
                new ClaseUsuario()
                {
                    Id = 2887,
                    Email = "carlos@ua.es",
                    Nombre = "Carlos Ramírez Herrera",
                    Codper = null,
                    Activo = true,
                    SuperAdmin = false
                },
                new ClaseUsuario()
                {
                    Id = 2647,
                    Email = "ana@ua.es",
                    Nombre = "Ana Martínez Torres",
                    Codper = null,
                    Activo = true,
                    SuperAdmin = true
                },
                new ClaseUsuario()
                {
                    Id = 2653,
                    Email = "juan@ua.es",
                    Nombre = "Juan González Rodríguez",
                    Codper = null,
                    Activo = true,
                    SuperAdmin = true
                },
                new ClaseUsuario()
                {
                    Id = 2655,
                    Email = "andrea@ua.es",
                    Nombre = "Andrea Pérez García",
                    Codper = null,
                    Activo = true,
                    SuperAdmin = true,
                    Foto = "https://randomuser.me/api/portraits/women/79.jpg"
                },
                new ClaseUsuario()
                {
                    Id = 2885,
                    Email = "davId@ua.es",
                    Nombre = "DavId Sánchez López",
                    Codper = null,
                    Activo = true,
                    SuperAdmin = false
                },
                new ClaseUsuario()
                {
                    Id = 1,
                    Email = "patricia@ua.es",
                    Nombre = "Patricia Hernández Morales",
                    Codper = null,
                    Activo = true,
                    SuperAdmin = true
                },
                new ClaseUsuario()
                {
                    Id = 2,
                    Email = "roberto@ua.es",
                    Nombre = "Roberto Vargas Romero",
                    Codper = 4,
                    Activo = true,
                    SuperAdmin = false
                },
                new ClaseUsuario()
                {
                    Id = 3,
                    Email = "gabriela@ua.es",
                    Nombre = "Gabriela Silva Mendoza",
                    Codper = null,
                    Activo = true,
                    SuperAdmin = true
                },
                new ClaseUsuario()
                {
                    Id = 2664,
                    Email = "andres@ua.es",
                    Nombre = "Andrés Castro Ruiz",
                    Codper = null,
                    Activo = false,
                    SuperAdmin = false
                },
                new ClaseUsuario()
                {
                    Id = 2644,
                    Email = "natalia@ua.es",
                    Nombre = "Natalia Ortega Herrera",
                    Codper = null,
                    Activo = true,
                    SuperAdmin = true
                },
                new ClaseUsuario()
                {
                    Id = 2648,
                    Email = "miguel@ua.es",
                    Nombre = "Miguel Ríos Jiménez",
                    Codper = null,
                    Activo = true,
                    SuperAdmin = true
                },
                new ClaseUsuario()
                {
                    Id = 2649,
                    Email = "valentina@ua.es",
                    Nombre = "Valentina Torres Vargas",
                    Codper = null,
                    Activo = true,
                    SuperAdmin = true
                },
                new ClaseUsuario()
                {
                    Id = 2652,
                    Email = "ricardo@ua.es",
                    Nombre = "Ricardo Méndez López",
                    Codper = null,
                    Activo = true,
                    SuperAdmin = true
                },
                new ClaseUsuario()
                {
                    Id = 2654,
                    Email = "camila@ua.es",
                    Nombre = "Camila Acosta Medina",
                    Codper = null,
                    Activo = true,
                    SuperAdmin = true
                },
                new ClaseUsuario()
                {
                    Id = 2656,
                    Email = "alejandra@ua.es",
                    Nombre = "Alejandra Cervantes Soto",
                    Codper = null,
                    Activo = true,
                    SuperAdmin = true
                },
                new ClaseUsuario()
                {
                    Id = 2784,
                    Email = "sebastian@ua.es",
                    Nombre = "Sebastián Luna Morales",
                    Codper = null,
                    Activo = true,
                    SuperAdmin = true
                }
            };


            return listado;
        }

       

        public ClaseDataTable Obtener(int primerregistro = 0, int numeroregistros = 50, string campoorden = "", string orden = "ASC", string? filtro = "", 
            string? campofiltro = "ALL", bool cargardatosadicionales = false)
        {
            var salida = new ClaseDataTable();
            var usuarios = Data;

            orden = orden.ToUpper();

            if (orden != "ASC" && orden != "DESC")
            {
                orden = "ASC";
            }

            campofiltro ??= "ALL";
            filtro ??= "";
            filtro = filtro.RemoveDiacritics();

            salida.NumeroRegistros = usuarios.Count();
            

            if (salida.NumeroRegistros > 0)
            {
                // Todo: Filtrar por el criterio que corresponda
            
                var usuariosfiltrados =
                    campofiltro == "ALL" ? string.IsNullOrEmpty(filtro) ? usuarios : usuarios.Where(u => u.Nombre.RemoveDiacritics().Contains(filtro, StringComparison.CurrentCultureIgnoreCase) || u.Email.RemoveDiacritics().Contains(filtro, StringComparison.CurrentCultureIgnoreCase))
                        : campofiltro.ToLower() == "email" ? usuarios.Where(u => u.Email.RemoveDiacritics().Contains(filtro, StringComparison.CurrentCultureIgnoreCase))
                        : campofiltro.ToLower() == "nombre" ? usuarios.Where(u => u.Nombre.RemoveDiacritics().Contains(filtro, StringComparison.CurrentCultureIgnoreCase))
                        : campofiltro.ToLower() == "activo" && filtro.ToLower() != "null" ? usuarios.Where(u => u.Activo == (filtro.ToLower() == "true" ? true: false)) 
                        : usuarios;

                salida.NumeroRegistrosFiltrados = usuariosfiltrados.Take(numeroregistros).Count();

                // Ordenamos
                if (!string.IsNullOrEmpty(campoorden))
                {
                    if (orden == "ASC")
                    {
                        usuariosfiltrados = usuariosfiltrados.OrderBy(s => s.GetType().GetProperties()
                        .FirstOrDefault(p => string.Equals(p.Name, campoorden, StringComparison.OrdinalIgnoreCase)).GetValue(s));
                    }
                    else
                    {
                        usuariosfiltrados = usuariosfiltrados.OrderByDescending(s => s.GetType().GetProperties()
                            .FirstOrDefault(p => string.Equals(p.Name, campoorden, StringComparison.OrdinalIgnoreCase)).GetValue(s));
                    }
                }

                // Paginamos
                salida.Registros = usuariosfiltrados.Skip(primerregistro).Take(numeroregistros);
            }
            else
            {
                salida.Registros = new List<ClaseUsuario>();
            }

            return salida;
        }

        public List<ClaseUsuario> ObtenerSimple(int primerregistro = 0, int numeroregistros = 50, string campoorden = "", string orden = "ASC", string? filtro = "")
        {
            var usuarios = Data;

            orden = orden.ToUpper();

            if (orden != "ASC" && orden != "DESC")
            {
                orden = "ASC";
            }

            filtro ??= "";
            filtro = filtro.RemoveDiacritics();

            var usuariosfiltrados = string.IsNullOrEmpty(filtro) ? usuarios : usuarios.Where(u => u.Nombre.RemoveDiacritics().Contains(filtro, StringComparison.CurrentCultureIgnoreCase) || u.Email.RemoveDiacritics().Contains(filtro, StringComparison.CurrentCultureIgnoreCase));

            // Ordenamos
            if (!string.IsNullOrEmpty(campoorden))
            {
                if (orden == "ASC")
                {
                    usuariosfiltrados = usuariosfiltrados.OrderBy(s => s.GetType().GetProperties()
                    .FirstOrDefault(p => string.Equals(p.Name, campoorden, StringComparison.OrdinalIgnoreCase)).GetValue(s));
                }
                else
                {
                    usuariosfiltrados = usuariosfiltrados.OrderByDescending(s => s.GetType().GetProperties()
                        .FirstOrDefault(p => string.Equals(p.Name, campoorden, StringComparison.OrdinalIgnoreCase)).GetValue(s));
                }
            }

            return usuariosfiltrados.Skip(primerregistro).Take(numeroregistros).ToList();
        }
    }
}
