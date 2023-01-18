using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsEFEscuela.Data;
using WindowsEFEscuela.Models;

namespace WindowsEFEscuela.Dac
{
    public static class AbmAlumno
    {

        private static DBEscuelaEFContext context = new DBEscuelaEFContext();

        public static List<Alumno> TraerTodos()
        {
            return context.Alumnos.ToList();
        }

        public static Alumno TraerUnoPorId(int id)
        {
            return context.Alumnos.Find(id);
        }

        public static int InsertarAlumno(Alumno alumno)
        {
            context.Alumnos.Add(alumno);

            return context.SaveChanges();
        }

        public static int ModificarAlumno(Alumno alumno)
        {
            Alumno alumnoOrigen = context.Alumnos.Find(alumno.IdAlumno);
            
            if (alumnoOrigen != null)
            {
                //alumnoOrigen.IdAlumno = alumno.IdAlumno;
                alumnoOrigen.Nombre = alumno.Nombre;
                alumnoOrigen.Apellido = alumno.Apellido;
                alumnoOrigen.FechaNacimiento = alumno.FechaNacimiento;
                alumnoOrigen.ProfesorId = alumno.ProfesorId;

                return context.SaveChanges();
            }

            MessageBox.Show("No se encontró el alumno a modificar.");
            return 0;
            
        }

        public static int EliminarAlumno(Alumno alumno)
        {
            Alumno alumnoOrigen = context.Alumnos.Find(alumno.IdAlumno);
            if (alumnoOrigen != null)
            {
                context.Alumnos.Remove(alumnoOrigen);
                return context.SaveChanges();
            }

            return 0;
        }
    }
}
