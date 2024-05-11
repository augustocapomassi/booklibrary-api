using System.Text.Json.Serialization;
using Hellang.Middleware.ProblemDetails;
using Swashbuckle.AspNetCore.Filters;
using BookLibrary.Api.Configuration;
using BookLibrary.Api;
using BookLibrary.Services.Configuration;
using Microsoft.AspNetCore.OData;
using BookLibrary.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.SetBasePath(Directory.GetCurrentDirectory());
builder.Configuration.AddJsonFile("appsettings.json", optional: false);
builder.Configuration.AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true);
builder.Configuration.AddEnvironmentVariables();

var logger = new LoggerFactory().CreateLogger<Program>();


builder.Services.AddAutoMapper(c =>
{
    c.AddProfile<AutomapperProfile>();
});

builder.Services.AddServices(builder.Configuration);
builder.Services.AddProblemDetails(problemDetailsOptions =>
    problemDetailsOptions.IncludeExceptionDetails = (context, _) =>
    {
        var hostEnvironment = context.RequestServices.GetRequiredService<IHostEnvironment>();
        return hostEnvironment.IsDevelopment();
    });

builder.Services.AddSwagger(builder.Configuration);
builder.Services.AddSwaggerExamplesFromAssemblies(typeof(ApiConstants).Assembly);
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
}).AddOData(options => options.EnableQueryFeatures());

var app = builder.Build();

app.UseProblemDetails();
app.UsePathBaseFromConfiguration(app.Configuration);
app.UseSwagger(app.Configuration);
app.UseRouting();

app.MapControllers();

app.Services.RunMigrations();

try
{
    app.Run();
}
catch (Exception ex)
{
    Console.WriteLine(ex);
}

namespace BookLibrary.Api
{
    public class Program;
}
