using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScoreBoard.Models
{
    public partial  class Partido
    {
 
        public int id { get; set; }
        public string local { get; set; }
        public string visitante { get; set; }
        public int PuntuacionLocal { get; set; }
        public int PuntuacionVisitante { get; set; }
        public string Estado { get; set; }
        public DateTime Fecha { get; set; }
      
    }

    public partial class ListaPartidos
    {
        public Dictionary<int, Partido> Partidos { get; set; }
    }
}
