using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class ConsultaSunat
    {
        public bool Success { get; set; }
        public DataInfo Data { get; set; }       
    }

    public class DataInfo
    {
        public string Numero { get; set; }
        public string nombre_completo { get; set; }
        public string Nombres { get; set; }
        public string apellido_paterno { get; set; }
        public string apellido_materno { get; set; }
        public int codigo_verificacion { get; set; }       
    }
}
