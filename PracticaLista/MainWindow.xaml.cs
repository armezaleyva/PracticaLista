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

namespace PracticaLista {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        List<Alumno> alumnos = new List<Alumno>();

        public MainWindow() {
            InitializeComponent();
            alumnos.Add(new Alumno("Juan López", "153697", "Lic. en Psicología"));
            alumnos.Add(new Alumno("Pedro Pérez", "812032", "Lic. en Derecho"));
            alumnos.Add(new Alumno("María García", "147941", "Ing. Civil"));
            alumnos.Add(new Alumno("Ana Valenzuela", "163922", "Lic. en Finanzas"));

            foreach (Alumno alumno in alumnos) {
                lstAlumnos.Items.Add(new ListBoxItem() {
                    Content = alumno.Nombre
                });
            }
        }

        private void lstAlumnos_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            var indexSeleccionado = lstAlumnos.SelectedIndex;
            lblNombre.Text = alumnos[indexSeleccionado].Nombre;
            lblMatricula.Text = alumnos[indexSeleccionado].Matricula;
            lblCarrera.Text = alumnos[indexSeleccionado].Carrera;
        }
    }
}
