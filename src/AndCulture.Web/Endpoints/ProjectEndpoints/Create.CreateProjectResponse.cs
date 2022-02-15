namespace AndCulture.Web.Endpoints.ProjectEndpoints;

public class CreateProjectResponse
{
  public CreateProjectResponse(string id, string name)
  {
    Id = Id;
    Name = name;
  }
  public string Id { get; set; }
  public string Name { get; set; }
}
