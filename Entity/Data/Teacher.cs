using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Data
{
    public class Teacher : BaseEntity
    {
        [Key]
        public int teId { get; set; }
        [Required]
        public string teName { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Specialty { get; set; }
    }
}
