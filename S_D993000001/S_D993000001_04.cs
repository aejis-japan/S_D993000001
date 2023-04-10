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
    public partial class S_D993000001_04 : Form
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
        public S_D993000001_04()
        {
            InitializeComponent();
        }

        private Microsoft.International.Windows.YomiAutoCompletionListener _listner;
        string _sDSysPGID = "S_D993000001_04";
        int _iTestKbn = 1;
        DataTable _dPF = new DataTable();


        private void S_D993000001_04_Load(object sender, EventArgs e)
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
                txtBukenCD.Text = parameter._sBukenCD.ToString().Trim();

                //オブジェクトの各種操作
                _listner = new Microsoft.International.Windows.YomiAutoCompletionListener(txtTLixilPF);



                //変数定義
                String _SPf = string.Empty;
                StringBuilder query = new StringBuilder();
                query.Clear();
                SqlDbIf db = new SqlDbIf();
                DataTable tb;
                db.Connect(parameter._sDB, parameter._sCatalog, parameter._sDBID, parameter._sPass, -1);

                /////////////////////////
                ////物件詳細データの抽出
                /////////////////////////
                query.Clear();
                query.AppendLine("SELECT * ");
                query.AppendLine("FROM TLIXIL ");
                query.AppendLine("WHERE TLixilBukenNo = '" + parameter._sBukenCD.ToString().Trim() + "'");
                tb = db.ExecuteSql(query.ToString(), -1);
                if (tb.Rows.Count == 0)
                {
                    //ログセット
                    _sRet = log.putOpeLog(parameter._sDB, parameter._sCatalog, parameter._sDBID, parameter._sPass, _sDSysPGID, parameter._sOpeManID.ToString(), parameter._sOpeManNam, 9, _iTestKbn,
                        "S_D993000001_04_Load", "物件Noを抽出できませんでした。物件No= " + parameter._sBukenCD.ToString().Trim(), "", Environment.UserName.ToString());
                    MessageBox.Show("該当データを抽出できません。\r\n至急、システム管理者へ連絡してください。","エラー",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    tb.Clear();
                    tb.Dispose();
                    db.Disconnect();
                }
                else if(tb.Rows.Count > 1)
                {
                    //ログセット
                    _sRet = log.putOpeLog(parameter._sDB, parameter._sCatalog, parameter._sDBID, parameter._sPass, _sDSysPGID, parameter._sOpeManID.ToString(), parameter._sOpeManNam, 9, _iTestKbn,
                        "S_D993000001_04_Load", "物件Noが複数存在します。物件No= " + parameter._sBukenCD.ToString().Trim(), "", Environment.UserName.ToString());
                    MessageBox.Show("該当データを複数存在します。\r\n至急、システム管理者へ連絡してください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tb.Clear();
                    tb.Dispose();
                    db.Disconnect();
                }
                else
                {
                    //指定された物件コードの詳細データを抽出
                    for (int i = 0; i <= tb.Rows.Count - 1; i++)
                    {
                        lblMBrBrCD.Text = tb.Rows[i]["TLixilBrandCD"].ToString().Trim();
                        lblTLixilBrand.Text = tb.Rows[i]["TLixilBrand"].ToString().Trim();
                        if (tb.Rows[i]["TLixilNouAddress"].ToString().Trim() == "未登録")
                        {
                            txtTLixilNouAddress.ForeColor = Color.Red;
                            lblArert.Visible = true;
                        }
                        else
                        {
                            txtTLixilNouAddress.ForeColor = SystemColors.WindowText;
                            lblArert.Visible = false;
                        }
                        txtTLixilNouAddress.Text = tb.Rows[i]["TLixilNouAddress"].ToString().Trim();
                        if (tb.Rows[i]["TLixilNouNam"].ToString().Trim().IndexOf("(仮名称)") + 1 > 0)
                        {
                            txtTLixilNouNam.ForeColor = Color.Red;
                            lblArert.Visible = true;
                        }
                        else
                        {
                            txtTLixilNouNam.ForeColor = SystemColors.WindowText;
                            lblArert.Visible = false;
                        }
                        txtTLixilNouNam.Text = tb.Rows[i]["TLixilNouNam"].ToString().Trim();
                        //出荷PFのセット                       
                        txtTLixilPF.Text = tb.Rows[i]["TLixilPF"].ToString().Trim();

                    }
                    tb.Clear();
                    tb.Dispose();
                }

            }
            catch (Exception ex)
            {
                _sRet = log.putOpeLog(parameter._sDB, parameter._sCatalog, parameter._sDBID, parameter._sPass, _sDSysPGID, parameter._sOpeManID.ToString(),
                    parameter._sOpeManNam, 12, _iTestKbn, "S_D993000001_04_Load", ex.ToString(), "", Environment.UserName.ToString()); 
            }
            finally
            {
                //db.Disconnect();
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            if (btnModify.Text == "修正を開始する")
            {
                btnModify.Text = "更新";
                toolTip1.SetToolTip(btnModify,"更新ボタンをクリックすると情報を更新できます。");
                txtTLixilNouNam.ReadOnly = false;
                txtTLixilNouAddress.ReadOnly = false;
                toolTip1.SetToolTip(txtTLixilNouNam,"編集可能です");
                toolTip1.SetToolTip(txtTLixilNouAddress, "編集可能です");
                lblNukenNam.ForeColor = Color.Yellow;
                lblBukenAddress.ForeColor = Color.Yellow;
                if (lblMBrBrCD.Text == "920102")
                {
                    btnSelBillder.Visible = true;
                }
                else
                {
                    btnSelBillder.Visible = false;
                }
            }
            else
            {
                ///////////////////////
                //// 更新作業開始 /////
                ///////////////////////
                StringBuilder query = new StringBuilder();
                SqlDbIf db = new SqlDbIf();
                //DataTable tb;
                db.Connect(parameter._sDB, parameter._sCatalog, parameter._sDBID, parameter._sPass, -1);
                query.Clear();
                query.Append("UPDATE TLIXIL SET");
                query.Append(" TLixilNouAddress = '" + txtTLixilNouAddress.Text.Trim() + "'");
                query.Append(",TLixilNouNam = '" + txtTLixilNouNam.Text.Trim() + "'");
                query.Append(",TLixilBrandCD = " + lblMBrBrCD.Text.Trim());
                query.Append(",TLixilBrand = '" + lblTLixilBrand.Text.Trim() + "'");
                query.Append(",TLixilTantoID = '" + parameter._sOpeManID + "'");
                query.Append(",TLixilTanNam = '" + parameter._sOpeManNam + "'");
                query.Append(",TLixilUpDay = FORMAT(GETDATE(),'yyyMMdd')");
                query.Append(",TLixilUpTim = FORMAT(GETDATE(),'HHmmss')");
                query.Append(" WHERE TLixilBukenNo = '" + txtBukenCD.Text.Trim() + "'");
                db.BeginTransaction();
                db.ExecuteSql(query.ToString(), -1);
                db.CommitTransaction();
                db.Disconnect();
                MessageBox.Show("更新が完了しました。\r\n編集禁止モードへ移ります。","更新完了",MessageBoxButtons.OK,MessageBoxIcon.Information);
                btnModify.Text = "修正を開始する";
                toolTip1.SetToolTip(btnModify, "ここをクリックすることで情報を編集できます");
                txtTLixilNouNam.ReadOnly = true;
                txtTLixilNouAddress.ReadOnly = true;
                toolTip1.SetToolTip(txtTLixilNouNam, "現在は編集禁止モードです");
                toolTip1.SetToolTip(txtTLixilNouAddress, "現在は編集禁止モードです");
                lblNukenNam.ForeColor = Color.White;
                lblBukenAddress.ForeColor = Color.White;
                btnSelBillder.Visible = false;
            }

        }

        private void btnSelBillder_Click(object sender, EventArgs e)
        {
            parameter._sBrandCD = "";
            parameter._sBrandNam = "";
            S_D993000001_05 f = new S_D993000001_05();
            f.ShowDialog();
            if (parameter._sBrandCD != "")
            {
                lblMBrBrCD.Text = parameter._sBrandCD;
            }
            if (parameter._sBrandNam != "")
            {
                lblTLixilBrand.Text = parameter._sBrandNam;
            }
        }



        private void cboTLixilDirector_KeyPress(object sender, KeyPressEventArgs e)
        {
            //e.Handled = true;
        }



        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
