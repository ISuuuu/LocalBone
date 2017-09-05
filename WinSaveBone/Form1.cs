using HandeBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;

using System.Linq;
using System.Text;
using System.Windows.Forms;
using HandeSwipe;

namespace WinSaveBone
{
    public partial class Form1 : Form
    {
        private SettingsEx setting;//配置文件 
        string paths;
        List<string> iniList;
        int flag = 0;
        string pathsResult = "";
        string pathWrite = "";
        double xDpi = 100;
        double yDpi = 100;
        double xbel = 1;
        double ybel = 1;
        SQLiteConnection conn;
        SQLiteCommand cmd = new SQLiteCommand();
        SQLiteDataReader reader;

        PersonInfo.Person pd = new PersonInfo.Person();
        Bone.BoneInfo b = new Bone.BoneInfo();

        private HandeSwipe.CardOperation card;//卡操作
        string cardID;  //卡号
        string subjectName = "";

 
        public Form1()
        {
            InitializeComponent();
            setting = new SettingsEx();
            paths = Application.StartupPath + "\\Setting.xml";
            setting.Read(paths);
            iniList = new List<string>();
            string filename  = setting["DataBase"]["SQLite"]["DataBaseName"];
            string strconn = SetConnectionString(Application.StartupPath, filename);
            pathsResult= setting["DeviceInfo"]["ResultData"]["Values"].ToString();
            pathWrite = setting["DeviceInfo"]["WritePath"]["Values"].ToString();
            xDpi =Convert.ToDouble(setting["fenbianlv"]["fbl"]["xDpi"].ToString());
            yDpi =Convert.ToDouble(setting["fenbianlv"]["fbl"]["yDpi"].ToString());
            xbel = Convert.ToDouble(setting["fenbianlv"]["dx"]["x"].ToString());
            ybel = Convert.ToDouble(setting["fenbianlv"]["dx"]["y"].ToString());
            subjectName = setting["Soft"]["Hospital"]["Support"].ToString();
            conn = new SQLiteConnection(strconn);
            conn.Open();
            cmd.Connection = conn;
           // timer1.Enabled = true;
            getTxtToListBox();

    
           // readLocalSetting();
        }

        private string getTxtToListBox() 
        {
            string[] dirs = Directory.GetFiles(pathsResult, "*.ini");
            if (dirs.Length>0) 
            {
                string[] aa = new string[dirs.Length];
                for (int a = 0; a < dirs.Length; a++) 
                {
                    aa[a] = System.IO.Path.GetFileName(dirs[a]);
                }
                listBox1.Items.Clear();
                listBox1.Items.AddRange(aa);
            }
           // timer1.Enabled = true;
            //just for fun!
            
            return "";
        }

        
        
        private void readLocalSetting()
        {       
           
            if (conn != null)
            {
                
                string sql = "select count(*) as ss from personinfo";
                cmd.CommandText = sql;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string sss = Convert.ToString(reader["ss"]);
                }
            }

        }

        private PersonInfo.Person getPerson(string cardId) 
        {
            if (conn != null) 
            {
                
                string sql = "select * from personinfo where CardID='" + cardId + "'";
                if (cmd.CommandText == "" || cmd.CommandText == null)
                {
                }
                else
                {
                    cmd.Dispose();
                    cmd = new SQLiteCommand();
                    cmd.Connection = conn;
                }
                cmd.CommandText = sql;
                reader = cmd.ExecuteReader();
                while (reader.Read()) 
                {
                    pd.idcard = cardId;
                    pd.idNum = Convert.ToString(reader["CredentialsNo"]);
                    pd.name = Convert.ToString(reader["ResidentName"]);
                    pd.sex = Convert.ToString(reader["SexName"]);
                    if (pd.idNum.Length == 18) 
                    {
                        pd.age = (DateTime.Now.Year - Convert.ToInt32(pd.idNum.Substring(6, 4))).ToString();  //1234561991
                    }
                }
            }
            return pd;
        
        }

        public string SetConnectionString(string strPath, string strDataBaseName)
        {
            string conn = "";
            conn = "Data Source=" + strPath + "\\" + strDataBaseName + ";Pooling=true;FailIfMissing=false";
            return conn;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listBox1.SelectedIndex >= 0) 
            {
                string txtName = this.listBox1.SelectedItem.ToString();
                if (txtName.Contains("_")) 
                {
                    //本地ini文件命名规则 （卡号_姓名.ini） ，读取时 根据文件名中的卡号，在数据库查找对应信息。
                    string cardID = txtName.Split('_')[0];
                    pd = getPerson(cardID);
                    lblName.Text = pd.name;
                    lblSex.Text = pd.sex;
                    lblAge.Text = pd.age;
                    lblCardID.Text = pd.idcard;
                    txtSuggest.Text = "";

                }
                //保存结果信息
                string paths = pathsResult + "\\" + txtName;
                if (File.Exists(paths))
                {
                    iniRead iniReadPath = new iniRead(paths);
                    b.tscore = iniReadPath.ReadInivalue("Result", "tscore").ToString();  //T值
                    b.zscore = iniReadPath.ReadInivalue("Result", "zscore").ToString();  //Z值
                    b.sos = iniReadPath.ReadInivalue("Result", "sos").ToString();
                    b.tscoreRatio = iniReadPath.ReadInivalue("Result", "tscoreRatio").ToString();
                    b.zscoreRatio = iniReadPath.ReadInivalue("Result", "zscoreRatio").ToString();
                    //SBUA = iniReadPath.ReadInivalue("Result", "bua").ToString();
                    b.site = iniReadPath.ReadInivalue("Result", "site").ToString();
                    b.height = iniReadPath.ReadInivalue("Result", "height").ToString();
                    b.weight = iniReadPath.ReadInivalue("Result", "weight").ToString();
                    b.time = iniReadPath.ReadInivalue("Result", "measuretime").ToString();
                    if (b.time.Contains("_")) 
                    {
                        b.time = b.time.Split('_')[0];
                        b.time = b.time.Insert(6, "-").Insert(4, "-");  //20170809
                    }
                    if (b.site.Trim() == "RIGHT_FOOT")
                    {
                        b.site = "右脚";
                    }
                    else
                    {
                        b.site = "左脚";
                    }
                    b.tscore = Math.Round(Convert.ToDouble(b.tscore), 2).ToString();
                    b.zscore = Math.Round(Convert.ToDouble(b.zscore), 2).ToString();
                    b.Result = getBoneResult(b.tscore);
                    b.Suggest = "";                   
                }
                

                
            }
        }

        private string getBoneResult(string tscore) 
        {
            string result = "";
            double t = Convert.ToDouble(tscore);
            if (t >= -1) { result = "骨密度正常"; }
            else if (t >= -2.5 && t < -1) { result = "骨密度减少"; }
            else { result = "骨质疏松"; }
            return result;
        }

        private void Btnreport_Click(object sender, EventArgs e)
        {
            if (pd.name == "") { MessageBox.Show("请确认此人已经刷卡登记"); }
            try
            {
                if (pd.name != null)
                {
                    if (txtSuggest.Text.Contains("再次输入建议")) { txtSuggest.Text = ""; }
                    b.Suggest = txtSuggest.Text;
                    pd.other = subjectName;
                    PicShow ps = new PicShow(pd, b, xDpi, yDpi,xbel,ybel);
                    //ps.subTitle1 = subjectName;
                    ps.Show();

                }
            }
            catch (Exception ee) 
            {
                Function.WriteLog("Print.log", ee.Message);
            }
           
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (flag == 0) 
            {
                txtSuggest.Text = "";
                flag = 1;
            }

        }

        private void BtnCardRead_Click(object sender, EventArgs e)
        {
            try
            {
                CardRead cr = new CardRead();
                cr.Init();
                pd = cr.Read();
                //savePersoninfo
                savePersoninfo(pd);
                WriteSonost3000Data(pathWrite, pd.idcard, pd.name, pd.bir, pd.sex, "", "");// 没有身高体重
            }
            catch (Exception ew) 
            {
                Function.WriteLog("readCard.log", ew.Message);
            }
           
        }

        private void savePersoninfo(PersonInfo.Person pp) 
        {           
            if (conn != null)
            {
                //pp.idcard = "123456";
                string sql = "select count(*) as num from personinfo where CardID='" + pp.idcard + "'";
                if (cmd.CommandText == "" || cmd.CommandText == null)
                {
                }
                else
                {
                    cmd.Dispose();
                    cmd = new SQLiteCommand();
                    cmd.Connection = conn;
                }
                cmd.CommandText = sql;
                string num= cmd.ExecuteScalar().ToString();
                if (num == "0")
                {
                    string sexName="";
                    if(pd.sex=="2"){sexName="女";}
                    else{sexName="男";}
                    string createTime=DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                     sql = "insert into personinfo(ResidentID,ResidentName,CredentialsNo,CardID,SexCD,SexName,BirthDay,CreateDate) values('" + pd.idNum + "','" + pd.name + "','" + pd.idNum + "','"+pd.idcard+"','" + pd.sex + "','" + sexName + "','" + pd.bir + "','" + createTime+ "')";
                     cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
                }
                else 
                {
                    //更新？ 
                }              
        }
        }
        private void WriteSonost3000Data(string filePath, string strid, string strname, string birthday, string sex, string Height, string Weight)
        {            
            if (File.Exists(filePath) == false)
            {
                FileStream fs = new FileStream(filePath, FileMode.Create);
                StreamWriter sw = new StreamWriter(fs, Encoding.Default);


                if (sex == "1" || sex == "男" || sex == "M")
                {
                    sex = "1";
                }
                else
                {
                    sex = "0";
                }
                if (birthday != "" && birthday != null)
                {
                    birthday = Convert.ToDateTime(birthday).ToString("yyyy-MM-dd");
                }
                //开始写入
                sw.WriteLine("[INSERT]");
                sw.WriteLine("ID=" + strid);
                sw.WriteLine("Name=" + strname);
                sw.WriteLine("Birthdate=" + birthday);
                sw.WriteLine("SEX=" + sex);
                sw.WriteLine("Height=" + Height);
                sw.WriteLine("Weight=" + Weight);
                //清空缓冲区
                sw.Flush();
                //关闭流
                sw.Close();
                fs.Close();
            }
            else
            {
                FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs, Encoding.Default);
                if (sex == "1" || sex == "男" || sex == "M")
                {
                    sex = "1";
                }
                else
                {
                    sex = "0";
                }
                if (birthday != "" && birthday != null)
                {
                    birthday = Convert.ToDateTime(birthday).ToString("yyyy-MM-dd");
                }
                //开始写入
                sw.WriteLine("[INSERT]");
                sw.WriteLine("ID=" + strid);
                sw.WriteLine("Name=" + strname);
                sw.WriteLine("Birthdate=" + birthday);
                sw.WriteLine("SEX=" + sex);
                sw.WriteLine("Height=" + Height);
                sw.WriteLine("Weight=" + Weight);
                //清空缓冲区
                sw.Flush();
                //关闭流
                sw.Close();
                fs.Close();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //timer1.Enabled = false;
            //getTxtToListBox();

        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            this.txtSuggest.Text = "";
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnF5_Click(object sender, EventArgs e)
        {
            getTxtToListBox();
        }

    }
}
