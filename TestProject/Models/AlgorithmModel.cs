using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestProject.Models
{
    public class AlgorithmModel
    {
        [Required(ErrorMessage = "Pleasee enter you number")]
        [RegularExpression(@"^(?:1(?:\.0)?|0?\.[1-9])$",ErrorMessage = "Enter decimal number between 0.0 to 1.0")]
        [Range(typeof(decimal),"0.0", "1.0", ErrorMessage = "Enter decimal number between 0.0 to 1.0")]
        public decimal a { get; set; }

        [Required(ErrorMessage = "Pleasee enter you number")]
        [RegularExpression(@"^(?:1(?:\.0)?|0?\.[1-9])$", ErrorMessage = "Enter decimal number between 0.0 to 1.0")]
        [Range(typeof(decimal), "0.0", "1.0", ErrorMessage = "Enter decimal number between 0.0 to 1.0")]
        public decimal b { get; set; }

        public FunctionType FunctionType { get; set; }
    }
    public enum FunctionType
    {
        [Description("a*b")]
        Algorithm1,

        [Description("(a+b) - (a*b)")]
        Algorithm2,

        //add mathematical expression in enum
        [Description("((a_b) + (a+b) - (a-b))/(a)")]
        Algorithm3
    }
}
