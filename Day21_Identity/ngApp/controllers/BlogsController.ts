namespace MyApp.Controllers {

    export class BlogsController {
        public blogs;
        private blogResource;

        constructor($resource:ng.resource.IResourceService) {
            this.blogResource = $resource('/api/blogs/:id');
            this.getBlogs();
        }

        public getBlogs() {
            this.blogs = this.blogResource.query();
        }

    }



}