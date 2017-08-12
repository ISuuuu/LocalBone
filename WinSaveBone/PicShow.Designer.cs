namespace WinSaveBone
{
    partial class PicShow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PicShow));
            this.plmain = new System.Windows.Forms.Panel();
            this.pl = new System.Windows.Forms.Panel();
            this.BtnPrint = new System.Windows.Forms.Button();
            this.plPic = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.plmain.SuspendLayout();
            this.pl.SuspendLayout();
            this.plPic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // plmain
            // 
            this.plmain.AutoScroll = true;
            this.plmain.Controls.Add(this.pl);
            this.plmain.Controls.Add(this.plPic);
            this.plmain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plmain.Location = new System.Drawing.Point(0, 0);
            this.plmain.Name = "plmain";
            this.plmain.Size = new System.Drawing.Size(978, 972);
            this.plmain.TabIndex = 0;
            // 
            // pl
            // 
            this.pl.Controls.Add(this.BtnPrint);
            this.pl.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.pl.Location = new System.Drawing.Point(0, 0);
            this.pl.Name = "pl";
            this.pl.Size = new System.Drawing.Size(111, 51);
            this.pl.TabIndex = 3;
            // 
            // BtnPrint
            // 
            this.BtnPrint.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnPrint.Location = new System.Drawing.Point(3, 3);
            this.BtnPrint.Name = "BtnPrint";
            this.BtnPrint.Size = new System.Drawing.Size(95, 41);
            this.BtnPrint.TabIndex = 0;
            this.BtnPrint.Text = "打 印";
            this.BtnPrint.UseVisualStyleBackColor = true;
            this.BtnPrint.Click += new System.EventHandler(this.BtnPrint_Click);
            // 
            // plPic
            // 
            this.plPic.AutoScroll = true;
            this.plPic.Controls.Add(this.pictureBox1);
            this.plPic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plPic.Location = new System.Drawing.Point(0, 0);
            this.plPic.Name = "plPic";
            this.plPic.Size = new System.Drawing.Size(978, 972);
            this.plPic.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Padding = new System.Windows.Forms.Padding(5);
            this.pictureBox1.Size = new System.Drawing.Size(978, 972);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // PicShow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 972);
            this.Controls.Add(this.plmain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PicShow";
            this.Text = "报告预览";
            this.plmain.ResumeLayout(false);
            this.pl.ResumeLayout(false);
            this.plPic.ResumeLayout(false);
            this.plPic.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel plmain;
        private System.Windows.Forms.Panel pl;
        private System.Windows.Forms.Button BtnPrint;
        private System.Windows.Forms.Panel plPic;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Drawing.Printing.PrintDocument printDocument1;


    }
}