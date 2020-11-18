namespace Commander.Dtos
{
  public class CommandReadDto
  {

    public int Id { get; set; }

    public string HowTo { get; set; }

    public string Line { get; set; }

    // Don't want to expose Plataform to the client
    // public string Plataform { get; set; }
  }
}