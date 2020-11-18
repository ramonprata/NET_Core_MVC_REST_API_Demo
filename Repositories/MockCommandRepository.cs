using System.Collections.Generic;
using Commander.Models;

namespace Commander.Repositories
{
  public class MockCommandRepository : ICommandRepository
  {
    public void CreateCommand(Command command)
    {
      throw new System.NotImplementedException();
    }

    public void DeleteCommand(Command command)
    {
      throw new System.NotImplementedException();
    }

    public IEnumerable<Command> GetAllCommands()
    {
      var commands = new List<Command> {
      new Command
      {
        Id = 0,
        HowTo = "how to do.. 0",
        Line = "command line.. 0",
        Plataform = "plataform.. 0"
      },
      new Command
      {
        Id = 1,
        HowTo = "how to do.. 1",
        Line = "command line.. 1",
        Plataform = "plataform.. 1"
      }
      };

      return commands;
    }

    public Command GetCommandById(int id)
    {
      return new Command
      {
        Id = 0,
        HowTo = "how to do..",
        Line = "command line..",
        Plataform = "plataform.."
      };
    }

    public bool SaveChanges()
    {
      throw new System.NotImplementedException();
    }

    public void UpdateCommand(Command command)
    {
      throw new System.NotImplementedException();
    }
  }
}