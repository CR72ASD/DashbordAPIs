using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Data
{
    public class Parent: BaseEntity
    {
        [Key]
        public int parID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string Jop { get; set;}
        [Required]
        public string Address { get; set; }
    }
}
