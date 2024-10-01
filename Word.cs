using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleFlashCards
{
    public class Word
    {
        public int Id { get; set; }
        public string word { get; set; }
        public string translateWord { get; set; }
        public string ExeplesOfUsingWord { get; set; }
        public string topicOfWord { get; set; }

        public Word()
        {

        }

        public static Word CreateWord(Word word)
        {
            Console.WriteLine("Введите слово");
            word.word = Console.ReadLine();
            Console.WriteLine("Введите перевод слова");
            word.translateWord = Console.ReadLine();
            Console.WriteLine("Введите предложение с примером использования слова");
            word.ExeplesOfUsingWord = Console.ReadLine();
            Console.WriteLine("Введите тему которой соответствует слово");
            word.topicOfWord = Console.ReadLine();
            return word;
        }

        public void ShowWord()
        {
            Console.WriteLine(topicOfWord);
            Console.WriteLine($"{word} - {translateWord}");
            Console.WriteLine(ExeplesOfUsingWord);
        }

    }
}
