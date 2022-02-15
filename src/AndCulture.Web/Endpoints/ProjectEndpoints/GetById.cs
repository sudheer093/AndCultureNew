using Ardalis.ApiEndpoints;
using AndCulture.Core.ProjectAggregate;
using AndCulture.Core.ProjectAggregate.Specifications;
using AndCulture.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AndCulture.Web.Endpoints.ProjectEndpoints;

public class GetById : BaseAsyncEndpoint
    .WithRequest<GetProjectByIdRequest>
    .WithResponse<GetProjectByIdResponse>
{
  private readonly IRepository<Project> _repository;

  public GetById(IRepository<Project> repository)
  {
    _repository = repository;
  }

  [HttpGet(GetProjectByIdRequest.Route)]
  [SwaggerOperation(
      Summary = "Gets a single Project",
      Description = "Gets a single Project by Id",
      OperationId = "Projects.GetById",
      Tags = new[] { "ProjectEndpoints" })
  ]
  public override async Task<ActionResult<GetProjectByIdResponse>> HandleAsync([FromRoute] GetProjectByIdRequest request,
      CancellationToken cancellationToken)
  {
    var spec = new ProjectByIdWithItemsSpec(request.ProjectId);
    var entity = await _repository.GetBySpecAsync(spec); // TODO: pass cancellation token
    if (entity == null) return NotFound();

    var response = new GetProjectByIdResponse
    (
        id: entity.Id,
        name: entity.Name,
        breweryType: entity.BreweryType,
        street: entity.Street,
        address2: entity.Address2,
        address3: entity.Address3,
        city: entity.City,
        state: entity.State,
        countyProvince: entity.CountyProvince,
        postalCode: entity.PostalCode,
        country: entity.Country,
        longitude: entity.Longitude,
        latitude: entity.Latitude,
        phone: entity.Phone,
        websiteUrl: entity.WebsiteUrl,
        updatedAt: entity.UpdatedAt,
        createdAt: entity.CreatedAt,
        items: entity.Items.Select(item => new ToDoItemRecord(item.Id, item.Title, item.Description, item.IsDone)).ToList()
    );
    return Ok(response);
  }
}
