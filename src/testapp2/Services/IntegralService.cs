using MathNet.Numerics.Integration;
using MathNet.Symbolics;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testapp2.Models;

namespace testapp2.Services
{
    public class IntegralService
    {
        [Produces("application/json")]
        public IntegralOutput Calculate(IntegralInput integralInput)
        {
            Func<double, double> f = SymbolicExpression.Parse(integralInput.Integral).Compile("x");
            double composite = SimpsonRule.IntegrateComposite(f, integralInput.A, integralInput.B, integralInput.N);
            return new IntegralOutput() { Answer = composite, Info = "Calculated"};
        }
    }
}
