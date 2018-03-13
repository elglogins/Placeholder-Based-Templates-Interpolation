using System;

namespace PBTP.Example.Models
{
    public class OrderModel
    {
        public int Id { get; set; }

        public string Firstname { get; set; }

        public decimal Total { get; set; }

        public MeetupModel Meetup { get; set; }


    }
}
