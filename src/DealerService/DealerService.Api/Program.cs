using DealerService.Application;
using DealerService.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IDealerRepository, InMemoryDealerRepository>();
builder.Services.AddSingleton<DealerService.Application.DealerService>();

var app = builder.Build();

app.MapGet("/dealers", (DealerService.Application.DealerService service) => service.GetAll());
app.MapGet("/dealers/{id:int}", (int id, DealerService.Application.DealerService service) =>
{
    var dealer = service.GetById(id);
    return dealer is not null ? Results.Ok(dealer) : Results.NotFound();
});
app.MapPost("/dealers", (DealerDto dto, DealerService.Application.DealerService service) =>
{
    var dealer = service.Add(dto.Name, dto.Location);
    return Results.Created($"/dealers/{dealer.Id}", dealer);
});

app.Run();

record DealerDto(string Name, string Location);
