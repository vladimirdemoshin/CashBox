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
    public partial class AddTovar : Form
    {
        DataSet dsCopyCopy = new DataSet();
        static bool NameClick = false;
        static bool Saved = true;
        public AddTovar(DataSet ds)
        {
            InitializeComponent();
            dsCopyCopy = ds;
            dataGridView1.DataSource = dsCopyCopy.Tables["Товар"];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text==""||textBox2.Text=="")
            {
                MessageBox.Show("Заполните все поля!");
                return;
            }
            DataRow newrow = dsCopyCopy.Tables["Товар"].NewRow();
            newrow["НомерТовара"] = dsCopyCopy.Tables["Товар"].Rows.Count + 1;
            newrow["НазваниеТовара"] = textBox1.Text;
            newrow["ЦенаТовара"] = Int32.Parse(textBox2.Text);
            dsCopyCopy.Tables["Товар"].Rows.Add(newrow);
            textBox1.Text = "";
            textBox2.Text = "";
            Saved = false;
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            if (!NameClick)
                textBox1.Text = "";
            NameClick = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dsCopyCopy.WriteXml("ammu.xml", XmlWriteMode.WriteSchema);
            MessageBox.Show("Изменения успешно сохранены!");
            Saved = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(!Saved)
            {
                DialogResult result = MessageBox.Show("Изменения не были сохранены, Вы уверены, что хотите продолжить?", "Выход из окна", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                    this.Close();
            }
            else this.Close();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
                return;
            int nom =
             (int)dataGridView1.SelectedRows[0].Cells["НомерТовара"].Value;
            DataRow dr = dsCopyCopy.Tables["Товар"].Rows.Find
     (new object[] { (object)nom });
            dr.Delete();
            Saved = false;
        }
    }
}
