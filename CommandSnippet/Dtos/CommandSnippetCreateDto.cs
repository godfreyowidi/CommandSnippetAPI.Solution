using System.ComponentModel.DataAnnotations;

namespace CommandSnippet.Dtos
{
  public class CommandSnippetCreateDto
  {
    [Required]
    [MaxLength(250)]
    public string HowTo { get; set; }
    
    [Required]
    public string Line { get; set; }

    [Required]
    public string Platform { get; set; }
  }
}