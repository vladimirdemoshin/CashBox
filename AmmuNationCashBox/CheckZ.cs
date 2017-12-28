using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmmuNationCashBox
{
    // класс для одной записи чека
    [Serializable]
    class CheckZ
    {
        // поля соответствуют информационным атрибутам 
        //строки табличной части чека
        string названиеТовара;
        int ценаТовара;
        int количество;
        int стоимость;

        // конструктор по умолчанию, нужен для сериализации
        public CheckZ()
        {
            названиеТовара = "";
            ценаТовара = 0;
            количество = 0;
            стоимость = 0;
        }

        // конструктор, инициализирующий запись
        public CheckZ(string s, int price, int count, int cost)
        {
            названиеТовара = s;
            ценаТовара = price;
            количество = count;
            стоимость = cost;
        }

        // свойства для доступа к полям класса
        public string НазваниеТовара
        {
            get { return названиеТовара; }
            set { названиеТовара = value; }
        }

        public int ЦенаТовара
        {
            get { return ценаТовара; }
            set { ценаТовара = value; }
        }

        public int Количество
        {
            get { return количество; }
            set { количество = value; }
        }

        public int Стоимость
        {
            get { return стоимость; }
            set { стоимость = value; }
        }
    }

}
