.NET Core 3.1 MVC REST API Demo

## Requirements

- Visual studio or VsCode
- Microsoft SQL Server Management Studio
- .NET cli
- Entity framework tool: `dotnet tool install --global dotnet-ef`

## Root

- **Startup.cs**

  - **Cofigure services**
    - setup all the services you might need in your container
      - DB context
      - Controllers
      - Mapper
      - Dependency injections
  - **Configure**
    - setup HTTP pipeline (middlewares)

- **appsettings.json**

  - Setup DB ConnectionStrings
  - Other things

- **Properties/launchSettings.json**

  - applicationUrl
  - environmentVariables
  - Other things

- **AppName.csproj**

  - package references

## Models

- Create all Entity Models (in this case, each one represents a DBEntity)

## Repositories

- **EntityNameContext:** a link between a DBEntity and ModelEntity
- **EntityNameRespository:** a class to interect with DBEntities via **EntityNameContext**
- **IEntityNameRespository:** an interface that the repository should implement. Decoupling the repository into interface and implementation, makes it easier to apply dependency injection (relying only on the interface) and also maintain the code

## Dtos

- **EntityNameDto:** used to map(transform) data from/to classes/entities.

  - Ex.: including, removing or changing data and properties from our models to a transformed output model

## Profiles

- responsible for creates a mapping between **ClassA** and its respective **ClassADto** and vice-versa.
  - **A** -> **ADto**
  - **ADto** -> **A**

## Controllers

- responsible for handle the HTTP requests coming to that specific route, and respond them
- setup in `Startup -> ConfigureServices`
- uses dependency injection to interact with other layers via interfaces
- they are the very last "thing" that will execute in the HTTP pipeline: `Startup -> Configure`

## Help

- **Migrations commands**

  - dotnet ef migrations add <migrationName>
  - dotnet ef migrations remove
  - dotnet ef database update

- **Run API commands**
  - dotnet build
  - dotnet run

## References

- [.NET Core 3.1 MVC REST API - Full Course](https://www.youtube.com/watch?v=fmvcAzHpsk8&ab_channel=LesJackson)
- [Oficial docs](https://docs.microsoft.com/en-us/aspnet/core/mvc/overview?view=aspnetcore-5.0)
