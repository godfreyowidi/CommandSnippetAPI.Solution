using CommandSnippet.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CommandSnippet.Data
{
  public class CommandSnippetContext : IdentityDbContext
  {
    public CommandSnippetContext(DbContextOptions<CommandSnippetContext> options) : base(options)
    {

    }
    public DbSet<Command> Commands { get; set; }
  }
}