using System;
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

    public void CreateCommand(Command command)
    {
      if (command == null)
      {
        throw new ArgumentNullException(nameof(command));
      }

      _context.Commands.Add(command);
    }

    public void UpdateCommand(Command command)
    {
      // nothing need to be done since we're using EF DBContext
    }

    public void DeleteCommand(Command command)
    {
      if (command == null)
      {
        throw new ArgumentNullException(nameof(command));
      }
      _context.Commands.Remove(command);
    }

    public bool SaveChanges()
    {
      return (_context.SaveChanges() >= 0);
    }

  }
}