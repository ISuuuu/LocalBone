using HandeBase;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace WinSaveBone
{
    public class PrintBone
    {
       public PersonInfo.Person pd = new PersonInfo.Person();
       public Bone.BoneInfo bi = new Bone.BoneInfo();
       public string subTitle1 = "";

        public double BoneThree(System.Drawing.Graphics gp, double dLeft, double dTop, double dWidth, double dHeight, float fRate)
        {
         
            double nLeft = dLeft * fRate;
            double nTop = dTop * fRate;
            double nWidth = dWidth * fRate;
            double nHeight = dHeight * fRate;
            int lineSpace = 0;
            double top = nTop;
            double height = 0;
            double left = 0;
            double width = 0;
            double tempTop = 0;

            string mainTitle = pd.other;
           
           // string subTitle1 = "1231";
            string subTitle2 = "13212";
                float rate=1.0f;
            List<string> title = new List<string>();
            Font font = new Font("宋体", 16, FontStyle.Regular);
            Brush brush = new SolidBrush(Color.Black);
            Pen pen = new Pen(Color.Black);
            int space = (int)(5 * fRate + 0.5);
            title.Add(mainTitle);         
            top = PrintHandler.DrawTitle(gp, nLeft, nTop+15*space, nWidth, font, brush, title);
            top += space;
            subTitle1 = "骨密度报告";

            title.Clear();
            if (subTitle1 != "")
            {
                title.Add(subTitle1);
            }

            //if (subTitle2 != "")
            //{
            //    title.Add(subTitle2);
            //}


            font = new Font(font.Name, font.Size - 2 * rate, font.Style);
            top = PrintHandler.DrawTitle(gp, nLeft, top+5*space, nWidth, font, brush, title);

            top += 10;
            gp.DrawLine(pen, (float)dLeft, (float)top, (float)(dLeft + dWidth), (float)top);
            top += 4;
            gp.DrawLine(pen, (float)dLeft, (float)top, (float)(dLeft + dWidth), (float)top);

            //个人信息
            top += 10;
            font = new Font(FontName.SimSun, 10.5f * fRate);
            PrintCells cells = new PrintCells(3);
            cells.Graphics = gp;
            cells.LineSpacing = space;
            cells.IsDrawLine = false;
            cells.AddRow(3);
            cells[0][0] = "卡    号：" + pd.idcard;
            cells[0][1] = "姓    名：" + pd.name;
            cells[0][2] = "检测日期：" + bi.time;

            cells[1][0] = "年    龄：" + pd.age + "岁";
            cells[1][1] = "性    别：" + pd.sex;
            cells[1][2] = "检测部位：" + bi.site;

            cells[2][0] = "身    高：" + bi.height + "cm";
            cells[2][1] = "体    重：" + bi.weight + "Kg";
            cells[2][2] = "";
            nLeft += 10 * space;
            //dWidth += 20 * space;

            top = cells.Draw(nLeft, top, nWidth, font, brush);
            lineSpace = (int)(20 * fRate + 0.5);
            top += lineSpace;
            gp.DrawLine(pen, (float)(nLeft-10*space), (float)top, (float)(nLeft + nWidth), (float)top);
            pen.Color = Color.White;
            gp.DrawLine(pen, (float)(nLeft + nWidth / 3), (float)top, (float)(nLeft + nWidth * 2 / 3), (float)top);

            top -= 7 * fRate;
            font = new Font(font.Name, font.Size, FontStyle.Bold);
            cells.RowsClear();
            cells.Columns = 1;
            cells.IsDrawLine = false;

            cells.TextAlign = HorizontalAlignment.Center;
            // cells.AddRowValue("超声波传递速度 (SOS) 检测结果");
            cells.AddRowValue("骨密度检测结果");
            top = cells.Draw(nLeft + nWidth / 3-10*space, top, nWidth / 3, font, brush);

            top += 10 * space;
            font = new Font(font.Name, font.Size, FontStyle.Regular);
            pen.Color = Color.Black;

            top += lineSpace;
            tempTop = top;
            height = (nTop + nHeight - top) / 3;
            width = nWidth / 2 - 2 * space;


            //图形
            DrawShapeThree(gp, nLeft + nWidth / 2 + space-15*space, top, width, height, fRate);

            cells.RowsClear();
            cells.Columns = 2;
            cells.TextAlign = HorizontalAlignment.Center;
            cells.CusTextAlign = new HorizontalAlignment[] { HorizontalAlignment.Left, HorizontalAlignment.Left };
            cells.AddRowValue("成人标准（T值）：", " ");
            cells.AddRowValue("-1<T", "骨密度正常");
            cells.AddRowValue("-2.5<t<-1", "骨密度减少");
            cells.AddRowValue("-2.5>T", "骨质疏松");
            top = cells.Draw(nLeft, top, nWidth / 2, font, brush);

            top += 8 * space;
            cells.RowsClear();
            cells.Columns = 2;
            cells.TextAlign = HorizontalAlignment.Center;
            cells.CusTextAlign = new HorizontalAlignment[] { HorizontalAlignment.Left, HorizontalAlignment.Left };
            cells.AddRowValue("儿童标准（Z值）：", " ");
            cells.AddRowValue("-1<Z", "健康");
            cells.AddRowValue("-1.5<Z<-1", "轻度不足");
            cells.AddRowValue("-2<Z<-1.5", "中度不足");
            cells.AddRowValue("Z<-2", "严重不足");
            top = cells.Draw(nLeft, top, nWidth / 2, font, brush);

            top = tempTop + height + 2 * space;

            width = nWidth / 2 - space;

            top += 5 * space;
            cells.RowsClear();
            cells.Columns = 2;
            double[] columnWidth = new double[] { dWidth * 1 / 3, dWidth * 2 / 3 };
            cells.CusColWith = columnWidth;
            cells.TextAlign = HorizontalAlignment.Left;
            cells.AddRowValue("检测结果:", "");
            cells.AddRowValue("", "");
            cells.AddRowValue("声速（SOS）：" + bi.sos + "M/S", "T值：" + bi.tscore);  //sost 股强度与年轻人比较,,bone.SOST
            cells.AddRowValue("", "");
            cells.AddRowValue("相对骨折风险：" + "", "Z值：" + bi.zscore);  //bone.TI  ,bone.SOSZ

            top = cells.Draw(nLeft, top, dWidth, font, brush);

            top += 5 * space;
            cells.RowsClear();
            cells.Columns = 2;
            cells.AddRowValue("结论:", bi.Result);
            top = cells.Draw(nLeft, top, width, font, brush);
            top += 5 * space;

            Regex reg = new Regex(@"(\S{50})");
            string source = reg.Replace(bi.Suggest, "$1\r\n");

            top += 5 * space;
            cells.RowsClear();
            cells.Columns = 2;
            cells.AddRowValue("建议:");
            cells.AddRowValue(source);
            double lastTop = nTop + nHeight - 70 * fRate;
            top = cells.Draw(nLeft, top, width, font, brush);
           


            //RectangleF relb = new RectangleF((float)dLeft - 6 * space, (float)top + 35 * space, (float)dWidth, (float)dWidth * 2 / 4);
            //gp.DrawString(s, font, brush, relb);

           // top = cells.Draw(nLeft, top, dWidth, lastTop - top - 2 * space, font, brush);

            //top = nTop + nHeight - 70 * fRate;
            top += 10 * space;
            cells.RowsClear();
            cells.Columns = 1;
            cells.AddRowValue("检查医生:");     
            top = cells.Draw(dWidth *80/100, dHeight - 25 * space, nWidth / 4, font, brush);
           

                //(System.Drawing.Graphics gp, double dLeft, double dTop, double dWidth, double dHeight, float fRate)
                //    double dd = pb.BoneThree(g, 10, 10, this.Width , height ,1.0f);


            //top = nTop + nHeight - 20 * fRate;
            //cells.RowsClear();
            //cells.Columns = 2;
            //cells.TextAlign = HorizontalAlignment.Right;
            //cells.CusTextAlign = new HorizontalAlignment[] { HorizontalAlignment.Left, HorizontalAlignment.Right };
            //cells.IsDrawLine = false;
            //cells.AddRowValue("注：该检测结果需结合临床，参照值来源于正常人群数据库", "打印时间:" + DateTime.Now.ToString("yyyy年MM月dd日 HH时mm分"));
            //top = cells.Draw(dLeft, top, dWidth, font, brush);

            return top;
        }


        private void DrawShapeThree(Graphics gp, double dLeft, double dTop, double dWidth, double dHeight, float fRate)
        {
            try
            {
                string file = Function.GetMainPath() + "\\Images\\";
                int x = 30;
                int y = 30;
                int zero = 0;
                int xSpace = 0;
                int ySpace = 0;
                int width = 0;
                int height = 0;
                if (pd.age.ToInt() >= 20)
                {

                    if (pd.sex == "男")
                    {
                        file += "BoneMale.jpg";
                    }
                    else
                    {
                        file += "BoneFemale.jpg";
                    }

                    xSpace = 37;
                    ySpace = 52;
                    zero = 186;
                    width = 508;
                    height = 420;
                }
                else
                {
                    //register.Sex = "";
                    if (pd.sex == "男")
                    {
                        file += "BoneChildMale.jpg";
                    }
                    else
                    {
                        file += "BoneChildFemale.jpg";
                    }

                    xSpace = 50;
                    ySpace = 52;
                    zero = 180;
                    width = 508;
                    height = 420;

                }


                Image image = Image.FromFile(file);
                Graphics g = Graphics.FromImage(image);
                Pen pen = new Pen(Color.Gray);
                pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;

                float T = bi.tscore.ToFloat(0);
                //T = -4.5f;
                float Ty = 0;
                if (T > 0)
                {
                    Ty = zero - (Math.Abs(T) * ySpace);
                }
                else
                {
                    Ty = zero + (Math.Abs(T) * ySpace);
                }


                float Tx = 0;
                if (pd.age.ToInt() >= 20)
                {
                    Tx = x + (pd.age.ToInt() - 20) / 5 * xSpace;
                }
                else
                {
                    Tx = x + pd.age.ToInt() / 2 * xSpace;
                }


                g.DrawLine(pen, new Point(x, (int)(Ty + 0.5)), new Point(x + width, (int)(Ty + 0.5)));
                g.DrawLine(pen, new Point((int)(Tx + 0.5), y), new Point((int)(Tx + 0.5), y + height));


                Font font = new Font(FontName.SimSun, 24.5f * fRate);

                SizeF size = Function.MeasureStringBound("*", font);

               // g.PixelOffsetMode = (PixelOffsetMode)PixelOffsetMode.HighQuality;
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                g.DrawString("*", font, new SolidBrush(Color.LightBlue), (int)(Tx + 0.5) - size.Width / 2 - 1.5f * fRate, (int)(Ty + 0.5) - size.Height / 2 + 1f * fRate);
                GraphicsPath path = new GraphicsPath();
                path.AddString("*", font.FontFamily, (int)font.Style, font.Size * 1.3f, new PointF((int)(Tx + 0.5) - size.Width / 2 - 1.5f * fRate, (int)(Ty + 0.5) - size.Height / 2 + 1f * fRate), new StringFormat());
                pen = new Pen(Color.White, 5);
                pen.Alignment = PenAlignment.Outset;
                g.DrawPath(pen, path);
                pen = new Pen(Color.Yellow, 3f);
                pen.Alignment = PenAlignment.Outset;
                g.DrawPath(pen, path);
                pen = new Pen(Color.Black, 1);
                pen.Alignment = PenAlignment.Outset;
                g.DrawPath(pen, path);
                g.FillPath(new SolidBrush(Color.DarkBlue), path);
                //g.DrawLine(pen, 0, zero, 50, zero);
                g.Dispose();

                gp.DrawImage(image, new Rectangle((int)dLeft, (int)dTop, (int)dWidth, (int)dHeight), new Rectangle(0, 0, image.Width, image.Height), GraphicsUnit.Pixel);
            }
            catch
            {

            }


        }

        
        public enum PixelOffsetMode
        {
            // 摘要:
            //     指定一个无效模式。
            Invalid = -1,
            //
            // 摘要:
            //     指定默认模式。
            Default = 0,
            //
            // 摘要:
            //     指定高速度、低质量呈现。
            HighSpeed = 1,
            //
            // 摘要:
            //     指定高质量、低速度呈现。
            HighQuality = 2,
            //
            // 摘要:
            //     指定没有任何像素偏移。
            None = 3,
            //
            // 摘要:
            //     指定像素在水平和垂直距离上均偏移 -.5 个单位，以进行高速锯齿消除。
            Half = 4,
        }

    }
}
