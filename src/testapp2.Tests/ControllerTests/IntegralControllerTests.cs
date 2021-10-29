using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testapp2.Models;
using testapp2.Controllers;
using Xunit;

namespace testapp2.Tests.ControllerTests
{
    public class IntegralControllerTests
    {
        [Fact]
        public void GetIntegral_Success()
        {
            IntegralInput integralInput = new IntegralInput() { A = 1, B = 9, N = 1000, Integral = "(x*x)/2" };
            IntegralController integralController = new IntegralController();
            var testRes = integralController.Post(integralInput);
            var expectedRes = 121.333;
            Assert.Equal(testRes.Answer, expectedRes, 3);
        }
    }
}
