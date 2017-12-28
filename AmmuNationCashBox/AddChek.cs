using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AmmuNationCashBox
{
    public partial class AddChek : Form
    {
        static bool Saved = true;

        int nom;        // номер текущего чека
        DateTime date;  // дата текущего чека

        DataTable table;    // таблица записей чека

        int count = 0;      // количество записей чека
        int total_cost = 0;   // общая стоимость чека
        DataSet dataSet = new DataSet();

        int discont;
        public AddChek(int nom, DateTime date, DataSet ds,int cardNum)
        {
            InitializeComponent();
            //date1.Text = DateTime.Today.ToShortDateString();
            //dataSet.ReadXml("ammu.xml", XmlReadMode.ReadSchema);
            //DataRow discont = dataSet.Tables["Клиент"].Rows.Find(cardNum);  //вот тут хз будет работать или нет
            //int disc = Convert.ToInt32(discont["ПроцентСкидки"]);
            //comboBoxID.DataSource = dataSet.Tables["Товар"];
            // сохраняем данные чека
            this.nom = nom;
            this.date = date;
            DataTable table = ds.Tables["ЗаписьЧека"];
            this.table = table;
            dataSet = ds;


            //discontLabel.Text = "Скидка:"+disc+" Процентов";

            label5.Text = "Дата: "+ DateTime.Today.ToShortDateString();
            // показываем номер чека
            labelNomer.Text = "Номер чека: " + nom;

            //dataGridView1.DataSource = dataSet.Tables["ЗаписьЧека"];
            // формирование DataGridView без автозаполнения
            // отмена генерации столбцов DataGridView
            dataGridView1.AutoGenerateColumns = false;

            // заполнение структуры таблицы записи чека для dataGridView1
            foreach (DataColumn dc in table.Columns)
            {
                // последовательное создание столбцов элемента управления
                DataGridViewTextBoxColumn dgvc =
      new DataGridViewTextBoxColumn();
                // заголовок столбца
                dgvc.HeaderText = dc.Caption;
                // добавление столбца в коллекцию столбцов DataGridView
                dataGridView1.Columns.Add(dgvc);
            }

            //прост забиваю комбобокс цифрами,потом по этому ключу-циферке буду высвечивать имя оружия
            //int i = ds.Tables["Товар"].Rows.Count;
            //int[] a = new int[i];
            //for(int j=0;j<i;j++)
            //{
            //    a[j] = j+1;
            //}
            //comboBoxID.DataSource = a;

            int i = ds.Tables["Товар"].Rows.Count;
            int[] a = new int[i];
            int count = 0;
            foreach (DataRow dataRow in ds.Tables["Товар"].Rows)
            {
                int localNum = int.Parse(dataRow["НомерТовара"].ToString());
                a[count] = localNum;
                count++;
            }
            comboBoxID.DataSource = a;

            int[] b = new int[10];
            for (int j = 0; j < 10; j++)
            {
                b[j] = j + 1;
            }
            comboBox1.DataSource = b;

            DataRow dr = dataSet.Tables["Клиент"].Rows.Find(cardNum);
            int discont = Convert.ToInt32(dr["ПроцентСкидки"]);
            discontLabel.Text = "Скидка: " + discont + " %";
            this.discont = discont;
        }


        private void add_Click(object sender, EventArgs e)
        {
            // вводим информацию о записи чека
            DataRow newrow = table.NewRow();
            newrow["НомерЗаписиЧека"] = count + 1;
            newrow["НомерЧека"] = nom;
            newrow["ДатаЧека"] = date;
            newrow["НазваниеТовара"] = textBox1.Text;
            // считываем данные из текстовых полей о товаре, 
            // количестве и цене
            //newrow["НомерТовара"] = int.Parse(comboBoxID.SelectedItem);
           
            newrow["ЦенаТовара"] = int.Parse(textBox2.Text);
            newrow["Количество"] = comboBox1.SelectedItem;
            int withDiscont = (int)newrow["ЦенаТовара"] * discont / 100;
            newrow["Стоимость"] = ((int)newrow["ЦенаТовара"] - withDiscont)
      * (int)newrow["Количество"];
            // запоминаем стоимость
            int cost = (int)newrow["Стоимость"];
            // добавляем запись о купленном товаре в таблицу
            table.Rows.Add(newrow);

            //      // добавляем новую строку в DataGridView c записями чека,
            //      // заполняем данными из новой строки таблицы
            DataGridViewRow dgwr = new DataGridViewRow();
            dgwr.CreateCells(dataGridView1, newrow["НомерЗаписиЧека"],
      newrow["НомерЧека"], newrow["ДатаЧека"],
      newrow["НазваниеТовара"],
      newrow["ЦенаТовара"], newrow["Количество"],
      newrow["Стоимость"]);
            dataGridView1.Rows.Add(dgwr);


            // корректировка общей стоимости
            total_cost = total_cost + cost;
            label_total.Text = "Итого: " + total_cost + " рублей";

            // корректировка общей стоимости в родительской таблице
            DataRow dr = newrow.GetParentRow("СвязьЧека");
            dr["ОбщаяСтоимость"] = total_cost;

            count++;
            Saved = false;
        }

        private void comboBoxID_SelectedIndexChanged(object sender, EventArgs e)
        {
            int num = Convert.ToInt32(comboBoxID.SelectedItem);
            DataRow dr = dataSet.Tables["Товар"].Rows.Find(new object[] { num });
            textBox1.Text = dr["НазваниеТовара"].ToString();
            textBox2.Text = dr["ЦенаТовара"].ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataSet.WriteXml("ammu.xml", XmlWriteMode.WriteSchema);
            MessageBox.Show("Изменения успешно сохранены!");
            Saved = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!Saved)
            {
                DialogResult result = MessageBox.Show("Изменения не были сохранены, Вы уверены, что хотите продолжить?", "Выход из окна", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                    this.Close();
            }
            else this.Close();
        }

    }
}
