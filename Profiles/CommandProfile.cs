
using AutoMapper;
using Commander.Dtos;
using Commander.Models;

namespace Commander.Profiles
{
  public class CommandProfile : Profile
  {
    // source => target
    public CommandProfile()
    {
      CreateMap<Command, CommandReadDto>();
      CreateMap<CommandCreateDto, Command>();
      CreateMap<CommandUpdateDto, Command>();
      CreateMap<Command, CommandUpdateDto>();
    }
  }
}