using AutoMapper;
using FlexiBooks.Models;
using FlexiBooks.DTOs;

namespace FlexiBooks.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // OUT: Entity → DTO
            CreateMap<Invoice, InvoiceDto>()
                .ForMember(dest => dest.ClientName, opt => opt.MapFrom(src => src.Client.Name));

            CreateMap<InvoiceItem, InvoiceItemDto>();

            // IN: DTO → Entity
            CreateMap<InvoiceCreateDto, Invoice>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.TotalAmount, opt => opt.Ignore())
                .ForMember(dest => dest.Client, opt => opt.Ignore());

            CreateMap<InvoiceItemDto, InvoiceItem>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.InvoiceId, opt => opt.Ignore())
                .ForMember(dest => dest.Invoice, opt => opt.Ignore())
                .ForMember(dest => dest.Product, opt => opt.Ignore());
        }
    }
}
