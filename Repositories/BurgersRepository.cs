using System.Collections.Generic;
using System.Data;
using System.Linq;
using burgershack.Models;
using Dapper;

namespace burgershack.Repositories
{


    public class BurgersRepository
    {
        private IDbConnection _db;


        public BurgersRepository(IDbConnection db)
        {
            _db = db;
        }

        // Crud Via SQL


        // GET ALL BURGERS

        public IEnumerable<Burger> GetAll()
        {
            return _db.Query<Burger>($"SELECT * FROM burgers");
            // query runs the sql command SELECT from all the burgers
        }
        //GET BURGER BY ID


        public Burger GetById(int id)
        {
            return _db.Query<Burger>("SELECT * FROM burgers WHERE id = @id", new { id }).FirstOrDefault();
            // this "dynamic" creates a brand new object with the property id.  Dapper will parse the id into the object.  dapper keeps you safe.

        }

        //CREATE BURGER

        // this burger here does not have the id on it.  When i return it, put an id on it.
        public Burger Create(Burger burger)
        {
            // executeScalar runs multiple lines of sql and puts them in order
            int id = _db.ExecuteScalar<int>(@"
        INSERT INTO burgers (name, description, price)
        VALUES (@Name, @Description, @Price);
        SELECT LAST_INSERT_ID();", burger
            );
            burger.Id = id;
            return burger;
        }

        // the add tells dapper where to inject text and sanitize.
        //dapper is your final safety check before it hits your database.


        // this returns the id of the record just inserted.  
        // takes the item, puts it in database, before it leaves database, asks what the id is, the database responds and it says thanks i'm gonna put it in there.

        //UPDATE BURGER
        public Burger Update(Burger burger)
        {

            _db.Execute(@"
        UPDATE burgers SET (name, description, price)) 
        VALUES (@Name, @Description, @Price)
        WHERE id = @Id
        ", burger);
            return burger;

        }

        // putting id in parameters will fail
        //DELETE BURGER

        public int Delete(int id)
        {
            return _db.Execute("DELETE FROM burgers WHERE id = @id", new { id });
        }



    }







}

