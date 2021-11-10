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
        int total;
        int totalc;
        int spacios;
        Vehicle vcobro;
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
                    string[] driver = items[4].Split(';');
                    Vehicle obtenervehiculo = new Vehicle(items[0], items[1], items[2], new Driver(driver[0], driver[1], driver[2], Convert.ToBoolean(driver[3])));
                    obtenervehiculo.timestamp = DateTime.Parse(items[3]);
                    listavehiculos.Add(obtenervehiculo);
                }
                parqueaderochek();

            }
            else
            {
                for (int i = 0; i < 10; i++)
                {
                    listavehiculos.Add(new Vehicle("Void", "Void", "Void", new Driver("Void", "Void", "Void", false)));
                    spacios = 10;
                    espaciosdis.Text = "Quedan " + spacios.ToString() + " espacios";
                }
                parqueaderochek();
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
            //listavehiculos.Add(new Vehicle(PlacaBox.Text, MarcaBox.Text, TipoBox.Text,, true));
            afiliadoslist();
            guardarlistafiliados(drivers[drivers.Count - 1]);
            RegisterBox.Text = "Nombre";
            IdenBox.Text = "Identificacion";
            SeBox.Text = "Sexo";
            
            
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
            foreach (Driver i in drivers)
            {
                if (comboBox1.Text == i.Nombre)
                {
                    obtenerdriver = i;
                    break;
                }
                else
                {
                    obtenerdriver = new Driver(NombreBox2.Text, IdenBox2.Text, SeBox2.Text, false);
                }
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
            spacios--;
            espaciosdis.Text ="Quedan " + spacios.ToString() + " espacios";
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
            int tic = 0;
            foreach (Vehicle i in listavehiculos)
            {
                if (i.Placa == vcobro.Placa | i.Conductor.Identificacion == vcobro.Conductor.Identificacion)
                {
                    spacios++;
                    if (spacios > 0)
                    {
                        RegistrarCarroClick.Enabled = true;
                        espaciosdis.Text = "Quedan " + spacios.ToString() + " espacios";
                    }
                    banda = tic + 1;
                    listavehiculos[tic] = new Vehicle("Void", "Void", "Void", new Driver("Void", "Void", "Void", false));
                    break;
                }
                tic++;
            }
            parqueaderochek();
            puestostxt.Text = "Lugar de la plataforma: " + banda.ToString() + " 1";

            total = total + totalc;
            TotalBox.Text = "Total: " + total.ToString();

            
            VentasBox.Text = "\n" + VentasBox.Text + "\n" + "Información del carro: \n Placa: " + vcobro.Placa + "\n Tipo: " + vcobro.Tipo + "\n Marca: " + vcobro.Marca + "\n Información del cliente: \n Nombre: " + vcobro.Conductor.Nombre + "\n Identificación: " + vcobro.Conductor.Identificacion + "\n Sexo: " + vcobro.Conductor.Sexo + "\n Afiliacion: " + vcobro.Conductor.Afiliado;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void NombreBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void PlacaEnter(object sender, EventArgs e)
        {
            if (PlacaBox.Text == "Placa Carro")
            {
                PlacaBox.Clear();
            }
        }

        private void PlacaLeave(object sender, EventArgs e)
        {
            if (PlacaBox.Text == "")
            {
                PlacaBox.Text = "Placa Carro";
            }
        }

        private void MarcaEnter(object sender, EventArgs e)
        {
            if (MarcaBox.Text == "Marca Carro")
            {
                MarcaBox.Clear();
            }
        }

        private void MarcaLeave(object sender, EventArgs e)
        {
            if (MarcaBox.Text == "")
            {
                MarcaBox.Text = "Marca Carro";
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            
             if (textBox4.Text == "Buscar vehiculo por placa o identificación del cliente")
            {
                textBox4.Clear();
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                textBox4.Text = "Buscar vehiculo por placa o identificación del cliente";
            }
        }

        private void BuscarBtn_Click(object sender, EventArgs e)
        {
            foreach (Vehicle i in listavehiculos)
            {
                if (i.Placa == textBox4.Text | i.Conductor.Identificacion == textBox4.Text)
                {
                    InfoBox.Text = "Información del Carro: \n Placa: " + i.Placa + "\n Tipo: " + i.Tipo + "\n Marca: " + i.Marca + "\nInformacion del cliente: \n Nombre: " + i.Conductor.Nombre + "\n Identificacion: " + i.Conductor.Identificacion + "\n Sexo: " + i.Conductor.Sexo + "\n Afiliacion: " + i.Conductor.Afiliado;
                    vcobro = i;
                    break;
                }
                else
                {
                    InfoBox.Text = "No hay ningún carro que se halla ingresado con estos datos";
                }
            }
            var tiempopasado = Math.Ceiling((DateTime.Now - vcobro.timestamp).TotalSeconds / 60);
            int totalpay = 50 * Convert.ToInt32(tiempopasado);
            if (vcobro.Tipo != "Particular")
            {
                totalpay = totalpay + Convert.ToInt32(totalpay * 0.2);
            }
            if (vcobro.Conductor.Afiliado == true)
            {
                totalpay = totalpay - Convert.ToInt32(totalpay * 0.1);
            }
            totalc = totalpay;
            if (InfoBox.Text == "No hay ningún carro que se halla ingresado con estos datos")
            {
                MessageBox.Show("!Asegurate de haber ingresado bien los datos del cliente o la placa del carro!");
            }
            else
            {
                MessageBox.Show("Debido a que estuviste " + tiempopasado.ToString() + " minutos en el parqueadero, vas a tener que pagar $" + totalpay.ToString() + " pesos");
            }
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
