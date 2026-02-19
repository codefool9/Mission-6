using System.ComponentModel.DataAnnotations;

namespace Mission_6.Models
{
    public class Movie
    {
        [Key]
        [Required]
        public int MovieId { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public Category? Category { get; set; } // Navigation property for the related Category

        [Required]
        public string Title { get; set; }

        [Required]
        [Range(1888, 2100)] // No movies before 1888
        public int Year { get; set; }

        [Required]
        public string Director { get; set; }

        [Required]
        public string Rating { get; set; }

        [Required]
        public bool Edited { get; set; } // EF Core maps 0/1 in SQLite to C# bool so this bool will be an int in the database

        [MaxLength(25)]
        public string? LentTo { get; set; }

        [Required]
        public bool CopiedToPlex { get; set; } // I'm using a bool; EF Core handles the conversion

        [MaxLength(25)]
        public string? Notes { get; set; }
    }
}