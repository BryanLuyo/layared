using BrandService.Domain;
using BrandService.Application;

namespace BrandService.Infrastructure;

public class InMemoryBrandRepository : IBrandRepository
{
    private readonly List<Brand> _brands = new()
    {
        new Brand { Id = 1, Name = "Toyota" },
        new Brand { Id = 2, Name = "Ford" }
    };

    public IEnumerable<Brand> GetAll() => _brands;

    public Brand? GetById(int id) => _brands.FirstOrDefault(b => b.Id == id);

    public void Add(Brand brand) => _brands.Add(brand);
}
