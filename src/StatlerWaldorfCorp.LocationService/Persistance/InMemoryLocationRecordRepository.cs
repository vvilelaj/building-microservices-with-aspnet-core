using System;
using System.Collections.Generic;
using System.Linq;
using StatlerWaldorfCorp.LocationService.Models;

namespace StatlerWaldorfCorp.LocationService.Persistance
{
    public class InMemoryLocationRecordRepository : ILocationRecordRepository
    {
        protected static ICollection<LocationRecord> _locations;

        public InMemoryLocationRecordRepository()
        {
            if (_locations == null)
            {
                _locations = new List<LocationRecord>();
            }
        }
        public LocationRecord Add(LocationRecord locationRecord)
        {
            _locations.Add(locationRecord);
            return locationRecord;
        }

        public ICollection<LocationRecord> AllForMember(Guid memberId)
        {
            return _locations
                .Where(location => location.MemberID == memberId)
                .Select(LocationRecord => new LocationRecord
                {
                    ID = LocationRecord.ID,
                    Latitude = LocationRecord.Latitude,
                    Longitude = LocationRecord.Longitude,
                    Altitude = LocationRecord.Altitude,
                    Timestamp = LocationRecord.Timestamp,
                    MemberID = LocationRecord.MemberID
                })
                .ToList();
        }

        public LocationRecord Delete(Guid memberId, Guid recordId)
        {
            throw new NotImplementedException();
        }

        public LocationRecord Get(LocationRecord locationRecord)
        {
            throw new NotImplementedException();
        }

        public LocationRecord GetLatestForMember(Guid memberId)
        {
            return _locations.Max();
        }

        public LocationRecord Update(LocationRecord locationRecord)
        {
            throw new NotImplementedException();
        }
    }
}