using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1_standings
{
    public class Driver
    {
        public int Id { get; set; }
        public string driverId { get; set; }
        public string? url { get; set; }
        public required string givenName { get; set; }
        public required string familyName { get; set; }
        public string? dateOfBirth { get; set; }
        public string nationality { get; set; }

        public override string ToString()
        {
            return $"{givenName} {familyName} (Id: {driverId}, Narodowość: {nationality}, Data urodzenia: {dateOfBirth})";
        }
    }

    public class DriverTable
    {
        public List<Driver> Drivers { get; set; }
    }

    public class MRData
    {
        public DriverTable DriverTable { get; set; }
    }

    public class RootObject
    {
        public MRData MRData { get; set; }
    }



}
