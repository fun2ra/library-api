using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace BasicLibrary.Entities
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [MaxLength(200)]
        public string? Description { get; set; }

        public string Genre { get; set; } = string.Empty;

        public Author Author { get; set; } = null!;
        public Guid AuthorId { get; set; }

        [Required]
        public int PublicationYear { get; set; }

        public Book(string title)
        {
            Title = title;
        }
    }
}
