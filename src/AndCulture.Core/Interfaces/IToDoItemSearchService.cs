using System.Collections.Generic;
using System.Threading.Tasks;
using Ardalis.Result;
using AndCulture.Core.ProjectAggregate;

namespace AndCulture.Core.Interfaces;

public interface IToDoItemSearchService
{
  Task<Result<ToDoItem>> GetNextIncompleteItemAsync(string projectId);
  Task<Result<List<ToDoItem>>> GetAllIncompleteItemsAsync(string projectId, string searchString);
}
