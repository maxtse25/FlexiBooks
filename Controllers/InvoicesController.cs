using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FlexiBooks.Data;
using FlexiBooks.Models;
using FlexiBooks.DTOs;

namespace FlexiBooks.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvoicesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public InvoicesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/invoices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Invoice>>> GetInvoices()
        {
            return await _context.Invoices
                .Include(i => i.Client)
                .Include(i => i.Items)
                    .ThenInclude(ii => ii.Product)
                .ToListAsync();
        }

        // POST: api/invoices
        [HttpPost]
        public async Task<ActionResult<Invoice>> CreateInvoice(InvoiceCreateDto dto)
        {
            var invoice = new Invoice
            {
                ClientId = dto.ClientId,
                DateIssued = dto.DateIssued,
                TotalAmount = dto.Items.Sum(i => i.UnitPrice * i.Quantity),
                Items = dto.Items.Select(i => new InvoiceItem
                {
                    ProductId = i.ProductId,
                    Quantity = i.Quantity,
                    UnitPrice = i.UnitPrice
                }).ToList()
            };

            _context.Invoices.Add(invoice);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetInvoices), new { id = invoice.Id }, invoice);
        }
    }
}
