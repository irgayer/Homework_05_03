using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_05_03
{
    class Program
    {
        static void Main(string[] args)
        {
            FiboContunier fiboContunier = new FiboContunier();
            fiboContunier.Run();

            SumToNumbers sum = new SumToNumbers();
            sum.Run();
        }
        
    }
}
