namespace Day21_Identity.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Security.Claims;

    internal sealed class Configuration : DbMigrationsConfiguration<Day21_Identity.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Day21_Identity.Models.ApplicationDbContext context)
        {
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new ApplicationUserManager(userStore);

            // Create a new user
            var user = userManager.FindByName("dan.do@codercamps.com");

            if (user == null)
            {
                user = new ApplicationUser
                {
                    UserName = "dan.do@codercamps.com",
                    Email = "dan.do@codercamps.com",
                    FirstName = "Dan",
                    LastName = "Do",
                };

                userManager.Create(user, "Secret123!");
                userManager.AddClaim(user.Id, new Claim("Admin", "true"));
                userManager.AddClaim(user.Id, new Claim("AwesomeLevel", "10"));
            }


            var user2 = userManager.FindByName("bob@bob.com");
            if (user2 == null)
            {
                user2 = new ApplicationUser
                {
                    UserName = "bob@bob.com",
                    Email = "bob@bob.com",
                    FirstName = "Bob",
                    LastName = "Smith"
                };

                userManager.Create(user2, "Secret123!");
                userManager.AddClaim(user2.Id, new Claim("AwesomeLevel", "9"));
            }


            var blogs = new Blog[]
            {
                new Blog { Title = "How awesome is HTML5", Message = "test message", IsActive = true, UserId = user.Id },
                new Blog { Title = "How awesome is AngularJS", Message = "test message", IsActive = true, UserId = user.Id },
                new Blog { Title = "How awesome is C#", Message = "test message", IsActive = true, UserId = user2.Id },
                new Blog { Title = "How awesome is .NET", Message = "test message", IsActive = true, UserId = user2.Id },
            };
            context.Blogs.AddOrUpdate(blogs);


            var comments = new Comment[]
            {
                new Comment { Message = "HTML5 is indeed awesome!!! 1", UserId = user2.Id, BlogId = 1 },
                new Comment { Message = "HTML5 is indeed awesome!!! 2", UserId = user2.Id, BlogId = 1},
                new Comment { Message = "HTML5 is indeed awesome!!! 3", UserId = user2.Id, BlogId = 1},
                new Comment { Message = "AngularJS is indeed awesome!!!", UserId = user2.Id, BlogId = 2 },
                new Comment { Message = "C# is indeed awesome!!!", UserId = user2.Id, BlogId = 3 },
                new Comment { Message = ".NET is indeed awesome!!!", UserId = user2.Id, BlogId = 4},
            };
            context.Comments.AddOrUpdate(comments);










            #region Seed Movies
            Movie[] movies = new Movie[]
            {
                new Movie { Title = "Terminator", Director = "Bob" },
                new Movie { Title = "Kill Bill", Director = "Jimmy" },
                new Movie { Title = "Star Wars 6", Director = "Lucas" }
            };

            context.Movies.AddOrUpdate(m => m.Title, movies);
            #endregion




        }
    }
}
