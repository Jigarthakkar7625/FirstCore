using AutoMapper;
using FirstCore.Data.Models;
using FirstCore.Models;

namespace FirstCore.AutoMapperProfile
{
    public class UserAddressProfile : Profile
    {
        public UserAddressProfile()
        {

            // Outgoing
            CreateMap<UserAddressDTO, UserAddress>();

            // Incoming
            CreateMap<UserAddress, UserAddressDTO>();

        }
    }
}
