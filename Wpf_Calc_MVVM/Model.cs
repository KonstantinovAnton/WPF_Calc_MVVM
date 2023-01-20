using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Wpf_Calc_MVVM
{
    internal class Model
    {
        // блок с данными

        private static double firstValue;
        private static double secondValue;
        private static double result;

        // блок с бизнес-логикой

        // свойство для получения значение первого числа
        public static double GetSetFirstValue
        {
            get
            {
                return firstValue;
            }
            set
            {
                firstValue = value;
            }
        }

        // свойство для получения значение второго числа
        public static double GetSetSecondValue
        {
            get
            {
                return secondValue;
            }
            set
            {
                secondValue = value;
            }
        }

        // метод для определения выполняется ли деление на ноль
        public static bool isDivisionWithZero(int comboBoxValue)
        {
            if (secondValue == 0 && comboBoxValue == 2)
                return true;

            return false;
        }

        // метод для подсчета значений
        public static void calcValues(int comboBoxValue)
        {
            switch (comboBoxValue)
            {
                case 0:
                    result = firstValue + secondValue;
                    break;
                case 1:
                    result = firstValue - secondValue;
                    break;
                case 2:
                    result = firstValue / secondValue;
                    break;
                case 3:
                    result = firstValue * secondValue;
                    break;
            }
        }
  
    }
}
