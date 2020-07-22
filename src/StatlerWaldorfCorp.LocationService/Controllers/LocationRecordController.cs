using System;
using Microsoft.AspNetCore.Mvc;
using StatlerWaldorfCorp.LocationService.Models;

namespace StatlerWaldorfCorp.LocationService.Controllers
{
    [Route("locations/{memberId}")]
    public class LocationRecordController : Controller
    {
        private readonly ILocationRecordRepository locationRepository;
        public LocationRecordController(ILocationRecordRepository locationRepository)
        {
            this.locationRepository = locationRepository;
        }

        [HttpPost]
        public IActionResult AddLocation(Guid memberId, [FromBody] LocationRecord locationRecord)
        {
            locationRepository.Add(locationRecord);
            return this.Created($"locations/{memberId}/{locationRecord.ID}", locationRecord);
        }

        [HttpGet]
        public IActionResult GetAll(Guid memberId)
        {
            var all = locationRepository.AllForMember(memberId);
            return this.Ok(all);
        }

        [HttpGet("latest")]
        public IActionResult GetLatestForMember(Guid memberId)
        {
            var latest = locationRepository.GetLatestForMember(memberId);
            return this.Ok(latest);
        }
    }
}