using System.Collections.Generic;
using System.Data;
using System.Linq;
using artist.Models;
using Dapper;

namespace artist.Data
{
  public class ArtistsRepository
  {
    private readonly IDbConnection _db;
    //SOLI(D) Principle
    // depeendency injection 
    public ArtistsRepository(IDbConnection db)
    {
      _db = db;
    }
    public List<Artist> GetAll()
    {
      var sql = "SELECT * FROM artists";
      return _db.Query<Artist>(sql).ToList();
    }

    public Artist GetOne(int id)
    {
      var sql = @"SELECT * FROM artists
                WHERE id = @id 
      ";
      return _db.QueryFirstOrDefault<Artist>(sql, new { id });
    }

    public Artist Create(Artist artistData)
    {
      var sql = @"
            INSERT INTO artists(name, birthYear, deathYear)
            VALUES(@Name, @BirthYear, @DeathYear);
            SELECT LAST_INSERT_ID();
            ";

      int id = _db.ExecuteScalar<int>(sql, artistData);
      artistData.Id = id;
      return artistData;

      // Review: this is terrible don't do it
      // never use string interpolation or concationation 
      // to build your sql statements

      // var sql = $@"INSERT INTO artists(name, birthYear, deathYear)
      //     VALUES({artistData.Name}, {artistData.BirthYear}, {artistData.DeathYear});
      //     SELECT LAST_ROW();";
      // return _db.ExecuteScalar<Artist>(sql);

    }



    public int Update(int id, Artist artist)
    {
      var sql = @"
            UPDATE artists
            SET 
            name = @Name,
            birthYear = @BirthYear,
            deathYear = @DeathYear
            WHERE id = @id;
            SELECT LAST_INSERT_ID();
            ";
      // _db.Execute(sql, artist);
      return _db.ExecuteScalar<int>(sql, new { id, artist.Name, artist.BirthYear, artist.DeathYear });
    }



    public void Delete(int id)
    {
      string sql = @"DELETE * FROM 
      artists 
      LIMIT 1
      WHERE id = @id
      ";

      _db.Execute(sql, new { id });
    }






  }







}