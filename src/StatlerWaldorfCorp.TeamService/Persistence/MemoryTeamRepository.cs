using System.Collections.Generic;
using StatlerWaldorfCorp.TeamService.Models;

namespace StatlerWaldorfCorp.TeamService.Persistence
{
    public class MemoryTeamRepository : ITeamRepository
    {
        protected static ICollection<Team> _teams;

        public MemoryTeamRepository()
        {
            if (_teams == null)
            {
                _teams = new List<Team>();
            }
        }

        public MemoryTeamRepository(ICollection<Team> teams)
        {
            _teams = teams;
        }

        public IEnumerable<Team> GetTeams()
        {
            return _teams;
        }

        public void AddTeam(Team t)
        {
            _teams.Add(t);
        }
    }
}