using System.Collections.Generic;
using System.Linq;
using Commander.Models;

namespace Commander.Repositories
{
  public class CommandRepository : ICommandRepository
  {
    private readonly CommandContext _context;

    public CommandRepository(CommandContext context)
    {
      _context = context;
    }

    public IEnumerable<Command> GetAllCommands()
    {
      return _context.Commands.ToList();
    }

    public Command GetCommandById(int id)
    {
      return _context.Commands.FirstOrDefault(command => command.Id == id);
    }
  }
}