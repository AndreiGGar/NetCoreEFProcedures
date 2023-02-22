using Microsoft.AspNetCore.Mvc;
using NetCoreEFProcedures.Models;
using NetCoreEFProcedures.Repositories;

namespace NetCoreEFProcedures.Controllers
{
    public class TrabajadoresController : Controller
    {
        private RepositoryTrabajadores repo;

        public TrabajadoresController(RepositoryTrabajadores repo)
        {
            this.repo = repo;
        }

        public IActionResult Index()
        {
            List<Trabajador> trabajadores = this.repo.GetTrabajadores();
            /*TrabajadoresModel model = new TrabajadoresModel();
            model.Trabajadores = trabajadores;*/
            List<string> oficios = this.repo.GetOficios();
            ViewData["OFICIOS"] = oficios;
            ViewData["TRABAJADORES"] = trabajadores;
            return View();
        }

        [HttpPost]
        public IActionResult Index(string oficio)
        {
            TrabajadoresModel model = this.repo.GetTrabajadoresOficio(oficio);
            List<string> oficios = this.repo.GetOficios();
            ViewData["OFICIOS"] = oficios;
            return View(model);
        }
    }
}
