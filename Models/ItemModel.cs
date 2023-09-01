using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace ASP.NET_CORE_Course.Models
{

    public class ItemModel
    {
        [Key]
        public int Id { get; set; }
        [Required, AllowNull]
        public string SKU { get; set; }
        [Required, AllowNull]
        public string Name { get; set; }
        [Required, AllowNull]
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
