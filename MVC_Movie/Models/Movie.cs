using System.ComponentModel.DataAnnotations;

namespace MVC_Movie.Models
{
    public class Movie
    {
        [Key] 
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [Required]
        public string? Mname { get; set; }
        [Required]
        public string? ReleaseDate { get; set; }
        [Required]
        public string? Genre { get; set; }
        public string? StarCast { get; set; }

        [ScaffoldColumn(false)]
        public int isActive { get; set; }
    }
}
