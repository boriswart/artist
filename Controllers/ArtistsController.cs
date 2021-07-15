using System;
using System.Collections.Generic;
using artist.Models;
using artist.Services;
using Microsoft.AspNetCore.Mvc;

namespace artist.Controllers
{
  [ApiController]
  [Route("/api/[Controller]")]
  public class ArtistsController : ControllerBase
  {
    private readonly ArtistsService _as;
    public ArtistsController(ArtistsService artistsService)
    {
      _as = artistsService;
    }
    [HttpGet]
    public ActionResult<List<ArtistsService>> GetArtists()
    {
      try
      {
        var artists = _as.GetAll();
        return Ok(artists);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }


    [HttpPost]
    public ActionResult<Artist> CreateArtist([FromBody] Artist artistData)
    {
      try
      {
        var artist = _as.CreateArtist(artistData);
        return Created($"api/artists/{artist.Id}", artist);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}
