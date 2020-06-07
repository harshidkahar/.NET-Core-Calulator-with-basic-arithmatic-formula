using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using TestProject.Services.Repository;
using TestProject.Models;
using System.Net.Http.Headers;
using TestProject;

namespace CalculatorTest
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void TestAlgorithm1()
        {
            decimal a, b;
            a = 0.1m;
            b = 0.5m;
            var function = FunctionType.Algorithm1;
            TestProject.Services.Repository.CalculateAlgotithm calculateAlgotithm = new CalculateAlgotithm();
            ReturnParameter param = calculateAlgotithm.CalAlgorithm(a, b, function);
            Assert.AreEqual(0.05m,Convert.ToDecimal(param.Var));
        }


        [TestMethod]
        public void TestAlgorithm2()
        {
            decimal a, b;
            a = 0.1m;
            b = 0.5m;
            var function = FunctionType.Algorithm2;
            TestProject.Services.Repository.CalculateAlgotithm calculateAlgotithm = new CalculateAlgotithm();
            ReturnParameter param = calculateAlgotithm.CalAlgorithm(a, b, function);
            Assert.AreEqual(0.55m, Convert.ToDecimal(param.Var));
        }
    }
}
