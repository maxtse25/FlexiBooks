using FlexiBooks.Models;

namespace FlexiBooks.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public DateTime DateIssued { get; set; }
        public decimal TotalAmount { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; } = null!;

        public ICollection<InvoiceItem> Items { get; set; } = new List<InvoiceItem>();
    }
}
