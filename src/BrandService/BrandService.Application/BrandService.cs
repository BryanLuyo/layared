using BrandService.Domain;

namespace BrandService.Application;

public class BrandService
{
    private readonly IBrandRepository _repository;

    public BrandService(IBrandRepository repository)
    {
        _repository = repository;
    }

    public IEnumerable<Brand> GetAll() => _repository.GetAll();

    public Brand? GetById(int id) => _repository.GetById(id);

    public Brand Add(string name)
    {
        var brand = new Brand { Id = _repository.GetAll().Count() + 1, Name = name };
        _repository.Add(brand);
        return brand;
    }
}
