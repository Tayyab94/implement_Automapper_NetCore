using AutoMapper;
using AutoMapper_CodeProject.Models.DTOs;

namespace AutoMapper_CodeProject.Models.CustomConvertor
{
    public class TeanToTeamMemberListConverter : ITypeConverter<Team, IEnumerable<TeamMember>>
    {
        public IEnumerable<TeamMember> Convert
            (Team source, IEnumerable<TeamMember> destination, ResolutionContext context)
        {
            // first Map from the People then from team
            foreach (var model in source.Members.Select(s => context.Mapper.Map<TeamMember>(s)))
            {
                context.Mapper.Map(source, model);
                yield return model;
            }
          
        }
    }
}
