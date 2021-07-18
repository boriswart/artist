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
    public int Create(Work work)
    {
      string sql = @"
      INSERT INTO works
      (artistId, title, imgUrl)
      VALUES
      (@artistId, @title, @ImgUrl);
      SELECT LAST_INSERT_ID();
      ";
      return _db.ExecuteScalar<int>(sql, work);
    }

    public List<Work> GetWorksByArtistId(int artistId)
    {
      string sql = @"
      SELECT * FROM works
      WHERE artistId = @ArtistId;
      ";
      return _db.Query<Work>(sql, new { artistId }).ToList();
    }
    public Work GetWorkById(int id)
    {
      string sql = @"
      SELECT * FROM works
      WHERE Id = @id;
      ";
      return _db.QueryFirstOrDefault<Work>(sql, new { id });
    }
  }
}