.NET Core 3.1 MVC REST API Demo

## Requirements

- Visual studio or VsCode
- Microsoft SQL Server Management Studio
- .NET cli
- Entity framework tool: `dotnet tool install --global dotnet-ef`

## root folder

- Startup.cs

  - Cofigure services
    - setup all the services you might need in your container
      - DB context
      - Controllers
      - Mapper
      - Dependency injections
  - Configure
    - setup HTTP pipeline (middlewares)

- appsettings.json

  - Setup DB ConnectionStrings
  - Other things

- Properties/launchSettings.json

  - applicationUrl
  - environmentVariables
  - Other things

- <AppName.csproj>

  - package references

## Models

- Create all Entity Models (in this case, each one represents a DBEntity)

## Repositories

- <EntityName>Context: the link between a DBEntity and ModelEntity
- <EntityName>Respository: a class to interect with DBEntities via <EntityName>Context
- **I**<EntityName>Respository: an interface that the repository should implement. Decoupling the repository into interface and implementation, makes it easier to apply dependency injection (relying only on the interface) and also maintain the code

## Dtos

- <EntityName>Dto: a class that can be used to map(transform) data.

  - Ex.: including, removing or changing data and properties from our models to a transformed output model

- Profiles: a class that creates the mapping between **A** and its respective **Dto** and vice-versa.
  - **A** -> **ADto**
  - **ADto** -> **A**

## Controllers

- Classes responsible for handle the Http requests and respond them
- Setup in Startup -> ConfigureServices
- Uses dependency injection to interact with the other layers via interfaces
- They are the very last "thing" that will execute in the Http pipeline: Startup -> Configure

## Help

- Migrations commands

  - dotnet ef migrations add <migrationName>
  - dotnet ef migrations remove
  - dotnet ef database update

- Run API commands
  - dotnet build
  - dotnet run

## References

- [.NET Core 3.1 MVC REST API - Full Course](https://www.youtube.com/watch?v=fmvcAzHpsk8&ab_channel=LesJackson)
- [Oficial docs](https://docs.microsoft.com/en-us/aspnet/core/mvc/overview?view=aspnetcore-5.0)
