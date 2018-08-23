using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HtmlExtractor.Api.Controllers
{
	// I am testing... // This code isn't useful..
	#region TESTing...
	public class TestController : ApiController
    {
        // GET: api/Test
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

		// GET: api/Test/5
		public string Get( int id )
		{
			return "value";
		}

		// GET: api/Test/5
		public string Get( string nome )
		{
			return "value nome";
		}

		// POST: api/Test
		public void Post([FromBody]string value)
        {
        }

        // PUT: api/Test/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Test/5
        public void Delete(int id)
        {
        }
    }
#endregion
}
