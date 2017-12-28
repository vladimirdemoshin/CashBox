namespace AmmuNationCashBox
{
    partial class ViewChek
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label_nomer = new System.Windows.Forms.Label();
            this.label_date = new System.Windows.Forms.Label();
            this.label_total = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 54);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(498, 150);
            this.dataGridView1.TabIndex = 0;
            // 
            // label_nomer
            // 
            this.label_nomer.AutoSize = true;
            this.label_nomer.Location = new System.Drawing.Point(9, 13);
            this.label_nomer.Name = "label_nomer";
            this.label_nomer.Size = new System.Drawing.Size(64, 13);
            this.label_nomer.TabIndex = 1;
            this.label_nomer.Text = "label_nomer";
            // 
            // label_date
            // 
            this.label_date.AutoSize = true;
            this.label_date.Location = new System.Drawing.Point(193, 13);
            this.label_date.Name = "label_date";
            this.label_date.Size = new System.Drawing.Size(56, 13);
            this.label_date.TabIndex = 2;
            this.label_date.Text = "label_date";
            // 
            // label_total
            // 
            this.label_total.AutoSize = true;
            this.label_total.Location = new System.Drawing.Point(392, 13);
            this.label_total.Name = "label_total";
            this.label_total.Size = new System.Drawing.Size(55, 13);
            this.label_total.TabIndex = 3;
            this.label_total.Text = "label_total";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(419, 224);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 26);
            this.button1.TabIndex = 4;
            this.button1.Text = "Закрыть";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ViewChek
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 262);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label_total);
            this.Controls.Add(this.label_date);
            this.Controls.Add(this.label_nomer);
            this.Controls.Add(this.dataGridView1);
            this.Name = "ViewChek";
            this.Text = "Просмотр чека";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label_nomer;
        private System.Windows.Forms.Label label_date;
        private System.Windows.Forms.Label label_total;
        private System.Windows.Forms.Button button1;
    }
}