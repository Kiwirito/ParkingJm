using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;
using ParkingJm.Clases_Container;
using ParkingJm.Clases;

namespace ParkingJm
{
    public partial class InterfazMain : Form
    {
        List<Driver> drivers;
        List<Vehicle> vehicles;
        public InterfazMain()
        {
            InitializeComponent();
            CenterToScreen();
            pictureBox3.BackColor = Color.Transparent;
            pictureBox5.BackColor = Color.Transparent;
        }

        private void InterfazMain_Load(object sender, EventArgs e)
        {
            //Se recarga la informacion de la lista de afiliados
            drivers = new List<Driver>();
            if (File.Exists("AfiliadosDatos.txt"))
            {
                foreach (string line in  System.IO.File.ReadLines("AfiliadosDatos.txt"))
                {
                    string[] items = line.Split(',');
                    drivers.Add(new Driver(items[0], items[2], items[3], true));
                }
                afiliadoslist();
            }

            

           
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void NombreEnter(object sender, EventArgs e)
        {
            if (RegisterBox.Text == "Nombre")
            {
                RegisterBox.Clear();
            }
        }

        private void NombreLeave(object sender, EventArgs e)
        {
            if (RegisterBox.Text == "")
            {
                RegisterBox.Text = "Nombre";
            }

        }


        private void IdentificacionLeave(object sender, EventArgs e)
        {
            if (IdenBox.Text == "")
            {
                IdenBox.Text = "Identificacion";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            drivers.Add(new Driver(RegisterBox.Text, IdenBox.Text, SeBox.Text, true));
            afiliadoslist();
            RegisterBox.Text = "Nombre";
            IdenBox.Text = "Identificacion";
            SeBox.Text = "Sexo";
            guardarlistafiliados(drivers[drivers.Count - 1]);
        }

        private void guardarlistafiliados(Driver nuevodriver)
        {
            string path = "AfiliadosDatos.txt";
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(nuevodriver.Nombre + "," + nuevodriver.Identificacion + "," + nuevodriver.Sexo + "," + nuevodriver.Afiliado);
            }
        }

        private void afiliadoslist()
        {
            comboBox1.Items.Clear();
            foreach(Driver x in drivers)
            {
                comboBox1.Items.Add(x.Nombre);
            }    
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void IdentificacionEnter(object sender, EventArgs e)
        {
            if (IdenBox.Text == "Identificacion")
            {
                IdenBox.Clear();
            }
        }

        private void IdenBox_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void IdenBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar);
        }

        private void NombreBox2_Enter(object sender, EventArgs e)
        {
            if (NombreBox2.Text == "Nombre")
            {
                NombreBox2.Clear();
            }
        }

        private void NombreBox2_Leave(object sender, EventArgs e)
        {
            if (NombreBox2.Text == "")
            {
                NombreBox2.Text = "Nombre";
            }
        }

        private void IdenBox2_Enter(object sender, EventArgs e)
        {
            if (IdenBox2.Text == "Identificacion")
            {
                IdenBox2.Clear();
            }
        }

        private void IdenBox2_Leave(object sender, EventArgs e)
        {
            if (IdenBox2.Text == "")
            {
                IdenBox2.Text = "Identificacion";
            }
        }

        private void IdenBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
             e.Handled = !char.IsDigit(e.KeyChar);
        }
    }
}
