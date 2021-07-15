using System;
using System.ComponentModel.DataAnnotations;

namespace artist.Models
{

  public class Artist
  {
    [Required]
    public string Name { get; set; }
    public int Id { get; set; }
    public int BirthYear { get; set; }
    public int? DeathYear { get; set; }
    public bool IsDead { get => DeathYear > 0; }

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

  }

}



