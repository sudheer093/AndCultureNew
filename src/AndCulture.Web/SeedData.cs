﻿using AndCulture.Core.ProjectAggregate;
using AndCulture.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AndCulture.Web;

public static class SeedData
{
  public static readonly Project TestProject1 = new Project("Test Project");
  public static readonly ToDoItem ToDoItem1 = new ToDoItem
  {
    Title = "Get Sample Working",
    Description = "Try to get the sample to build."
  };
  public static readonly ToDoItem ToDoItem2 = new ToDoItem
  {
    Title = "Review Solution",
    Description = "Review the different projects in the solution and how they relate to one another."
  };
  public static readonly ToDoItem ToDoItem3 = new ToDoItem
  {
    Title = "Run and Review Tests",
    Description = "Make sure all the tests run and review what they are doing."
  };

  public static void Initialize(IServiceProvider serviceProvider)
  {
    using (var dbContext = new AppDbContext(
        serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>(), null))
    {
      // Look for any TODO items.
      if (dbContext.ToDoItems.Any())
      {
        return;   // DB has been seeded
      }

      PopulateTestData(dbContext);


    }
  }
  public static void PopulateTestData(AppDbContext dbContext)
  {
    foreach (var item in dbContext.ToDoItems)
    {
      dbContext.Remove(item);
    }
    dbContext.SaveChanges();

    TestProject1.Id = "";
    AddProjects(dbContext);

    dbContext.SaveChanges();
  }

  private static void AddProjects(AppDbContext dbContext)
  {
    var data = @"[{ 'id':'10-56-brewing-company-knox','name':'10-56 Brewing Company','brewery_type':'micro', 'street':'400 Brown Cir','address_2':null,'address_3':null,'city':'Knox','state':'Indiana','county_province':null,'postal_code':'46534','country':'United States', 'longitude':-86.627954,'latitude':41.289715,'phone':'6308165790','website_url':null,'updated_at':'2021-10-23T02:24:55.243Z','created_at':'2021-10-23T02:24:55.243Z'},
      { 'id':'10-barrel-brewing-co-bend-1','name':'10 Barrel Brewing Co','brewery_type':'large', 'street':'62970 18th St','address_2':null,'address_3':null,'city':'Bend','state':'Oregon','county_province':null,'postal_code':'97701-9847','country':'United States', 'phone':'5415851007','website_url':'http://www.10barrel.com','updated_at':'2021-10-23T02:24:55.243Z','created_at':'2021-10-23T02:24:55.243Z'},
      { 'id':'10-barrel-brewing-co-bend-2','name':'10 Barrel Brewing Co','brewery_type':'large', 'street':'1135 NW Galveston Ave Ste B','address_2':null,'address_3':null,'city':'Bend','state':'Oregon','county_province':null,'postal_code':'97703-2465','country':'United States','phone':'5415851007','website_url':null,'updated_at':'2021-10-23T02:24:55.243Z','created_at':'2021-10-23T02:24:55.243Z'},
      { 'id':'10-barrel-brewing-co-bend-pub-bend','name':'10 Barrel Brewing Co - Bend Pub','brewery_type':'large','street':'62950 NE 18th St','address_2':null,'address_3':null,'city':'Bend','state':'Oregon','county_province':null,'postal_code':'97701','country':'United States','longitude':-121.2809536,'latitude':44.0912109,'phone':'5415851007','website_url':null,'updated_at':'2021-10-23T02:24:55.243Z','created_at':'2021-10-23T02:24:55.243Z'},
      { 'id':'10-barrel-brewing-co-boise-boise','name':'10 Barrel Brewing Co - Boise','brewery_type':'large','street':'826 W Bannock St','address_2':null,'address_3':null,'city':'Boise','state':'Idaho','county_province':null,'postal_code':'83702-5857','country':'United States','longitude':-116.202929,'latitude':43.618516,'phone':'2083445870','website_url':'http://www.10barrel.com','updated_at':'2021-10-23T02:24:55.243Z','created_at':'2021-10-23T02:24:55.243Z'},
      { 'id':'10-barrel-brewing-co-denver-denver','name':'10 Barrel Brewing Co - Denver','brewery_type':'large','street':'2620 Walnut St','address_2':null,'address_3':null,'city':'Denver','state':'Colorado','county_province':null,'postal_code':'80205-2231','country':'United States','longitude':-104.9853655,'latitude':39.7592508,'phone':'7205738992','website_url':null,'updated_at':'2021-10-23T02:24:55.243Z','created_at':'2021-10-23T02:24:55.243Z'},
      { 'id':'10-barrel-brewing-co-portland','name':'10 Barrel Brewing Co','brewery_type':'large','street':'1411 NW Flanders St','address_2':null,'address_3':null,'city':'Portland','state':'Oregon','county_province':null,'postal_code':'97209-2620','country':'United States','longitude':-122.6855056,'latitude':45.5259786,'phone':'5032241700','website_url':'http://www.10barrel.com','updated_at':'2021-10-23T02:24:55.243Z','created_at':'2021-10-23T02:24:55.243Z'},
      { 'id':'10-barrel-brewing-co-san-diego','name':'10 Barrel Brewing Co','brewery_type':'large','street':'1501 E St','address_2':null,'address_3':null,'city':'San Diego','state':'California','county_province':null,'postal_code':'92101-6618','country':'United States','longitude':-117.129593,'latitude':32.714813,'phone':'6195782311','website_url':'http://10barrel.com','updated_at':'2021-10-23T02:24:55.243Z','created_at':'2021-10-23T02:24:55.243Z'},
      { 'id':'10-torr-distilling-and-brewing-reno','name':'10 Torr Distilling and Brewing','brewery_type':'micro','street':'490 Mill St','address_2':null,'address_3':null,'city':'Reno','state':'Nevada','county_province':null,'postal_code':'89502','country':'United States','longitude':-119.7732015,'latitude':39.5171702,'phone':'7755307014','website_url':'http://www.10torr.com','updated_at':'2021-10-23T02:24:55.243Z','created_at':'2021-10-23T02:24:55.243Z'},
      { 'id':'101-brewery-quilcene','name':'101 Brewery','brewery_type':'brewpub','street':'294793 US Highway 101','address_2':null,'address_3':null,'city':'Quilcene','state':'Washington','county_province':null,'postal_code':'98376-9000','country':'United States','longitude':-122.87558226136872,'latitude':47.823475773720666,'phone':'3607656485','website_url':'http://www.101brewery.com','updated_at':'2021-10-23T02:24:55.243Z','created_at':'2021-10-23T02:24:55.243Z'},
      { 'id':'101-north-brewing-company-petaluma','name':'101 North Brewing Company','brewery_type':'micro','street':'1304 Scott St Ste D','address_2':null,'address_3':null,'city':'Petaluma','state':'California','county_province':null,'postal_code':'94954-7100','country':'United States','phone':'7077534934','website_url':'http://www.101northbeer.com','updated_at':'2021-10-23T02:24:55.243Z','created_at':'2021-10-23T02:24:55.243Z'},
      { 'id':'105-west-brewing-co-castle-rock','name':'105 West Brewing Co','brewery_type':'micro','street':'1043 Park St','address_2':null,'address_3':null,'city':'Castle Rock','state':'Colorado','county_province':null,'postal_code':'80109-1585','country':'United States','longitude':-104.8667206,'latitude':39.38269495,'phone':'3033257321','website_url':'http://www.105westbrewing.com','updated_at':'2021-10-23T02:24:55.243Z','created_at':'2021-10-23T02:24:55.243Z'},
      { 'id':'10k-brewing-anoka','name':'10K Brewing','brewery_type':'micro','street':'2005 2nd Ave','address_2':null,'address_3':null,'city':'Anoka','state':'Minnesota','county_province':null,'postal_code':'55303-2243','country':'United States','longitude':-93.38952559,'latitude':45.19812039,'phone':'7633924753','website_url':'http://10KBrew.com','updated_at':'2021-10-23T02:24:55.243Z','created_at':'2021-10-23T02:24:55.243Z'},
      { 'id':'10th-district-brewing-company-abington','name':'10th District Brewing Company','brewery_type':'micro','street':'491 Washington St','address_2':null,'address_3':null,'city':'Abington','state':'Massachusetts','county_province':null,'postal_code':'02351-2419','country':'United States','longitude':-70.94594149,'latitude':42.10591754,'phone':'7813071554','website_url':'http://www.10thdistrictbrewing.com','updated_at':'2021-10-23T02:24:55.243Z','created_at':'2021-10-23T02:24:55.243Z'},
      { 'id':'11-below-brewing-company-houston','name':'11 Below Brewing Company','brewery_type':'micro','street':'6820 Bourgeois Rd','address_2':null,'address_3':null,'city':'Houston','state':'Texas','county_province':null,'postal_code':'77066-3107','country':'United States','longitude':-95.5186591,'latitude':29.9515464,'phone':'2814442337','website_url':'http://www.11belowbrewing.com','updated_at':'2021-10-23T02:24:55.243Z','created_at':'2021-10-23T02:24:55.243Z'},
      { 'id':'1188-brewing-co-john-day','name':'1188 Brewing Co','brewery_type':'brewpub','street':'141 E Main St','address_2':null,'address_3':null,'city':'John Day','state':'Oregon','county_province':null,'postal_code':'97845-1210','country':'United States','longitude':-118.9218754,'latitude':44.4146563,'phone':'5415751188','website_url':'http://www.1188brewing.com','updated_at':'2021-10-23T02:24:55.243Z','created_at':'2021-10-23T02:24:55.243Z'},
      { 'id':'12-acres-brewing-company-killeshin','name':'12 Acres Brewing Company','brewery_type':'micro','street':'Unnamed Street','address_2':'Clonmore','address_3':null,'city':'Killeshin','state':null,'county_province':'Laois','postal_code':'R93 X3X8','country':'Ireland','longitude':-6.979343891,'latitude':52.84930763,'phone':'3.53599E+11','website_url':'https://12acresbrewing.ie/','updated_at':'2021-10-23T02:24:55.243Z','created_at':'2021-10-23T02:24:55.243Z'},
      { 'id':'12-gates-brewing-company-williamsville','name':'12 Gates Brewing Company','brewery_type':'brewpub','street':'80 Earhart Dr Ste 20','address_2':null,'address_3':null,'city':'Williamsville','state':'New York','county_province':null,'postal_code':'14221-7804','country':'United States','phone':'7169066600','website_url':'http://www.12gatesbrewing.com','updated_at':'2021-10-23T02:24:55.243Z','created_at':'2021-10-23T02:24:55.243Z'},
      { 'id':'12-west-brewing-company-gilbert','name':'12 West Brewing Company','brewery_type':'micro','street':'3000 E Ray Rd Bldg 6','address_2':null,'address_3':null,'city':'Gilbert','state':'Arizona','county_province':null,'postal_code':'85296-7832','country':'United States','phone':'6023395014','website_url':'http://www.12westbrewing.com','updated_at':'2021-10-23T02:24:55.243Z','created_at':'2021-10-23T02:24:55.243Z'},
      { 'id':'12-west-brewing-company-production-facility-mesa','name':'12 West Brewing Company - Production Facility','brewery_type':'micro','street':null,'address_2':null,'address_3':null,'city':'Mesa','state':'Arizona','county_province':null,'postal_code':'85207','country':'United States','longitude':-111.5860662,'latitude':33.436188,'phone':null,'website_url':null,'updated_at':'2021-10-23T02:24:55.243Z','created_at':'2021-10-23T02:24:55.243Z'}]";
    var projects = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Project>>(data);
    if (projects != null)
    {
      dbContext.Projects.AddRange(projects);
    }
  }
}
