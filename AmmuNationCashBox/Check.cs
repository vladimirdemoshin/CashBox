using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmmuNationCashBox
{
    // класс для инкапсуляции информации всего документа «Чек»
    [Serializable]
    class Check
    {
        // поля соответствуют атрибутам шапки документа
        int номерЧека;
        DateTime датаЧека;
        int номерКлиентскойКарты;
        string фиоКассира;
        int общаяСтоимость;

        // список для хранения строк табличной части документа 
        ArrayList list;

        // конструктор по умолчанию, нужен для сериализации
        public Check()
        {
            номерЧека = 0;
            датаЧека = DateTime.Today;
            номерКлиентскойКарты = 0;
            фиоКассира = "";
            общаяСтоимость = 0;
            list = new ArrayList();
        }

        // конструктор, инициализирующий атрибуты шапки чека
        public Check(int nom, DateTime d, int card, string kassa)
        {
            номерЧека = nom;
            датаЧека = d;
            номерКлиентскойКарты = card;
            фиоКассира = kassa;
            // общую стоимость следует синхронизировать 
            //с табличной частью
            общаяСтоимость = 0;
            list = new ArrayList();
        }

        // метод добавления записи к табличной части документа, 
        // заполненный объект записи чека метод получает как параметр
        public void AddZ(CheckZ z)
        {
            // добавляем объект записи в список
            list.Add(z);
            // корректировка общей стоимости чека
            общаяСтоимость += z.Стоимость;
        }

        // свойства для доступа к полям класса
        public int НомерЧека
        {
            get { return номерЧека; }
            set { номерЧека = value; }
        }

        public DateTime ДатаЧека
        {
            get { return датаЧека; }
            set { датаЧека = value; }
        }

        public int НомерКлиентскойКарты
        {
            get { return номерКлиентскойКарты; }
            set { номерКлиентскойКарты = value; }
        }

        public string ФИОКассира
        {
            get { return фиоКассира; }
            set { фиоКассира = value; }
        }

        public int ОбщаяСтоимость
        {
            get { return общаяСтоимость; }
            set { общаяСтоимость = value; }
        }

        public ArrayList Список
        {
            get { return list; }
            set { list = value; }
        }
    }

}
