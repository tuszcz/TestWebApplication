using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class ResponseModel
    {
        public string TransactionId { get; set; }
        public string ResponseStatus { get; set; }
        public string ResponseMessage { get; set; }
    }
}