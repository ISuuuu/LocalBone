using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace WinSaveBone
{


    public class CardRead
    {
        //读取卡号和个人基本信息
        [DllImport("jobextT.dll", EntryPoint = "iGetCardInfo", CharSet = CharSet.Ansi, SetLastError = false)]
        public static extern long ReadCardInfo
          (
            ref byte pIssuingDate,/*发卡日期  (出参)*/
            ref byte pCardNO,/*社会保障卡卡号(出参)*/
            ref byte pSiNumber,/*证件编号 (即社会保障号)(出参)*/
            ref byte pName,/*姓名(出参)*/
            ref byte pSex,/*性别(出参)*/
            ref byte pBirthDate,/*出生日期(出参)*/
            ref byte pErrMsg/*错误信息(出参)*/
           );
        PersonInfo.Person pd = new PersonInfo.Person();

        #region  
        private byte[] pIssuedeptid;
        /// <summary>
        /// 创建日期
        /// </summary>
        private byte[] pIssuedate;
        /// <summary>
        /// 卡类型（身份证.军官证..）
        /// </summary>
        private byte[] pIdtype;
        private byte[] pCardtype;
        /// <summary>
        /// 身份证号
        /// </summary>
        private byte[] pId;
        /// <summary>
        /// 姓名
        /// </summary>
        private byte[] pName;
        /// <summary>
        /// 性别（1男2女）
        /// </summary>
        private byte[] pSex;
        /// <summary>
        /// 出身日期
        /// </summary>
        private byte[] pBirthDate;
        /// <summary>
        /// 所在单位
        /// </summary>
        private byte[] pCompany;
        /// <summary>
        /// 地址
        /// </summary>
        private byte[] pAddress;
        /// <summary>
        /// 电话
        /// </summary>
        private byte[] pTelephone;

        private byte[] pCardno;
        //private byte[] pidtype;
        /// <summary>社保号
        /// 
        /// </summary>
        private byte[] pSiNumber;

        /// <summary>错误信息
        /// 
        /// </summary>
        private byte[] errmsg;
        #endregion

        public PersonInfo.Person  Read() 
        {
            long ss = ReadCardInfo(ref pIssuedate[0], ref pCardno[0], ref pSiNumber[0], ref pName[0], ref pSex[0], ref pBirthDate[0], ref errmsg[0]);
           string strCardNum = System.Text.Encoding.Default.GetString(pCardno, 0, pCardno.Length).TrimEnd('\0').TrimEnd(' ');
           if (strCardNum != null) 
           {
               string  strSiNumber = System.Text.Encoding.Default.GetString(pSiNumber, 0, pSiNumber.Length).TrimEnd('\0').TrimEnd(' ');

               string  strName = System.Text.Encoding.Default.GetString(pName, 0, pName.Length).TrimEnd('\0').TrimEnd(' ');
               string strbirthday = System.Text.Encoding.Default.GetString(pBirthDate, 0, pBirthDate.Length).TrimEnd('\0').TrimEnd(' ');
               string strSex = System.Text.Encoding.Default.GetString(pSex, 0, pSex.Length).TrimEnd('\0').TrimEnd(' ');
               //if (strSex == "2")
               //{
               //    strSex = "女";
               //}
               //else 
               //{
               //    strSex = "男";
               //}
               pd.name = strName;
               pd.sex = strSex;
               pd.idcard = strCardNum;
               pd.idNum = strSiNumber;
               pd.bir = strbirthday.Insert(6,"-").Insert(4,"-"); //1991-09-09
               string age = (DateTime.Now.Year - Convert.ToInt32(strbirthday.Substring(0, 4))).ToString();
               pd.age = age;
               
              
           }
           return pd;

        }


        public void Init() 
        {           
            errmsg = new byte[1024];          
            pIssuedeptid = new byte[1024];
            pIssuedate = new byte[1024];
            pIdtype = new byte[1024];
            pId = new byte[1024];
            pName = new byte[1024];
            pSex = new byte[1024];
            pBirthDate = new byte[1024];
            pCompany = new byte[1024];
            pAddress = new byte[1024];
            pTelephone = new byte[1024];
            pIssuedeptid = new byte[1024];
            pIssuedate = new byte[1024];
            pCardtype = new byte[1024];
            pSiNumber = new byte[1024];
            //pCardtype = new byte[1024];
            pCardno = new byte[1024];
        }



    }
}
