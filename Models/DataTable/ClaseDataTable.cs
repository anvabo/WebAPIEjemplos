namespace ua.Models.DataTable
{
    public class ClaseDataTable
    {
        public int NumeroRegistros { get; set; }
        public int NumeroRegistrosFiltrados { get; set; }
        public IEnumerable<object> Registros { get; set; }

        public ClaseDataTable()
        {
            NumeroRegistros = 0;
        }
    }
}

