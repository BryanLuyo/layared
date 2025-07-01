using DealerService.Domain;

namespace DealerService.Application;

public class DealerService
{
    private readonly IDealerRepository _repository;

    public DealerService(IDealerRepository repository)
    {
        _repository = repository;
    }

    public IEnumerable<Dealer> GetAll() => _repository.GetAll();

    public Dealer? GetById(int id) => _repository.GetById(id);

    public Dealer Add(string name, string location)
    {
        var dealer = new Dealer { Id = _repository.GetAll().Count() + 1, Name = name, Location = location };
        _repository.Add(dealer);
        return dealer;
    }
}
