var MyApp;
(function (MyApp) {
    var Controllers;
    (function (Controllers) {
        var MovieController = (function () {
            function MovieController(movieService) {
                this.movieService = movieService;
                this.movies = movieService.listMovies();
            }
            return MovieController;
        })();
        Controllers.MovieController = MovieController;
    })(Controllers = MyApp.Controllers || (MyApp.Controllers = {}));
})(MyApp || (MyApp = {}));
//# sourceMappingURL=MovieController.js.map