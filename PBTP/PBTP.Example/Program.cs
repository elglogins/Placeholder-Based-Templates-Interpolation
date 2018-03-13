using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PBTP.Core.Services;
using PBTP.Example.Models;

namespace PBTP.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            var templateParserService = new TemplateParserService();
            var model = new EmailReceiptMessageDataModel
            {
                TicketUrl = "http://yourticket.com",
                Order = new OrderModel
                {
                    Id = 12345,
                    Total = 99,
                    Firstname = "John",
                    Meetup = new MeetupModel
                    {
                        Location = new MeetupLocationModel
                        {
                            City = "New York",
                            Lat = 40.730610,
                            Long = -73.935242
                        },
                        Name = "EMOJI meetup",
                        StartsOn = new DateTime(2017, 4, 10, 16, 00, 00),
                    }
                }
            };

            var text = @"
                Hello {{Order.Firstname}},

                Order number #{{Order.Id}}

                Your ticket to {{Order.Meetup.Name}} for {{Order.Total}}$ is 
                available <a href=""{{TicketUrl}}"">here</a>.

                <strong>{{Order.Meetup.StartsOn}} @ {{Order.Meetup.Location.City}} </strong>
            ";

            var result = templateParserService.Interpolate(model, text);
            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}
