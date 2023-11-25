using Data.Sql.Helpers;
using Domain.Models;
using Domain.Models.Properties;
using Domain.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Sql.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly SqlProperty sqlProperty;
        private readonly SettingProperty settingProperty;
        private object sqlDbType;

        public UsuarioRepository(
          IOptions<SqlProperty> sqlProperty,
          IOptions<SettingProperty> settingProperty
          )
        {
            this.sqlProperty = sqlProperty.Value;
            this.sqlProperty.CrearCadenaConexion();
            this.settingProperty = settingProperty.Value;
        }

        public async Task<List<Usuario>> BuscarUsuario()
        {
            List<Usuario> usuarios = new List<Usuario>();

            using (var cn = new SqlConnection(sqlProperty.CadenaConexion))
            {               
                using (var cmd = cn.CreateCommand())
                {
                    await cn.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SP_GetUsuarios";
                    cmd.CommandTimeout = settingProperty.TiempoEsperaBdSegundos;

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            Usuario usuario = new Usuario
                            {
                                id = reader.GetInt32(reader.GetOrdinal("id")),
                                nombre = reader.GetString(reader.GetOrdinal("nombre")),
                                apellido = reader.GetString(reader.GetOrdinal("apellido")),
                                usuario = reader.GetString(reader.GetOrdinal("usuario")),
                                contraseña = reader.GetString(reader.GetOrdinal("contraseña")),
                                fecha_creacion = reader.GetDateTime(reader.GetOrdinal("fecha_creacion"))
                            };
                            usuarios.Add(usuario);
                        }
                    }
                    await cn.CloseAsync();
                }
                             
            }

            return usuarios;
        }

    }
}
