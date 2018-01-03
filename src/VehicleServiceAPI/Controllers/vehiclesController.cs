using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Security.Claims;
using System.IdentityModel.Tokens;
using System.Diagnostics;
using VehicleServiceAPI.Models;
using System.Configuration;

namespace VehicleServiceAPI.Controllers
{
    public class vehiclesController : ApiController
    {
        private static Dictionary<int, Vehicle> vehicleMap = new Dictionary<int, Vehicle>(); /* in memory storage */

        static vehiclesController()
        {
            vehicleMap.Add(0, new Vehicle { Id = 0, Year = 2010, Make = "Infiniti", Model = "FX35" });
            vehicleMap.Add(1, new Vehicle { Id = 1, Year = 2011, Make = "Lexus", Model = "RX350" });
            vehicleMap.Add(2, new Vehicle { Id = 2, Year = 2000, Make = "Lexus", Model = "RX350" });
            vehicleMap.Add(3, new Vehicle { Id = 3, Year = 2015, Make = "Infiniti", Model = "FX35" });
            vehicleMap.Add(4, new Vehicle { Id = 4, Year = 2011, Make = "Audi", Model = "A6" });
            vehicleMap.Add(5, new Vehicle { Id = 5, Year = 2000, Make = "Lexus", Model = "RX250" });
            vehicleMap.Add(6, new Vehicle { Id = 6, Year = 2012, Make = "Infiniti", Model = "G35" });
            vehicleMap.Add(7, new Vehicle { Id = 7, Year = 2011, Make = "BMW", Model = "X5" });
            vehicleMap.Add(8, new Vehicle { Id = 8, Year = 2006, Make = "BMW", Model = "X3" });
            vehicleMap.Add(9, new Vehicle { Id = 9, Year = 2015, Make = "Audi", Model = "Q7" });
        }

        // GET: vehicles/
        public List<Vehicle> Get()
        {
            return vehicleMap.Values.ToList();
        }

        // GET: vehicles/{id}
        public Vehicle GetById(int id)
        {
            return vehicleMap.Values.Where(m => m.Id == id).First();
        }

        // POST: vehicles
        public void Post(Vehicle v)
        {
            if (IsEmpty(v.Make) || IsEmpty(v.Model) || !yearRange(v.Year)) return;
            v.Id = vehicleMap.Count > 0 ? vehicleMap.Keys.Max() + 1 : 1;
            vehicleMap.Add(v.Id, v);
        }

        // PUT: vehicles
        public void Put(Vehicle v)
        {
            if (IsEmpty(v.Make) || IsEmpty(v.Model) || !yearRange(v.Year)) return;
            Vehicle xv = vehicleMap.Values.First(a => (a.Id == v.Id));
            if (v != null && xv != null)
            {
                xv.Make = v.Make;
                xv.Model = v.Model;
                xv.Year = v.Year;
            }
        }

        // DELETE: vehicles/{id}
        public void Delete(int id)
        {
            Vehicle v = vehicleMap.Values.First(a => a.Id == id);
            if (v != null)
            {
                vehicleMap.Remove(v.Id);
            }
        }

        // GET: vehicles/make/{make}
        [Route("vehicles/make/{make}")]
        [HttpGet]
        public List<Vehicle> GetByMake(string make)
        {
            return vehicleMap.Values.Where(x => x.Make == make).ToList();
        }
        
        // GET: vehicles/model/{model}
        [Route("vehicles/model/{model}")]
        [HttpGet]
        public List<Vehicle> GetByModel(string model)
        {
            return vehicleMap.Values.Where(x => x.Model == model).ToList();
        }

        // GET: vehicles/year/{year}
        [Route("vehicles/year/{year}")]
        [HttpGet]
        public List<Vehicle> GetByYear(int year)
        {
            return vehicleMap.Values.Where(x => x.Year == year).ToList();
        }

        // GET: vehicles/make/{make}/year/{year}
        [Route("vehicles/make/{make}/year/{year}")]
        [HttpGet]
        public List<Vehicle> GetByMakeYear(string make, int year)
        {
            return vehicleMap.Values.Where(x => x.Make == make && x.Year == year).ToList();
        }

        // GET: vehicles/make/{make}/model/{model}
        [Route("vehicles/make/{make}/model/{model}")]
        [HttpGet]
        public List<Vehicle> GetByMakeModel(string make, string model)
        {
            return vehicleMap.Values.Where(x => x.Make == make && x.Model == model).ToList();
        }

        // GET: vehicles/model/{model}/year/{year}
        [Route("vehicles/model/{model}/year/{year}")]
        [HttpGet]
        public List<Vehicle> GetByModelYear(string model, int year)
        {
            return vehicleMap.Values.Where(x => x.Model == model && x.Year == year).ToList();
        }

        // check range of year
        private Boolean yearRange(int year)
        {
            if (year >= 1950 && year <= 2050)
                return true;
            else
                return false;
        }

        // check for empty of null string
        private Boolean IsEmpty(string str)
        {
            return String.IsNullOrEmpty(str);
        }
    }
}

