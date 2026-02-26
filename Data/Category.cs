using System.ComponentModel.DataAnnotations;

namespace MiniProject01.Data
{
    public class Category
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter category name")]
        public string Name { get; set; }

        public string? ImageUrl { get; set; }
    }
}