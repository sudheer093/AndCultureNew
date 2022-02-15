
namespace AndCulture.Web.Endpoints.ProjectEndpoints;

public class GetProjectByIdResponse
{
  public GetProjectByIdResponse(string id, string name, string? breweryType,
    string? street,
    string? address2,
    string? address3,
    string? city,
    string? state,
    string? countyProvince,
    string? postalCode,
    string? country,
    double longitude,
    double latitude,
    string? phone,
    string? websiteUrl,
    DateTime updatedAt,
    DateTime createdAt, List<ToDoItemRecord> items)
  {
    Id = id;
    Name = name;
    Items = items;
    Brewery_Type = breweryType;
    Street = street;
    Address_2 = address2;
    Address_3 = address3;
    City = city;
    State = state;
    County_Province = countyProvince;
    Postal_Code = postalCode;
    Country = country;
    Longitude = longitude;
    Latitude = latitude;
    Phone = phone;
    Website_Url = websiteUrl;
    Updated_At = updatedAt;
    Created_At = createdAt;
  }

  public string Id { get; set; }
  public string Name { get; set; }
  public string? Brewery_Type { get; set; }
  public string? Street { get; set; }
  public string? Address_2 { get; set; }
  public string? Address_3 { get; set; }
  public string? City { get; set; }
  public string? State { get; set; }
  public string? County_Province { get; set; }
  public string? Postal_Code { get; set; }
  public string? Country { get; set; }
  public double Longitude { get; set; }
  public double Latitude { get; set; }
  public string? Phone { get; set; }
  public string? Website_Url { get; set; }
  public DateTime Updated_At { get; set; }
  public DateTime Created_At { get; set; }
  public List<ToDoItemRecord> Items { get; set; } = new();
}
