namespace FlexiBooks.DTOs
{
    public class InvoiceCreateDto
    {
        public int ClientId { get; set; }
        public DateTime DateIssued { get; set; }
        public List<InvoiceItemDto> Items { get; set; } = new();
    }

    public class InvoiceItemDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
