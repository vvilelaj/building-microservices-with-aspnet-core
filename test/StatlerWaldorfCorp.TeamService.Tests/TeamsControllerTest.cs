using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using StatlerWaldorfCorp.TeamService.Models;
using Xunit;

namespace StatlerWaldorfCorp.TeamService.Tests
{
    public class TeamsControllerTest
    {
        TeamsController controller = new TeamsController(new TestMemoryTeamRepository());

        [Fact]
        public async void QueryTeamListReturnsCorrectTeams()
        {
           TeamsController controller = new TeamsController(new TestMemoryTeamRepository());
            var rawTeams = (IEnumerable<Team>)(await controller.GetAllTeams() as ObjectResult).Value;
            List<Team> teams = new List<Team>(rawTeams);
            Assert.Equal(teams.Count, 2);
            Assert.Equal(teams[0].Name, "one");
            Assert.Equal(teams[1].Name, "two");  
        }

        [Fact]
        public async void CreateTeamAddsTeamToList()
        {
            TeamsController controller = new TeamsController(new TestMemoryTeamRepository());
            var teams = (IEnumerable<Team>)
              (await controller.GetAllTeams() as ObjectResult).Value;
            List<Team> original = new List<Team>(teams);

            Team t = new Team("sample");
            var result = await controller.CreateTeam(t);

            var newTeamsRaw =
             (IEnumerable<Team>)
               (await controller.GetAllTeams() as ObjectResult).Value;

            List<Team> newTeams = new List<Team>(newTeamsRaw);
            Assert.Equal(newTeams.Count, original.Count + 1);
            var sampleTeam =
             newTeams.FirstOrDefault(
               target => target.Name == "sample");
            Assert.NotNull(sampleTeam);
        }
    }
}
