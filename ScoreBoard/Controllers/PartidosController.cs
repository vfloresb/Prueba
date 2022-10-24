using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ScoreBoard.Models;
using Microsoft.Extensions.Logging;
using ScoreBoard.DataContext;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ScoreBoard.Controllers
{
    public class PartidosController : Controller
    {

        private readonly ILogger<PartidosController> _logger;
        private readonly AppDbContext _context;
        public PartidosController(ILogger<PartidosController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        
        // GET: Obtenemos los partidos ordenados por la suma mayor del resultado, y ordenador por la fecha de ingreso en el sistema más reciente.
        public ActionResult ListarPartidos()
        {
            var partidos = _context.Partidos.Where(P => P.Estado == "Finalizado").OrderByDescending(p => (p.PuntuacionLocal+p.PuntuacionVisitante)).OrderBy(p=> p.Fecha).ToList();

            return View(partidos);
        }

        public ActionResult ListarPartidosCurso()
        {
            var partidos = _context.Partidos.Where(P => P.Estado == "Jugando" || P.Estado == "Descanso").OrderByDescending(p => (p.PuntuacionLocal + p.PuntuacionVisitante)).OrderBy(p => p.Fecha).ToList();

            return View(partidos);
        }

        public ActionResult IniciarPartido()
        {
            try
            {
                return View();
            }
            catch
            {
                return PartialView();
            }
        }

        //Creamos un nuevo partido con los datos introducidos.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult IniciarPartido(Partido datosPartido)
        {
            try
            {
                datosPartido.Estado = "Jugando";
                datosPartido.Fecha = DateTime.Now;
                _context.Partidos.Add(datosPartido);
                _context.SaveChanges();

                var partidos = _context.Partidos.Where(P => P.Fecha== datosPartido.Fecha && P.local==datosPartido.local && P.visitante == datosPartido.visitante).ToList();

                return View("ActualizarPartido", partidos[0]);
            }
            catch
            {
                return View();
            }
        }

        // GET: JuegosController/Edit/5
        [HttpGet]
        public ActionResult ActualizarPartido(int valorSeleccionado)
        {
            var partido = _context.Partidos.Find(valorSeleccionado);
            return View("ActualizarPartido",partido);

        }

        //Actualizamos los datos de un partido en concreto.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ActualizarPartido(Partido datosPartido)
        {
            try
            {
                _context.Update(datosPartido);
                _context.SaveChanges();

                var partido = _context.Partidos.Find(datosPartido.id);
                ViewBag.partidos = new SelectList(_context.Partidos.Where(P => P.Estado != "Finalizado"), "id", "local");

                return View("ActualizarPartido", partido);
            }
            catch
            {
                return View("ActualizarPartido");
            }
        }


        public Partido OnValueChanged(ChangeEventArgs e)
        {
            var partido = _context.Partidos.Find(e.Value);
            return partido;
        }

    }
}
