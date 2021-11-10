using ParkingJm.Clases_Container;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingJm.Clases
{
    class Vehicle
    {
        public string Tipo;
        public string Marca;
        public string Placa;
        public Driver Conductor;
        public DateTime timestamp = DateTime.Now;


        public Vehicle(string placa, string tipo, string marca, Driver conductor)
        {
            Tipo = tipo;
            Placa = placa;
            Marca = marca;
            Conductor = conductor;
        }
    }
}
