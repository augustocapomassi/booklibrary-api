using AutoMapper;
using BookLibrary.Api.Contracts;
using BookLibrary.Repository.DBEntities;

namespace BookLibrary.Api;

public class AutomapperProfile : Profile
{
    public AutomapperProfile()
    {
        CreateMap<Book, BookDto>();
    }
}