using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsEFEscuela.Dac;
using WindowsEFEscuela.Data;
using WindowsEFEscuela.Models;

namespace WindowsEFEscuela
{
    public partial class frmAlumnos : Form
    {
        public frmAlumnos()
        {
            InitializeComponent();
        }

        private void frmAlumnos_Load(object sender, EventArgs e)
        {

            DBEscuelaEFContext context = new DBEscuelaEFContext();

            foreach (Profesor profesor in context.Profesores)
            {
                comboProfesores.Items.Add(profesor.Nombre + " Id: " + profesor.ProfesorId);
            }

            

            //comboProfesores.Items.Add(profesor);
            AlumnosTodos();
        }

        private void AlumnosTodos()
        {
            gridAlumnos.DataSource = AbmAlumno.TraerTodos();
        }

        private void LimpiarTextBox()
        {
            txtId.Text = string.Empty;
            txtNombre.Text = string.Empty;  
            txtApellido.Text= string.Empty;
            fechaNacimiento.Text = string.Empty;
            comboProfesores.SelectedIndex = 0;
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            //int idProf = obtenerIdProf();

            Alumno alumno = new Alumno()
            {
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                FechaNacimiento = Convert.ToDateTime(fechaNacimiento.Value.ToString("d")),
                ProfesorId = obtenerIdProf()
            };

            int filasAfectadas = AbmAlumno.InsertarAlumno(alumno);

            if (filasAfectadas > 0)
            {
                AlumnosTodos();
                LimpiarTextBox();
            }

        }

        private int obtenerIdProf()
        {
            string[] profTxtComboBox = new string[3];

            profTxtComboBox = comboProfesores.Text.Split(' ');

            int idProf = Convert.ToInt32(profTxtComboBox[2]);

            return idProf;
        }

        private void gridAlumnos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Alumno alumno = new Alumno()
            {
                IdAlumno = Convert.ToInt32(txtId.Text),
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                FechaNacimiento = Convert.ToDateTime(fechaNacimiento.Value.ToString("d"))
            };

            AbmAlumno.EliminarAlumno(alumno);

            AlumnosTodos();
            LimpiarTextBox();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Alumno alumno = new Alumno()
            {
                IdAlumno = Convert.ToInt32(txtId.Text),
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                FechaNacimiento = Convert.ToDateTime(fechaNacimiento.Value.ToString("d")),
                ProfesorId = obtenerIdProf()
            };

            AbmAlumno.ModificarAlumno(alumno);

            AlumnosTodos();
            LimpiarTextBox();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            List<Alumno> alumnos = new List<Alumno>();

            alumnos.Add(AbmAlumno.TraerUnoPorId(Convert.ToInt32(txtId.Text)));

            gridAlumnos.DataSource = alumnos;

            LimpiarTextBox();

        }

        private void btnTodos_Click(object sender, EventArgs e)
        {
            AlumnosTodos();
            LimpiarTextBox();
        }
    }
}
