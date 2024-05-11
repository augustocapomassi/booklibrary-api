using Microsoft.AspNetCore.OData.Query;

namespace BookLibrary.Services;

public interface IBooksFinderService
{
    Task<IEnumerable<T>> GetBookEntriesWithODataAsync<T>(
      ODataQueryOptions<T> options,
      CancellationToken cancellationToken = default) where T : class;
}

