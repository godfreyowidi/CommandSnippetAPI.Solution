using System.Collections.Generic;
using CommandSnippet.Models;

namespace CommandSnippet.Data
{
  public class MockCommandSnippetRepo : ICommandSnippetRepo
  {
    public void CreateCommandSnippet(Command cmd)
    {
      throw new System.NotImplementedException();
    }

    public void DeleteCommandSnippet(Command cmd)
    {
      throw new System.NotImplementedException();
    }

    public IEnumerable<Command> GetAllCommands()
    {
      var commands = new List<Command>
      {
        new Command{Id=0, HowTo="Boil and egg", Line="Boil water", Platform="Kettle and pan" },
        new Command{Id=1, HowTo="Cut brea", Line="Get a knife", Platform="Knife and chopping board" },
        new Command{Id=2, HowTo="Make cup of tea", Line="Place teabag in cup", Platform="Kettle and cup" },
      };
      return commands;
    }
    public Command GetCommandById(int id)
    {
      return new Command{Id=0, HowTo="Boil and egg", Line="Boil water", Platform="Kettle and pan" };
    }

    public bool SaveChanges()
    {
      throw new System.NotImplementedException();
    }

    public void UpdateCommandSnippet(Command cmd)
    {
      throw new System.NotImplementedException();
    }
  }
}