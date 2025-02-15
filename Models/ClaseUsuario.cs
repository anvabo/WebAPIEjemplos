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
        public string Foto { get; set; } = "https://randomuser.me/api/portraits/men/40.jpg";
        public int? Codper { get; set; }
        public bool Activo { get; set; } = true;
        public DateTime FehaNacimiento { get; set; } = DateTime.Now.Date;
        public bool SuperAdmin { get; set; } = false;
        public double Valoracion { get; set; } = 0;
        public ClaseUsuario()
        {
        }

    }
}
