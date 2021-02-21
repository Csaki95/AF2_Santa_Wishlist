using System;
using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class Presents
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Colour { get; set; }
        [Required]
        public uint Weight { get; set; }
        [Required]
        [Range(1, 10)]
        public int Priority { get; set; }
    }
}
