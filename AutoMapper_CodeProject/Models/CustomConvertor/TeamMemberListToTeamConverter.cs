using AutoMapper;
using AutoMapper_CodeProject.Models.DTOs;

namespace AutoMapper_CodeProject.Models.CustomConvertor
{
    public class TeamMemberListToTeamConverter : ITypeConverter<IEnumerable<TeamMember>, IEnumerable<Team>>
    {
        public IEnumerable<Team> Convert
            (IEnumerable<TeamMember> source, IEnumerable<Team> destination, ResolutionContext context)
        {
            var teams = source.DistinctBy(m => new { m.TeamId, m.TeamName })
                .Select(member => context.Mapper.Map<Team>(member));

            foreach (var team in teams)
            {
                team.Members = new List<People>();
                foreach (var member in source.Where(s => s.TeamId == team.Id && s.TeamName == team.Name))
                {
                    team.Members.Add(context.Mapper.Map<People>(member));
                }
                yield return team;
            }
            /*
         List<int> ids = new List<int>();
         foreach (var item in source)
         {
             int id = item.TeamId;
             if (ids.Contains(id))
             {
                 continue;
             }
             var model = context.Mapper.Map<Team>(item);
             model.Members = new List<People>();
             foreach (var people in source.Where(x => x.TeamId == model.Id && x.TeamName == model.Name))
             {
                 model.Members.Add(context.Mapper.Map<People>(people));
             }
             ids.Add(id);
             yield return model;
         }
         */


        }
    }
}
