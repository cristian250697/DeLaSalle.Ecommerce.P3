using DeLaSalle.Ecommerce.Core.Entities;

namespace DeLaSalle.Ecommerce.Api.Services.Interfaces;

public interface IBrandService
{
    Task<bool> BrandExist(int id);
    Task<Brand> SaveAsync(Brand brand);
    Task<Brand> UpdateAsync(Brand brand);
    Task<List<Brand>> GetAllAsync();
    Task<bool> DeleteAsync(int id);
    Task<Brand> GetById(int id);
}