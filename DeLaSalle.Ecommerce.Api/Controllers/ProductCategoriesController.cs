using DeLaSalle.Ecommerce.Api.Repositories.Interfaces;
using DeLaSalle.Ecommerce.Api.Services.Interfaces;
using DeLaSalle.Ecommerce.Core.Dto;
using DeLaSalle.Ecommerce.Core.Http;
using Microsoft.AspNetCore.Mvc;

namespace DeLaSalle.Ecommerce.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductCategoriesController : ControllerBase
{
    private readonly IProductCategoryRepository _productCategoryRepository;
    private readonly IProductCategoryService _productCategoryService;
    
    public ProductCategoriesController(IProductCategoryService productCategoryService)
    {
        _productCategoryService = productCategoryService;
    }
    
    [HttpGet]
    public async Task<ActionResult<Response<List<ProductCategoryDto>>>> GetAll()
    {
        var response = new Response<List<ProductCategoryDto>>
        {
            Data = await _productCategoryService.GetAllAsync()
        };

        // response.Data = categories;
        return Ok(response);
    }
    
    [HttpPost]
    public async Task<ActionResult<Response<ProductCategoryDto>>> Post([FromBody] ProductCategoryDto categoryDto)
    {
        var response = new Response<ProductCategoryDto>
        {
            Data = await _productCategoryService.SaveAsync(categoryDto)
        };
        // var response = new Response<ProductCategoryDto>();
        // var category = new ProductCategory
        // {
        //     Name = categoryDto.Name,
        //     Description = categoryDto.Description,
        //     CreatedBy = "",
        //     CreatedDate = DateTime.Now,
        //     UpdatedBy = "",
        //     UpdatedDate = DateTime.Now
        // };
        //
        // category = await _productCategoryRepository.SaveAsync(category);
        // categoryDto.Id = category.Id;
        //
        // response.Data = categoryDto;
        //
        // // category = await _productCategoryRepository.SaveAsync(category);
        // // response.Data = category;
        
        return Created($"/api/[controler]/{response.Data.Id}",response);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<ProductCategoryDto>>> GetById( int id )
    {

        var response = new Response<ProductCategoryDto>();

        bool exist = await _productCategoryService.ProductCategoryExist(id);

        if (!exist)
        {
            response.Errors.Add("Product Category not found");
            return NotFound(response);
        }

        response.Data = await _productCategoryService.GetById(id);
        return Ok(response);
        // var response = new Response<ProductCategoryDto>();
        // var category = await _productCategoryRepository.GetById(id);
        //
        // var categoryDto = new ProductCategoryDto(category);
        // response.Data = categoryDto;
        //
        // // var response = new Response<ProductCategory>();
        // // var category = await _productCategoryRepository.GetById(id);
        // // response.Data = category;
        //
        // if (category == null)
        // {
        //     response.Errors.Add("Product Category Not Found");
        //     return NotFound(response);
        // }

        return Ok(response);
    }

    [HttpPut]
    public async Task<ActionResult<Response<ProductCategoryDto>>> Update([FromBody] ProductCategoryDto categoryDto)
    {
        var response = new Response<ProductCategoryDto>();
        bool exist = await _productCategoryService.ProductCategoryExist(categoryDto.Id);

        if (!exist)
        {
            response.Errors.Add("Product Category not found");
            return NotFound(response);
        }

        response.Data = await _productCategoryService.UpdateAsync(categoryDto);
        return Ok(response);
        
        // var category = await _productCategoryRepository.GetById(categoryDto.Id);
        //
        // if (category == null)
        // {
        //     response.Errors.Add("Product Category not found");
        //     return NotFound(response);
        // }
        //
        // category.Name = categoryDto.Name;
        // category.Description = categoryDto.Description;
        // category.UpdatedBy = "";
        // category.UpdatedDate = DateTime.Now;
        //
        // await _productCategoryRepository.UpdateAsync(category);
        // response.Data = categoryDto;
        //
        // // var result = await _productCategoryRepository.UpdateAsync(category);
        // // var response = new Response<ProductCategory>{ Data = result};
        return Ok(response);
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<bool>>> Delete(int id)
    {
        var response = new Response<bool>();
        bool exist = await _productCategoryService.ProductCategoryExist(id);

        if (!exist)
        {
            response.Errors.Add("Product Category not found");
            return NotFound(response);
        }

        var result = await _productCategoryService.DeleteAsync(id);
        response.Data = result;
        
        // var response = new Response<bool>();
        // var result = await _productCategoryRepository.DeleteAsync(id);
        // response.Data = result;
        
        return Ok(response);
    }
    
}
