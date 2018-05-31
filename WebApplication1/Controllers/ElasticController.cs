using Nest;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    public class ElasticController : ApiController
    {

        private static ConnectionSettings connSettings = new ConnectionSettings(new Uri("http://kb-ls4qlqhio6hqu.westeurope.cloudapp.azure.com:5601/"));

        private static ElasticClient client;

       

        public ElasticController()
        {
            connSettings.DisableDirectStreaming().PrettyJson()
                .BasicAuthentication("elastic", "0508386300T");
            client = new ElasticClient(connSettings);
        }


        public static ConnectionSettings ConnSettings => connSettings;

        [HttpGet]
       // [Route("Get_Index")]
        public IHttpActionResult GET(String Index)
        {
            var response = client.IndexExists(Index).Exists;
            if (response == false)
            {
                return NotFound();
            }
            return Ok(response);

            //
        }
        //Work in Progress not working yet
        [HttpPost]
        public IHttpActionResult POST([FromBody]dynamic Read, String index)
        {
            string q = Read.q();
            return Ok(q);
        }
    }
}
