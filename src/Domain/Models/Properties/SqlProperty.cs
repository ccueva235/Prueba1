using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Properties
{
    public class SqlProperty
    {
        public string DataSource { get; set; } = string.Empty;
        public string User { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string CadenaConexion { get; set; } = string.Empty;

        public void CrearCadenaConexion()
        {
            CadenaConexion = $"data source={DataSource};user id={User};password={Password};TrustServerCertificate=true;";
        }
    }
}
