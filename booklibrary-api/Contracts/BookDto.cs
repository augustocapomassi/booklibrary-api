namespace BookLibrary.Api.Contracts;

public record BookDto(
    int BookId,
    string Title,
    string FirstName,
    string LastName,
    int TotalCopies,
    int CopiesInUse,
    string Type,
    string Isbn,
    string Category);
