using System.Collections.Generic;
using AutoMapper;
using CommandSnippet.Data;
using CommandSnippet.Dtos;
using CommandSnippet.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace CommandSnippet.Controllers
{
  [Route("api/commands")]
  [ApiController]
  public class CommandsController : ControllerBase
  {
    private readonly ICommandSnippetRepo _repository;
    private readonly IMapper _mapper;

    public CommandsController(ICommandSnippetRepo repository, IMapper mapper)
    {
      _repository = repository;
      _mapper = mapper;
    }

    //private readonly MockCommandSnippetRepo _repository = new MockCommandSnippetRepo();
    //GET: api/commands/
    [HttpGet]
    public ActionResult <IEnumerable<CommandSnippetReadDto>> GetAllCommands()
    {
      var commandItems = _repository.GetAllCommands();
      return Ok(_mapper.Map<IEnumerable<CommandSnippetReadDto>>(commandItems));
    }

    //GET: api/commands/{id}
    [HttpGet("{id}", Name="GetCommandById")]
    public ActionResult <CommandSnippetReadDto> GetCommandById(int id)
    {
      var commandItem = _repository.GetCommandById(id);
      if (commandItem != null)
      {
        return Ok(_mapper.Map<CommandSnippetReadDto>(commandItem));
      }
      return NotFound();
    }

    //POST: api/commands
    [HttpPost]
    public ActionResult <CommandSnippetReadDto> CreateCommandSnippet(CommandSnippetUpdateDto commandSnippetCreateDto)
    {
      var commandModel = _mapper.Map<Command>(commandSnippetCreateDto);
      _repository.CreateCommandSnippet(commandModel);
      _repository.SaveChanges();

      var commandSnippetReadDto = _mapper.Map<CommandSnippetReadDto>(commandModel);

      return CreatedAtRoute(nameof(GetCommandById), new { Id = commandSnippetReadDto.Id}, commandSnippetReadDto);
      //return Ok(commandModel);
    }

    //PUT: api/commands/{id}
    [HttpPut("{id}")]
    public ActionResult UpdateCommandSnippet(int id, CommandSnippetUpdateDto commandSnippetUpdateDto)
    {
      var commandModelFromRepo = _repository.GetCommandById(id);
      if (commandModelFromRepo == null)
      {
        return NotFound();
      }
      _mapper.Map(commandSnippetUpdateDto, commandModelFromRepo);
      _repository.UpdateCommandSnippet(commandModelFromRepo);
      _repository.SaveChanges();
      return NoContent();
    }
    
    //Patch: api/commands/{id}
    [HttpPatch("{id}")]
    public ActionResult PartialCommandSnippetUpdate(int id, JsonPatchDocument<CommandSnippetUpdateDto> patchDoc)
    {
      var commandModelFromRepo = _repository.GetCommandById(id);
      if (commandModelFromRepo == null)
      {
        return NotFound();
      } 

      var commandToPatch = _mapper.Map<CommandSnippetUpdateDto>(commandModelFromRepo);
      patchDoc.ApplyTo(commandToPatch, ModelState);

      if (!TryValidateModel(commandToPatch))
      {
        return ValidationProblem(ModelState);
      }
      _mapper.Map(commandToPatch, commandModelFromRepo);
      _repository.UpdateCommandSnippet(commandModelFromRepo);
      _repository.SaveChanges();
      return NoContent();
    }

    //DELETE: api/commands/{id}
    [HttpDelete("{id}")]
    public ActionResult DeleteCommandSnippet(int id)
    {
      var commandModelFromRepo = _repository.GetCommandById(id);
      if (commandModelFromRepo == null)
      {
        return NotFound();
      } 
      _repository.DeleteCommandSnippet(commandModelFromRepo);
      _repository.SaveChanges();

      return NoContent();
    }
  }
}