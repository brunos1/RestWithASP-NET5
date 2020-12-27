using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASP_NET5.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        // Sum Operation
        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult GetSum(string firstNumber, string secondNumber)
        {
            if (isNumeric(firstNumber) && isNumeric(secondNumber)) 
            {
                var sum = convertToDecimal(firstNumber) + convertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }

            return BadRequest("Invalid Input");
        }

        // Subtraction Operation
        [HttpGet("sub/{fistNumber}/{secondNumber}")]
        public IActionResult GetSubtraction(string firstNumber, string secondNumber)
        {
            if (isNumeric(firstNumber) && isNumeric(secondNumber))
            {
                var sub = convertToDecimal(firstNumber) - convertToDecimal(secondNumber);
                return Ok(sub.ToString());
            }

            return BadRequest("Invalid Input");
        }

        // Multiplication Operation
        [HttpGet("mult/{firstNumber}/{secondNumber}")]
        public IActionResult GetMultiplication(string firstNumber, string secondNumber)
        {
            if (isNumeric(firstNumber) && isNumeric(secondNumber))
            {
                var mult = convertToDecimal(firstNumber) * convertToDecimal(secondNumber);
                return Ok(mult.ToString());
            }

            return BadRequest("Invalid Input");
        }

        // Division Operation
        [HttpGet("div/{firstNumber}/{secondNumber}")]
        public IActionResult GetDivision(string firstNumber, string secondNumber)
        {
            if (isNumeric(firstNumber) && isNumeric(secondNumber))
            {
                var div = convertToDecimal(firstNumber) / convertToDecimal(secondNumber);
                return Ok(div.ToString());
            }

            return BadRequest("Invalid Input");
        }

        // Average Operation
        [HttpGet("avg/{grade1}/{grade2}/{grade3}")]
        public IActionResult GetAvg(string grade1, string grade2, string grade3)
        {
            if (isNumeric(grade1) && isNumeric(grade2) && isNumeric(grade3))
            {
                var g1 = convertToDecimal(grade1);
                var g2 = convertToDecimal(grade2);
                var g3 = convertToDecimal(grade3);

                var avg = (g1 + g2 + g3) / 3;
                return Ok(avg.ToString());
            }

            return BadRequest("Invalid Input");
        }

        // Square Operation
        [HttpGet("sqrt/{number}")]
        public IActionResult GetSqrt(string number)
        {
            if (isNumeric(number))
            {
                var sqrt = Math.Sqrt((double)convertToDecimal(number));
                return Ok(sqrt.ToString());
            }   

            return BadRequest("Invalid Input");
        }

        private bool isNumeric(string strNumber)
        {
            double number;
            bool isNumber = double.TryParse(
                strNumber, 
                System.Globalization.NumberStyles.Any, 
                System.Globalization.NumberFormatInfo.InvariantInfo, 
                out number
            );
            return isNumber;
        }

        private decimal convertToDecimal(string strNumber)
        {
            decimal decimalValue;
            if (decimal.TryParse(strNumber, out decimalValue))
            {
                return decimalValue;
            }
            return 0;
        }
    }
}
