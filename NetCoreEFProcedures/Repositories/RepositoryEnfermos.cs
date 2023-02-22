using NetCoreEFProcedures.Data;
using NetCoreEFProcedures.Models;
using System.Data.Common;
using System.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace NetCoreEFProcedures.Repositories
{
    public class RepositoryEnfermos
    {
        private HospitalContext context;
        public RepositoryEnfermos(HospitalContext context)

        {
            this.context = context;
        }
        public List<Enfermo> GetEnfermos() {

            using (DbCommand com = this.context.Database.GetDbConnection().CreateCommand())
            {
                string sql = "SP_ENFERMOS";
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = sql;
                com.Connection.Open();
                DbDataReader reader = com.ExecuteReader();
                List<Enfermo> enfermos = new List<Enfermo>();
                while (reader.Read())
                {
                    Enfermo enfermo = new Enfermo
                    {
                        Inscripcion = int.Parse(reader["INSCRIPCION"].ToString()),
                        Apellido = reader["APELLIDO"].ToString(),
                        Direccion = reader["DIRECCION"].ToString(),
                        FechaNacimiento = DateTime.Parse(reader["FECHA_NAC"].ToString()),
                        Sexo = reader["S"].ToString()
                    };
                    enfermos.Add(enfermo);
                }
                reader.Close();
                com.Connection.Close();
                return enfermos;
            }
        }
        public Enfermo FindEnfermo(int inscripcion)
        {
            string sql = "SP_BUSCAR_ENFERMO @INSCRIPCION";
            SqlParameter paminscripcion = new SqlParameter("@INSCRIPCION", inscripcion);
            var consulta = this.context.Enfermos.FromSqlRaw(sql, paminscripcion);
            Enfermo enfermo = consulta.AsEnumerable().FirstOrDefault();
            return enfermo;
        }

        public void DeleteEnfermo(int inscripcion)
        {
            string sql = "SP_DELETE_ENFERMO @INSCRIPCION";
            SqlParameter paminscripcion = new SqlParameter("@INSCRIPCION", inscripcion);
            this.context.Database.ExecuteSqlRaw(sql, paminscripcion);
        }
    }
}
