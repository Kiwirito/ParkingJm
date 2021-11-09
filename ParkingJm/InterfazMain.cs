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
        List<Vehicle> listavehiculos;
        int banda;
        Driver obtenerdriver;
        Vehicle carrodato;
        public InterfazMain()
        {
            InitializeComponent();
            CenterToScreen();
            pictureBox3.BackColor = Color.Transparent;
            Car3.BackColor = Color.Transparent;
        }

        private void InterfazMain_Load(object sender, EventArgs e)
        {
            pua10.Visible = false;
            pua2.Visible = false;
            pua3.Visible = false;
            pua4.Visible = false;
            pua5.Visible = false;
            pua6.Visible = false;
            pua7.Visible = false;
            pua8.Visible = false;
            pua9.Visible = false;
            pua1.Visible = false;

            Car1.Visible = false;
            Car2.Visible = false;
            Car3.Visible = false;
            Car4.Visible = false;
            Car5.Visible = false;
            Car6.Visible = false;
            Car7.Visible = false;
            Car8.Visible = false;
            Car9.Visible = false;
            Car10.Visible = false;

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
            listavehiculos = new List<Vehicle>();
            if (File.Exists("VehiculosPark.txt"))
            {
                foreach (string line in System.IO.File.ReadLines("VehiculosPark.txt"))
                {
                    string[] items = line.Split(',');
                    drivers.Add(new Driver(items[0], items[2], items[3], true));
                }

            }
            else
            {
                for (int i = 0; i < 10; i++)
                {
                    listavehiculos.Add(new Vehicle("Void", "Void", "Void", new Driver("Void", "Void", "Void", false)));

                }
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
            if (SeBox.Text == "Mujer")
            {
                MessageBox.Show("Se inscribio la afiliada " + RegisterBox.Text + " correctamente");
            }
            if (SeBox.Text == "Hombre")
            {
                MessageBox.Show("Se inscribio el afiliado " + RegisterBox.Text + " correctamente");
            }
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
        private void Guardarlistaparkeadero(Vehicle nuevovehiculo)
        {
            string path = "VehiculosPark.txt";
            using (StreamWriter tw = File.AppendText(path))
            {
                tw.WriteLine(nuevovehiculo.Placa + "," + nuevovehiculo.Tipo + "," + nuevovehiculo.Marca + "," + nuevovehiculo.Conductor);
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

        private void RegistrarCarroClick_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "Eres Afiliado?")
            {
                foreach (Driver r in drivers)
                {
                    if(comboBox1.Text.Contains(r.Nombre))
                    {
                        obtenerdriver = r;
                    }
                }
            }
            else
            {
                obtenerdriver = new Driver(NombreBox2.Text, IdenBox2.Text, SeBox2.Text, false);
            }
            carrodato = new Vehicle(PlacaBox.Text, TipoBox.Text, MarcaBox.Text, obtenerdriver);
            int caminoDerecho = 0;
            int caminoIzquierdo = 0;
            int ContDerecho = 1;
            int ContIzquierdo = 10;
            List<Vehicle> NuevaLista = new List<Vehicle>();
            int Reversa = listavehiculos.Count - 1;
            List<Vehicle> ListaReversa = new List<Vehicle>();
            while (Reversa >= 0)
            {
                ListaReversa.Add(listavehiculos[Reversa]);
                Reversa--;
            }
            for (int i = 0; i < 10; i++)
            {
                if (listavehiculos[caminoDerecho].Marca == "Void")
                {
                    break;
                }
                caminoDerecho++;
                ContDerecho++;
            }
            for (int i = 0; i < 10; i++)
            {
                if (ListaReversa[caminoIzquierdo].Marca == "Void")
                {
                    break;
                }
                caminoIzquierdo++;
                ContIzquierdo--;
            }
            if (caminoIzquierdo < caminoDerecho)
            {
                for (int i = 9 - caminoIzquierdo; i < 10; i++)
                {
                    if (i == 9 - caminoIzquierdo)
                    {
                        NuevaLista.Add(carrodato);

                    }
                    else
                    {
                        NuevaLista.Add(listavehiculos[i]);
                    }
                }

                for (int i = 0; i < 9 - caminoIzquierdo; i++)
                {
                    NuevaLista.Add(listavehiculos[i]);
                    banda = ContDerecho;
                }
            }
            else
            {
                for (int i = caminoDerecho; i < 10; i++)
                {
                    if (i == caminoDerecho)
                    {
                        NuevaLista.Add(carrodato);

                    }
                    else
                    {
                        NuevaLista.Add(listavehiculos[i]);
                    }
                }

                for (int i = 0; i < caminoDerecho; i++)
                {
                    NuevaLista.Add(listavehiculos[i]);
                    banda = ContIzquierdo;
                }
            }
            listavehiculos = NuevaLista;
            parqueaderochek();

            if (banda == 0)
            {
                puestostxt.Text = "Lugar de la plataforma: 1";
            }
            else
            {
                puestostxt.Text = "Lugar de la plataforma: " + banda.ToString();
            }
            

        }
        public void parqueaderochek()
        {
           
            int countloop = 0;
            foreach (Vehicle i in listavehiculos)
            {
                
                if (countloop == 0 & i.Marca != "Void")
                {
                    Car1.Visible = true;

                    pua10.Visible = false;
                    pua2.Visible = false;
                    pua3.Visible = false;
                    pua4.Visible = false;
                    pua5.Visible = false;
                    pua6.Visible = false;
                    pua7.Visible = false;
                    pua8.Visible = false;
                    pua9.Visible = false;

                    pua1.Visible = true;
                }
                if (countloop == 0 & i.Marca == "Void")
                {
                    Car1.Visible = false;
                }

                if (countloop == 1 & i.Marca != "Void")
                {
                    Car2.Visible = true;

                    pua1.Visible = false;
                    pua3.Visible = false;
                    pua4.Visible = false;
                    pua5.Visible = false;
                    pua6.Visible = false;
                    pua7.Visible = false;
                    pua8.Visible = false;
                    pua9.Visible = false;
                    pua10.Visible = false;

                    pua2.Visible = true;
                }
                if (countloop == 1 & i.Marca == "Void")
                {
                    Car2.Visible = false;
                }

                if (countloop == 2 & i.Marca != "Void")
                {
                    Car3.Visible = true;

                    pua1.Visible = false;
                    pua2.Visible = false;
                    pua4.Visible = false;
                    pua5.Visible = false;
                    pua6.Visible = false;
                    pua7.Visible = false;
                    pua8.Visible = false;
                    pua9.Visible = false;
                    pua10.Visible = false;

                    pua3.Visible = true;
                }
                if (countloop == 2 & i.Marca == "Void")
                {
                    Car3.Visible = false;
                }

                if (countloop == 3 & i.Marca != "Void")
                {
                    Car4.Visible = true;

                    pua1.Visible = false;
                    pua2.Visible = false;
                    pua3.Visible = false;
                    pua5.Visible = false;
                    pua6.Visible = false;
                    pua7.Visible = false;
                    pua8.Visible = false;
                    pua9.Visible = false;
                    pua10.Visible = false;

                    pua4.Visible = true;
                }
                if (countloop == 3 & i.Marca == "Void")
                {
                    Car4.Visible = false;
                }

                if (countloop == 4 & i.Marca != "Void")
                {
                    Car5.Visible = true;

                    pua1.Visible = false;
                    pua2.Visible = false;
                    pua3.Visible = false;
                    pua4.Visible = false;
                    pua6.Visible = false;
                    pua7.Visible = false;
                    pua8.Visible = false;
                    pua9.Visible = false;
                    pua10.Visible = false;

                    pua5.Visible = true;
                }
                if (countloop == 4 & i.Marca == "Void")
                {
                    Car5.Visible = false;
                }

                if (countloop == 5 & i.Marca != "Void")
                {
                    Car6.Visible = true;

                    pua1.Visible = false;
                    pua2.Visible = false;
                    pua3.Visible = false;
                    pua4.Visible = false;
                    pua5.Visible = false;
                    pua7.Visible = false;
                    pua8.Visible = false;
                    pua9.Visible = false;
                    pua10.Visible = false;

                    pua6.Visible = true;
                }
                if (countloop == 5 & i.Marca == "Void")
                {
                    Car6.Visible = false;
                }

                if (countloop == 6 & i.Marca != "Void")
                {
                    Car7.Visible = true;


                    pua1.Visible = false;
                    pua2.Visible = false;
                    pua3.Visible = false;
                    pua4.Visible = false;
                    pua5.Visible = false;
                    pua6.Visible = false;
                    pua8.Visible = false;
                    pua9.Visible = false;
                    pua10.Visible = false;

                    pua7.Visible = true;
                }
                if (countloop == 6 & i.Marca == "Void")
                {
                    Car7.Visible = false;
                }

                if (countloop == 7 & i.Marca != "Void")
                {
                    Car8.Visible = true;


                    pua1.Visible = false;
                    pua2.Visible = false;
                    pua3.Visible = false;
                    pua4.Visible = false;
                    pua5.Visible = false;
                    pua6.Visible = false;
                    pua7.Visible = false;
                    pua9.Visible = false;
                    pua10.Visible = false;

                    pua8.Visible = true;
                }
                if (countloop == 7 & i.Marca == "Void")
                {
                    Car8.Visible = false;
                }

                if (countloop == 8 & i.Marca != "Void")
                {
                    Car9.Visible = true;


                    pua1.Visible = false;
                    pua2.Visible = false;
                    pua3.Visible = false;
                    pua4.Visible = false;
                    pua5.Visible = false;
                    pua6.Visible = false;
                    pua8.Visible = false;
                    pua7.Visible = false;
                    pua10.Visible = false;

                    pua9.Visible = true;
                }
                if (countloop == 8 & i.Marca == "Void")
                {
                    Car9.Visible = false;
                }

                if (countloop == 9 & i.Marca != "Void")
                {
                    Car10.Visible = true;


                    pua1.Visible = false;
                    pua2.Visible = false;
                    pua3.Visible = false;
                    pua4.Visible = false;
                    pua5.Visible = false;
                    pua6.Visible = false;
                    pua7.Visible = false;
                    pua8.Visible = false;
                    pua9.Visible = false;

                    pua10.Visible = true;
                }
                if (countloop == 9 & i.Marca == "Void")
                {
                    Car10.Visible = false;
                }

                countloop++;
            }
        }

        private void LiquidarBtn_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void NombreBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
