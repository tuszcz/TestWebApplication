using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class TransactionModel
    {
        public string TransactionId { get; set; }
        public string Hash { get; set; }

        public ClientDataModel ClientData { get; set; }
        public ReservationModel Reservation { get; set; }
    }
}