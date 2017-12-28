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
    public partial class AddClient : Form
    {
        static bool FIOClick = false;
        static bool PhoneClick = false;
        static bool Saved = true;
        DataSet dsCopy = new DataSet();
        public AddClient(DataSet ds)
        {
            InitializeComponent();
            
            dsCopy = ds;
            dataGridView1.DataSource = dsCopy.Tables["Клиент"];

            int[] a = new int[101];
            for (int i = 0; i < 101; i++)
                a[i] = i;
            comboBox1.DataSource = a;

        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            if (!FIOClick)
                textBox1.Text = "";
            FIOClick = true;
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            if (!PhoneClick)
                textBox2.Text = "";
            PhoneClick = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataRow newrow = dsCopy.Tables["Клиент"].NewRow();
            newrow["НомерКлиентскойКарты"] = dsCopy.Tables["Клиент"].Rows.Count + 1;
            newrow["ФИОКлиента"] = textBox1.Text;
            newrow["Телефон"] = textBox2.Text;
            newrow["ПроцентСкидки"] = comboBox1.SelectedItem;
            dsCopy.Tables["Клиент"].Rows.Add(newrow);
            textBox1.Text = "";
            textBox2.Text = "";
            Saved = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dsCopy.WriteXml("ammu.xml", XmlWriteMode.WriteSchema);
            MessageBox.Show("Изменения успешно сохранены!");
            Saved = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
                return;
            int nom =
             (int)dataGridView1.SelectedRows[0].Cells["НомерКлиентскойКарты"].Value;
            DataRow dr = dsCopy.Tables["Клиент"].Rows.Find
     (new object[] { (object)nom });
            dr.Delete();
            Saved = false;
        }

        private void button4_Click(object sender, EventArgs e)
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
