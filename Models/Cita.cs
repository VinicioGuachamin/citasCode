using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pruebaBackendPry.Models
{
    public class Cita
    {
        public int Id { get; set; }
        public string Placa { get; set; }
        public DateTime Fecha { get; set; }
        public string Estado { get; set; }
    }
}
