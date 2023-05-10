using System.ComponentModel.DataAnnotations;

namespace Entity.Data
{
    public class Session : BaseEntity
    {
        public int Id { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string Study_Year { get; set; }
        [Required]
        public string Education_Level { get; set; }
        [Required]
        public string Url { get; set; }
        [Required]
        public Teacher Teacher { get; set; }
    }
}