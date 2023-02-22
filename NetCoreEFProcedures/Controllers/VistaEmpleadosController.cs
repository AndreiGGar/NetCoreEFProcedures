using Microsoft.AspNetCore.Mvc;
using NetCoreEFProcedures.Models;
using NetCoreEFProcedures.Repositories;

namespace NetCoreEFProcedures.Controllers
{
    public class VistaEmpleadosController : Controller
    {
        private RepositoryVistaEmpleados repo;
        public VistaEmpleadosController(RepositoryVistaEmpleados repo)
        {
            this.repo = repo;
        }

        public IActionResult Index()
        {
            List<VistaEmpleados> empleados = this.repo.GetEmpleados();
            return View(empleados);
        }
    }
}
