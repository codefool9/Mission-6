using System.ComponentModel.DataAnnotations;

namespace Mission__6.Models
{
    public class Movie
    {
        // Primary Key - Required for the SQLite database to track records
        [Key]
        [Required]
        public int MovieId { get; set; }

        [Required(ErrorMessage = "Category is required")]
        public string Category { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Year is required")]
        [Range(1888, 2100, ErrorMessage = "Please enter a valid year")]
        public int Year { get; set; }

        [Required(ErrorMessage = "Director is required")]
        public string Director { get; set; }

        [Required(ErrorMessage = "Rating is required")]
        public string Rating { get; set; }
        public bool? Edited { get; set; } // Yes/No option

        public string? LentTo { get; set; }

        [MaxLength(25, ErrorMessage = "Notes must be 25 characters or less")] // Limit to 25 chars
        public string? Notes { get; set; }
    }
}