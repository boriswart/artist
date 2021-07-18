
using System.ComponentModel.DataAnnotations;

namespace artist.Models
{
  public class Work
  {
    public int Id { get; set; }

    [Required]
    public int ArtistId { get; set; }
    public string title { get; set; }
    public string ImgUrl { get; set; }
  }
}
