using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReportGenerationLib;
using Microsoft.QualityTools.Testing.Fakes;
using ReportGenerationLib.Fakes;
using System.Fakes;

namespace ReportGenerationLib.UnitTests
{
    [TestClass]
    public class ReportGeneratorTests
    {
        [TestMethod]
        [TestCategory("Unit")]
        public void GetReportNameTest()
        {
            //using (ShimsContext.Create())
            //{
            //    ShimUserRepository.AllInstances.GetUserInt32 = (self, userId) => new User
            //    {
            //        Id = userId,
            //        FirstName = "Abel",
            //        LastName = "Wang",
            //        CityCode = 1
            //    };
            //    ShimDateTime.NowGet = () => new DateTime(2017, 12, 12);
                
            //    var reportName = ReportGenerator.GetReportName(235423);

            //    Assert.AreEqual("Wang_Abel_Los Angeles_12/12/2017 12:00 AM", reportName);
            //}

        }
    }
}
