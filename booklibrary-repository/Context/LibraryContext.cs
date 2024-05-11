using BookLibrary.Repository.DBEntities;
using Microsoft.EntityFrameworkCore;

namespace BookLibrary.Repository.Context;

public sealed class LibraryContext : DbContext
{
    public LibraryContext(DbContextOptions<LibraryContext> options)
        : base(options)
    {
    }

    public DbSet<Book> Books => Set<Book>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Book>().HasKey(x => x.BookId);
        modelBuilder.Entity<Book>().HasData(GetSeedData());
    }

    private static IReadOnlyCollection<Book> GetSeedData()
    {
        return
        [
            new Book
            {
                BookId = 1,
                Title = "Pride and Prejudice",
                FirstName = "Jane",
                LastName = "Austen",
                TotalCopies = 100,
                CopiesInUse = 80,
                Category = "Hardcover",
                Isbn = "1234567891",
                Type = "Fiction"
            },
            new Book
            {
                BookId = 2,
                Title = "To Kill a Mockingbird",
                FirstName = "Harper",
                LastName = "Lee",
                TotalCopies = 75,
                CopiesInUse = 65,
                Category = "Paperback",
                Isbn = "1234567892",
                Type = "Fiction"
            },
            new Book
            {
                BookId = 3,
                Title = "The Catcher in the Rye",
                FirstName = "J.D.",
                LastName = "Salinger",
                TotalCopies = 50,
                CopiesInUse = 45,
                Category = "Hardcover",
                Isbn = "1234567893",
                Type = "Fiction"
            },
            new Book
            {
                BookId = 4,
                Title = "The Great Gatsby",
                FirstName = "F. Scott",
                LastName = "Fitzgerald",
                TotalCopies = 50,
                CopiesInUse = 22,
                Category = "Hardcover",
                Isbn = "1234567894",
                Type = "'Non-Fiction"
            },
            new Book
            {
                BookId = 5,
                Title = "The Alchemist",
                FirstName = "Paulo",
                LastName = "Coelho",
                TotalCopies = 50,
                CopiesInUse = 35,
                Category = "Hardcover",
                Isbn = "1234567895",
                Type = "'Biography"
            },
            new Book
            {
                BookId = 6,
                Title = "The Book Thief",
                FirstName = "Markus",
                LastName = "Zusak",
                TotalCopies = 75,
                CopiesInUse = 11,
                Category = "Hardcover",
                Isbn = "1234567896",
                Type = "'Mystery"
            }
        ];
    }
}