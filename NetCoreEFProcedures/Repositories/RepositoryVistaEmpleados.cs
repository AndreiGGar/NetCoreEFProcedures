using NetCoreEFProcedures.Data;
using NetCoreEFProcedures.Models;

namespace NetCoreEFProcedures.Repositories
{
    #region PROCEDURES
    /* CREATE VIEW V_EMPLEADOS_DEPT
        AS
        SELECT CAST(ISNULL(ROW_NUMBER() OVER(ORDER BY APELLIDO), 0) AS int) AS CLAVE, EMP.APELLIDO, EMP.OFICIO, DEPT.DNOMBRE AS NOMBRE, DEPT.LOC AS LOCALIDAD 
        FROM EMP INNER JOIN DEPT
        ON EMP.DEPT_NO = DEPT.DEPT_NO
        GO
     */
    #endregion
    public class RepositoryVistaEmpleados
    {
        private HospitalContext context;

        public RepositoryVistaEmpleados(HospitalContext context)
        {
            this.context = context;
        }

        public List<VistaEmpleados> GetEmpleados()
        {
            var consulta = from datos in this.context.VistaEmpleados
                           select datos;
            return consulta.ToList();
        }
    }
}
