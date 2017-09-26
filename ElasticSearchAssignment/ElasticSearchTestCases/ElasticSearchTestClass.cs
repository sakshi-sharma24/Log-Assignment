using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ElasticSearchAssignment;
using System.Linq;

namespace ElasticSearchTestCases
{
    [TestClass]
    public class ElasticSearchTestClass
    {
        [TestMethod]
        public void AddNewIndexTest()
        {
            ElasticSearch objSearch = new ElasticSearch();

            objSearch.AddNewIndex(new Log("1",DateTime.Now, DateTime.Now, "172.16.14.49", "6565"));
            objSearch.AddNewIndex(new Log("2", DateTime.Now, DateTime.Now, "172.16.14.159", "5565"));
          
           
        }


        [TestMethod]
            public void GetResultTest()
            {
                ElasticSearch objSearch = new ElasticSearch();
                var result = objSearch.GetResult("1");
            Assert.IsFalse(result.FirstOrDefault<Log>(x => x.Status == "1") != null);
            //Assert.IsFalse(result.FirstOrDefault<Hotel>(x => x.Country == "India") != null);
            //Assert.IsFalse(result.FirstOrDefault<Hotel>(x => x.Country == "India") != null);
        }
        }
}
    
