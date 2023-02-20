using NetCoreEFProcedures.Data;
using NetCoreEFProcedures.Models;
using System.Data.Common;
using System.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using System.Linq;

namespace NetCoreEFProcedures.Repositories
{
    public class RepositoryDoctores
    {
        private EnfermosContext context;
        public RepositoryDoctores(EnfermosContext context)

        {
            this.context = context;
        }
        public List<Doctor> GetDoctores() {

            using (DbCommand com = this.context.Database.GetDbConnection().CreateCommand())
            {
                string sql = "SP_DOCTORES";
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = sql;
                com.Connection.Open();
                DbDataReader reader = com.ExecuteReader();
                List<Doctor> doctores = new List<Doctor>();
                while (reader.Read())
                {
                    Doctor doctor = new Doctor
                    {
                        HOSPITAL_COD = int.Parse(reader["HOSPITAL_COD"].ToString()),
                        DOCTOR_NO = int.Parse(reader["DOCTOR_NO"].ToString()),
                        APELLIDO = reader["APELLIDO"].ToString(),
                        ESPECIALIDAD = reader["ESPECIALIDAD"].ToString(),
                        SALARIO = int.Parse(reader["SALARIO"].ToString()),
                    };
                    doctores.Add(doctor);
                }
                reader.Close();
                com.Connection.Close();
                return doctores;
            }
        }

        public List<string> GetEspecialidades()
        {
            var consulta = (from datos in this.context.Doctores
                            select datos.ESPECIALIDAD).Distinct();
            return consulta.ToList();
        }

        public async Task IncrementoSalarioAsync(string especialidad, int incremento = 0)
        {
            string sql = "SP_ESPECIALIDADES @ESPECIALIDAD, @INCREMENTO";
            SqlParameter pamespecialidad = new SqlParameter("@ESPECIALIDAD", especialidad);
            SqlParameter pamincremento = new SqlParameter("@INCREMENTO", incremento);
            await this.context.Database.ExecuteSqlRawAsync(sql, pamespecialidad, pamincremento);
        }
    }
}
