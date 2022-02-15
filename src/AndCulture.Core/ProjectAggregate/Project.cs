using System;
using System.Collections.Generic;
using System.Linq;
using Ardalis.GuardClauses;
using AndCulture.Core.ProjectAggregate.Events;
using AndCulture.SharedKernel;
using AndCulture.SharedKernel.Interfaces;
using Newtonsoft.Json;

namespace AndCulture.Core.ProjectAggregate;

public class Project : IAggregateRoot
{

  public string? Id { get; set; }
  public string? Name { get; set; }
  [JsonProperty("brewery_type")]
  public string? BreweryType { get; set; }
  public string? Street { get; set; }
  [JsonProperty("address_2")]
  public string? Address2 { get; set; }
  [JsonProperty("address_3")]
  public string? Address3 { get; set; }
  public string? City { get; set; }
  public string? State { get; set; }
  [JsonProperty("county_province")]
  public string? CountyProvince { get; set; }
  [JsonProperty("postal_code")]
  public string? PostalCode { get; set; }
  public string? Country { get; set; }
  public double Longitude { get; set; }
  public double Latitude { get; set; }
  public string? Phone { get; set; }
  [JsonProperty("website_url")]
  public string? WebsiteUrl { get; set; }
  [JsonProperty("updated_at")]
  public DateTime UpdatedAt { get; set; }
  [JsonProperty("updated_at")]
  public DateTime CreatedAt { get; set; }

  private List<ToDoItem> _items = new List<ToDoItem>();
  public IEnumerable<ToDoItem> Items => _items.AsReadOnly();
  public ProjectStatus Status => _items.All(i => i.IsDone) ? ProjectStatus.Complete : ProjectStatus.InProgress;

  public Project(string name)
  {
    Name = Guard.Against.NullOrEmpty(name, nameof(name));
  }

  public void AddItem(ToDoItem newItem)
  {
    Guard.Against.Null(newItem, nameof(newItem));
    _items.Add(newItem);

    var newItemAddedEvent = new NewItemAddedEvent(this, newItem);
    //Events.Add(newItemAddedEvent);
  }

  public void UpdateName(string newName)
  {
    Name = Guard.Against.NullOrEmpty(newName, nameof(newName));
  }
}
