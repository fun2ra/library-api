namespace BasicLibrary.Models
{
    public class AuthorDto
    {
        public Guid Id { get; set; }
        public string FisrtName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int YearOfBirth { get; set; }
        public ICollection<BookDto>? Books { get; set; } = new List<BookDto>();
    }
}
