using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using WebApplication.Models;

namespace WebApplication.Repositories
{
    public class TestRepository
    {
        private readonly TestDatabaseEntities _databaseEntities = new TestDatabaseEntities();

        public bool SaveReservation(ReservationModel reservationModel)
        {
            try
            {
                var reservationStatus = new ReservationsStatus
                {
                    ReservationId = reservationModel.ReservationId,
                    Confirmed = reservationModel.ReservationStatus == "CONFIRMED"
                };

                _databaseEntities.ReservationsStatus.Add(reservationStatus);
                _databaseEntities.SaveChanges();

                return true;
            }
            catch (Exception e)
            {
                // TODO: add an exception log
                return false;
            }
        }
    }
}