using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingJm.Clases_Container
{
  
    class Driver
    {
        
        public string Nombre;
        public string Identificacion;
        public string Sexo;
        public bool Afiliado;

        public Driver() { } //Se crea un constructor vacio

        public Driver(string nombre, string identificacion, string sexo, bool afiliado)
        {
            Nombre = nombre;
            Identificacion = identificacion;
            Sexo = sexo;
            Afiliado = afiliado;

        }
    }
}
