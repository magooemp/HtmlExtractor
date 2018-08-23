using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace HtmlExtractor.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
			// Web API configuration and services
			var cors = new EnableCorsAttribute("*","*","*");
			config.EnableCors( cors );
			//TODO: Configurar cors para origin=site q pode, header q pode (nao usar), tipo de requisicao (get, post, put)

			// Web API routes
			config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
			// I am testing... // This code isn't useful..
			config.Routes.MapHttpRoute(
			   name: "DefaultApistring",
			   routeTemplate: "api/{controller}/outrarota/{nome}",
			   defaults: new { nome = RouteParameter.Optional }
		   );
			// -------
		}
    }
}
