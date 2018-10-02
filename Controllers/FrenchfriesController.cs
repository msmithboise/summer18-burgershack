using System;
using System.Collections.Generic;
using burgershack.Models;
using burgershack.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace burgershack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FrenchfriesController : Controller
    {
        FrenchfriesRepository _repo;

        public FrenchfriesController(FrenchfriesRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IEnumerable<Frenchfry> Get()
        {
            return _repo.GetAll();
        }

        [HttpPost]
        public Frenchfry Post([FromBody] Frenchfry frenchfry)
        {
            if (ModelState.IsValid)
            {
                frenchfry = new Frenchfry(frenchfry.Name, frenchfry.Description, frenchfry.Price);
                return _repo.Create(frenchfry);
            }
            throw new Exception("INVALID Frenchfry");
        }

    }

}