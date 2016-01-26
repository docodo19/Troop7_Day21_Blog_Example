namespace MyApp.Controllers {

    export class MovieController {
        public movies;

        constructor(private movieService:MyApp.Services.MovieService) {
            this.movies = movieService.listMovies();
        }

    }
}