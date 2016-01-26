var MyApp;
(function (MyApp) {
    var Controllers;
    (function (Controllers) {
        var BlogDetailsController = (function () {
            function BlogDetailsController($resource, $routeParams) {
                this.$resource = $resource;
                this.$routeParams = $routeParams;
                this.blogResource = $resource('/api/blogs/:id');
                this.blogId = $routeParams['id'];
                this.getBlog(this.blogId);
            }
            BlogDetailsController.prototype.getBlog = function (id) {
                this.data = this.blogResource.get({ id: id });
                console.log(this.data);
            };
            return BlogDetailsController;
        })();
        Controllers.BlogDetailsController = BlogDetailsController;
    })(Controllers = MyApp.Controllers || (MyApp.Controllers = {}));
})(MyApp || (MyApp = {}));
//# sourceMappingURL=BlogDetailsController.js.map