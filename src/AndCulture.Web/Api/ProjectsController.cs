using AndCulture.Core.ProjectAggregate;
using AndCulture.Core.ProjectAggregate.Specifications;
using AndCulture.SharedKernel.Interfaces;
using AndCulture.Web.ApiModels;
using Microsoft.AspNetCore.Mvc;

namespace AndCulture.Web.Api;

/// <summary>
/// A sample API Controller. Consider using API Endpoints (see Endpoints folder) for a more SOLID approach to building APIs
/// https://github.com/ardalis/ApiEndpoints
/// </summary>
public class ProjectsController : BaseApiController
{
  private readonly IRepository<Project> _repository;

  public ProjectsController(IRepository<Project> repository)
  {
    _repository = repository;
  }

  // GET: api/Projects
  [HttpGet]
  public async Task<IActionResult> List()
  {
    var projectDTOs = (await _repository.ListAsync())
        .Select(project => new ProjectDTO
        { 
          Id = project.Id,
          Name = project.Name,
          Address2 = project.Address2,
          Address3 = project.Address3,
          BreweryType = project.BreweryType,
          City = project.City,
          Country = project.Country,
          CountyProvince = project.CountyProvince,
          Latitude = project.Latitude,
          Longitude = project.Longitude,
          Phone = project.Phone,
          PostalCode = project.PostalCode,
          State = project.State,
          Street = project.Street,
          WebsiteUrl = project.WebsiteUrl,
        })
        .ToList();

    return Ok(projectDTOs);
  }

  // GET: api/Projects
  [Route("GetById", Name = "GetById")]
  [HttpGet]
  public async Task<IActionResult> GetById(string productId)
  {
    var projectSpec = new ProjectByIdWithItemsSpec(productId);
    var project = await _repository.GetBySpecAsync(projectSpec);
    if (project == null)
    {
      return NotFound();
    }

    var result = new ProjectDTO
    {
      Id = project.Id,
      Name = project.Name,
      Address2 = project.Address2,
      Address3 = project.Address3,
      BreweryType = project.BreweryType,
      City = project.City,
      Country = project.Country,
      CountyProvince = project.CountyProvince,
      Latitude = project.Latitude,
      Longitude = project.Longitude,
      Phone = project.Phone,
      PostalCode = project.PostalCode,
      State = project.State,
      Street = project.Street,
      WebsiteUrl = project.WebsiteUrl,

    };

    return Ok(result);
  }


}
