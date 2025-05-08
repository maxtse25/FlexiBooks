namespace FlexiBooks.DTOs
{
    public class InvoiceDto
    {
        public int Id { get; set; }
        public DateTime DateIssued { get; set; }
        public decimal TotalAmount { get; set; }

        public string? ClientName { get; set; }
        public List<InvoiceItemDto> Items { get; set; } = new();
    }
}
