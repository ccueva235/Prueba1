using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Sql.Helpers
{
    public class SqlConvert
    {
        public static List<TModel> ReaderToModel<TModel>(SqlDataReader reader) where TModel : class
        {
            var data = new DataTable();
            data.Load(reader);

            List<TModel> modelList = new List<TModel>();

            foreach (DataRow row in data.Rows)
            {
                TModel model = Activator.CreateInstance<TModel>();

                foreach (var property in typeof(TModel).GetProperties())
                {
                    if (data.Columns.Contains(property.Name) && row[property.Name] != DBNull.Value)
                    {
                        property.SetValue(model, row[property.Name]);
                    }
                }

                modelList.Add(model);
            }

            return modelList;
        }
    }
}
