using System.Collections.Generic;
using Commander.Models;

namespace Commander.Repositories
{
  public interface ICommandRepository
  {
    IEnumerable<Command> GetAllCommands();
    Command GetCommandById(int id);
  }
}