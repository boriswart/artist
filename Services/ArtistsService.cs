using System;
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

    public Artist GetOne(int id)
    {
      return _artistsRepo.GetOne(id);
    }

    public Artist CreateArtist(Artist artistData)
    {
      return _artistsRepo.Create(artistData);
    }

    public Artist Update(int id, Artist artist)
    {
      artist.Id = id;
      Artist original = GetOne(id);
      if (original == null)
      {
        throw new Exception("Invalid Id");
      }
      artist.Name = artist.Name != null ? artist.Name : original.Name;
      artist.BirthYear = artist.BirthYear > 0 ? artist.BirthYear : original.BirthYear;
      artist.DeathYear = artist.DeathYear >= 0 ? artist.DeathYear : original.DeathYear;
      int updated = _artistsRepo.Update(id, artist);
      if (updated >= 0)
      {
        return artist;
      }
      else
      {
        throw new Exception("Could not Update!");
      }
    }

    public Artist Delete(int id)
    {
      Artist artist = _artistsRepo.GetOne(id);
      _artistsRepo.Delete(id);

      return artist;
    }
  }
}
