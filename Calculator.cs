using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_5._1_Calculator
{   
    
    interface ICalculator
    {
        decimal Add (decimal i, decimal j);
        decimal Subtract(decimal i, decimal j);
        decimal Multiply (decimal i, decimal j);
        decimal Divide (decimal i, decimal j);  
    }
    class MathCls : ICalculator
    {
        decimal ICalculator.Add(decimal i, decimal j)
        {
            return i + j;
        }

        decimal ICalculator.Divide(decimal i, decimal j)
        {
            try
            {
                if ( j != 0)
                {
                    return i / j;
                }
                else
                {
                    throw new DivideByZeroException();
                }
            }
            catch(DivideByZeroException ex)
            {
                return 0;
            }
            
        }

        decimal ICalculator.Multiply(decimal i, decimal j)
        {
            return j * i;
        }

        decimal ICalculator.Subtract(decimal i, decimal j)
        {
            return i - j;
        }
    }
}
