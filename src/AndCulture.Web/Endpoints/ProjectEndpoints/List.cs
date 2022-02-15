using Ardalis.ApiEndpoints;
using AndCulture.Core.ProjectAggregate;
using AndCulture.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AndCulture.Web.Endpoints.ProjectEndpoints;

public class List : BaseAsyncEndpoint
    .WithoutRequest
    .WithResponse<List<Project>>
{
  private readonly IReadRepository<Project> _repository;

  public List(IReadRepository<Project> repository)
  {
    _repository = repository;
  }

  [HttpGet("/Projects")]
  [SwaggerOperation(
      Summary = "Gets a list of all Projects",
      Description = "Gets a list of all Projects",
      OperationId = "Project.List",
      Tags = new[] { "ProjectEndpoints" })
  ]
  public override async Task<ActionResult<List<Project>>> HandleAsync(CancellationToken cancellationToken)
  {
    var response = new ProjectListResponse();
    response.Projects = (await _repository.ListAsync()) // TODO: pass cancellation token
        .Select(project => new ProjectRecord(project.Id, project.Name, 
        project.BreweryType,
        project.Street,
        project.Address2,
        project.Address3,
        project.City,
        project.State,
        project.CountyProvince,
        project.PostalCode,
        project.Country,
        project.Longitude,
        project.Latitude,
        project.Phone,
        project.WebsiteUrl,
        project.UpdatedAt,
        project.CreatedAt))
        .ToList();

    return Ok(response.Projects);
  }
}
