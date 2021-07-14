using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace RabotaSstruct
{
    
    class Program
    {
        
        static void Main(string[] args)
        {

            string path = @"C:\Новая папка\Input.txt";// путь папки
            beginning(path);// открытие метода по началу работы 

            Console.ReadKey();
        }
        public static void Add(string path, string text)
        {



            StreamWriter writer = new StreamWriter(path, true);// создания потока по добавлении в запись 
            writer.Write("\n" + text);// запись в файл
            writer.Close();//  закрытие потока
        }
        public static void Delete(string path)
        {
            Console.WriteLine("Чтобы удалить строчку напишите Delete1, чтобы удалить все напишите all Delete.");
            switch(Console.ReadLine())//условия по удалению строки или файла
            {
                case "Delete1":
                   
                     string[] str = File.ReadAllLines(path);// создания массива
                    Console.WriteLine("напишите имя , фамилию или название работы которое нужно удалить");
                    string Name = Console.ReadLine();// текс по нахождению которого будет производиться удаление
                    using (StreamWriter sw = new StreamWriter(path))//  создания потока
                    {
                            sw.AutoFlush = true;
                            foreach (string s in str)// читает массив
                        {
                                if (!s.Contains(Name))//  условие по нахождении строчки
                            {
                                    sw.WriteLine(s);
                                }
                            }
                        } 
                    break;
                case "all Delete":
                    File.Delete(path);// удаление всего файла
                    break;
            }




        }//  метод по удалению строки или файла
        public static void Editing(string path)
        {
            string[] str = File.ReadAllLines(path);// массив строк
            Console.WriteLine("напишите имя , фамилию или название работы которое нужно редактировать");
            string Name = Console.ReadLine();//  строка по нахождению файла или слова
            using (StreamWriter sw = new StreamWriter(path))// создания потока
            {
                sw.AutoFlush = true;
                foreach (string s in str)// читает весь массив
                {
                    if (!s.Contains(Name))// условия по нахождению слова или строки 
                    {
                        sw.WriteLine(s);
                       
                    }
                }
            }
            addingСomments(path);// открытия метода по созданию новой строчки

        }// метод по редактированию строки
        public static void beginning(string path)
        {

            Console.WriteLine("Здравствуйте, программа создана для создания файла с примечаниями, разных научных работ");
            char i = 'д';
            do// бесконечный цикл
            {
                Console.WriteLine("введите 1 - добавление, 2 - редактирование, 3 - удаление ");
                switch (Console.ReadLine())
                {
                    case "1":
                        addingСomments(path);// метод по созданию строки
                        Console.WriteLine("добавление произошло");
                        break;
                    case "2":
                        Editing(path);// метод по редактированию
                        Console.WriteLine("редактирование");
                        break;
                    case "3":
                        Delete(path);// метод по удалению
                        Console.WriteLine("Удаление произошло");
                        break;
                    default:
                        Console.WriteLine("пока");
                        break;

                }
                Console.WriteLine("чтобы продолжить напишите Д, закончить Н");
                i = Console.ReadKey(true).KeyChar;
            } while (char.ToLower(i) == 'д');
        }// метод по началы работы и выбор функций
        public static void addingСomments(string path)
        {
            int ID = 0;
            if (!File.Exists(path))// условие. если нет папки то идет создание и запись первого замичания 
            {
                Console.WriteLine("Создал файл");
                File.Create(path);
                ID = 1;// в первой строке айди ровна 1
            }
            else
            {
                string[] str = File.ReadAllLines(path);// массив строк  
                if (str.Length == 0)
                {
                    ID++;
                }
                else
                {
                    char[] separtors = " \r\n\"',".ToCharArray(); // Строка сепараторов
                    string[] ave = str[str.Length - 1].Split(separtors);//последнняя строка с разбивом символов в массив
                    ID = int.Parse(ave[1]);//конверт символа в инт
                    ID++;//увеличение айди на 1
                }
            }

            Console.WriteLine("Введите имя");
            string Name = Console.ReadLine();// переменная имени
            Console.WriteLine("Введите Фамилию");
            string Surname = Console.ReadLine();// переменная Фамилии
            Console.WriteLine("Введите название");
            string JobTitles = Console.ReadLine();// переменная названии
            Console.WriteLine("Напишите примечание");
            string Note = Console.ReadLine();// переменная примечанию
            


            prime4anie prime4Anie = new prime4anie() // добавления данных
            {

                date = DateTime.Now,
                Name = Name,
                Surname = Surname,
                JobTitles = JobTitles,
                Note = Note,
                ID = ID,
            };
        
            Console.WriteLine(prime4Anie.Print());
            string text = prime4Anie.Print();//сама строка
            Add(path, text);// метод записи в файл
        }// метод по добавлению строки
    }
}
