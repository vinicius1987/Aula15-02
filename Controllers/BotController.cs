using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Google.Cloud.Dialogflow.V2;
using Google.Protobuf;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebhookDF.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BotController : ControllerBase
    {
		private static readonly JsonParser _jsonParser = new JsonParser(JsonParser.Settings.Default.WithIgnoreUnknownFields(true));

		System.Text.Json.JsonSerializerOptions _jsonSetting = new System.Text.Json.JsonSerializerOptions()
		{
			PropertyNameCaseInsensitive = true
		};

		string _agentName = "botunoeste-tojago";

		public BotController()
		{
		}


		[HttpGet]
        public IActionResult Get()
        {
			return Ok(new { msg = "deu certo" });
        }

		private bool Autorizado(IHeaderDictionary httpHeader)
		{

			string basicAuth = httpHeader["Authorization"];

			if (!string.IsNullOrEmpty(basicAuth))
			{
				basicAuth = basicAuth.Replace("Basic ", "");

				byte[] aux = System.Convert.FromBase64String(basicAuth);
				basicAuth = System.Text.Encoding.UTF8.GetString(aux);

				if (basicAuth == "nome:token")
					return true;
			}

			return false;
		}
		
		

	}
}
 