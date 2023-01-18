using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsEFEscuela.Models
{
    [Table("Alumnos")]
    public class Alumno
    {
        [Key]
        public int IdAlumno { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(50)]
        [Required]
        public string Nombre { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(50)]
        [Required]
        public string Apellido { get; set; }

        [Column(TypeName = "date")]
        public DateTime? FechaNacimiento { get; set; }  //DateTime? es para permitir valor null, por defecto viene como not null

        
        public int ProfesorId { get; set; }

        [ForeignKey("ProfesorId")]
        public Profesor Profesor { get; set; }
    }
}
