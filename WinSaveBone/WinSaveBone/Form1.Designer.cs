namespace WinSaveBone
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.Btnreport = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BtnCardRead = new System.Windows.Forms.Button();
            this.lblCardID = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblAge = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblSex = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSuggest = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.listBox1);
            this.panel1.Location = new System.Drawing.Point(4, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(240, 296);
            this.panel1.TabIndex = 0;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(3, 3);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(234, 280);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // Btnreport
            // 
            this.Btnreport.Location = new System.Drawing.Point(4, 236);
            this.Btnreport.Name = "Btnreport";
            this.Btnreport.Size = new System.Drawing.Size(75, 23);
            this.Btnreport.TabIndex = 1;
            this.Btnreport.Text = "报告预览";
            this.Btnreport.UseVisualStyleBackColor = true;
            this.Btnreport.Click += new System.EventHandler(this.Btnreport_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.BtnCardRead);
            this.panel2.Controls.Add(this.lblCardID);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.lblAge);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.lblSex);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.lblName);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txtSuggest);
            this.panel2.Controls.Add(this.Btnreport);
            this.panel2.Location = new System.Drawing.Point(255, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(369, 293);
            this.panel2.TabIndex = 2;
            // 
            // BtnCardRead
            // 
            this.BtnCardRead.Location = new System.Drawing.Point(140, 236);
            this.BtnCardRead.Name = "BtnCardRead";
            this.BtnCardRead.Size = new System.Drawing.Size(75, 23);
            this.BtnCardRead.TabIndex = 12;
            this.BtnCardRead.Text = "读 卡";
            this.BtnCardRead.UseVisualStyleBackColor = true;
            this.BtnCardRead.Click += new System.EventHandler(this.BtnCardRead_Click);
            // 
            // lblCardID
            // 
            this.lblCardID.AutoSize = true;
            this.lblCardID.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCardID.Location = new System.Drawing.Point(202, 42);
            this.lblCardID.Name = "lblCardID";
            this.lblCardID.Size = new System.Drawing.Size(0, 20);
            this.lblCardID.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(138, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 20);
            this.label6.TabIndex = 10;
            this.label6.Text = "卡 号：";
            // 
            // lblAge
            // 
            this.lblAge.AutoSize = true;
            this.lblAge.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblAge.Location = new System.Drawing.Point(207, 10);
            this.lblAge.Name = "lblAge";
            this.lblAge.Size = new System.Drawing.Size(0, 20);
            this.lblAge.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(143, 10);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 20);
            this.label8.TabIndex = 8;
            this.label8.Text = "年 龄：";
            // 
            // lblSex
            // 
            this.lblSex.AutoSize = true;
            this.lblSex.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSex.Location = new System.Drawing.Point(85, 42);
            this.lblSex.Name = "lblSex";
            this.lblSex.Size = new System.Drawing.Size(0, 20);
            this.lblSex.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(21, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "性 别：";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblName.Location = new System.Drawing.Point(84, 10);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(0, 20);
            this.lblName.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(20, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "姓 名：";
            // 
            // txtSuggest
            // 
            this.txtSuggest.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtSuggest.Location = new System.Drawing.Point(4, 79);
            this.txtSuggest.Multiline = true;
            this.txtSuggest.Name = "txtSuggest";
            this.txtSuggest.Size = new System.Drawing.Size(344, 132);
            this.txtSuggest.TabIndex = 2;
            this.txtSuggest.Text = "在此输入建议";
            this.txtSuggest.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textBox1_MouseClick);
            // 
            // timer1
            // 
            this.timer1.Interval = 3000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 307);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button Btnreport;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtSuggest;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCardID;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblAge;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblSex;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button BtnCardRead;
        private System.Windows.Forms.Timer timer1;
    }
}

