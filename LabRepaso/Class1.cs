using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabRepaso
{
    internal class Empleado
    {
        int noEmpleado;
        string nombre;
        decimal sueldoHora;


        public int NoEmpleado { get => noEmpleado; set => noEmpleado = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public decimal SueldoHora { get => sueldoHora; set => sueldoHora = value; }
        
    }
}
