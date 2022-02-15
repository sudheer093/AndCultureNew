using System.Linq;
using System.Threading.Tasks;
using AndCulture.Core.ProjectAggregate;
using AndCulture.Core.ProjectAggregate.Specifications;
using AndCulture.SharedKernel.Interfaces;
using AndCulture.Web.ApiModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AndCulture.Web.Pages.ToDoRazorPage;

public class IndexModel : PageModel
{
  private readonly IRepository<Project> _repository;

  [BindProperty(SupportsGet = true)]
  public string ProjectId { get; set; }
  public string Message { get; set; } = "";

  public ProjectDTO? Project { get; set; }

  public IndexModel(IRepository<Project> repository)
  {
    _repository = repository;
  }

  public async Task OnGetAsync()
  {
    var projectSpec = new ProjectByIdWithItemsSpec(ProjectId);
    var project = await _repository.GetBySpecAsync(projectSpec);

    if (project == null)
    {
      Message = "No project found.";
      return;
    }

    Project = new ProjectDTO
    {
      Id = project.Id ,
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
      Items = project.Items
        .Select(item => ToDoItemDTO.FromToDoItem(item))
        .ToList()
    };
  }
}
