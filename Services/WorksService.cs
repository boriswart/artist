using System;
using System.Linq;
using System.Collections.Generic;
using artist.Models;
using artist.Data;

namespace artist.Services
{
  public class WorksService
  {

    private readonly WorksRepository _repo;

    private readonly WorksService _worksService;

    public WorksService(WorksRepository repo, WorksService worksService)
    {
      _repo = repo;
      _worksService = worksService;
    }

    public Work Create(Work work)
    {
      int id = _repo.Create(work);
      work.Id = id;
      List<Work> works = new List<Work>();
      works = GetWorksByArtistId(work.ArtistId);

      return _repo.GetWorkById(work.Id);

      //REVIEW: here works were originally catstudies... so some cats studies showed 
      // true or 'trues' and some proved false so here is an example of how to set 
      // a boolean in theory based on results of another model studies...

      // if (works.Count > 8)
      // {
      //   int trues = works.FindAll(s => s.Test == true).Count;
      //   CatTheory newResult = new CatTheory();
      //   if (trues > (studies.Count / 2))
      //   {
      //     newResult.Result = "This is a Fact";
      //   }
      //   else if (trues == (studies.Count / 2))
      //   {
      //     newResult.Result = "Data is inconclusive";
      //   }
      //   else
      //   {
      //     newResult.Result = "This is Bogus";
      //   }
      //  _theoryService.update(study.TheoryId, newResult);
      // }

    }
    public List<Work> GetWorksByArtistId(int artistId)
    {
      return _repo.GetWorksByArtistId(artistId);
    }

    public Work GetWorkById(int artistId)
    {
      return _repo.GetWorkById(artistId);
    }

  }
}
