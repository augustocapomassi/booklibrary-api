using AutoMapper;
using AutoMapper.AspNet.OData;
using BookLibrary.Repository.Context;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.EntityFrameworkCore;

namespace BookLibrary.Services;

internal class BooksFinderService : IBooksFinderService
{
    private readonly LibraryContext libraryContext;
    private readonly IMapper mapper;

    public BooksFinderService(
        LibraryContext libraryContext,
        IMapper mapper)
    {
        this.libraryContext = libraryContext;
        this.mapper = mapper;
        
    }

    public async Task<IEnumerable<T>> GetBookEntriesWithODataAsync<T>(
      ODataQueryOptions<T> options,
      CancellationToken cancellationToken = default)
      where T : class
    {
        QuerySettings querySettings = new()
        {
            AsyncSettings = new AsyncSettings
            {
                CancellationToken = cancellationToken,
            },
        };

        return await this.libraryContext.Books
            .AsNoTracking()
            .GetQueryAsync(this.mapper, options, querySettings);
    }
}