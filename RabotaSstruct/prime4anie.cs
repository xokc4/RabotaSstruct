using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabotaSstruct
{
    public class prime4anie
    {
       
       

        public DateTime date; // дата

        public string Surname; //  Фамилия

        public string Name; //  Имя

        public string JobTitles; //  Название

        public string Note; // примечание

        public  int ID;//  айди
        

        public void prime4(DateTime date, string Name, string Surname, string JobTitles, string Note, int ID)// способ работы с данными
        {
            this.date = date;
            this.Name = Name;
            this.Surname = Surname;
            this.JobTitles = JobTitles;
            this.Note = Note;
            ID = ID++;
        }
        public string Print()// шаблон строки
        {
            return $"Айди {ID}, Имя: {Name}, фамилия: {Surname}, Названия работы: {JobTitles }, Примечание: {Note}, Время создания: {date} " ;
            }

    }
}
