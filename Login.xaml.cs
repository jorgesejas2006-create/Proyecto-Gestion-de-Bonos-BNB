using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Text.RegularExpressions;
using System.IO;

namespace ProyectoProgra2._0
{
    /// <summary>
    /// Lógica de interacción para Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        private readonly string rutaYarchivo = "c:\\datosUsuario\\datosUsr.txt";
        public Login()
        {
            InitializeComponent();
        }
        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            string email = txtgmail.Text.Trim();
            string pass = pwdpas.Password.Trim();

            if (email == "" || pass == "")
            {
                MessageBox.Show("Debe ingresar E-mail y Contraseña");
                return;
            }

            if (!File.Exists(rutaYarchivo))
            {
                MessageBox.Show("No existe el archivo de usuarios. Regístrese primero.");
                return;
            }

            string[] lineas = File.ReadAllLines(rutaYarchivo);
            bool loginCorrecto = false;

            foreach (string linea in lineas)
            {
                string[] datos = linea.Split(',');

                if (datos.Length >= 3)
                {
                    string emailGuardado = datos[1];
                    string passGuardada = datos[datos.Length - 1];

                    if (emailGuardado == email && passGuardada == pass)
                    {
                        loginCorrecto = true;
                        break;
                    }
                }
            }
            if (loginCorrecto)
            {
                MainWindow win = new MainWindow();
                win.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Correo o contraseña incorrectos");
            }
        }

        private void btnLinpiar_Click(object sender, RoutedEventArgs e)
        {
            txtgmail.Clear();
            pwdpas.Clear();
        }

        private void btnRegistro_Click(object sender, RoutedEventArgs e)
        { 
            Sing_up win = new Sing_up();
            win.Show();
            this.Close();
        }
    }
}
