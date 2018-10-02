using System.Collections.Generic;
using System.Data;
using System.Linq;
using burgershack.Models;
using Dapper;


namespace burgershack.Repositories
{

    public class FrenchfriesRepository
    {
        private IDbConnection _db;

        public FrenchfriesRepository(IDbConnection db)
        {
            _db = db;
        }

        //CRUD VIA SQL

        //GET ALL frenchfryS
        public IEnumerable<Frenchfry> GetAll()
        {
            return _db.Query<Frenchfry>("SELECT * FROM frenchfries;");
        }

        //GET frenchfry BY ID
        public Frenchfry GetById(int id)
        {
            return _db.Query<Frenchfry>("SELECT * FROM frenchfries WHERE id = @id;", new { id }).FirstOrDefault();
        }

        //CREATE frenchfry
        public Frenchfry Create(Frenchfry frenchfry)
        {
            int id = _db.ExecuteScalar<int>(@"
        INSERT INTO frenchfries (name, description, price)
        VALUES (@Name, @Description, @Price);
        SELECT LAST_INSERT_ID();", frenchfry
            );
            frenchfry.Id = id;
            return frenchfry;
        }

        //UPDATE frenchfry
        public Frenchfry Update(Frenchfry frenchfry)
        {
            _db.Execute(@"
      UPDATE frenchfries SET (name, description, price) 
      VALUES (@Name, @Description, @Price)
      WHERE id = @Id
      ", frenchfry);
            return frenchfry;
        }

        //DELETE frenchfry
        public Frenchfry Delete(Frenchfry frenchfry)
        {
            _db.Execute("DELETE FROM frenchfries WHERE id = @Id", frenchfry);
            return frenchfry;
        }

        public int Delete(int id)
        {
            return _db.Execute("DELETE FROM frenchfries WHERE id = @id", new { id });
        }


    }

}
