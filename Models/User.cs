using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace burgershack.Models
{

    public class UserLogin
    { // HELPER MODEL
      // this is the info I need to create a user, its to keep it private.
      // this is your login form and registration form
      // this is the info your client has to pass on the frontend.

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        public string password { get; set; }


    }

    public class UserRegistration
    { // HELPER MODEL
      // this is the info I need to create a user, its to keep it private.
      // this is your login form and registration form
      // this is the info your client has to pass on the frontend.

        [Required]
        [EmailAddress]
        public string Email { get; set; }


    }

    public class User
    {

        public string Id { get; set; }

        public bool Active { get; set; } = true;


        public string Username { get; set; }

        [Required]


        internal string Hash { get; set; }
        // internal means the front end never recieves it.  
        // Hash is to retrieve a user by their email.
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public ClaimsPrincipal _principal { get; private set; }
        // this is your token.  Its the id that points to your user object.

        internal void SetClaims()
        {

            // this is saying req.session.uid = id
            var claims = new List<Claim>{
                new Claim(ClaimTypes.Email, Email),
                new Claim(ClaimTypes.NameIdentifier, Id)
            };
            var userIdentity = new ClaimsIdentity(claims, "login");
            _principal = new ClaimsPrincipal(userIdentity);

        }


        // public User(){
        //     Email = "J@j.com"
        // };






    }


}