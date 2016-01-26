namespace MyApp.Controllers {

    export class BlogDetailsController {
        public data;
        private blogId;
        private blogResource;
        constructor(private $resource:ng.resource.IResourceService, private $routeParams:ng.route.IRouteParamsService) {

            this.blogResource = $resource('/api/blogs/:id');
            this.blogId = $routeParams['id'];
            this.getBlog(this.blogId);

        }

        public getBlog(id) {
            this.data = this.blogResource.get({ id: id });
            console.log(this.data);
        }

    }



}