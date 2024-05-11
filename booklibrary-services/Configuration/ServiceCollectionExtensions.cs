using BookLibrary.Repository.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookLibrary.Services.Configuration;

public static class ServiceCollectionExtensions
{
    public static void AddServices(
        this IServiceCollection serviceCollection,
        IConfiguration configuration)
    {
        string? connectionString = configuration.GetConnectionString("LibraryContext");
        if (!string.IsNullOrEmpty(connectionString))
        {
            serviceCollection.AddDbContext<LibraryContext>(options => options.UseSqlServer(connectionString).UseSnakeCaseNamingConvention());
        }

        serviceCollection.AddTransient<IBooksFinderService, BooksFinderService>();
    }
}
