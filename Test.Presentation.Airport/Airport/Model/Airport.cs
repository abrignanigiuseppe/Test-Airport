using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Api.Model
{
    public class Airport
    {
        public long Id { get; set; }
        public string Iata { get; set; }
        public string Lon { get; set; }
        public string Iso { get; set; }
        public int Status { get; set; }
        public string Name { get; set; }
        public string Continent { get; set; }
        public string Type { get; set; }
        public string Lat { get; set; }
        public string Size { get; set; }
    }
}
