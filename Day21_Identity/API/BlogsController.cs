using Day21_Identity.Models;
using Microsoft.AspNet.Identity; // Brings is various tools for getting user related tools
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Day21_Identity.API
{
    public class BlogsController : ApiController
    {
        ApplicationDbContext _db = new ApplicationDbContext();


        [Authorize]
        public IHttpActionResult Get()
        {
            var userId = User.Identity.GetUserId();
            var data = _db.Blogs.Where(b => b.UserId == userId && b.IsActive == true).ToList();
            return Ok(data);
        }

        [Authorize]
        public IHttpActionResult Get(int id)
        {
            var userId = User.Identity.GetUserId();

            var data = new BlogViewModel();
            data.Blog = _db.Blogs.Where(b => b.Id == id && b.UserId == userId).FirstOrDefault();
            data.Comments = _db.Comments.Where(c => c.BlogId == id).ToList();

            return Ok(data);
        }


    }
}
