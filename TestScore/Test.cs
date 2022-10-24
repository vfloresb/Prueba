using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using ScoreBoard.Controllers;
using ScoreBoard.DataContext;
using ScoreBoard.Models;
using System;
using Xunit;
using ScoreBoard.DataContext.Data;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace TestScore
{
    public class Test
    {


        [Fact]
        public void TestNuevoPartido()
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseInMemoryDatabase(databaseName: "Score_DB");
            var _context = new AppDbContext(optionsBuilder.Options);

            var controller = new PartidosController(new NullLogger<PartidosController>(), _context);
            Partido dp = new Partido();

            dp.local = "Prueba";
            dp.visitante = "Prueba";
            dp.Fecha = DateTime.Now;
            dp.Estado = "Jugando";

            var result = controller.IniciarPartido(dp) as ViewResult;
            var partido = (Partido)result.Model;
            Assert.Equal("Prueba", partido.local);
        }

        [Fact]
        public void TestActualizarPartido()
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseInMemoryDatabase(databaseName: "Score_DB");

            var _context = new AppDbContext(optionsBuilder.Options);

            

            var controller = new PartidosController(new NullLogger<PartidosController>(), _context);
            Partido dp = new Partido();

            dp.local = "Prueba";
            dp.visitante = "Prueba";
            dp.Fecha = DateTime.Now;
            dp.Estado = "Jugando";

            var result = controller.IniciarPartido(dp) as ViewResult;
            var partido = (Partido)result.Model;


            //actualizamos el partido creado finalizandolo y poniendole otro resultado

            partido.Estado = "Finalizado";
            partido.PuntuacionLocal = 5;
            partido.PuntuacionVisitante = 2;

            var result2 = controller.ActualizarPartido(dp) as ViewResult;
            var partido2 = (Partido)result.Model;

            Assert.Equal(5, partido2.PuntuacionLocal);
            Assert.Equal(2, partido2.PuntuacionVisitante);
        }

        [Fact]
        public void TestObtenerPartidosFinalizados()
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseInMemoryDatabase(databaseName: "Score_DB");
            var _context = new AppDbContext(optionsBuilder.Options);

            var controller = new PartidosController(new NullLogger<PartidosController>(), _context);

            

                _context.Partidos.AddRange(
                    new Partido { id = 1, local = "Uruguay", visitante = "Italia", PuntuacionLocal = 6, PuntuacionVisitante = 6, Estado = "Finalizado", Fecha = DateTime.Now },
                    new Partido { id = 2, local = "España", visitante = "Brasil", PuntuacionLocal = 10, PuntuacionVisitante = 2, Estado = "Finalizado", Fecha = DateTime.Now },
                    new Partido { id = 3, local = "México", visitante = "Canada", PuntuacionLocal = 0, PuntuacionVisitante = 5, Estado = "Finalizado", Fecha = DateTime.Now },
                    new Partido { id = 4, local = "Argentina", visitante = "Australia", PuntuacionLocal = 3, PuntuacionVisitante = 1, Estado = "Finalizado", Fecha = DateTime.Now },
                    new Partido { id = 5, local = "Alemania", visitante = "Francia", PuntuacionLocal = 2, PuntuacionVisitante = 2, Estado = "Finalizado", Fecha = DateTime.Now }

                 );

                _context.SaveChanges();


            //Listamos los partidos
           


            
            
            var result = controller.ListarPartidos() as ViewResult;
            var partidos = (List<Partido>)result.Model;

            Assert.Equal(5, partidos.Count);
        }
    }
}
