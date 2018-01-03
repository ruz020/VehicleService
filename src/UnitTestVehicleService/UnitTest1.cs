using Microsoft.VisualStudio.TestTools.UnitTesting;
using VehicleServiceAPI;
using VehicleServiceAPI.Controllers;
using VehicleServiceAPI.Models;
using System;
using System.Web.Http;
using System.Collections.Generic;

namespace UnitTestVehicleService
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestGetById()
        {
            Vehicle v0 = new Vehicle { Id = 0, Year = 2010, Make = "Infiniti", Model = "FX35" };
            Vehicle v1 = new Vehicle { Id = 1, Year = 2011, Make = "Lexus", Model = "RX350" };
            var vc = new vehiclesController();

            Assert.AreEqual(v0, vc.GetById(0), "GetById failed");
        }

        [TestMethod]
        public void TestGet()
        {
            List<Vehicle> vs = new List<Vehicle>();
            Vehicle v0 = new Vehicle { Id = 0, Year = 2010, Make = "Infiniti", Model = "FX35" };
            Vehicle v1 = new Vehicle { Id = 1, Year = 2011, Make = "Lexus", Model = "RX350" };
            Vehicle v2 = new Vehicle { Id = 2, Year = 2000, Make = "Lexus", Model = "RX350" };
            Vehicle v3 = new Vehicle { Id = 3, Year = 2015, Make = "Infiniti", Model = "FX35" };
            Vehicle v4 = new Vehicle { Id = 4, Year = 2011, Make = "Audi", Model = "A6" };
            Vehicle v5 = new Vehicle { Id = 5, Year = 2000, Make = "Lexus", Model = "RX250" };
            Vehicle v6 = new Vehicle { Id = 6, Year = 2012, Make = "Infiniti", Model = "G35" };
            Vehicle v7 = new Vehicle { Id = 7, Year = 2011, Make = "BMW", Model = "X5" };
            Vehicle v8 = new Vehicle { Id = 8, Year = 2006, Make = "BMW", Model = "X3" };
            Vehicle v9 = new Vehicle { Id = 9, Year = 2015, Make = "Audi", Model = "Q7" };
            vs.Add(v0);
            vs.Add(v1);
            vs.Add(v2);
            vs.Add(v3);
            vs.Add(v4);
            vs.Add(v5);
            vs.Add(v6);
            vs.Add(v7);
            vs.Add(v8);
            vs.Add(v9);
            var vc = new vehiclesController();

            CollectionAssert.AreEqual(vs, vc.Get(), "Get failed");
        }

        [TestMethod]
        public void TestGetByYear()
        {
            List<Vehicle> vs = new List<Vehicle>();
            Vehicle v0 = new Vehicle { Id = 3, Year = 2015, Make = "Infiniti", Model = "FX35" };
            Vehicle v1 = new Vehicle { Id = 9, Year = 2015, Make = "Audi", Model = "Q7" };
            vs.Add(v0);
            vs.Add(v1);
            var vc = new vehiclesController();

            CollectionAssert.AreEqual(vs, vc.GetByYear(2015), "GetByYear failed");
        }

        [TestMethod]
        public void TestGetByMakeModel()
        {
            List<Vehicle> vs = new List<Vehicle>();
            Vehicle v0 = new Vehicle { Id = 1, Year = 2011, Make = "Lexus", Model = "RX350" };
            Vehicle v1 = new Vehicle { Id = 2, Year = 2000, Make = "Lexus", Model = "RX350" };
            vs.Add(v0);
            vs.Add(v1);
            var vc = new vehiclesController();

            CollectionAssert.AreEqual(vs, vc.GetByMakeModel("Lexus","RX350"), "GetByMakeModel failed");
        }

        [TestMethod]
        public void TestPost()
        {
            List<Vehicle> vs = new List<Vehicle>();
            Vehicle v0 = new Vehicle { Id = 0, Year = 2010, Make = "Infiniti", Model = "FX35" };
            Vehicle v1 = new Vehicle { Id = 1, Year = 2011, Make = "Lexus", Model = "RX350" };
            Vehicle v2 = new Vehicle { Id = 2, Year = 2000, Make = "Lexus", Model = "RX350" };
            Vehicle v3 = new Vehicle { Id = 3, Year = 2015, Make = "Infiniti", Model = "FX35" };
            Vehicle v4 = new Vehicle { Id = 4, Year = 2011, Make = "Audi", Model = "A6" };
            Vehicle v5 = new Vehicle { Id = 5, Year = 2000, Make = "Lexus", Model = "RX250" };
            Vehicle v6 = new Vehicle { Id = 6, Year = 2012, Make = "Infiniti", Model = "G35" };
            Vehicle v7 = new Vehicle { Id = 7, Year = 2011, Make = "BMW", Model = "X5" };
            Vehicle v8 = new Vehicle { Id = 8, Year = 2006, Make = "BMW", Model = "X3" };
            Vehicle v9 = new Vehicle { Id = 9, Year = 2015, Make = "Audi", Model = "Q7" };
            Vehicle v10 = new Vehicle { Id = 10, Year = 2007, Make = "Audi", Model = "Q5" };
            vs.Add(v0);
            vs.Add(v1);
            vs.Add(v2);
            vs.Add(v3);
            vs.Add(v4);
            vs.Add(v5);
            vs.Add(v6);
            vs.Add(v7);
            vs.Add(v8);
            vs.Add(v9);
            vs.Add(v10);
            var vc = new vehiclesController();
            vc.Post(v10);

            CollectionAssert.AreEqual(vs, vc.Get(), "Post failed");
        }

        [TestMethod]
        public void TestDelete()
        {
            List<Vehicle> vs = new List<Vehicle>();
            Vehicle v0 = new Vehicle { Id = 0, Year = 2010, Make = "Infiniti", Model = "FX35" };
            Vehicle v1 = new Vehicle { Id = 1, Year = 2011, Make = "Lexus", Model = "RX350" };
            Vehicle v2 = new Vehicle { Id = 2, Year = 2000, Make = "Lexus", Model = "RX350" };
            Vehicle v3 = new Vehicle { Id = 3, Year = 2015, Make = "Infiniti", Model = "FX35" };
            Vehicle v4 = new Vehicle { Id = 4, Year = 2011, Make = "Audi", Model = "A6" };
           
            Vehicle v6 = new Vehicle { Id = 6, Year = 2012, Make = "Infiniti", Model = "G35" };
            Vehicle v7 = new Vehicle { Id = 7, Year = 2011, Make = "BMW", Model = "X5" };
            Vehicle v8 = new Vehicle { Id = 8, Year = 2006, Make = "BMW", Model = "X3" };
            Vehicle v9 = new Vehicle { Id = 9, Year = 2015, Make = "Audi", Model = "Q7" };
            vs.Add(v0);
            vs.Add(v1);
            vs.Add(v2);
            vs.Add(v3);
            vs.Add(v4);
         
            vs.Add(v6);
            vs.Add(v7);
            vs.Add(v8);
            vs.Add(v9);
            var vc = new vehiclesController();
            vc.Delete(5);

            CollectionAssert.AreEqual(vs, vc.Get(), "Delete failed");
        }

        [TestMethod]
        public void TestPut()
        {
            Vehicle v5 = new Vehicle { Id = 5, Year = 2008, Make = "Lexus", Model = "RX250" };
            
            var vc = new vehiclesController();
            vc.Put(v5);

            Assert.AreEqual(v5, vc.GetById(5), "Put failed");
        }
    }
}
