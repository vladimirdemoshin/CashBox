namespace AmmuNationCashBox
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.date = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.add = new System.Windows.Forms.Button();
            this.delete = new System.Windows.Forms.Button();
            this.view = new System.Windows.Forms.Button();
            this.addClient = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.FIO = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.doc = new System.Windows.Forms.Button();
            this.serial = new System.Windows.Forms.Button();
            this.gen = new System.Windows.Forms.Button();
            this.verify = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(321, 199);
            this.dataGridView1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(350, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Кассир :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(350, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Дата :";
            // 
            // date
            // 
            this.date.AutoSize = true;
            this.date.Location = new System.Drawing.Point(415, 9);
            this.date.Name = "date";
            this.date.Size = new System.Drawing.Size(30, 13);
            this.date.TabIndex = 4;
            this.date.Text = "Data";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(350, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Магазин :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(415, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "AmmuNation";
            // 
            // add
            // 
            this.add.Location = new System.Drawing.Point(13, 230);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(159, 23);
            this.add.TabIndex = 7;
            this.add.Text = "Добавить Чек";
            this.add.UseVisualStyleBackColor = true;
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // delete
            // 
            this.delete.Location = new System.Drawing.Point(177, 230);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(159, 23);
            this.delete.TabIndex = 10;
            this.delete.Text = "Удалить  Чек";
            this.delete.UseVisualStyleBackColor = true;
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // view
            // 
            this.view.Location = new System.Drawing.Point(13, 260);
            this.view.Name = "view";
            this.view.Size = new System.Drawing.Size(159, 23);
            this.view.TabIndex = 11;
            this.view.Text = "Просмотр Чека";
            this.view.UseVisualStyleBackColor = true;
            this.view.Click += new System.EventHandler(this.view_Click);
            // 
            // addClient
            // 
            this.addClient.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.addClient.Location = new System.Drawing.Point(575, 271);
            this.addClient.Name = "addClient";
            this.addClient.Size = new System.Drawing.Size(171, 32);
            this.addClient.TabIndex = 12;
            this.addClient.Text = "Работа с Клиентом";
            this.addClient.UseVisualStyleBackColor = false;
            this.addClient.Click += new System.EventHandler(this.addClient_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button1.Location = new System.Drawing.Point(575, 309);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(171, 31);
            this.button1.TabIndex = 13;
            this.button1.Text = "Товарооборот";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(353, 101);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(112, 20);
            this.textBox1.TabIndex = 14;
            this.textBox1.Text = "Выберите клиента:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(350, 134);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Номер карты:";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(353, 150);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(79, 21);
            this.comboBox1.TabIndex = 16;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(572, 134);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "ФИО:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(449, 150);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(294, 20);
            this.textBox2.TabIndex = 18;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(636, 34);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(110, 23);
            this.button2.TabIndex = 19;
            this.button2.Text = "Выбрать кассира";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // FIO
            // 
            this.FIO.Location = new System.Drawing.Point(418, 37);
            this.FIO.Name = "FIO";
            this.FIO.ReadOnly = true;
            this.FIO.Size = new System.Drawing.Size(209, 20);
            this.FIO.TabIndex = 20;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(575, 176);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(171, 23);
            this.button3.TabIndex = 21;
            this.button3.Text = "Обновить список клиентов";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // doc
            // 
            this.doc.Location = new System.Drawing.Point(178, 259);
            this.doc.Name = "doc";
            this.doc.Size = new System.Drawing.Size(158, 23);
            this.doc.TabIndex = 22;
            this.doc.Text = "Сохранить Чек";
            this.doc.UseVisualStyleBackColor = true;
            this.doc.Click += new System.EventHandler(this.doc_Click);
            // 
            // serial
            // 
            this.serial.Location = new System.Drawing.Point(14, 289);
            this.serial.Name = "serial";
            this.serial.Size = new System.Drawing.Size(158, 23);
            this.serial.TabIndex = 23;
            this.serial.Text = "Сериализовать Чек";
            this.serial.UseVisualStyleBackColor = true;
            this.serial.Click += new System.EventHandler(this.serial_Click);
            // 
            // gen
            // 
            this.gen.Location = new System.Drawing.Point(178, 287);
            this.gen.Name = "gen";
            this.gen.Size = new System.Drawing.Size(159, 53);
            this.gen.TabIndex = 24;
            this.gen.Text = "Сгенерировать цифровую подпись";
            this.gen.UseVisualStyleBackColor = true;
            this.gen.Click += new System.EventHandler(this.gen_Click);
            // 
            // verify
            // 
            this.verify.Location = new System.Drawing.Point(13, 318);
            this.verify.Name = "verify";
            this.verify.Size = new System.Drawing.Size(158, 23);
            this.verify.TabIndex = 25;
            this.verify.Text = "Верифицировать Документ";
            this.verify.UseVisualStyleBackColor = true;
            this.verify.Click += new System.EventHandler(this.verify_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(755, 352);
            this.Controls.Add(this.verify);
            this.Controls.Add(this.gen);
            this.Controls.Add(this.serial);
            this.Controls.Add(this.doc);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.FIO);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.addClient);
            this.Controls.Add(this.view);
            this.Controls.Add(this.delete);
            this.Controls.Add(this.add);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.date);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Касса";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label date;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.Button delete;
        private System.Windows.Forms.Button view;
        private System.Windows.Forms.Button addClient;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox FIO;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button doc;
        private System.Windows.Forms.Button serial;
        private System.Windows.Forms.Button gen;
        private System.Windows.Forms.Button verify;
    }
}

