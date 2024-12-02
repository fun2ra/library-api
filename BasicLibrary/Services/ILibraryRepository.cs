using BasicLibrary.Entities;
using System.Collections;

namespace BasicLibrary.Services;
public interface ILibraryRepository
{
    Task<IEnumerable<Author>> GetAllAuthors();
    Task<Author> GetAuthorById(Guid id);
    Task CreateAuthor(Author author);
    Task<bool> SaveChangesAsync();
}
