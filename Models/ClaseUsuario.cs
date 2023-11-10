using System;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace ua.Models
{
    public class ClaseUsuario
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Email { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public int? Codper { get; set; }
        public bool Activo { get; set; } = true;
        public DateTime FehaNacimiento { get; set; } = DateTime.Now.Date;
        public bool SuperAdmin { get; set; } = false;

        public ClaseUsuario()
        {
        }

public ClaseUsuario(IDataRecord rs)
{
    if (rs != null)
    {
        Id = Int32.Parse(rs["ID_USUARIO"]?.ToString() ?? "-1");

        Email = rs["EMAIL"]?.ToString() ?? "";
        Nombre = rs["NOMBRE_USUARIO"]?.ToString() ?? "";

        Codper = rs["CODPER_UAAPPS"] != DBNull.Value ? Int32.Parse(rs["CODPER_UAAPPS"]?.ToString()) : null;

        Activo = (rs["ACTIVO_SN"]?.ToString() ?? "N").ToUpper() == "S";
        SuperAdmin = (rs["SUPER_ADMIN"]?.ToString() ?? "N").ToUpper() == "S";
    }
}
    }
}
