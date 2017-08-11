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

        public PicShow(PersonInfo.Person pdd,Bone.BoneInfo pbb,double xD,double yD)
        {
            InitializeComponent();
            pb.pd = pdd;
            pb.bi = pbb;
            xdpi = xD;
            ydpi = yD;
            setPic();
        }


        private  void setPic() 
        {
           // Graphics g = new Graphics();
            Bitmap bmp = new Bitmap(this.Width, this.Height);

            bmp.SetResolution((float)xdpi, (float)ydpi);
            using (Graphics g = Graphics.FromImage(bmp))
            {
              double dd=  pb.BoneThree(g, 0, 0, this.Width, this.Height, 1.0f);
                pictureBox1.Image = bmp;
            }
            
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
            e.Graphics.DrawImage(pictureBox1.Image, 20, 20);

        }
    }
}
