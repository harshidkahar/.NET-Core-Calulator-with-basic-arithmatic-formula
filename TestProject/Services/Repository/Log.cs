using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProject.Services.Infrastructure;

using System.IO;
using System.Text;
using System.Runtime.InteropServices;
using TestProject.Models;

namespace TestProject.Services.Repository
{
    public class Log : ILog
    {
        public void LogData(FunctionType functionType, decimal inputA, decimal inputB, string result)
        {

            var function = functionType;
            string formula = function.GetDescription();

            using (StreamWriter w = File.AppendText("log.txt"))
            {
                LogData(formula, inputA, inputB, result, w);
            }
        }

        public void LogData(string TypeOfCalculation, decimal inputA, decimal inputB, string result, TextWriter textWriter)
        {
            textWriter.Write("\r\nLog Entry : ");
            textWriter.WriteLine("Date Time:" + DateTime.Now.ToLongDateString() +" " + DateTime.Now.ToLongTimeString());
            textWriter.WriteLine("Type of Calculation :" + TypeOfCalculation);
            textWriter.WriteLine("Inputs A = "+ inputA +", B = "+ inputB);
            textWriter.WriteLine("Result = " + result);
            textWriter.WriteLine("----------------------------------");
        }
    }
}
