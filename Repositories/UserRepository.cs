using System;
using System.Data;
using System.Linq;
using BCrypt.Net;
using burgershack.Models;
using Dapper;

namespace burgershack.Repositories
{
    public class UserRepository
    {
        IDbConnection _db;
        //Login  C


        //Register 

        public User Register(UserRegistration creds)
        {
            // generate the user id
            // HASH THE PASSWORD
            string id = Guid.NewGuid().ToString();
            string hash = BCrypt.Net.BCrypt.HashPassword(creds.Password);
            int success = _db.Execute(@"
           INSERT INTO users (id, username, email, hash);
           VALUES (@id, @username, @email, @hash)
           ", new
            {
                id,
                username = creds.Username,
                email = creds.Email,
                hash
            });

            if (success != 1) { return null; }

            return new User()
            {
                Username = creds.Username,
                Email = creds.Email,
                Hash = null,
                Id = id
            };
            public User(IDbConnection db)
            {
                _db = db;
            }






        }
        // Update U

        public User Login(UserLogin creds)
        {
            User user = _db.Query<User>(@"
               SELECT * FROM users WHERE email = @Email 
               ", creds).FirstOrDefault();

            if (user == null) { return null; }
            bool validPass = BCrypt.Net.BCrypt.Verify(creds.password, user.Hash);
            if (!validPass) { return null; }
            user.Hash = null;
            return user;

        }


        //  Change Password U

        // Delete D
    }