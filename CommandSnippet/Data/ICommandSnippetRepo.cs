using System.Collections.Generic;
using CommandSnippet.Models;

namespace CommandSnippet.Data
{
  public interface ICommandSnippetRepo
  {
    bool SaveChanges();
    IEnumerable<Command> GetAllCommands();
    Command GetCommandById(int id);
    void CreateCommandSnippet(Command cmd);
    void UpdateCommandSnippet(Command cmd);
    void DeleteCommandSnippet(Command cmd);
  }
}