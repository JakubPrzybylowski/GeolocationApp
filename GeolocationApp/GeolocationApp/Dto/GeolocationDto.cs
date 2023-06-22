using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeolocationApp.Dto
{
    public  class GeolocationDto
    {
        public GeolocationDto()
        {

        }
        public GeolocationDto(Geolocation geolocation)
        {
            Ip = geolocation.Ip;
            Hostname = geolocation.Hostname;
            Type = geolocation.Type;
            ContinentCode = geolocation.Continent_code;
            ContinentName = geolocation.Continent_name;
            CountryCode = geolocation.Country_code;
            CountryName = geolocation.Country_name;
            RegionCode = geolocation.Region_code;
            RegionName = geolocation.Region_name;
            City = geolocation.City;
            Zip = geolocation.Zip;
        }
        public string Ip { get; set; }
        public string Hostname { get; set; }
        public string Type { get; set; }
        public string ContinentCode { get; set; }
        public string ContinentName { get; set; }
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
        public string RegionCode { get; set; }
        public string RegionName { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
    }
}
