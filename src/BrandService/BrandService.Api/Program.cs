using BrandService.Application;
using BrandService.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// DI configuration
builder.Services.AddSingleton<IBrandRepository, InMemoryBrandRepository>();
builder.Services.AddSingleton<BrandService.Application.BrandService>();

var app = builder.Build();

app.MapGet("/brands", (BrandService.Application.BrandService service) => service.GetAll());
app.MapGet("/brands/{id:int}", (int id, BrandService.Application.BrandService service) =>
{
    var brand = service.GetById(id);
    return brand is not null ? Results.Ok(brand) : Results.NotFound();
});
app.MapPost("/brands", (BrandDto dto, BrandService.Application.BrandService service) =>
{
    var brand = service.Add(dto.Name);
    return Results.Created($"/brands/{brand.Id}", brand);
});

app.Run();

record BrandDto(string Name);
