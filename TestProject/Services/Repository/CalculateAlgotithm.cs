using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProject.Services.Infrastructure;
using TestProject.Models;
using System.Data;

namespace TestProject.Services.Repository
{
    public class CalculateAlgotithm : ICalculateAlgotithm
    {
        static ReturnParameter param = new ReturnParameter();
        public ReturnParameter CalAlgorithm(decimal a, decimal b, FunctionType functionType)
        {
            try
            {
                var function = functionType;
                string formula = function.GetDescription();
                formula = formula.Replace("a", a.ToString());
                formula = formula.Replace("b", b.ToString());
                param.Var = new DataTable().Compute(formula, null);
                param.Flag = true;
            }
            catch (Exception ex)
            {
                param.Message = "Mathematical expression is invalid!!!";
                param.Flag = false;
                param.Var = null;
            }
            return param;
        }
    }
}
