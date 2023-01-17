using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsEFEscuela.Models;

namespace WindowsEFEscuela.Data
{
    public class DBEscuelaEFContext : DbContext
    {
        public DBEscuelaEFContext():base("KeyDB") { }

        public DbSet<Alumno> Alumnos { get; set; }

        public DbSet<Profesor> Profesores { get; set; }

        public DbSet<Aula> Aulas { get; set; }

        public DbSet<Materia> Materias { get; set; }
    }
}
