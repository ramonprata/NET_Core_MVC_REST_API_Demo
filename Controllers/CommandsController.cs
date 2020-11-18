using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Commander.Models;
using Commander.Repositories;
using AutoMapper;
using Commander.Dtos;
using Microsoft.AspNetCore.JsonPatch;

namespace Commander.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CommandsController : ControllerBase
  {
    private readonly ICommandRepository _repository;
    private readonly IMapper _mapper;

    public CommandsController(ICommandRepository repository, IMapper mapper)
    {
      _repository = repository;
      _mapper = mapper;
    }

    // GET api/commands
    [HttpGet]
    public ActionResult<IEnumerable<CommandReadDto>> GetAllCommands()
    {
      var commandItems = _repository.GetAllCommands();
      var commandItemsDtoMapped = _mapper.Map<IEnumerable<CommandReadDto>>(commandItems);
      return Ok(commandItemsDtoMapped);
    }

    // GET api/commands/{id}
    [HttpGet("{id}", Name = "GetCommandById")]
    public ActionResult<CommandReadDto> GetCommandById(int id)
    {
      var commandItem = _repository.GetCommandById(id);
      if (commandItem != null)
      {
        // return Ok(commandItem);
        var commandItemDtoMapped = _mapper.Map<CommandReadDto>(commandItem);
        return Ok(commandItemDtoMapped);
      }
      return NotFound();
    }

    // POST api/commands/
    [HttpPost]
    public ActionResult<CommandReadDto> CreateCommand(CommandCreateDto newCommand)
    {
      var commandModel = _mapper.Map<Command>(newCommand);
      _repository.CreateCommand(commandModel);

      // persist the created command
      _repository.SaveChanges();

      // return Ok(commandModel);

      // return the created command using the GetCommandById route
      return CreatedAtRoute(nameof(GetCommandById), new { Id = commandModel.Id }, commandModel);
    }

    // PUT api/commands/{id}
    [HttpPut("{id}")]
    public ActionResult UpdateCommand(int id, CommandCreateDto commandUpdate)
    {
      var commandFromRepo = _repository.GetCommandById(id);
      if (commandFromRepo == null)
      {
        return NotFound();
      }
      // changes commandFromRepo according to commandUpdate
      _mapper.Map(commandUpdate, commandFromRepo);

      _repository.UpdateCommand(commandFromRepo);
      _repository.SaveChanges();
      return NoContent();
    }


    // PATCH api/commands/{id}
    [HttpPatch("{id}")]
    public ActionResult PartialUpdateCommand(int id, JsonPatchDocument<CommandUpdateDto> patchDoc)
    {
      var commandFromRepo = _repository.GetCommandById(id);
      if (commandFromRepo == null)
      {
        return NotFound();
      }

      var commandToPatch = _mapper.Map<CommandUpdateDto>(commandFromRepo);
      patchDoc.ApplyTo(commandToPatch, ModelState);

      if (!TryValidateModel(commandToPatch))
      {
        return ValidationProblem(ModelState);
      }

      _mapper.Map(commandToPatch, commandFromRepo);
      _repository.UpdateCommand(commandFromRepo);
      _repository.SaveChanges();
      return NoContent();
    }


    // PATCH api/commands/{id}
    [HttpDelete("{id}")]
    public ActionResult DeleteCommand(int id)
    {
      var commandFromRepo = _repository.GetCommandById(id);
      if (commandFromRepo == null)
      {
        return NotFound();
      }

      _repository.DeleteCommand(commandFromRepo);
      _repository.SaveChanges();

      return NoContent();
    }

  }
}