using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class EndpointController : Controller
    {
        [HttpPost]
        public ActionResult TestEndpoint()
        {
            var response = new ResponseModel();
            var transactionModel = EndpointHelper.GetModelFromRequest(Request.InputStream);

            if (EndpointHelper.CheckTransactionModelHash(transactionModel))
            {
                
            }
            else
            {
                response.TransactionId = transactionModel.TransactionId;
                response.ResponseStatus = "FAILED";
                response.ResponseMessage = "invalid hash";
            }
            
            return Content(JsonConvert.SerializeObject(response));
        }

        
    }
}
