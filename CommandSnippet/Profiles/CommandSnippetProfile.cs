using AutoMapper;
using CommandSnippet.Dtos;
using CommandSnippet.Models;

namespace CommandSnippet.Profiles
{
  public class CommandSnippetProfile : Profile
  {
    public CommandSnippetProfile()
    {
      //Source -> Target
      CreateMap<Command, CommandSnippetReadDto>();
      CreateMap<CommandSnippetUpdateDto, Command>();
      CreateMap<CommandSnippetUpdateDto, Command>();
      CreateMap<Command, CommandSnippetUpdateDto>();
    }
  }
}