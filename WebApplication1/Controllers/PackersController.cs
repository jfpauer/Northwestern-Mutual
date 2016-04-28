using ClassLibrary1;
using ClassLibrary1.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebApplication1.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PackersController : ApiController
    {
        [Route("api/Packers/GetPackers")]
        [HttpGet]
        public List<PackersPlayer> GetPackers(string searchInput)
        {
            try
            {
                var service = ServiceFacadeFactory.CreateWebApplication1ServiceFacade();

                return service.GetPackers(searchInput);
            }
            catch (Exception ex)
            {
                string error = "Error with GetPlayerByNumber() in PackersController. Message[" + ex.Message + "]";
                Debug.WriteLine(error);
                return new List<PackersPlayer>() { new PackersPlayer() { Name = "Error in WebService", Number = ex.Message } };
            }
        }
    }
}
