using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using artist.Models;
using Dapper;

namespace artist.Data
{
  public class WorksRepository
  {
    private readonly IDbConnection _db;
    //SOLI(D) Principle
    // depeendency injection 
    public WorksRepository(IDbConnection db)
    {
      _db = db;
    }

    internal int Create(Work work)
    {
      throw new NotImplementedException();
    }

    internal List<Work> GetWorksByArtistId(int artistId)
    {
      throw new NotImplementedException();
    }

    internal Work GetWorkById(int id)
    {
      throw new NotImplementedException();
    }
  }
}