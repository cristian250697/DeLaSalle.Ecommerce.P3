using DeLaSalle.Ecommerce.Api.Repositories.Interfaces;
using DeLaSalle.Ecommerce.Api.Services.Interfaces;
using DeLaSalle.Ecommerce.Core.Entities;

namespace DeLaSalle.Ecommerce.Api.Services;

public class BrandService : IBrandService
{

    private readonly IBrandRepository _brandRepository;

    public BrandService(IBrandRepository repository)
    {
        _brandRepository = repository;
    }
    
    public async Task<bool> BrandExist(int id)
    {
        var brand = await _brandRepository.GetById(id);
        return (brand != null);
    }
        
    public async Task<Brand> SaveAsync(Brand brand)
    {
        var newBrand = new Brand
        {
            Name = brand.Name,
            Description = brand.Description,
            CreatedBy = brand.CreatedBy,
            CreatedDate = DateTime.Now,
            UpdatedBy = brand.UpdatedBy,
            UpdatedDate = DateTime.Now
        };

        newBrand = await _brandRepository.SaveAsync(newBrand);

        return newBrand;
    }

    public async Task<Brand> UpdateAsync(Brand brand)
    {
        var brandDB = await _brandRepository.GetById(brand.Id);

        if (brandDB == null)
            throw new Exception("Brand not found");
        
        brandDB.Name = brand.Name;
        brandDB.Description = brand.Description;
        brandDB.UpdatedBy = brand.UpdatedBy;
        brandDB.UpdatedDate = DateTime.Now;
        
        await _brandRepository.UpdateAsync(brandDB);

        return brandDB;
    }

    public async Task<List<Brand>> GetAllAsync()
    {
        return await _brandRepository.GetAllAsync();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var brand = await _brandRepository.GetById(id);
        
        if(brand == null)
            throw new Exception("Brand not found");
        
        return await _brandRepository.DeleteAsync(id);
    }

    public async Task<Brand> GetById(int id)
    {
        var brand = await _brandRepository.GetById(id);
        
        if(brand == null)
            throw new Exception("Brand not found");
           
        return brand;
    }
}