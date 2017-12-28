using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.IO;
using System.Security.Cryptography;


namespace AmmuNationCashBox
{
    public partial class Form1 : Form
    {
        public DataSet ds = new DataSet();
        public Form1()
        {
            ds.ReadXml("ammu.xml", XmlReadMode.ReadSchema);
            InitializeComponent();
            dataGridView1.DataSource = ds.Tables["Чек"];
            date.Text = DateTime.Today.ToShortDateString();
            refreshClients();
        }

        private void refreshClients()
        {
            comboBox1.DataSource = null;

            int i = ds.Tables["Клиент"].Rows.Count;
            int[] a = new int[i];
            int count = 0;
            foreach (DataRow dr in ds.Tables["Клиент"].Rows)
            {
                int localNum = int.Parse(dr["НомерКлиентскойКарты"].ToString());
                a[count] = localNum;
                count++;
            }
            comboBox1.DataSource = a;
        }

        private void add_Click(object sender, EventArgs e)
        {
            //если номер карты не заполнен,то начать заново
            if(FIO.Text ==""||textBox2.Text=="")
            {
                MessageBox.Show("Заполните все поля, для того,чтобы начать запись чека!");
                return;
            }
            int cardNum = (int)comboBox1.SelectedItem;
            //int cardNum = 0;
            //if (validateCartNumber == "" || Int32.TryParse(validateCartNumber, out cardNum) == false)
            //{
            //    MessageBox.Show("Введите корректный номер клиентской карты!");
            //    return;
            //}
            // ввод информации о чеке
            // создание нового чека
            DataRow newrow = ds.Tables["Чек"].NewRow();
            // заполнение атрибутов чека
            // для определения номера чека можно узнать 
            // количество строк в таблице чеков
            newrow["НомерЧека"] = ds.Tables["Чек"].Rows.Count + 1;
            // запоминаем номер чека
            int nom = (int)newrow["НомерЧека"];
            newrow["ДатаЧека"] = DateTime.Today;
            //запоминаем номер клиентской карты
            newrow["НомерКлиентскойКарты"] = cardNum;
            // запоминаем дату чека	
            DateTime date = (DateTime)newrow["ДатаЧека"];
            newrow["ФИОКассира"] = FIO.Text;
            // пока не введены данные о записях чека, 
            // общая стоимость равна 0
            newrow["ОбщаяСтоимость"] = 0;
            // записываем созданную запись в таблицу
            ds.Tables["Чек"].Rows.Add(newrow);
            //  выбираем новый чек в качестве текущего
            foreach (DataGridViewRow dgvr in dataGridView1.SelectedRows)
                dgvr.Selected = false;
            dataGridView1.Rows[dataGridView1.Rows.Count - 2].Selected =
        true;
            // вызываем диалог формирования записей чека

            AddChek dlg = new AddChek(nom, date, ds,cardNum);
            dlg.ShowDialog();
            ds.WriteXml("ammu.xml", XmlWriteMode.WriteSchema);

        }

        private void delete_Click(object sender, EventArgs e)
        {
            // если чек не был выбран, удалять нечего
            if (dataGridView1.SelectedRows.Count == 0)
                return;
            DialogResult result = MessageBox.Show("Вы уверены? Действие нельзя будет отменить.", "Удаление чека", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            { 
            //получение номера текущего выбранного чека
            int nom =
             (int)dataGridView1.SelectedRows[0].Cells["НомерЧека"].Value;
            //получение даты текущего выбранного чека
            DateTime date = (DateTime)dataGridView1.SelectedRows[0].
                                           Cells["ДатаЧека"].Value;
            // поиск чека по ключу
            DataRow dr = ds.Tables["Чек"].Rows.Find
     (new object[] { (object)nom, (object)date });
            dr.Delete();
            ds.WriteXml("ammu.xml", XmlWriteMode.WriteSchema);
            }

        }

        private void view_Click(object sender, EventArgs e)
        {
            // если чек не был выбран, удалять нечего
            if (dataGridView1.SelectedRows.Count == 0)
                return;
            //получение номера текущего выбранного чека
            int nom = (int)dataGridView1.SelectedRows[0].
                                            Cells["НомерЧека"].Value;
            //получение даты текущего выбранного чека
            DateTime date = (DateTime)dataGridView1.SelectedRows[0].
                                    Cells["ДатаЧека"].Value;
            // вызываем диалог показа детализации выбранного чека
            ViewChek dlg = new ViewChek(ds.Tables["ЗаписьЧека"],
     ds.Tables["Чек"].Rows.Find(new object[] { nom, date }));
            dlg.ShowDialog();


        }

        private void addClient_Click(object sender, EventArgs e)
        {
            AddClient addcl = new AddClient(ds);
            addcl.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddTovar addtov = new AddTovar(ds);
            addtov.ShowDialog();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                textBox2.Text = "";
            }
            else
            {
                int num = Convert.ToInt32(comboBox1.SelectedItem);
                DataRow dr = ds.Tables["Клиент"].Rows.Find(new object[] { num });
                textBox2.Text = dr["ФИОКлиента"].ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ChangeCassir chCas = new ChangeCassir();
            chCas.ShowDialog();
            String newName = chCas.NewName;
            FIO.Text = newName;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            refreshClients();
        }

        // метод инкапсуляции данных о чеке
        Check CreateCheck(int nom, DateTime date)
        {
            // поиск чека по ключу
            DataRow dr = ds.Tables["Чек"].Rows.Find
      (new object[] { (object)nom, (object)date });
            // создаем объект чека для последующей сериализации
            Check chek = new Check((int)dr["НомерЧека"],
                                  (DateTime)dr["ДатаЧека"],
             (int)dr["НомерКлиентскойКарты"],
             (string)dr["ФИОКассира"]);
            // выбираем все записи, соответствующие 
            // выбранному чеку - дочерние записи
            DataRow[] drs = dr.GetChildRows("СвязьЧека");
            foreach (DataRow d in drs)
            {
                // формируем объект записи чека и добавляем его 
                // в объект чека
                CheckZ z = new CheckZ((string)d["НазваниеТовара"],
                                      (int)d["ЦенаТовара"],
           (int)d["Количество"],
           (int)d["Стоимость"]);
                chek.AddZ(z);
            }
            return chek;
        }

        private void doc_Click(object sender, EventArgs e)
        {
            // определяем, для какого чека следует создать печатную форму
            if (dataGridView1.SelectedRows.Count == 0)
                return;
            // получение номера текущего выбранного чека
            int nom = (int)dataGridView1.SelectedRows[0].
                                           Cells["НомерЧека"].Value;
            // получение даты текущего выбранного чека
            DateTime date = (DateTime)dataGridView1.SelectedRows[0].
                                           Cells["ДатаЧека"].Value;
            // инкапсуляция данных для показа в печатной форме
            Check chek = CreateCheck(nom, date);

            // работа с документами Word
            // создание объекта-приложения
            Word.Application app = new Word.Application();
            // создание и добавление объекта-документа MS Word
            Word.Document doc = app.Documents.Add();

            // создание параграфа с заголовком 
            // (указание номера и даты чека)
            Word.Paragraph p = doc.Content.Paragraphs.Add();
            // задание текста параграфа
            p.Range.Text = "Чек №" + chek.НомерЧека +
                                           " от " + chek.ДатаЧека;
            // указание, что шрифт должен быть полужирным
            p.Range.Font.Bold = 1;
            // центрирование абзаца
            p.Format.Alignment =
                         Word.WdParagraphAlignment.wdAlignParagraphCenter;
            // устанавливаем межабзацный отступ
            p.Format.SpaceAfter = 20;
            p.Range.InsertParagraphAfter();

            // вставка параграфа с указанием магазина
            p = doc.Content.Paragraphs.Add();
            p.Range.Text = "Номер клиентской карты : " + chek.НомерКлиентскойКарты;
            p.Format.Alignment =
                         Word.WdParagraphAlignment.wdAlignParagraphLeft;
            p.Format.SpaceAfter = 20;
            p.Range.InsertParagraphAfter();

            // вставка параграфа с указанием кассира      
            p = doc.Content.Paragraphs.Add();
            p.Range.Text = "Кассир: " + chek.ФИОКассира;
            p.Format.Alignment =
                         Word.WdParagraphAlignment.wdAlignParagraphLeft;
            p.Format.SpaceAfter = 20;
            p.Range.InsertParagraphAfter();

            // вставка параграфа с указанием общей суммы по чеку
            p = doc.Content.Paragraphs.Add();
            p.Range.Text = "Сумма: " + chek.ОбщаяСтоимость;
            p.Format.Alignment =
                         Word.WdParagraphAlignment.wdAlignParagraphLeft;
            p.Range.Font.Size = 20;
            p.Format.SpaceAfter = 20;
            p.Range.InsertParagraphAfter();

            // вставка параграфа с таблицей, в которой указана детальная
            // информация о купленных товарах
            p = doc.Content.Paragraphs.Add();

            // при создании таблицы указывается ее 
            // количество строк и столбцов (2 и 3 параметры)
            Word.Table tab =
                      doc.Tables.Add(p.Range, 1 + chek.Список.Count, 4);
            // указание, что таблица должна иметь рамку
            tab.Borders.Enable = 1;

            // заполняем ячейки таблицы – обращение к таблице
            // осуществляется с помощью функции 
            // Cell(номер строки, номер столбца)
            // отметим, что нумерация строк и столбцов начинается с 1
            tab.Cell(1, 1).Range.Text = "Товар";
            tab.Cell(1, 2).Range.Text = "Цена";
            tab.Cell(1, 3).Range.Text = "Количество";
            tab.Cell(1, 4).Range.Text = "Стоимость";

            // просматриваем список купленных товаров и 
            // заполняем остальные строки таблицы
            for (int i = 0; i < chek.Список.Count; i++)
            {
                tab.Cell(i + 2, 1).Range.Text =
                             (chek.Список[i] as CheckZ).НазваниеТовара;
                tab.Cell(i + 2, 2).Range.Text =
                             "" + (chek.Список[i] as CheckZ).ЦенаТовара;
                tab.Cell(i + 2, 3).Range.Text =
                             "" + (chek.Список[i] as CheckZ).Количество;
                tab.Cell(i + 2, 4).Range.Text =
                             "" + (chek.Список[i] as CheckZ).Стоимость;
            }

            // сохранение документа
            doc.Save();
            // активируем окно MS Word для просмотра 
            // сгенерированного документа
            app.Visible = true;

        }

        private void serial_Click(object sender, EventArgs e)
        {
            // определяем, для какого чека следует создать печатную форму
            if (dataGridView1.SelectedRows.Count == 0)
                return;
            //получение номера текущего выбранного чека
            int nom = (int)dataGridView1.SelectedRows[0].
                                         Cells["НомерЧека"].Value;
            //получение даты текущего выбранного чека
            DateTime date = (DateTime)dataGridView1.SelectedRows[0].
                                         Cells["ДатаЧека"].Value;
            // инкапсуляция данных для сериализации
            Check chek = CreateCheck(nom, date);

            // вызов стандартного диалога сохранения файла
            SaveFileDialog dlg = new SaveFileDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                // создание файлового потока, в который 
                // будет сериализоваться информация о чеке
                FileStream fs = new FileStream(dlg.FileName,
                                               FileMode.Create);
                // создание сериализатора
                SoapFormatter ser = new SoapFormatter();
                // сериализация объекта chek
                ser.Serialize(fs, chek);
                // закрытие файла
                fs.Close();
                MessageBox.Show("Сформирован файл " + dlg.FileName);
            }

        }

        private void gen_Click(object sender, EventArgs e)
        {
            // создаем объект выбранного чека
            // как и в примере из предыдущего раздела
            // В результате имеем заполненный 
            // объект класса Check с именем сhek
            if (dataGridView1.SelectedRows.Count == 0)
                return;
            //получение номера текущего выбранного чека
            int nom = (int)dataGridView1.SelectedRows[0].
                                             Cells["НомерЧека"].Value;
            //получение даты текущего выбранного чека
            DateTime date = (DateTime)dataGridView1.SelectedRows[0].
                                              Cells["ДатаЧека"].Value;
            // инкапсуляция данных для показа в печатной форме
            Check chek = CreateCheck(nom, date);

            // подпись будет создаваться для сериализованного 
            // объекта класса Check  
            // проводим SOAP сериализацию объекта chek
            // создаем объект-форматер
            SoapFormatter ser = new SoapFormatter();

            // создаем поток для сериализации объекта 
            // в оперативной памяти   
            MemoryStream ms = new MemoryStream();
            // проводим сериализацию в память     
            ser.Serialize(ms, chek);

            // считываем сериализованные данные – в результате 
            // получаем массив байт
            // переходим в начало потока в памяти
            ms.Seek(0, SeekOrigin.Begin);
            // получаем массив байт, определяющий объект чека, 
            // считывая из потока в памяти
            byte[] message = new byte[ms.Length];
            ms.Read(message, 0, (int)ms.Length);

            // получаем цифровую подпись с помощью алгоритма DSA
            DSACryptoServiceProvider dsa =
                                     new DSACryptoServiceProvider();
            // цифровая подпись – это также набор байт. 
            byte[] signature = dsa.SignData(message);

            // сохраняем параметры ключа в виде структурированной строки
            string key = dsa.ToXmlString(true);

            // сохраним подпись данного документа в бинарном файле, 
            // имя которого зависит от номера чека
            BinaryWriter br = new BinaryWriter(new FileStream("check" +
     chek.НомерЧека + ".dat", FileMode.Create));

            // сохраняем ключ в созданный файл
            br.Write(key);
            // сохраняем в файл цифровую подпись
            // сначала количество байт
            br.Write(signature.Length);
            // затем саму подпись
            br.Write(signature);
            // закрываем файл с подписью
            br.Close();
            MessageBox.Show("Создана цифровая подпись");
        }

        private void verify_Click(object sender, EventArgs e)
        {
            // создаем объект выбранного чека
            // как и в примере из предыдущего раздела
            if (dataGridView1.SelectedRows.Count == 0)
                return;
            //получение номера текущего выбранного чека
            int nom = (int)dataGridView1.SelectedRows[0].
                                           Cells["НомерЧека"].Value;
            //получение даты текущего выбранного чека
            DateTime date = (DateTime)dataGridView1.SelectedRows[0].
                                Cells["ДатаЧека"].Value;
            // инкапсуляция данных для показа в печатной форме
            Check chek = CreateCheck(nom, date);
            // проводим генерацию хэш-значения для объекта chek
            // SOAP сериализация объекта для формирования 
            // цифровой подписи
            SoapFormatter ser = new SoapFormatter();
            // создаем поток для сериализации объекта 
            // в оперативной памяти
            MemoryStream ms = new MemoryStream();
            ser.Serialize(ms, chek);

            // переходим в начало потока в памяти
            ms.Seek(0, SeekOrigin.Begin);
            // получаем массив байт, определяющий объект чека
            byte[] message = new byte[ms.Length];
            ms.Read(message, 0, (int)ms.Length);

            // работа с цифровой подписью - считываем подпись и 
            // ключ из файла и осуществляем верификацию
            // читаем данные из файла-подписи
            BinaryReader br = new BinaryReader
                      (new FileStream("check" + nom + ".dat",
                       FileMode.Open));
            // читаем ключ для шифрования
            string key = br.ReadString();

            // читаем данные подписи
            int n_sign = br.ReadInt32();
            byte[] b_sign = br.ReadBytes(n_sign);
            br.Close();

            // импортируем параметры в провайдер шифрования
            DSACryptoServiceProvider dsa =
                                     new DSACryptoServiceProvider();
            dsa.FromXmlString(key);

            // проводим верификацию подписей
            // первый параметр - данные для проверки
            // второй параметр - цифровая подпись
            if (dsa.VerifyData(message, b_sign))
                MessageBox.Show("Верификация чека пройдена");
            else
                MessageBox.Show("Верификация чека не пройдена");

        }
    }
}
