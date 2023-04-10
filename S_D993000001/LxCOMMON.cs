using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Adodb;
using System.Windows.Forms;

namespace COMMON
{
    class para
    {
        public static string _sCatalog;
        public static string _sDB;
        public static string _sDBID;
        public static string _sPass;
    }
    class LxCOMMON
    {
        /// <summary>
        /// YYYYMM をYYYY/MM形式に変換する
        /// <param name="sDate">元の日付用文字列</param>
        /// <param name="iKeta">0→/を入れる,1→年・月を入れる</param>
        /// </summary>
        public String YM_Conv1(string sDate, int iMode)
        {
            //YYYYMM をYYYY/MM形式に変換する
            string sRet = string.Empty;
            if (sDate.Length == 6)
            {
                if (sDate.IndexOf("/") < 0)
                {
                    if (iMode == 0)
                    {
                        sRet = sDate.Substring(0, 4) + "/" + sDate.Substring(4, 2);
                    }
                    else
                    {
                        sRet = sDate.Substring(0, 4) + "年" + sDate.Substring(4, 2) + "月";
                    }

                }
                else
                {
                    sRet = "99999";
                }

            }
            else
            {
                sRet = "99999";
            }
            return sRet;
        }

        /// <summary>
        /// YYYY/MM → YYYYMMへ変換
        /// <param name="sDate">表示年月(YYYY/MM)</param>
        /// </summary>
        public int YMD_ConvInt2(string sDate)
        {
            int iRet = 0;
            string sTmp = string.Empty;

            if (sDate.Length != 7)
            {
                iRet = 9;
            }
            else
            {
                sTmp = sDate.Trim().Substring(0, 4) + sDate.Trim().Substring(5, 2);
            }

            iRet = int.Parse(sTmp);
            return iRet;
        }
        /// <summary>
        /// YYYYMMDD をYYYY/MM/DD形式に変換する
        /// <param name="sDate">元の日付用文字列</param>
        /// <param name="iMode">0 → /を入れる,1 → 年・月を入れる</param>
        /// </summary>
        public String YMD_Conv(string sDate, int iMode)
        {
            //YYYYMM をYYYY/MM形式に変換する
            string sRet = string.Empty;
            if (sDate.Length == 8)
            {
                if (sDate.IndexOf("/") < 0)
                {
                    if (iMode == 0)
                    {
                        sRet = sDate.Substring(0, 4) + "/" + sDate.Substring(4, 2) + "/" + sDate.Substring(6, 2);
                    }
                    else
                    {
                        sRet = sDate.Substring(0, 4) + "年" + sDate.Substring(4, 2) + "月" + sDate.Substring(6, 2) + "日";
                    }

                }
                else
                {
                    sRet = "99999";
                }

            }
            else
            {
                sRet = "99999";
            }
            return sRet;
        }

        /// <summary>
        /// HHmmss をHH:mm:ss形式に変換する
        /// <param name="sTime">時間(HHmmss)</param>
        /// </summary>
        public String HMS_Conv(string sTime)
        {
            //HHmmss をHH:mm:ss形式に変換する
            string sRet = string.Empty;
            if (sTime.Length == 6)
            {
                if (sTime.IndexOf(":") < 0)
                {
                    sRet = sTime.Substring(0, 2) + ":" + sTime.Substring(2, 2) + ":" + sTime.Substring(4, 2);
                }
                else
                {
                    sRet = "99999";
                }

            }
            else
            {
                sRet = "99999";
            }
            return sRet;
        }

        /// <summary>
        /// 日付の整合性チェック
        /// <param name="sDate">日付(yyyyMMdd)</param>
        /// </summary>
        public String DateYMD_CHK(string sDate)
        {
            int iDate;
            DateTime dt;


            switch (sDate.Trim().Length)
            {
                case 0:
                    return "ERROR";
                //break;
                case 6:
                    if (int.TryParse(sDate.Trim(), out iDate))
                    {
                        if (int.Parse(sDate.Trim().Substring(2, 2)) > 12 || int.Parse(sDate.Trim().Substring(2, 2)) < 1)
                        {
                            return "ERROR";
                        }
                        else
                        {
                            if (DateTime.TryParse("20" + sDate.Trim().Substring(0, 2) + "/" + sDate.Trim().Substring(2, 2) + "/" + sDate.Trim().Substring(4, 2), out dt))
                            {
                                return "20" + sDate.Trim().Substring(0, 2) + "/" + sDate.Trim().Substring(2, 2) + "/" + sDate.Trim().Substring(4, 2);
                            }
                            else
                            {
                                return "ERROR";
                            }

                        }

                    }
                    else
                    { return "ERROR"; }
                //break;
                case 8:
                    if (int.TryParse(sDate.Trim(), out iDate))
                    {
                        if (int.Parse(sDate.Trim().Substring(4, 2)) > 12 || int.Parse(sDate.Trim().Substring(4, 2)) < 1)
                        {
                            return "ERROR";
                        }
                        else
                        {
                            if (DateTime.TryParse(sDate.Trim().Substring(0, 4) + "/" + sDate.Trim().Substring(4, 2) + "/" + sDate.Trim().Substring(6, 2), out dt))
                            {
                                return sDate.Trim().Substring(0, 4) + "/" + sDate.Trim().Substring(4, 2) + "/" + sDate.Trim().Substring(6, 2);
                            }
                            else
                            {
                                return "ERROR";
                            }

                        }

                    }
                    else
                    {
                        if (sDate.Trim().Substring(2, 1) != "/" && sDate.Trim().Substring(5, 1) != "/")
                        {
                            return "ERROR";
                        }
                        else
                        {
                            if (DateTime.TryParse("20" + sDate, out dt))
                            {
                                return "20" + sDate;
                            }
                            else
                            {
                                return "ERROR";
                            }

                        }
                    }
                //break;
                case 10:
                    if (sDate.Trim().Substring(4, 1) != "/" && sDate.Trim().Substring(7, 1) != "/")
                    {
                        return "ERROR";
                    }
                    else
                    {
                        if (int.Parse(sDate.Trim().Substring(5, 2)) > 12 || int.Parse(sDate.Trim().Substring(5, 2)) < 1)
                        {
                            return "ERROR";
                        }
                        else
                        {
                            if (DateTime.TryParse(sDate, out dt))
                            {
                                return sDate;
                            }
                            else
                            {
                                return "ERROR";
                            }

                        }

                    }
                default:
                    return "ERROR";
            }


        }
        /// <summary>
        /// yyyy/MM/ddをyyyyMMddに変換する
        /// <param name="sDate">日付(yyyyMMdd)</param>
        /// </summary>
        public int YMD_ConvInt(string sDate)
        {
            int iRet = 0;
            string sTmp = string.Empty;

            if (sDate.Length != 10)
            {
                iRet = 9;
            }
            else
            {
                sTmp = sDate.Trim().Substring(0, 4) + sDate.Trim().Substring(5, 2) + sDate.Trim().Substring(8, 2);
            }

            iRet = int.Parse(sTmp);
            return iRet;
        }
    }

    class LxGetData
    {
        //PF名の呼び出し
        public String getPfName(string sPFCd)
        {
            string sSQL = string.Empty;
            string sRet = string.Empty;


            SqlDbIf db = new SqlDbIf();
            DataTable tb;
            db.Connect(para._sDB, para._sCatalog, para._sDBID, para._sPass, -1);
            sSQL = "SELECT * FROM hs.LxMPF WHERE PfPfCD2 = '" + sPFCd.Trim() + "'";

            tb = db.ExecuteSql(sSQL, -1);
            if (tb.Rows.Count != 0)
            {
                for (int i = 0; i <= tb.Rows.Count - 1; i++)
                {
                    sRet = tb.Rows[i]["PfNam"].ToString();
                }
            }
            else
            {
                sRet = "9999999999";
            }
            tb.Clear();
            tb.Dispose();
            db.Disconnect();
            return sRet;
        }
        public String getManNam(string sManNo)
        {
            string sSQL = string.Empty;
            string sRet = string.Empty;


            SqlDbIf db = new SqlDbIf();
            DataTable tb;
            db.Connect(para._sDB, para._sCatalog, para._sDBID, para._sPass, -1);
            sSQL = "SELECT * FROM hs.MTANTO WHERE TanManNo = '" + sManNo.Trim() + "'";


            tb = db.ExecuteSql(sSQL, -1);
            if (tb.Rows.Count != 0)
            {
                for (int i = 0; i <= tb.Rows.Count - 1; i++)
                {
                    sRet = tb.Rows[i]["TanManNam"].ToString();
                }
            }
            else
            {
                sRet = "99999";
            }
            tb.Clear();
            db.Disconnect();
            return sRet;
        }
    }
}
