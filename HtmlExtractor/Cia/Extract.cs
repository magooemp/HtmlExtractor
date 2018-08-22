using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using HtmlAgilityPack;
using HtmlExtractor.Cia.Model;

namespace HtmlExtractor.Cia
{
	public class Extract
	{
		public static List<CiaFactBook> CountryDataRip( string sCountry )
		{
			// Oficial CIA URL for latest CiaFactBook information
			string urlCountry = "https:/"+$"/www.cia.gov/library/publications/the-world-factbook/geos/{sCountry}.html";

			HtmlDocument doc = new HtmlDocument();
			HtmlWeb webmain = new HtmlWeb();
			doc = webmain.Load( urlCountry );
			var htmlBody =  doc.DocumentNode.SelectSingleNode( "//div[@class='wfb-text-box']" );
			var vTable = doc.DocumentNode.SelectNodes("//ul[@class='expandcollapse']/li");

			List<CiaFactBook> CiaFactBookLines = new List<CiaFactBook>();

			foreach ( HtmlNode table in vTable )
			{
				var vRow = table.SelectNodes( "div");
				if ( vRow != null )
				{
					string sMasterTitle = string.Empty;	
					string sTitle= string.Empty;
					string sProperty= string.Empty;
					string sSpanTitle = string.Empty;
					string sSpanValue = string.Empty; 

					foreach ( HtmlNode row in vRow )
					{
						string vId = (row?.Attributes["id"]?.Value ?? "");
						string vClass =  (row?.Attributes["class"]?.Value ?? "");
						var vSpan = row.SelectNodes( "span");

						if ( vId == "field" ) // When id='field' is a Title, sTitle receive the inner text of html tag.
						{
							sTitle = row.InnerText;
						}
						if ( vClass == "category_data" ) // When class=category_data is value, now we have all variables we need and will create a ROW - CiaFactBook
						{
							sMasterTitle = row.ParentNode.PreviousSibling.InnerText;
							sProperty = row.InnerText;
							sProperty += "";

							CiaFactBook CiaFactBookLine = new CiaFactBook();

							CiaFactBookLine.Country = sCountry;
							CiaFactBookLine.Category = sMasterTitle;
							CiaFactBookLine.Title = sTitle;
							CiaFactBookLine.Subtitle = "";
							CiaFactBookLine.Value = sProperty;
							CiaFactBookLines.Add( CiaFactBookLine );
						}

						if ( vSpan != null ) // when tag is Span we have more than one value for the same 'Title' with differents 'Subtitles'
						{
							foreach ( HtmlNode span in vSpan )
							{
								string vSpanClass =  (span?.Attributes["class"]?.Value ?? "");

								if ( vSpanClass == "category" ) // when Class=category is SubTitle
								{
									sSpanTitle = span.InnerText; // receive the inner text os <span> tag
								}
								if ( vSpanClass == "category_data" )  // When class=category_data is value, now we have all variables we need and will create a ROW - CiaFactBook
								{
									sSpanValue = span.InnerText;

									CiaFactBook CiaFactBookLine = new CiaFactBook();
									CiaFactBookLine.Country = sCountry;
									CiaFactBookLine.Category = row.ParentNode.PreviousSibling.InnerText;
									CiaFactBookLine.Title = sTitle;
									CiaFactBookLine.Subtitle = sSpanTitle;
									CiaFactBookLine.Value = sSpanValue;
									CiaFactBookLines.Add( CiaFactBookLine );

								}
							} 
						} 
					} 
				}
			}

			return CiaFactBookLines; // List of CiaFactBook rows
		}

		
		public static List<CiaFactBookCountries> CountriesToRip( )
		{
			//oficial url of latest CiaFactBook information
			string urlCountry = @"https://www.cia.gov/library/publications/the-world-factbook/fields/2028.html";

			HtmlDocument doc = new HtmlDocument();
			HtmlWeb webmain = new HtmlWeb();
			doc = webmain.Load( urlCountry );
			var htmlBody =  doc.DocumentNode.SelectSingleNode( "//select[@class='selecter_links']" );

			var vTable = doc.DocumentNode.SelectNodes("//option");
			List<CiaFactBookCountries> lCiaFactBookCountries = new List<CiaFactBookCountries>();
			foreach ( HtmlNode row in vTable )
			{
				int iStart =  row.OuterHtml.IndexOf(".html");
				if ( iStart > 0 ) // Real Country data
				{
					CiaFactBookCountries CountryRow = new CiaFactBookCountries(); 
					CountryRow.CountryCode =  (row.OuterHtml.Substring( iStart-2,2)); // br=brazil us=united states
					CountryRow.CountryName = row.InnerText.Trim();
					lCiaFactBookCountries.Add( CountryRow );
				 }
			}
			return lCiaFactBookCountries; // List of Countries 
		}
	}
}
