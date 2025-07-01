using DealerService.Domain;
using DealerService.Application;

namespace DealerService.Infrastructure;

public class InMemoryDealerRepository : IDealerRepository
{
    private readonly List<Dealer> _dealers = new()
    {
        new Dealer { Id = 1, Name = "Dealer One", Location = "City A" },
        new Dealer { Id = 2, Name = "Dealer Two", Location = "City B" }
    };

    public IEnumerable<Dealer> GetAll() => _dealers;

    public Dealer? GetById(int id) => _dealers.FirstOrDefault(d => d.Id == id);

    public void Add(Dealer dealer) => _dealers.Add(dealer);
}
