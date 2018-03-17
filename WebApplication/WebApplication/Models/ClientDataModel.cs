using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class ClientDataModel
    {
        public string Name { get; set; }
        public AddressModel Address { get; set; }
    }
}