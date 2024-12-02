using BasicLibrary.Contexts;
using BasicLibrary.Entities;
using BasicLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace BasicLibrary.Services
{
    public class LibraryRepository : ILibraryRepository
    {
        private readonly LibraryDbContext _libraryDb;

        public LibraryRepository(LibraryDbContext libraryDbContext)
        {
            _libraryDb = libraryDbContext ?? throw new ArgumentNullException(nameof(libraryDbContext));
        }

        public async Task<IEnumerable<Author>> GetAllAuthors()
        {
            return await _libraryDb.Authors.OrderBy(_ => _.LastName).ToListAsync();
        }

        public async Task<Author> GetAuthorById(Guid id)
        {
            return await _libraryDb.Authors.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task CreateAuthor(Author author)
        {
            await _libraryDb.Authors.AddAsync(author);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _libraryDb.SaveChangesAsync() > 0;
        }


    }
}
