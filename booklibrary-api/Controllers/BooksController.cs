using BookLibrary.Api.Contracts;
using BookLibrary.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace BookLibrary.Api.Controllers;

[ApiController]
public class BooksController : ControllerBase
{
    private readonly IBooksFinderService booksFinderService;

    public BooksController(IBooksFinderService booksFinderService)
    {
        this.booksFinderService = booksFinderService;
    }

    /// <summary>
    /// Returns books data based on the provided Odata query filtered.
    /// </summary>
    /// <param name="options">The resolved OData query params from the request.</param>
    /// <returns>Result books data for provided OData query params filtered. </returns>
    [HttpGet("books")]
    [ApiExplorerSettings(IgnoreApi = true)]
    [ProducesResponseType(typeof(BookDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> GetBooksFiltered(ODataQueryOptions<BookDto> options, CancellationToken cancellationToken)
    {
        IEnumerable<BookDto> books = await this.booksFinderService.GetBookEntriesWithODataAsync(
            options,
            cancellationToken);

        return books.Any() ? this.Ok(books) : this.NoContent();
    }
}