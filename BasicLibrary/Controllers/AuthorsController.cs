using BasicLibrary.Entities;
using BasicLibrary.Models;
using BasicLibrary.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BasicLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly ILibraryRepository _library;

        public AuthorsController(ILibraryRepository libraryRepository)
        {
            _library = libraryRepository ?? throw new ArgumentNullException(nameof(libraryRepository));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorDto>>> GetAuthors()
        {
            var authors = await _library.GetAllAuthors();

            var authorDtos = new List<AuthorDto>();

            foreach (var author in authors)
            {
                authorDtos.Add(new AuthorDto()
                {
                    Id = author.Id,
                    FisrtName = author.FirstName,
                    LastName = author.LastName,
                    YearOfBirth = author.YearOfBirth,
                    Books = new List<BookDto>()
                });
            }

            return Ok(authorDtos);
        }

        [HttpGet("{id}", Name = "GetAuthorById")]
        public async Task<ActionResult<AuthorDto>> GetAuthorById(Guid id)
        {
            var author = await _library.GetAuthorById(id);

            if (author == null)
            {
                return NotFound();
            }

            AuthorDto authorToReturn = new AuthorDto()
            {
                Id = author.Id,
                FisrtName = author.FirstName,
                LastName = author.LastName,
                YearOfBirth = author.YearOfBirth,
            };

            return Ok(authorToReturn);
        }

        [HttpPost]
        public ActionResult CreateAuthor(AuthorForCreationDto author)
        {
            var authorEntity = new Author(author.FisrtName, author.LastName, author.YearOfBirth);

            _library.CreateAuthor(authorEntity);
            _library.SaveChangesAsync();

            return CreatedAtRoute("GetAuthorById", new { Id = authorEntity.Id }, authorEntity);
        }
    }
}
