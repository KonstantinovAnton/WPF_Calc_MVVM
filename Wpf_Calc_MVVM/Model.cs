using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Wpf_Calc_MVVM
{
    public class Model
    {
      
        // блок с данными

        public static double firstValue;
        public static double secondValue;
        public static double result;

        public static List<string> dataList = new List<string> { "Сложение", "Вычитание", "Умножение","Деление" };
        public static List<string> labelList = new List<string> { "+", "-", "*", "/" };
    }
}
