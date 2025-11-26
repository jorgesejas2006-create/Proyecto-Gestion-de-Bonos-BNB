using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.RegularExpressions;
using System.IO;

namespace ProyectoProgra2._0
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly string rutaYarchivo = "c:\\datosUsuario\\datosUsr.txt";
        public MainWindow()
        {
            InitializeComponent();
        }
        private void btnContrasena_Click(object sender, RoutedEventArgs e)
        {
            PanelContraseña.Visibility = Visibility.Visible;
        }
        private void AceptarContraseña_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!File.Exists(rutaYarchivo))
                    return;

                string contraseñaGuardada = File.ReadAllText(rutaYarchivo).Trim();
                string contraseñaIngresada = txtPassword.Password.Trim();

                if (contraseñaGuardada == contraseñaIngresada)
                {
                    Menu ventanaMenu = new Menu();
                    ventanaMenu.Show();
                    this.Close();
                }
                else
                {
                    txtPassword.Clear();
                }
            }
            catch { }
        }
        private void cerarSesion_Click(object sender, RoutedEventArgs e)
        {
            Login ventanaLogin = new Login();
            ventanaLogin.Show();
            this.Close();
        }
    }
}
     
