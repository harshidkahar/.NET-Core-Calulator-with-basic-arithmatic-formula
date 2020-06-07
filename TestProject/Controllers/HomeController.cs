using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;

using TestProject.Models;
using TestProject.Services;
using TestProject.Services.Infrastructure;

namespace TestProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICalculateAlgotithm _calculateAlgotithm;
        private readonly ILog _log;
        public HomeController(ICalculateAlgotithm calculateAlgotithm, ILog log)
        {
            _calculateAlgotithm = calculateAlgotithm;
            _log = log;
        }

        public IActionResult Index()
        {
            var enumData = from TestProject.Models.FunctionType e in Enum.GetValues(typeof(FunctionType))
                           select new
                           {
                               ID = (int)e,
                               Name = e.GetDescription(),
                               Value = e.ToString()
                           };

            ViewBag.EnumList = new SelectList(enumData, "ID", "Name", "Value");


            return View();
        }

        [HttpPost]
        public IActionResult Index(AlgorithmModel algorithmModel)
        {
            if (ModelState.IsValid)
            {
                decimal result = 0;

                ReturnParameter param = _calculateAlgotithm.CalAlgorithm(algorithmModel.a, algorithmModel.b, algorithmModel.FunctionType);

                if (param.Flag == true)
                {
                    result = Convert.ToDecimal(param.Var);
                    _log.LogData(algorithmModel.FunctionType, algorithmModel.a, algorithmModel.b, result.ToString());

                    result = Math.Round(result, 2);
                    return RedirectToAction("Result", "Home", new { @result = param.Var });
                }
                else
                {
                    _log.LogData(algorithmModel.FunctionType, algorithmModel.a, algorithmModel.b, param.Message);
                    return RedirectToAction("Result", "Home", new { @result = param.Message });
                }
            }
            return View();
        }

        public IActionResult Result(string result)
        {
            ViewBag.Result = result;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
