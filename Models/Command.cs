using System.ComponentModel.DataAnnotations;

namespace Commander.Models
{
  public class Command
  {
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(400)]
    public string HowTo { get; set; }

    [Required]
    [MaxLength(300)]
    public string Line { get; set; }

    [Required]
    [MaxLength(100)]
    public string Plataform { get; set; }
  }
}