using System.Linq;
using System.Web.Http;
using WIV.Data.Repositories;
using WIV.Domain;

namespace WIV.Api.Controllers
{
    [RoutePrefix("workitems")]
    public class WorkItemsController : ApiController
    {
        private readonly WorkItemRepository repo = new WorkItemRepository();

        [HttpGet]
        [Route("getall")]
        public IHttpActionResult GetAll([FromUri]Pagination pagination)
        {
            pagination = pagination ?? new Pagination();

            var results = repo.GetAll();
            var total = results.Count();

            if (pagination.HasOffset)
                results = results.Skip(pagination.Offset.Value);
            results = results.Take(pagination.Limit);

            var result = new PagedResults<WorkItem>()
            {
                Limit = pagination.Limit,
                Count = results.Count(),
                Offset = pagination.Offset.GetValueOrDefault(),
                Total = total,
                Results = results,
            };

            return Ok(result);
        }

        protected override void Dispose(bool disposing)
        {
            repo.Dispose();
            base.Dispose(disposing);
        }
    }
}
