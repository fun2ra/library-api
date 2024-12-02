namespace BasicLibrary.Models
{
    public class BookDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string Genre { get; set; } = string.Empty;
        public int PublicationYear { get; set; }

    }
}
