using Autofac;
using AndCulture.Core.Interfaces;
using AndCulture.Core.Services;

namespace AndCulture.Core;

public class DefaultCoreModule : Module
{
  protected override void Load(ContainerBuilder builder)
  {
    builder.RegisterType<ToDoItemSearchService>()
        .As<IToDoItemSearchService>().InstancePerLifetimeScope();
  }
}
