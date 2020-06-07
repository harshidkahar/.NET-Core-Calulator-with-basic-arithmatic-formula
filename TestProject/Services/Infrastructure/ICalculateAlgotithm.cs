using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using TestProject.Models;

namespace TestProject.Services.Infrastructure
{
    public interface ICalculateAlgotithm
    {
        public ReturnParameter CalAlgorithm(decimal a, decimal b, FunctionType functionType);
    }
}
