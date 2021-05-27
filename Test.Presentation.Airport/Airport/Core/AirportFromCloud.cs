using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Airport.Api.Infrastructure;
using Airport.Api.Model;
using Microsoft.EntityFrameworkCore;

namespace Airport.Api.Core
{
    public class AirportFromCloud
    {
        readonly AirportContext airportContext;
        public AirportFromCloud()
        {
            airportContext = new AirportContextDesignFactory().CreateDbContext(new String[1]);
        }

        public async Task LoadAndSaveAirports()
        {
            var airports = await LoadAirports();
            await SaveAirports(airports);

        }

        public async Task <List<Model.Airport>> LoadAirports()
        {
            var options = new JsonSerializerOptions();
            options.PropertyNameCaseInsensitive = true;
            options.Converters.Add(new JsonStringEnumConverter());

            var json = string.Empty;
            return await Task.Run(() =>
            {
                using (WebClient wc = new WebClient())
                {
                    json =  wc.DownloadString("https://raw.githubusercontent.com/jbrooksuk/JSON-Airports/master/airports.json");
                }

                var airport =
                   JsonSerializer.Deserialize<List<Model.Airport>>(json, options);
                return airport;
            });
        }

        public async Task SaveAirports(List<Model.Airport> listOfAirPorts)
        {        try
                    {
                        this.airportContext.RemoveRange(this.airportContext.Airports.ToList());
                        this.airportContext.Airports.AddRange(listOfAirPorts);
                        this.airportContext.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        
                    }
            
        }

        public async Task AddAirport(Model.Airport airport)
        {
            try
            {
                this.airportContext.Airports.Add(airport);
                this.airportContext.SaveChanges();
            }
            catch (Exception ex)
            {

            }

        }

        public async Task<IEnumerable<Model.Airport>> GetAirports()
        {
            var items = this.airportContext.Airports;
            return await items.ToListAsync();
        }


    }
}
