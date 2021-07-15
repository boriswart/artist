using System.Collections.Generic;
using artist.Data;
using artist.Models;

namespace artist.Services
{

  public class ArtistsService
  {
    private readonly ArtistsRepository _artistsRepo;

    public ArtistsService(ArtistsRepository artistsRepo)
    {
      _artistsRepo = artistsRepo;
    }

    public List<Artist> GetAll()
    {
      return _artistsRepo.GetAll();
    }

    public Artist CreateArtist(Artist artistData)
    {
      return _artistsRepo.Create(artistData);
    }
  }
}