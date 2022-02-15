namespace AndCulture.Web.ApiModels;

// ApiModel DTOs are used by ApiController classes and are typically kept in a side-by-side folder

public class ProjectDTO
{
  public string? Id { get; set; }
  public string? Name { get; set; }
  public string? BreweryType { get; set; }
  public string? Street { get; set; }
  public string? Address2 { get; set; }
  public string? Address3 { get; set; }
  public string? City { get; set; }
  public string? State { get; set; }
  public string? CountyProvince { get; set; }
  public string? PostalCode { get; set; }
  public string? Country { get; set; }
  public double Longitude { get; set; }
  public double Latitude { get; set; }
  public string? Phone { get; set; }
  public string? WebsiteUrl { get; set; }
  public List<ToDoItemDTO> Items { get; set; } = new();
}
