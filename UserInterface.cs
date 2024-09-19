using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleFlashCards
{
    internal class UserInterface
    {
        private bool _state = true;

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
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:AddTopic();
                        break;
                    case 5:
                        printWords();
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
            //исправить чтобы получал не по слову а вводилась тема а потом несколько слов с ней связанных
            bool exit = false;
            List<Word> words = new List<Word>();
            do
            {
                exit = false;
                words.Add(Word.CreateWord(new Word()));
                Console.WriteLine("Желаете ввести ещё одно слово? Y/N");
                if (Console.ReadKey(true).KeyChar == 'y')
                    exit = true;

            }
            while (exit);

            using (ApplicationContext db = new ApplicationContext() )
            {
                db.Words.AddRange(words);
                db.SaveChanges();
            }

        }
        void PrintMenu()
        {
            Console.WriteLine("1.Выбрать тему.");
            Console.WriteLine("2.Учить слова.");
            Console.WriteLine("3.Повторить выученное.");
            Console.WriteLine("4.Добавить свою тему.");
            Console.WriteLine("5.Вывести слова.");
            Console.WriteLine("0.Закончить работу");
        }
    
        void printWords()
        {
            Console.WriteLine("Слова:");
            using (ApplicationContext db = new ApplicationContext())
            {
                var words = db.Words.ToArray();
                foreach (var item in words)
                {
                    item.ShowWord();
                }
                Console.ReadKey();
            }
        }
    
    
    }
}
