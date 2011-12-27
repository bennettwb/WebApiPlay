using WebApi.Hubs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;

namespace WebApi.Tests
{
    
    
    /// <summary>
    ///This is a test class for EventConduitTest and is intended
    ///to contain all EventConduitTest Unit Tests
    ///</summary>
    [TestClass()]
    public class EventConduitTest
    {


      

     
     
        [TestMethod()]
        public void ProcessTest()
        {
            string input = string.Empty; // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = EventConduit.Process(input);
       
         
        }
    }
}
