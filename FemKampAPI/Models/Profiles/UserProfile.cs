using AutoMapper;
using FemKampAPI.Models.Dtos;

namespace FemKampAPI.Models.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserResponse>();
            CreateMap<UserCreate, User>();
        }
    }
}
