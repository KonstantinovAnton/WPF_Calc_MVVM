using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Wpf_Calc_MVVM
{
    class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

      

        // Свойство для первого числа
        public double firstValue
        {
            get { return Model.firstValue; }
            set {
                try
                {
                    Model.firstValue = Convert.ToDouble(value);
                }
                catch
                {
                    MessageBox.Show("Некорректное первое число");
                    Model.firstValue = 0;
                }
            
            }
        }

        // Свойство для второго числа
        public double secondValue
        {
            get { return Model.secondValue; }
            set
            {
                try
                {
                    Model.secondValue = Convert.ToDouble(value);
                }
                catch
                {
                    MessageBox.Show("Некорректное второе число");
                    Model.firstValue = 0;
                }
            }
        }

        // Свойство для заполнения Combobox
        public List<string> comboChange 
        {
            get
            {
                return Model.dataList;
            }
        }

        int indexOperation = 0;
      

        // Свойство для индекса Combobox
        public int indexSelected
        {
            set
            {
                indexOperation = value;
                PropertyChanged(this, new PropertyChangedEventArgs("labelOfOperation"));  
            }
        }


        // Свойство для знака операции
        public string labelOfOperation
        {
            get
            {
                return Model.labelList[indexOperation];
            }
        }



        public RoutedCommand calcResult { get; set; } = new RoutedCommand();

        // Обработка нажатия на кнопку "Вычислить"
        public void calcResult_Executed(object sender, ExecutedRoutedEventArgs e) 
        {
            PropertyChanged(this, new PropertyChangedEventArgs("textBlockResult"));
        }

        // Вывод результата вычисления
        public string textBlockResult
        {
            get {  
                
                double firstValue = Model.firstValue;
                double secondValue = Model.secondValue;                    

                // Проверка деления на ноль
                if (secondValue == 0 && indexOperation == 3)
                {
                    MessageBox.Show("Деление на ноль запрещено");
                    return "";
                }    
                    

                switch (indexOperation)
                {
                    case 0:
                        return "" + (firstValue + secondValue);
                        break;
                    case 1:
                        return "" + (firstValue - secondValue);
                        break;
                    case 2:
                        return "" + (firstValue * secondValue);
                        break;
                    case 3:
                        return "" + (firstValue / secondValue);
                        break;
                    default:
                        return "";
                        break;

                }
            }
        }


        public CommandBinding bind; // создание объекта для привязки команды
        public ViewModel()
        {
            bind = new CommandBinding(calcResult);  // инициализация объекта для привязки данных
            bind.Executed += calcResult_Executed;  // добавление обработчика событий
        }


    }
}
