using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Controllers
{
    public class EndpointController : Controller
    {
        [HttpPost]
        public ActionResult TestEndpoint()
        {
            var jsonString = EndpointHelper.GetModelFromRequest(Request.InputStream);
            

            return null;
        }

        
    }
}
