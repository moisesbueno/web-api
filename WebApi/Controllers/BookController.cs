using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/book")]
    public class BookController : ControllerBase
    {

        private readonly ILogger<BookController> _logger;
        private readonly SalesContext _salesContext;

        public BookController(ILogger<BookController> logger, SalesContext salesContext)
        {
            _logger = logger;
            _salesContext = salesContext;
        }

        [HttpPost("")]
        public async Task<IActionResult> Create([FromBody] BookModelIn bookModelIn)
        {
            var bookModel = new Book()
            {
                Id = Guid.NewGuid(),
                Name = bookModelIn.BookName
            };
            await _salesContext.Books.AddAsync(bookModel);

            await _salesContext.SaveChangesAsync();

            return Ok(bookModel);
        }


        [HttpPut("{bookId}")]
        public async Task<IActionResult> Update([FromRoute] Guid bookId, [FromBody] BookModelIn bookModelIn)
        {
            var book = await _salesContext.Books.FirstAsync(b => b.Id == bookId);
            book.Name = bookModelIn.BookName;

            await _salesContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{bookId}")]
        public async Task<IActionResult> Remove([FromRoute] Guid bookId)
        {
            var book = await _salesContext.Books.FirstAsync(b => b.Id == bookId);

            _salesContext.Books.Remove(book);
            await _salesContext.SaveChangesAsync();

            return Ok();
        }

        [HttpGet("")]
        public async Task<IActionResult> Get()
        {
            var res = await _salesContext.Books.AsNoTracking().ToListAsync();

            return Ok(res);
        }


    }
}
