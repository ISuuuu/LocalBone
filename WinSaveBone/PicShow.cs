using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinSaveBone
{
    public partial class PicShow : Form
    {
        PrintBone pb = new PrintBone();
        double xdpi = 100;
        double ydpi = 100;
        double xBl = 1;
        double yBl = 1;
        public string subTitle1;



        public PicShow(PersonInfo.Person pdd,Bone.BoneInfo pbb,double xD,double yD,double x,double y)
        {
            InitializeComponent();
           
            //A4210:297
          
            this.Height = this.Width * 297 / 210;
            this.Refresh();
            pb.pd = pdd;
            pb.bi = pbb;
            xdpi = xD;
            ydpi = yD;
            xBl = x;
            yBl = y;
            setPic();
           
        }

       
      


        private  void setPic() 
        {
           // Bitmap bmp = new Bitmap(this.Width, this.Height);
            Bitmap bmp = new Bitmap(this.Width, this.Width * 297 / 210);


            bmp.SetResolution((float)xdpi, (float)ydpi);
            using (Graphics g = Graphics.FromImage(bmp))
            {
             // double dd=  pb.BoneThree(g, 0, 0, this.Width*xBl, this.Height*yBl, 1.0f);
                double height = this.Width * 297 / 210;
                double dd = pb.BoneThree(g, 0, 0, this.Width , height ,1.0f);
                //A4纸比例210：297
             
                pictureBox1.Image = bmp;
               
            }
            string paths = Application.StartupPath + @"\abc.jpg";
            //bmp.Save(paths, System.Drawing.Imaging.ImageFormat.Jpeg);
            Bitmap bb = new Bitmap(this.pictureBox1.Image);
            bb.Save(paths);
            
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            PrintDialog MyPrintDg = new PrintDialog();
            MyPrintDg.Document = printDocument1;
            if (MyPrintDg.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    printDocument1.Print();
                }
                catch
                {   //停止打印
                    printDocument1.PrintController.OnEndPrint(printDocument1, new System.Drawing.Printing.PrintEventArgs());
                }
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(pictureBox1.Image, 0, 0);

        }

       
    }
}
