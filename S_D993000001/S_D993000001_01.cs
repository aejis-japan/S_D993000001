using System;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Adodb;
using COMMON;
using DSYSLOG;
using para = COMMON.para;

namespace S_D993000001
{
    public partial class S_D993000001_01 : Form
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
        public S_D993000001_01()
        {
            InitializeComponent();
        }

        string _sDSysPGID = "S_D993000001_01";
        int _iTestKbn = 1;

        private void HS1001_Load(object sender, EventArgs e)
        {
            //キーイベントをフォームで受け取る
            this.KeyPreview = true;
            //KeyDownイベントハンドラを追加
            this.KeyDown += new KeyEventHandler(HS1001_KeyDown);
            //ThreadExceptionイベントハンドラを追加
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string sSQL = string.Empty;
            StringBuilder query = new StringBuilder();
            DSYSLOG_SET log = new DSYSLOG_SET();
            string _sRet = string.Empty;
            

            SqlDbIf db = new SqlDbIf();
            DataTable tb;
            db.Connect(parameter._sDB, parameter._sCatalog, parameter._sDBID, parameter._sPass, -1);

            sSQL = "SELECT * FROM MTANTO WHERE MTanTantoID = '" + txtUserID.Text.Trim() + "' AND MTanTanPass = '" + txtPass.Text.Trim() + "'";

            tb = db.ExecuteSql(sSQL, -1);

            if (tb.Rows.Count != 0)
            {

                for (int i = 0; i <= tb.Rows.Count - 1; i++)
                {
                    parameter._sOpeManID = tb.Rows[i]["MTanTantoID"].ToString().Trim();
                    parameter._sOpeManNam= tb.Rows[i]["MTanTanNam"].ToString().Trim();
                    this.Text = "メニュー (ようこそ　" + tb.Rows[i]["MTanTanNam"].ToString().Trim() + "さん)";
                }

                _sRet = log.putOpeLog(parameter._sDB, parameter._sCatalog, parameter._sDBID, parameter._sPass, _sDSysPGID, parameter._sOpeManID, parameter._sOpeManNam, 2, _iTestKbn,
                    "btnLogin_Click", "Login Successed","",Environment.UserName.ToString());
                if (_sRet != "")
                {
                    MessageBox.Show("ログ保管に失敗しました \r\n - エラー：" + _sRet.ToString() + "- \r\nこのエラー内容をシステム管理者へお知らせください。",
                        "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tb.Clear();
                    tb.Dispose();
                    db.Disconnect();
                    this.Close();
                }
                //ログイン成功
                lblUserID.Visible = false;
                lblPass.Visible = false;
                txtUserID.Visible = false;
                txtPass.Visible = false;
                btnLogin.Visible = false;
                lblMemo.Visible = false;
                //btnEntry.Visible = true;
                btnImport.Visible = true;
                btnEntry.Visible = true;
                btnExit.Visible = true;

                //COMMONクラスのDB接続パラメータをセット
                para._sCatalog = parameter._sCatalog;
                para._sDB = parameter._sDB;
                para._sDBID = parameter._sDBID;
                para._sPass = parameter._sPass;
            }
            else
            {
                MessageBox.Show("ユーザーIDもしくはパスワードが正しくありません。", "ログインエラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _sRet = log.putOpeLog(parameter._sDB, parameter._sCatalog, parameter._sDBID, parameter._sPass, _sDSysPGID, txtUserID.Text.Trim(), "Entry Password = " + txtPass.Text.Trim() , 2, _iTestKbn,
                    "btnLogin_Click", "Login Failed","",Environment.UserName.ToString());
                if (_sRet != "")
                {
                    MessageBox.Show("ログ保管に失敗しました \r\n - エラー：" + _sRet.ToString() + "- \r\nこのエラー内容をシステム管理者へお知らせください。",
                        "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tb.Clear();
                    tb.Dispose();
                    db.Disconnect();
                    this.Close();
                }
            }
            tb.Clear();
            tb.Dispose();
            db.Disconnect();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            DSYSLOG_SET log = new DSYSLOG_SET();
            string _sRet = string.Empty;
            _sRet = log.putOpeLog(parameter._sDB, parameter._sCatalog, parameter._sDBID, parameter._sPass, _sDSysPGID, txtUserID.Text.Trim(), parameter._sOpeManNam, 11, _iTestKbn,
                "btnImport_Click()", "btnImport_Click()","", Environment.UserName.ToString());
            S_D993000001_02 f = new S_D993000001_02();
            f.ShowDialog(this);
        }

        private void btnEntry_Click(object sender, EventArgs e)
        {
            S_D993000001_03 f = new S_D993000001_03();
            f.ShowDialog(this);
        }
    }
}
