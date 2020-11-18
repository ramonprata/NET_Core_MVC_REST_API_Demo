using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Commander.Models;
using Commander.Repositories;
using AutoMapper;
using Commander.Dtos;

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
    [HttpGet("{id}")]
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

  }
}