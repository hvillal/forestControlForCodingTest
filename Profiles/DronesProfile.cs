using AutoMapper;
using FirstAPI.Helpers;
using FirstAPI.Models;

namespace FirstAPI.Profiles
{
    public class DronesProfile : Profile
    {
        public DronesProfile()
        {
            CreateMap<DroneInput, Drone>()
                .ForMember(
                    dest => dest.InitialPosition,
                    opt => opt.MapFrom(src => src.InitialPosition.GetDronePosition())
                )
                .ForMember(
                    dest => dest.Actions,
                    opt => opt.MapFrom(src => src.Actions.GetDroneActions())
                );
            CreateMap<Drone, DroneOutput>()
                .ForMember(
                    dest => dest.FinalPosition,
                    opt => opt.MapFrom(src => $"{src.FinalPosition.PositionX} {src.FinalPosition.PositionY} {(char)src.FinalPosition.Direction}")
                );
        }
    }
}
