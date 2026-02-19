using System.ComponentModel.DataAnnotations;

namespace Mission_6.Models
{
    public class Category
    {
        [Key]
        [Required]
        public int CategoryId { get; internal set; }
        public string CategoryName { get; internal set; }
    }
}