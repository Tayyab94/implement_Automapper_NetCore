using AutoMapper;
using AutoMapper_CodeProject.Models;
using AutoMapper_CodeProject.Models.CustomConvertor;
using AutoMapper_CodeProject.Models.DTOs;

namespace AutoMapper_CodeProject.Profiles
{
    public class AutoMapperProfile :Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Team, TeamMember>()
                .ForMember(dest => dest.TeamId, act => act.MapFrom(src => src.Id))
                .ForMember(dest => dest.TeamName, act => act.MapFrom(src => src.Name));


            CreateMap<People, TeamMember>()
              .ForMember(dest => dest.PeopleId, act => act.MapFrom(src => src.Id))
              .ForMember(dest => dest.PeopleName, act => act.MapFrom(src => src.Name));


            CreateMap<Team, IEnumerable<TeamMember>>()
                .ConvertUsing<TeanToTeamMemberListConverter>();


            CreateMap<TeamMember, Team>()
                .ForMember(dest => dest.Id, act => act.MapFrom(src => src.TeamId))
                  .ForMember(dest => dest.Name, act => act.MapFrom(src => src.TeamName));



            CreateMap<TeamMember, People>()
                .ForMember(dest => dest.Id, act => act.MapFrom(src => src.PeopleId))
                  .ForMember(dest => dest.Name, act => act.MapFrom(src => src.PeopleName));

            CreateMap<IEnumerable<TeamMember>, IEnumerable<Team>>()
    .ConvertUsing<TeamMemberListToTeamConverter>();

        }
    }

}
