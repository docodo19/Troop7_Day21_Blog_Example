using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Day21_Identity.Models
{
    public class BlogViewModel
    {
        public Blog Blog { get; set; }
        public List<Comment> Comments { get; set; }
    }
}