var MyApp;
(function (MyApp) {
    var Controllers;
    (function (Controllers) {
        var BlogsController = (function () {
            function BlogsController($resource) {
                this.blogResource = $resource('/api/blogs/:id');
                this.getBlogs();
            }
            BlogsController.prototype.getBlogs = function () {
                this.blogs = this.blogResource.query();
            };
            return BlogsController;
        })();
        Controllers.BlogsController = BlogsController;
    })(Controllers = MyApp.Controllers || (MyApp.Controllers = {}));
})(MyApp || (MyApp = {}));
//# sourceMappingURL=BlogsController.js.map