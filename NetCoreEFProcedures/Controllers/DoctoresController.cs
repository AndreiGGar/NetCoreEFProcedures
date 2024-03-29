﻿using Microsoft.AspNetCore.Mvc;
using NetCoreEFProcedures.Models;
using NetCoreEFProcedures.Repositories;

namespace NetCoreEFProcedures.Controllers
{
    public class DoctoresController : Controller
    {
        private RepositoryDoctores repo;
        public DoctoresController(RepositoryDoctores repo)
        {
            this.repo = repo;
        }

        public IActionResult Index()
        {
            List<Doctor> doctores = this.repo.GetDoctores();
            List<string> especialidades = this.repo.GetEspecialidades();
            ViewData["ESPECIALIDADES"] = especialidades;
            return View(doctores);
        }

        [HttpPost]
        public async Task<IActionResult> Index(string especialidad, int incremento)
        {
            await this.repo.IncrementoSalarioAsync(especialidad, incremento);
            List<Doctor> doctores = this.repo.GetDoctores();
            List<string> especialidades = this.repo.GetEspecialidades();
            ViewData["ESPECIALIDADES"] = especialidades;
            return View(doctores);
        }
    }
}
