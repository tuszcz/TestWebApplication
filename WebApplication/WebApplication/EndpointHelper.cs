using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace WebApplication
{
    public static class EndpointHelper
    {
        public static string GetModelFromRequest(Stream requestStream)
        {
            //requestStream.Seek(0, SeekOrigin.Begin);

            var jsonString = new StreamReader(requestStream).ReadToEnd();

            return jsonString;
        }
    }
}