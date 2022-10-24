using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ScoreBoard.Models;
using ScoreBoard.DataContext;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ScoreBoard.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;
        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var partidosList = _context.Partidos.Select(x => new
            {
                x.id,
                MacthName = x.local + " - " + x.visitante,
                x.Estado
            }).Where(P => P.Estado != "Finalizado");

            ViewBag.partidos = new SelectList(partidosList, "id", "MacthName");
            ViewBag.numeropartidos = partidosList.Count();
            return View();
        }

       
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
