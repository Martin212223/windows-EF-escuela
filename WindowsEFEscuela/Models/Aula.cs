using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsEFEscuela.Models
{
    [Table("Aulas")]
    public class Aula
    {
        public int AulaId { get; set; }

        [Required]
        public int Capacidad { get; set; }

        [Column(TypeName = "char")]
        [StringLength(1)]
        [Required]
        public string Codigo { get; set; }
    }
}
