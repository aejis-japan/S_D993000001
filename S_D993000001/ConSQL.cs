using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Adodb
{
   public class SqlDbIf
    {
        /// <summary>
        /// SQLコネクション
        /// </summary>
        private SqlConnection _con = null;

        /// <summary>
        /// トランザクション・オブジェクト
        /// </summary>
        /// <remarks></remarks>
        private SqlTransaction _trn = null;

        /// <summary>
        /// DB接続
        /// </summary>
        /// <param name="svr">サーバー名／IP</param>
        /// <param name="dbn">データベース名</param>
        /// <param name="uid">ユーザーID</param>
        /// <param name="pas">パスワード</param>
        /// <param name="tot">タイムアウト値</param>
        /// <remarks></remarks>
        public void Connect(
            String svr, String dbn, String uid, String pas, int tot)
        {

            try
            {
                if (_con == null)
                {
                    _con = new SqlConnection();
                }

                String cst = "";
                cst = cst + "Server=" + svr;
                cst = cst + ";Database=" + dbn;
                cst = cst + ";User ID=" + uid;
                cst = cst + ";Password=" + pas;
                if (tot > -1)
                {
                    //_con.ConnectionTimeout = tot;
                    cst = cst + ";Connect Timeout=" + tot.ToString();
                }
                _con.ConnectionString = cst;

                _con.Open();
            }
            catch (Exception ex)
            {
                throw new Exception("Connect Error", ex);
            }
        }

        /// <summary>
        /// DB切断
        /// </summary>
        public void Disconnect()
        {
            try
            {
                _con.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Disconnect Error", ex);
            }
        }

        /// <summary>
        /// SQLの実行
        /// </summary>
        /// <param name="sql">SQL文</param>
        /// <param name="tot">タイムアウト値</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public DataTable ExecuteSql(String sql, int tot)
        {
            DataTable dt = new DataTable();

            try
            {
                SqlCommand sqlCommand = new SqlCommand(sql, _con, _trn);

                if (tot > -1)
                {
                    sqlCommand.CommandTimeout = tot;
                }

                SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);

                adapter.Fill(dt);
                adapter.Dispose();
                sqlCommand.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("ExecuteSql Error", ex);
            }

            return dt;
        }
        public DataSet ExecuteSql4DS(String sql, int tot,string sDsName)
        {
            DataSet ds = new DataSet();

            try
            {
                SqlCommand sqlCommand = new SqlCommand(sql, _con, _trn);

                if (tot > -1)
                {
                    sqlCommand.CommandTimeout = tot;
                }

                SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);

                adapter.Fill(ds, sDsName);
                adapter.Dispose();
                sqlCommand.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("ExecuteSql Error", ex);
            }

            return ds;
        }

        /// <summary>
        /// トランザクション開始
        /// </summary>
        /// <remarks></remarks>
        public void BeginTransaction()
        {
            try
            {
                _trn = _con.BeginTransaction();
            }
            catch (Exception ex)
            {
                throw new Exception("BeginTransaction Error", ex);
            }
        }

        /// <summary>
        /// コミット
        /// </summary>
        /// <remarks></remarks>
        public void CommitTransaction()
        {
            try
            {
                if (_trn != null)
                {
                    _trn.Commit();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("CommitTransaction Error", ex);
            }
            finally
            {
                _trn = null;
            }
        }

        /// <summary>
        /// ロールバック
        /// </summary>
        /// <remarks></remarks>
        public void RollbackTransaction()
        {
            try
            {
                if (_trn != null)
                {
                    _trn.Rollback();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("RollbackTransaction Error", ex);
            }
            finally
            {
                _trn = null;
            }
        }

        /// <summary>
        /// デストラクタ
        /// </summary>
        /// <remarks></remarks>
        //~SqlDbIf()
        //{
        //    Disconnect();
        //}
    }
}

//使用例
//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Text;
//using System.Windows.Forms;

//namespace Adodb
//{
//    public partial class Form1 : Form
//    {
//        public Form1()
//        {
//            InitializeComponent();
//        }

//        // DB検索
//        private void button1_Click(object sender, EventArgs e)
//        {
//            SqlDbIf db = new SqlDbIf();
//            DataTable tb;
//            db.Connect("localhost", "master", "sa", "", -1);
//            tb = db.ExecuteSql("select col1,col2,col3 from test", -1);
//            for (int i = 0; i <= tb.Rows.Count - 1; i++)
//            {
//                System.Diagnostics.Trace.WriteLine(
//                    tb.Rows[i]["col1"].ToString() + ":" +
//                    tb.Rows[i]["col2"].ToString() + ":" +
//                    tb.Rows[i]["col3"].ToString());
//            }
//            db.Disconnect();
//        }

//        // DB追加
//        private void button2_Click(object sender, EventArgs e)
//        {
//            SqlDbIf db = new SqlDbIf();
//            db.Connect("localhost", "master", "sa", "", -1);
//            db.BeginTransaction();
//            db.ExecuteSql(
//                "insert into test(col1,col2,col3) " +
//                "values('1234567890',9,'2010-02-14 05:06:07')", -1);
//            db.CommitTransaction();
//            db.Disconnect();
//        }

//        // DB更新
//        private void button3_Click(object sender, EventArgs e)
//        {
//            SqlDbIf db = new SqlDbIf();
//            db.Connect("localhost", "master", "sa", "", -1);
//            db.BeginTransaction();
//            db.ExecuteSql(
//                "update test set col2=3,col3='2010-02-15 05:06:07' " +
//                "where col1='1234567890'", -1);
//            db.CommitTransaction();
//            db.Disconnect();
//        }

//        // DB削除
//        private void button4_Click(object sender, EventArgs e)
//        {
//            SqlDbIf db = new SqlDbIf();
//            db.Connect("localhost", "master", "sa", "", -1);
//            db.BeginTransaction();
//            db.ExecuteSql(
//                "delete from test " +
//                "where col1='1234567890'", -1);
//            db.CommitTransaction();
//            db.Disconnect();
//        }
//    }
//}