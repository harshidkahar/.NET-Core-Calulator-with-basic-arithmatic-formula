using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProject.Models;

namespace TestProject.Services.Infrastructure
{
    public interface ILog
    {
        public void LogData(FunctionType functionType, decimal inputA, decimal inputB, string result);
    }
}
