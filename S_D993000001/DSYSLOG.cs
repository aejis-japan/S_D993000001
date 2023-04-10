using System;
using System.Text;
using Adodb;

namespace DSYSLOG
{
    class para
    {
        //public static string _sCatalog;
        //public static string _sDB;
        //public static string _sDBID;
        //public static string _sPass;
    }
    class DSYSLOG_SET
    {
        public string putOpeLog(string _sDB,string _sCatalog,string _sDBID, string _sPass,
            string _DSysPG_ID, string _DSysOpeID,string _DSysOpeNam,int _DSysOpeKbn,int _DSysTestKbn,
            string _DsysCommand, string _DSysOpeMsg,string _DSysSelectFile, string _DSysMachineNam)
        {
            StringBuilder query = new StringBuilder();
            string sSQL = string.Empty;
            string _sRet = string.Empty;
            _sRet = "";
            //パラメータインプットチェック
            if (_sDB == "")         { _sRet = "Parameter Empty is _sDB";            return _sRet; }
            if (_sCatalog == "")    { _sRet = "Parameter Empty is _sCatalog";       return _sRet; }
            if (_sDBID == "")       { _sRet = "Parameter Empty is _sDBID";          return _sRet; }
            if (_sPass == "")       { _sRet = "Parameter Empty is _sPass";          return _sRet; }
            if (_DSysPG_ID == "")   { _sRet = "Parameter Empty is _DSysPG_ID";      return _sRet; }
            if (_DSysOpeID == "")   { _sRet = "Parameter Empty is _DSysOpeID";      return _sRet; }
            //if (_DSysOpeNam == "")  { _sRet = "Parameter Empty is _DSysOpeNam";     return _sRet; }            
            if (_DSysOpeMsg == "")  { _sRet = "Parameter Empty is _DSysOpeMsg";     return _sRet; }

            SqlDbIf db = new SqlDbIf();
            try
            {
                
                //DataTable tb;
                db.Connect(_sDB, _sCatalog, _sDBID, _sPass, -1);
                query.AppendLine("INSERT INTO DSYSLOG(");
                query.AppendLine("DSysPG_ID,DSysDate,DSysTim,DSysOpeID,DSysOpeNam,DSysOpeKbn,DSysTestKbn,DSysCommand,DSysOpeMsg,DSysSelectFile,DSysMachineNam) ");
                query.AppendLine("VALUES(");
                query.AppendLine("'" + _DSysPG_ID +"',");
                query.AppendLine("FORMAT(GETDATE(),'yyyMMdd'),");
                query.AppendLine("FORMAT(GETDATE(),'HHmmss'),");
                query.AppendLine("'" + _DSysOpeID + "',");
                query.AppendLine("'" + _DSysOpeNam + "',");
                query.AppendLine(_DSysOpeKbn + ",");
                query.AppendLine(_DSysTestKbn + ",");
                query.AppendLine("'" + _DsysCommand + "',");
                query.AppendLine("'" + _DSysOpeMsg + "',");
                query.AppendLine("'" + _DSysSelectFile + "',");
                query.AppendLine("'" + _DSysMachineNam + "')");
                Console.WriteLine(query.ToString());
                db.BeginTransaction();
                db.ExecuteSql(query.ToString(), -1);
                db.CommitTransaction();
                _sRet = "";            

            }
            catch (Exception ex)
            {
                //throw new Exception("ExecuteSql Error", ex);
                _sRet = ex.ToString();
            }
            finally
            {
                db.Disconnect();                
            }
            return _sRet;



        }
    }
}
