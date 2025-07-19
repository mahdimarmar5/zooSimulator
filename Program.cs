using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddTransient<IAnimalRepo, AnimalRepo>();
builder.Services.AddTransient<IZooService, ZooService>();

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer("Server=MSSQLLocalDB; Database= Animals;TrustServerCertificate=True"));



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseMiddleware<LoggingMiddleware>();

var zooAPI = app.MapGroup("/animals");

app.MapGet("/", async (IZooService zooService) => await zooService.GetAllAnimalsFromZooAsync());
app.MapPost("/{name}/add", (string name, IZooService zooService) =>
{
    Animal? newAnimal = name.ToLower() switch
    {
        "lion" => new Lion(MovementType.Walking),
        "tiger" => new Tiger(MovementType.Walking),
        "eagle" => new Eagle(MovementType.Flying),
        _ => null
    };

    if (newAnimal is not null)
    {
        var wasAdded = zooService.AddAnimalToZoo(newAnimal);

        if (wasAdded)
        {
            return Results.Created($"/animals/{name}/add", newAnimal);
        }

        return Results.BadRequest("Animal already in zoo!");
    }

    return Results.BadRequest("Animal does not need to be saved");
});
app.Run();


[JsonSerializable(typeof(List<Animal>))]
[JsonSerializable(typeof(Animal))]

internal partial class AppJsonSerializerContext : JsonSerializerContext{

}

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
