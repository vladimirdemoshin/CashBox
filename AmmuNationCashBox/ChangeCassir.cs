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
    public partial class ChangeCassir : Form
    {
        public String NewName { get; private set; }
        public ChangeCassir()
        {
            InitializeComponent();
            NewName = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text=="")
            {
                MessageBox.Show("Введите ФИО!");
                return;
            }
            NewName = textBox1.Text;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
