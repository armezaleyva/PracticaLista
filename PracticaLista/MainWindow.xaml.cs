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

            Materia historia = new Materia("HST123", "Historia");
            Materia matematicas = new Materia("MAT456", "Matemáticas");
            Materia civismo = new Materia("CIV741", "Civismo");
            Materia espanol = new Materia("ESP963", "Español");
            Materia artistica = new Materia("ART852", "Artística");

            alumnos.Add(new Alumno("Juan López", "153697", "Lic. en Psicología"));
            alumnos.Add(new Alumno("Pedro Pérez", "812032", "Lic. en Derecho"));
            alumnos.Add(new Alumno("María García", "147941", "Ing. Civil"));
            alumnos.Add(new Alumno("Erick Recors", "163922", "Ing. Biomédica"));

            alumnos[0].Materias.Add(espanol);
            alumnos[0].Materias.Add(artistica);

            alumnos[1].Materias.Add(civismo);
            alumnos[1].Materias.Add(matematicas);

            alumnos[2].Materias.Add(historia);
            alumnos[2].Materias.Add(espanol);

            alumnos[3].Materias.Add(civismo);
            alumnos[3].Materias.Add(artistica);

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

            lstMaterias.Items.Clear();
            foreach (Materia materia in alumnos[indexSeleccionado].Materias) {
                lstMaterias.Items.Add(new ListBoxItem() {
                        Content = materia.Nombre
                    });
            }
        }

        private void lstMaterias_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (lstMaterias.Items.IsEmpty) {

            }
            else {
                var alumnoSeleccionado = lstAlumnos.SelectedIndex;
                var indexSeleccionado = lstMaterias.SelectedIndex;
                var materiaSeleccionada = alumnos[alumnoSeleccionado].Materias[indexSeleccionado];
                lblClaveMateria.Text = materiaSeleccionada.Clave;
                lblNombreMateria.Text = materiaSeleccionada.Nombre;
            }
        }
    }
}
