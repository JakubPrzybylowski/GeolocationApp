using GeolocationApp.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeolocationApp.Mappers
{
    public class GeolocationMapper : MapperBase<Geolocation, GeolocationDto>
    {
        public override Geolocation Map(GeolocationDto element)
        {
            return new Geolocation();
        }

        public override GeolocationDto Map(Geolocation element)
        {
            return new GeolocationDto
            {
                Ip = element.Ip,
                Hostname = element.Hostname,
                Type = element.Type,
                ContinentCode = element.Continent_code,
                ContinentName = element.Continent_name,
                CountryCode = element.Country_code,
                CountryName = element.Country_name,
                RegionCode = element.Region_code,
                RegionName = element.Region_name,
                City = element.City,
                Zip = element.Zip
            };
        }
    }
}
