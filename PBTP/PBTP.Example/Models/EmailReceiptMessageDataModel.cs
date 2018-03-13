using PBTP.Core.Models;

namespace PBTP.Example.Models
{
    public class EmailReceiptMessageDataModel : BaseTemplateDataModel
    {
        public string TicketUrl { get; set; }

        public OrderModel Order { get; set; }
    }
}
