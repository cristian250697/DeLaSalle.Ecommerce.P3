using DeLaSalle.Ecommerce.Api.Repositories.Interfaces;
using DeLaSalle.Ecommerce.Api.Services.Interfaces;
using DeLaSalle.Ecommerce.Core.Entities;
using DeLaSalle.Ecommerce.Core.Http;
using Microsoft.AspNetCore.Mvc;

namespace DeLaSalle.Ecommerce.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BrandController : Controller
{
    private readonly IBrandRepository _brandRepository;
    private readonly IBrandService _brandService;

    public BrandController(IBrandService service)
    {
        _brandService = service;
    }
    
    [HttpGet]
    public async Task<ActionResult<Response<List<Brand>>>> GetAll()
    {
        var response = new Response<List<Brand>>
        {
            Data = await _brandService.GetAllAsync()
        };

        return Ok(response);
    }
    
    [HttpPost]
    public async Task<ActionResult<Response<Brand>>> Post([FromBody] Brand categoryDto)
    {
        var response = new Response<Brand>
        {
            Data = await _brandService.SaveAsync(categoryDto)
        };
        
        return Created($"/api/[controler]/{response.Data.Id}",response);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<Brand>>> GetById( int id )
    {

        var response = new Response<Brand>();

        bool exist = await _brandService.BrandExist(id);

        if (!exist)
        {
            response.Errors.Add("Brand not found");
            return NotFound(response);
        }

        response.Data = await _brandService.GetById(id);
        return Ok(response);

    }

    [HttpPut]
    public async Task<ActionResult<Response<Brand>>> Update([FromBody] Brand categoryDto)
    {
        var response = new Response<Brand>();
        bool exist = await _brandService.BrandExist(categoryDto.Id);

        if (!exist)
        {
            response.Errors.Add("Brand not found");
            return NotFound(response);
        }

        response.Data = await _brandService.UpdateAsync(categoryDto);
        return Ok(response);
        
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<bool>>> Delete(int id)
    {
        var response = new Response<bool>();
        bool exist = await _brandService.BrandExist(id);

        if (!exist)
        {
            response.Errors.Add("Brand not found");
            return NotFound(response);
        }

        var result = await _brandService.DeleteAsync(id);
        response.Data = result;

        return Ok(response);
    }
    
    
}