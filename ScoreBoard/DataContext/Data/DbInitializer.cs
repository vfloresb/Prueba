using ScoreBoard.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ScoreBoard.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScoreBoard.DataContext.Data
{
    public static class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var _context = new AppDbContext(serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()))
            {
                // Agregando Partidos a la BD
                if (_context.Partidos.Any())
                {
                    return;
                }

                _context.Partidos.AddRange(
                    new Partido { id = 1, local = "Uruguay", visitante = "Italia", PuntuacionLocal = 6, PuntuacionVisitante = 6, Estado = "Finalizado", Fecha = DateTime.Now },
                    new Partido { id = 2, local = "España", visitante = "Brasil", PuntuacionLocal = 10, PuntuacionVisitante = 2, Estado = "Finalizado", Fecha = DateTime.Now },
                    new Partido { id = 3, local = "México", visitante = "Canada", PuntuacionLocal = 0, PuntuacionVisitante = 5, Estado = "Finalizado", Fecha = DateTime.Now },
                    new Partido { id = 4, local = "Argentina", visitante = "Australia", PuntuacionLocal = 3, PuntuacionVisitante = 1, Estado = "Finalizado", Fecha = DateTime.Now },
                    new Partido { id = 5, local = "Alemania", visitante = "Francia", PuntuacionLocal = 2, PuntuacionVisitante = 2, Estado = "Finalizado", Fecha = DateTime.Now }
                    
                 );

                _context.SaveChanges();



            }
        }
    }
}
