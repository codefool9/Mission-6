using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission_6.Models
{
    public class Movie
    {
        [Key]
        [Required]
        public int MovieId { get; set; }

        [Required(ErrorMessage = "Please enter a movie title")]
        public string Title { get; set; }

        [Required]
        [Range(1888, 2026, ErrorMessage = "Year must be 1888 or later")] // I made it so no movies can be added with a year before the first known film, and I set an upper limit to prevent unrealistic future years
        public int Year { get; set; }

        public string? Director { get; set; }
        public string? Rating { get; set; }

        [Required]
        public bool Edited { get; set; }

        public string? LentTo { get; set; }

        [MaxLength(25)]
        public string? Notes { get; set; }

        [Required]
        public bool CopiedToPlex { get; set; }

        [Required(ErrorMessage = "Please select a category")]
        public int CategoryId { get; set; } // The Foreign Key

        [ForeignKey("CategoryId")]
        public Category? Category { get; set; } // The Navigation Property
    }
}