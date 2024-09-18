using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleFlashCards
{
    internal class UserInterface
    {
        private bool _state = true;
        void PrintMenu()
        {
            Console.WriteLine("1.Выбрать тему.");
            Console.WriteLine("2.Учить слова.");
            Console.WriteLine("3.Повторить выученное.");
            Console.WriteLine("4.Добавить свою тему.");
            Console.WriteLine("0.Закончить работу");
        }

        public void Start()
        {
            do
            {
                PrintMenu();
                int UserChoice = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                switch (UserChoice)
                {
                    case 0:
                        _state = false;
                        break;
                    case 1:
                        //
                        break;
                    case 2:
                        //
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    default:
                        Console.WriteLine("Неверный ввод");
                        break;
                }
            }
            while (_state);
        }

        public void AddTopic()
        {
            
        }
    }
}
