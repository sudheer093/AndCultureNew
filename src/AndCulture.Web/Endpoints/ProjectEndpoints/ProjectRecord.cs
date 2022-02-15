namespace AndCulture.Web.Endpoints.ProjectEndpoints;

public record ProjectRecord(string Id, string Name, 
  string? Brewery_Type ,
  string? Street ,
  string? Address_2 ,
  string? Address_3 ,
  string? City ,
  string? State ,
  string? County_Province ,
  string? Postal_Code ,
  string? Country ,
  double Longitude ,
  double Latitude ,
  string? Phone ,
  string? Website_Url ,
  DateTime Updated_At ,
  DateTime Created_At );
