using DealerService.Domain;

namespace DealerService.Application;

public interface IDealerRepository
{
    IEnumerable<Dealer> GetAll();
    Dealer? GetById(int id);
    void Add(Dealer dealer);
}
