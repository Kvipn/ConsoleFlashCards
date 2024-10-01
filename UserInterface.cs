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
                        LearnWord();
                        break;
                    case 3:
                        break;
                    case 4:
                        AddWord();
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
        void PrintMenu()
        {
            Console.Clear();
            Console.WriteLine("1.----------");
            Console.WriteLine("2.Учить слова.");
            Console.WriteLine("3.Повторить выученное.");
            Console.WriteLine("4.Добавить слова.");
            Console.WriteLine("5.Вывести слова.");
            Console.WriteLine("0.Закончить работу");
        }

        public void LearnWord()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var words = db.Words.ToArray();
                List<Word> UnLearnedwordList = words.ToList();
                List<Word> LeanedwordList = new List<Word>();

                while (UnLearnedwordList.Count != 0)
                {
                    foreach (var item in UnLearnedwordList.ToList())
                    {
                        Console.WriteLine(item.word);
                        Console.WriteLine();
                        Console.WriteLine("Показать полностью");
                        Console.ReadKey();
                        Console.Clear();
                        item.ShowWord();
                        Console.WriteLine("1 - Выучил слово");
                        Console.WriteLine("2 - Отложить на повтор");
                        var res = int.Parse(Console.ReadLine());
                        Console.Clear();
                        switch (res)
                        {
                            case 1:LeanedwordList.Add(item);
                                UnLearnedwordList.Remove(item);
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
        }

        public void AddWord()
        {
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

            using (ApplicationContext db = new ApplicationContext())
            {
                db.Words.AddRange(words);
                db.SaveChanges();
            }

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
