using BrandService.Domain;

namespace BrandService.Application;

public interface IBrandRepository
{
    IEnumerable<Brand> GetAll();
    Brand? GetById(int id);
    void Add(Brand brand);
}
