using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Models
{
   public class Jugador:Persona
    {
        public DateTime FechaNacimiento { get; set; }
        public string Puesto { get; set; }
        public Jugador() { }

        public Jugador(string nombre, string apellido, DateTime fechaNacimiento, string puesto):base(nombre, apellido)
        {
            FechaNacimiento = fechaNacimiento;
            Puesto = puesto;
        }
    }
}
