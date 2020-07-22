using System;
using System.Diagnostics.CodeAnalysis;

namespace StatlerWaldorfCorp.LocationService.Models
{
    public class LocationRecord : IComparable<LocationRecord>
    {
        public LocationRecord()
        {
            ID = Guid.NewGuid();
        }
        public Guid ID { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public float Altitude { get; set; }
        public long Timestamp { get; set; }
        public Guid MemberID { get; set; }

        public int CompareTo([AllowNull] LocationRecord other)
        {
            if(Timestamp == other?.Timestamp) return 0;
            if(Timestamp < other?.Timestamp) return -1;
            if(Timestamp > other?.Timestamp) return 1;
            return -1;
        }
    }
}