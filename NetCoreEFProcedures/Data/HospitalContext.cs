using Microsoft.EntityFrameworkCore;
using NetCoreEFProcedures.Models;

namespace NetCoreEFProcedures.Data
{
    public class HospitalContext : DbContext
    {
        public HospitalContext(DbContextOptions<HospitalContext> options) : base(options) { }
        public DbSet<Enfermo> Enfermos { get; set; }
        public DbSet<Doctor> Doctores { get; set; }
        public DbSet<VistaEmpleados> VistaEmpleados { get; set; }
        public DbSet<Trabajador> Trabajadores { get; set; }
    }
}
