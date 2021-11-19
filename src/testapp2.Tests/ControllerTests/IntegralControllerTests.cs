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
            IntegralInput integralInput = new IntegralInput() { A = 1, B = 9, N = 1000, Integral = "x*x/2" };
            IntegralController integralController = new IntegralController();
            var testRes = integralController.Post(integralInput);
            var expectedRes = 121.333;
            Assert.Equal(testRes.Answer, expectedRes, 1);
        }
        [Fact]
        public void GetBigIntegral_Success()
        {
            IntegralInput integralInput = new IntegralInput() { A = 1, B = 1200, N = 1000, Integral = "x*x*x/(x+3)" };
            IntegralController integralController = new IntegralController();
            var testRes = integralController.Post(integralInput);
            var expectedRes = 573850638.0971241;
            Assert.Equal(testRes.Answer, expectedRes, 1);
        }
        [Fact]
        public void GetIntegralBlowerA()
        {
            IntegralInput integralInput = new IntegralInput() { A = 9, B = 1, N = 1000, Integral = "x*x" };
            IntegralController integralController = new IntegralController();
            var testRes = integralController.Post(integralInput);
            var expectedRes = -242.666;
            Assert.Equal(testRes.Answer, expectedRes, 1);
        }
        [Fact]
        public void GetNullException()
        {
            IntegralInput integralInput = new IntegralInput() { A = 0, B = 0, N = 0, Integral = "string" };
            IntegralController integralController = new IntegralController();
            Action testRes = ()=> integralController.Post(integralInput);
            Assert.Throws<NullReferenceException>(testRes);
        }

       
        [Fact]
        public void GetIntegralNIsOdd()
        {
            IntegralInput integralInput = new IntegralInput() { A = 1, B = 2, N = 33, Integral = "x*x" };
            IntegralController integralController = new IntegralController();
            Action testRes = () => integralController.Post(integralInput);
            Assert.Throws<ArgumentException>(testRes);
        }
    }
}
