namespace ua.Models.DataTable
{
    public class ClaseDataTable
    {
        public int NumeroRegistros { get; set; }
        public int NumeroRegistrosFiltrados { get; set; }
        public IEnumerable<object> Registros { get; set; }
        public Dictionary<string, List<ClaseDatosAdicionalesDataTable>>? DatosAdicionales { get; set; } = null;

        public ClaseDataTable()
        {
            NumeroRegistros = 0;
            DatosAdicionales = null;
        }
    }
}

