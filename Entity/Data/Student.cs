using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Data
{
    public class Student : BaseEntity
    {
        [Key]
        public int stuId { get; set; }
        [Required]
        public string stuName { get; set; }
        [Required]
        public string Study_Year { get; set; }
        [Required]
        public string Phone { get;set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public Session Session { get; set; }
        [Required]
        public Parent Parent { get; set; }

    }
}
