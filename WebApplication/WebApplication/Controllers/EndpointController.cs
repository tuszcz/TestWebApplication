using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using WebApplication.Models;
using WebApplication.Repositories;

namespace WebApplication.Controllers
{
    public class EndpointController : Controller
    {
        [HttpPost]
        public ActionResult TestEndpoint()
        {
            string responseStatus;
            var responseMessage = string.Empty;

            var response = new ResponseModel();
            var transactionModel = EndpointHelper.GetModelFromRequest(Request.InputStream);
            
            // TODO: input string log

            if (EndpointHelper.CheckTransactionModelHash(transactionModel))
            {
                var repository = new TestRepository();

                var result = repository.SaveReservation(transactionModel.Reservation);

                responseStatus = result ? "SUCCESS" : "FAILED";
            }
            else
            {
                responseStatus = "FAILED";
                responseMessage = "invalid hash";
            }

            response.TransactionId = transactionModel.TransactionId;
            response.ResponseStatus = responseStatus;
            response.ResponseMessage = responseMessage;
            
            // TODO: response log

            return Content(JsonConvert.SerializeObject(response));
        }
    }
}
