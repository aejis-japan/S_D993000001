using System;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using System.Text;
using System.IO;
using System.Windows.Forms;
using Adodb;
using COMMON;
using DSYSLOG;
using para = COMMON.para;

namespace S_D993000001
{
    public partial class S_D993000001_03 : Form
    {
        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            try
            {
                //エラーメッセージを表示する
                MessageBox.Show("エラーが発生しました。\r\n" + "エラー内容を記録もしくは画面キャプチャを行い、システム管理者へ連絡してください。\r\n" + "エラー内容：" + e.Exception.Message + "\r\n" + e.Exception.Data.ToString(), "【ApplicationThreadException】エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                //アプリケーションを終了する
                Application.Exit();
            }
        }
        private void HS1001_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bool forward = e.Modifiers != Keys.Shift;
                //this.ProcessTabKey(forward);
                this.SelectNextControl(this.ActiveControl, forward, true, true, true);
                e.Handled = true;
            }
        }
        public S_D993000001_03()
        {
            InitializeComponent();
        }

        public enum iGrid
        {
            BukenCD                 = 0,                        //物件コード
            GenbaNam                = 1,                        //物件名（現場名）
            Brand                   = 2,                        //ビルダー名
            Address                 = 3,                         //住所
            PF                      = 4,                        //出荷PF
            Directer                = 5,                        //監督名
            Tanto                   = 6                         //担当
        }
        string _sDSysPGID = "S_D993000001_03";
        int _iTestKbn = 1;


        private void S_D993000001_03_Load(object sender, EventArgs e)
        {
            //ログセット
            DSYSLOG_SET log = new DSYSLOG_SET();
            string _sRet = string.Empty;

            try
            {
                //キーイベントをフォームで受け取る
                this.KeyPreview = true;
                //KeyDownイベントハンドラを追加
                this.KeyDown += new KeyEventHandler(HS1001_KeyDown);
                //ThreadExceptionイベントハンドラを追加
                Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);

                //this.fpSpread1.Sheets[0].RemoveRows(0, fpSpread1.Sheets[0].NonEmptyRowCount);
                //fpSpread1.Refresh();
                //fpSpread1.Update();

                //変数定義
                StringBuilder query = new StringBuilder();
                //int i = 0;
                query.Clear();
                SqlDbIf db = new SqlDbIf();
                DataTable tb;
                db.Connect(parameter._sDB, parameter._sCatalog, parameter._sDBID, parameter._sPass, -1);
                query.AppendLine("SELECT TLixilBukenNo,TLixilNouAddress,TLixilNouNam,TLixilTanNam,TLixilBrand ");
                query.AppendLine("FROM TLIXIL ");
                query.AppendLine("GROUP BY TLixilBukenNo, TLixilNouAddress,TLixilNouNam,TLixilBrand,TLixilTanNam,TLixilInsDay ");
                query.AppendLine("ORDER BY TLixilInsDay");
                tb = db.ExecuteSql(query.ToString(), -1);
                if (tb.Rows.Count != 0)
                {                    
                    for (int i = 0; i <= tb.Rows.Count - 1; i++)
                    {
                        this.fpSpread1_Sheet1.AddRows(i, 1);
                        this.fpSpread1_Sheet1.SetText(i, (int)iGrid.BukenCD, tb.Rows[i]["TLixilBukenNo"].ToString().Trim());            //物件コード
                        this.fpSpread1_Sheet1.SetText(i, (int)iGrid.Brand, tb.Rows[i]["TLixilBrand"].ToString().Trim());                //ビルダー名
                        this.fpSpread1_Sheet1.SetText(i, (int)iGrid.GenbaNam, tb.Rows[i]["TLixilNouNam"].ToString().Trim());            //物件名
                        if (tb.Rows[i]["TLixilNouNam"].ToString().Trim().IndexOf("(仮名称)") + 1 > 0 )
                        {
                            fpSpread1.Sheets[0].Cells[i, (int)iGrid.GenbaNam].ForeColor = Color.Red;
                        }
                        this.fpSpread1_Sheet1.SetText(i, (int)iGrid.Address, tb.Rows[i]["TLixilNouAddress"].ToString().Trim());         //納品先住所
                        if (tb.Rows[i]["TLixilNouAddress"].ToString().Trim() == "未登録")
                        {
                            fpSpread1.Sheets[0].Cells[i, (int)iGrid.Address].ForeColor = Color.Red;
                        }
                        this.fpSpread1_Sheet1.SetText(i, (int)iGrid.Tanto, tb.Rows[i]["TLixilTanNam"].ToString().Trim());            //担当者
                    }

                }
                tb.Clear();
                tb.Dispose();
                db.Disconnect();
            }
            catch (Exception ex)
            {
                _sRet = log.putOpeLog(parameter._sDB, parameter._sCatalog, parameter._sDBID, parameter._sPass, _sDSysPGID, parameter._sOpeManID.ToString(),
                    parameter._sOpeManNam, 12, _iTestKbn, "S_D993000001_03_Load", ex.ToString(), "", Environment.UserName.ToString());
            }
            finally
            {

                _sRet = log.putOpeLog(parameter._sDB, parameter._sCatalog, parameter._sDBID, parameter._sPass, _sDSysPGID, parameter._sOpeManID.ToString(), parameter._sOpeManNam, 12, _iTestKbn,
                    "S_D993000001_03_Load", "S_D993000001_03_Load proccess end", "", Environment.UserName.ToString());
                this.Text = this.Text + "　(" + parameter._sOpeManID.ToString() + " : " + parameter._sOpeManNam + "　)";
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fpSpread1_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            parameter._sBukenCD = fpSpread1.Sheets[0].Cells[e.Row, 0].Text.ToString();
            //Console.WriteLine(parameter._sBukenCD);
            S_D993000001_04 f = new S_D993000001_04();
            f.ShowDialog(this);
        }

        private void fpSpread1_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {

        }
    }
}
