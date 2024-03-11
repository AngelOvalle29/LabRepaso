using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabRepaso
{
    internal class Reporte
    {
        string nombreEmpleado;
        int mes;
        decimal sueldoMensual;

        public string NombreEmpleado { get => nombreEmpleado; set => nombreEmpleado = value; }
        public int Mes { get => mes; set => mes = value; }
        public decimal SueldoMensual { get => sueldoMensual; set => sueldoMensual = value; }
    }
}
