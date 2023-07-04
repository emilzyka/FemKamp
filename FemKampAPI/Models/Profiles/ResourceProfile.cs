using AutoMapper;
using FemKampAPI.Models.Dtos;

namespace FemKampAPI.Models.Profiles
{
    public class ResourceProfile : Profile
    {
        public ResourceProfile()
        {
            CreateMap<ResourceGroup, ResourceResponse>();
            CreateMap<ResourceCreate, ResourceGroup>();
        }
    }
}
