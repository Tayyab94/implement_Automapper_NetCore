using AutoMapper;
using MapperApp.Models;
using MapperApp.Models.DTOS.IncomingDTOs;
using MapperApp.Models.DTOS.OutgoingDTOs;

namespace MapperApp.Profiles
{
    public class DriverProfile: Profile
    {
        public DriverProfile() {
            CreateMap<DriverForCreationDTO, Driver>()
                .ForMember(dest=> dest.Id,
                act=> act.MapFrom(src=>Guid.NewGuid()))
                .ForMember(dest => dest.FirstName,
                act => act.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName,
                act => act.MapFrom(src => src.LastName))
                .ForMember(dest => dest.DriverNumber,
                act => act.MapFrom(src => src.DriverNumber))
                .ForMember(dest => dest.WorldChampianShip,
                act => act.MapFrom(src => src.WorldChampianship))
                .ForMember(dest => dest.status,
                act => act.MapFrom(src => 1))
                .ForMember(dest => dest.AddedDate,
                act => act.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.UpdatedDate,
                act => act.MapFrom(src => DateTime.UtcNow));


            // This Mapper is useing to get the List of User's Record
            CreateMap<Driver, DriverDTO>()
                .ForMember(dest => dest.FullName, act => act.MapFrom(src => $"{src.FirstName} {src.LastName}"))
                .ForMember(dest => dest.Id, act => act.MapFrom(src => src.Id))
                .ForMember(dest => dest.DriverNo, act => act.MapFrom(src => src.DriverNumber))
                .ForMember(dest => dest.WorldChampianships, act => act.MapFrom(src => src.WorldChampianShip));


        }


    }
}
