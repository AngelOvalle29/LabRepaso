using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabRepaso
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<Empleado> empleados = new List<Empleado>();
        List<Asistencia> asistencias = new List<Asistencia>();
        List<Reporte> reportes = new List<Reporte>();
        public void MostrarEmpleados()
        {
            //Mostrar la lista de empleados en el GridView
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = empleados;
            dataGridView1.Refresh();
        }
        public void MostrarAsistencia()
        {
            dataGridView2.DataSource = null;
            dataGridView2.DataSource = asistencias;
            dataGridView2.Refresh();
        }
        public void MostrarReporte()
        {
            dataGridView3.DataSource = null;
            dataGridView3.DataSource = reportes;
            dataGridView3.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CargarEmpleados();
            MostrarEmpleados();
            CargarAsistencia();
            MostrarAsistencia();


        }
        public void CargarEmpleados()
        {
            // Cargar o leer los Datos de los Empleados
            

            //Leer el Archivo y Cargarlo a la Lista
            string fileName = "Repaso.txt";

            //Abrimos el archivo, en este caso lo abrimos para lectura
            FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);

            //Un ciclo para leer el archivo hasta el final del archivo
            //Lo leído se va guardando en un control richTextBox
            while (reader.Peek() > -1)
            //Esta linea envía el texto leído a un control richTextBox, se puede cambiar para que
            //lo muestre en otro control por ejemplo un combobox
            {
                
                Empleado empleado = new Empleado();
                empleado.NoEmpleado = Convert.ToInt16(reader.ReadLine());
                empleado.Nombre = (reader.ReadLine());
                empleado.SueldoHora = Convert.ToDecimal(reader.ReadLine());
                

                //Guardar el empleado en la lista de Empleados
                empleados.Add(empleado);
            }
            //Cerrar el archivo, esta linea es importante porque sino despues de correr varias veces el programa daría error de que el archivo quedó abierto muchas veces. Entonces es necesario cerrarlo despues de terminar de leerlo.
            reader.Close();

            
        }
        public void CargarAsistencia()
        {
            string fileName = "Asistencia.txt";

            //Abrimos el archivo, en este caso lo abrimos para lectura
            FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);

            //Un ciclo para leer el archivo hasta el final del archivo
            //Lo leído se va guardando en un control richTextBox
            while (reader.Peek() > -1)
            //Esta linea envía el texto leído a un control richTextBox, se puede cambiar para que
            //lo muestre en otro control por ejemplo un combobox
            {
                Asistencia asistencia  = new Asistencia();
                asistencia.NoEmpleado1 = Convert.ToInt16(reader.ReadLine());
                asistencia.HorasMes= Convert.ToInt16(reader.ReadLine());
                asistencia.Mes = Convert.ToInt16(reader.ReadLine());


                //Guardar el empleado en la lista de Empleados
                asistencias.Add(asistencia);
            }
            //Cerrar el archivo, esta linea es importante porque sino despues de correr varias veces el programa daría error de que el archivo quedó abierto muchas veces. Entonces es necesario cerrarlo despues de terminar de leerlo.
            reader.Close();


        }
        public void CargarReporte()
        {
            //Ciclo para nuestra lista que queremos recorrer, va ir leyendo empleado por empleado y copiara lo que lea en la variable declarada
            foreach (Empleado empleado in empleados)
            {
                //Extraer la primera columna para luego tenerlo en una variable
                int noEmpleado = empleado.NoEmpleado;
                foreach (Asistencia asistencia in asistencias)
                {
                    if (noEmpleado == asistencia.NoEmpleado1)
                    {
                        Reporte reporte = new Reporte();
                        reporte.NombreEmpleado = empleado.Nombre;
                        reporte.Mes = asistencia.Mes;
                        reporte.SueldoMensual = empleado.SueldoHora * asistencia.HorasMes;

                        reportes.Add(reporte);




                    }
                }
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CargarReporte();
            MostrarReporte();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CargarEmpleados(); 
            CargarAsistencia();
            comboBox1.DisplayMember = "Nombre";
            comboBox1.ValueMember = "NoEmpleado";
            comboBox2.ValueMember = "SueldoHora";
            comboBox1.DataSource = empleados;
            comboBox2.DataSource = empleados;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int nombre = Convert.ToInt16(comboBox1.SelectedValue);
            int noEmpleado = Convert.ToInt16(comboBox1.SelectedValue);
            
            //for(int i = 0; i < empleados.Count; i++)
            //{
               // if(nombre == empleados[i].NoEmpleado)
                //{
                   // textBox1.Text = empleados[i].Nombre;
                //}
            //}
            //Buscar por medio de Find
            Empleado empleadoEncontrado = empleados.Find(c => c.NoEmpleado == nombre);
            Asistencia asistenciaEncontrado = asistencias.Find(c => c.NoEmpleado1 == noEmpleado);

            decimal sueldo = empleadoEncontrado.SueldoHora = asistenciaEncontrado.HorasMes;

            label2.Text = empleadoEncontrado.Nombre;
            label3.Text = sueldo.ToString();
            //textBox1.Text = empleadoEncontrado.Nombre;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = comboBox1.Text + comboBox2.Text;
        }
        
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //decimal sueldo = Convert.ToDecimal(comboBox2.SelectedValue);
            //Empleado empleadoSueldo = empleados.Find(c => c.SueldoHora == sueldo);


            //textBox2.Text = Convert.ToString(empleadoSueldo.SueldoHora);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
