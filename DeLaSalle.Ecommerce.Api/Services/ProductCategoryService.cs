using DeLaSalle.Ecommerce.Api.Repositories.Interfaces;
using DeLaSalle.Ecommerce.Api.Services.Interfaces;
using DeLaSalle.Ecommerce.Core.Dto;
using DeLaSalle.Ecommerce.Core.Entities;

namespace DeLaSalle.Ecommerce.Api.Services;

public class ProductCategoryService : IProductCategoryService
{
    
    // Repository injection
    private readonly IProductCategoryRepository _productCategoryRepository;

    public ProductCategoryService(IProductCategoryRepository productCategoryRepository)
    {
        _productCategoryRepository = productCategoryRepository;
    }
    
    public async Task<bool> ProductCategoryExist(int id)
    {
        var category = await _productCategoryRepository.GetById(id);
        return (category != null);
    }

    public async Task<ProductCategoryDto> SaveAsync(ProductCategoryDto categoryDto)
    {
        var category = new ProductCategory
        {
            Name = categoryDto.Name,
            Description = categoryDto.Description,
            CreatedBy = "",
            CreatedDate = DateTime.Now,
            UpdatedBy = "",
            UpdatedDate = DateTime.Now
        };

        category = await _productCategoryRepository.SaveAsync(category);

        return new ProductCategoryDto(category);
    }

    public async Task<ProductCategoryDto> UpdateAsync(ProductCategoryDto categoryDto)
    {
        var category = await _productCategoryRepository.GetById(categoryDto.Id);

        if (category == null)
            throw new Exception("Product Category not found");
        
        category.Name = categoryDto.Name;
        category.Description = categoryDto.Description;
        category.UpdatedBy = "";
        category.UpdatedDate = DateTime.Now;
        
        await _productCategoryRepository.UpdateAsync(category);

        return categoryDto;
    }

    public async Task<List<ProductCategoryDto>> GetAllAsync()
    {
        var categories = await _productCategoryRepository.GetAllAsync();
        var categoriesDto = categories.Select(c => new ProductCategoryDto(c)).ToList();

        return categoriesDto;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var category = await _productCategoryRepository.GetById(id);
        
        if(category == null)
            throw new Exception("Product Category not found");
        
        return await _productCategoryRepository.DeleteAsync(id);
    }

    public async Task<ProductCategoryDto> GetById(int id)
    {
        var category = await _productCategoryRepository.GetById(id);
        
        if(category == null)
           throw new Exception("Product Category not found");
           
        var categoryDto = new ProductCategoryDto(category);
        
        return categoryDto;
    }
}