using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Helpers;
using Newtonsoft.Json;
using WebApplication.Helpers;
using WebApplication.Models;

namespace WebApplication
{
    public static class EndpointHelper
    {
        public static TransactionModel GetModelFromRequest(Stream requestStream)
        {
            requestStream.Seek(0, SeekOrigin.Begin);

            var jsonString = new StreamReader(requestStream).ReadToEnd();
            return JsonConvert.DeserializeObject<TransactionModel>(jsonString);
        }

        public static bool CheckTransactionModelHash(TransactionModel transactionModel)
        {
            var hashString = GetTransactionHashString(transactionModel);

            var hash = CryptographyHelper.GetHashSha256(hashString);

            return transactionModel.Hash == hash;
        }

        private static string GetTransactionHashString(TransactionModel transactionModel)
        {
            var stringBuilder = new StringBuilder();

            stringBuilder
                .Append(transactionModel.TransactionId).Append('|')
                .Append(transactionModel.ClientData.Name).Append('|')
                .Append(transactionModel.ClientData.Address.Country).Append('|')
                .Append(transactionModel.ClientData.Address.PostalCode).Append('|')
                .Append(transactionModel.ClientData.Address.City).Append('|')
                .Append(transactionModel.Reservation.ReservationId).Append('|')
                .Append(transactionModel.Reservation.ReservationStatus).Append('|')
                .Append(ConfigurationManager.AppSettings["EndpointPrivateKey"]);

            return stringBuilder.ToString();
        }
    }
}