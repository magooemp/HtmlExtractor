using System.Collections.Generic;
using System.Web.Http;
using HtmlExtractor.Cia;
using HtmlExtractor.Cia.Model;

namespace HtmlExtractor.Api.Controllers
{
	[RoutePrefix("api/cia")]
    public class CiaController : ApiController
    {
		// GET: api/Cia
		// Will returns a List of avaliable countries
		[HttpGet]
		[Route( "countries" )]
		public IEnumerable<CiaFactBookCountries> Countries(  )
		{ 
			return Extract.CountriesToRip();
		}


		// GET: api/Cia
		// Will returns all information about selected country 

		[HttpGet]
		[Route( "{Country}" )]
		public IEnumerable<CiaFactBook> Get( string Country )
		{
			return Extract.CountryDataRip( Country ); // List of CiaFactBook rows
		} 
	}
}
