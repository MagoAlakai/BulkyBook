namespace BulkyBook1.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Display(Name = "Display Order")]
        [Range(1, 9, ErrorMessage = "Display Order must be within 1 and 9!!")]
        public int DisplayOrder { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.UtcNow;
    }
}


