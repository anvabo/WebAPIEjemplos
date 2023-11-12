using System;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace ua.Models
{
    public class ClaseCategoriaTarea
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; } = string.Empty;
    }
    public class ClaseTarea
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public int? CodperPropietario { get; set; }
        public bool Activa { get; set; } = true;
        public DateTime FechaInicio { get; set; } = DateTime.Now.Date;
        public DateTime FechaFin { get; set; } = DateTime.Now.Date;

        public List<ClaseCategoriaTarea> Categorias { get; set; }
        
        
    }
}
