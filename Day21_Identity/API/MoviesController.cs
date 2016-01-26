using Day21_Identity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace Day21_Identity.API
{
    // Authorize attribute will only let logged in users have access
    [Authorize]
    public class MoviesController : ApiController
    {
        ApplicationDbContext _db = new ApplicationDbContext();

        public IHttpActionResult Get()
        {
            var user = User.Identity as ClaimsIdentity;

            if(!user.HasClaim("Admin", "true"))
            {
                return Unauthorized();
            }

            return Ok(_db.Movies.ToList());
        }

        public IHttpActionResult Get(int id)
        {
            return Ok(_db.Movies.Where(m => m.Id == id).FirstOrDefault());
        }
    }
}
