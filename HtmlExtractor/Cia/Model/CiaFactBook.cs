using System;
using System.Collections.Generic;
using System.Text;

namespace HtmlExtractor.Cia.Model
{
	public class CiaFactBook
	{
		public string Country { get; set; }
		public string Category { get; set; }
		public string Title { get; set; }
		public string Subtitle { get; set; }
		public string Value { get; set; }
	}
	public class CiaFactBookCountries
	{
		public string CountryCode { get; set; }
		public string CountryName { get; set; } 
	}
}
