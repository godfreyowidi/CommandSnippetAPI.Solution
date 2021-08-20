using System;
using System.Collections.Generic;
using System.Linq;
using CommandSnippet.Models;

namespace CommandSnippet.Data
{
  public class SqlCommandSnippetRepo : ICommandSnippetRepo
  {
    private readonly CommandSnippetContext _context;

    public SqlCommandSnippetRepo(CommandSnippetContext context)
    {
      _context = context;
    }

    public void CreateCommandSnippet(Command cmd)
    {
      if (cmd == null)
      {
        throw new ArgumentNullException(nameof(cmd));
      }
      _context.Commands.Add(cmd);
    }

    public void DeleteCommandSnippet(Command cmd)
    {
      if (cmd == null)
      {
        throw new ArgumentNullException(nameof(cmd));
      }
      _context.Commands.Remove(cmd);
    }

    public IEnumerable<Command> GetAllCommands()
    {
      return _context.Commands.ToList();
    }

    public Command GetCommandById(int id)
    {
      return _context.Commands.FirstOrDefault(p => p.Id == id);
    }

    public bool SaveChanges()
    {
      return (_context.SaveChanges() >= 0);
    }

    public void UpdateCommandSnippet(Command cmd)
    {
      //We do Nothing
    }
  }
}