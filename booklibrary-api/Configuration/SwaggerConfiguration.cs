using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

namespace BookLibrary.Api.Configuration;

internal static class SwaggerConfiguration
{
    public static void AddSwagger(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc(
                ApiConstants.SwaggerVersion,
                new OpenApiInfo
                {
                    Title = ApiConstants.SwaggerTitle,
                    Version = ApiConstants.SwaggerVersion,
                });

            var directory = new DirectoryInfo(AppContext.BaseDirectory);
            foreach (var fileInfo in directory.EnumerateFiles(ApiConstants.SwaggerJsonFileExt))
            {
                c.IncludeXmlComments(fileInfo.FullName);
            }

            c.ExampleFilters();
        });
    }
}