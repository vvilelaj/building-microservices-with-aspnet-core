using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StatlerWaldorfCorp.TeamService.Models;
using StatlerWaldorfCorp.TeamService.Persistence;

namespace StatlerWaldorfCorp.TeamService
{
    public class TeamsController : Controller
    {
        ITeamRepository repository;

        public TeamsController()
        {
        }

        public TeamsController(ITeamRepository repo)
        {
            repository = repo;
        }

        [HttpGet]
        public async virtual Task<IActionResult> GetAllTeams()
        {
            return this.Ok(repository.GetTeams());
        }

        public  async virtual Task<IActionResult> CreateTeam(Team t)
        {
            this.repository.AddTeam(t); 
            return Ok();
        }
    }
}