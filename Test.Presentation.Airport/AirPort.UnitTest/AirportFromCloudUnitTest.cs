using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Airport.Api.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AirPort.UnitTest
{
    [TestClass]
    public class AirportFromCloudUnitTest
    {

        [TestMethod]
        public async Task TestLoadAirports()
        {
            var testClass = new AirportFromCloud();
            var result = await testClass.LoadAirports();
            Assert.IsTrue(result != null);
        }


        [TestMethod]
        public async Task LoadAndSaveAirports()
        {
            var testClass = new AirportFromCloud();
            var result = await testClass.LoadAirports();
            await testClass.SaveAirports(result);

            var items = await testClass.GetAirports();

            Assert.IsTrue(items!= null);
        }

        [TestMethod]
        public async Task LoadAndSaveAirports2()
        {
            var testClass = new AirportFromCloud();
            await testClass.LoadAndSaveAirports();

            var items = await testClass.GetAirports();

            Assert.IsTrue(items != null);
        }
    }
}
