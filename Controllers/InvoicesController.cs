using AutoMapper;
using FlexiBooks.Data;
using FlexiBooks.DTOs;
using FlexiBooks.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlexiBooks.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvoicesController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public InvoicesController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/invoices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InvoiceDto>>> GetInvoices()
        {
            var invoices = await _context.Invoices
                .Include(i => i.Client)
                .Include(i => i.Items)
                    .ThenInclude(ii => ii.Product)
                .ToListAsync();

            return Ok(_mapper.Map<IEnumerable<InvoiceDto>>(invoices));
        }

        // POST: api/invoices
        [HttpPost]
        public async Task<ActionResult<InvoiceDto>> CreateInvoice(InvoiceCreateDto dto)
        {
            var invoice = _mapper.Map<Invoice>(dto);
            invoice.TotalAmount = dto.Items.Sum(i => i.UnitPrice * i.Quantity);

            _context.Invoices.Add(invoice);
            await _context.SaveChangesAsync();

            var result = _mapper.Map<InvoiceDto>(invoice);
            return CreatedAtAction(nameof(GetInvoices), new { id = invoice.Id }, result);
        }
    }
}
