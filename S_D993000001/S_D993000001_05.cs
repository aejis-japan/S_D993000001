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
    public partial class S_D993000001_05 : Form
    {
        public S_D993000001_05()
        {
            InitializeComponent();
        }

        string _sDSysPGID = "S_D993000001_05";
        int _iTestKbn = 1;

        private void DispBrand(string _sSortType,string _skana)
        {
            //ログセット
            DSYSLOG_SET log = new DSYSLOG_SET();
            string _sRet = string.Empty;

            //変数定義
            StringBuilder query = new StringBuilder();
            query.Clear();
            SqlDbIf db = new SqlDbIf();
            DataTable tb;
            db.Connect(parameter._sDB, parameter._sCatalog, parameter._sDBID, parameter._sPass, -1);
            if (_skana == "")
            {
                query.AppendLine("SELECT * FROM MBRAND WHERE MBrParent <> 0 ORDER BY " + _sSortType);
            }
            else
            {
                query.AppendLine("SELECT * FROM MBRAND WHERE MBrBrKana Like '%" + _skana + "%' AND MBrParent <> 0 ORDER BY " + _sSortType);
            }
            
            tb = db.ExecuteSql(query.ToString(), -1);
            if (tb.Rows.Count != 0)
            {
                for (int i = 0; i <= tb.Rows.Count - 1; i++)
                {
                    this.fpSpread1_Sheet2.AddRows(i, 1);
                    this.fpSpread1_Sheet2.SetText(i, 0, tb.Rows[i]["MBrBrCD"].ToString().Trim());
                    this.fpSpread1_Sheet2.SetText(i, 1, tb.Rows[i]["MBrBrNam"].ToString().Trim());
                }
            }
            tb.Clear();
            tb.Dispose();
            db.Disconnect();
        }

        private void S_D993000001_05_Load(object sender, EventArgs e)
        {

            DispBrand("MBrBrCD","");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rdoSortKana_CheckedChanged(object sender, EventArgs e)
        {
            this.fpSpread1.Sheets[0].RemoveRows(0, fpSpread1.Sheets[0].NonEmptyRowCount);
            fpSpread1.Refresh();
            fpSpread1.Update();
            txtKanaSearch.Text = "";

            if (rdoSortKana.Checked == true)
            {
                DispBrand("MBrBrKana","");
            }
            else
            {
                DispBrand("MBrBrCD","");
            }
        }

        private void btnKanaSearch_Click(object sender, EventArgs e)
        {
            //ｶﾅ検索で絞り込み
            //表のクリア
            this.fpSpread1.Sheets[0].RemoveRows(0, fpSpread1.Sheets[0].NonEmptyRowCount);
            fpSpread1.Refresh();
            fpSpread1.Update();
            rdoSortKana.Checked = true;
            //検索の実行
            //但し念のためｶﾅにしておくこと
            DispBrand("MBrBrKana", Microsoft.VisualBasic.Strings.StrConv(txtKanaSearch.Text.ToString().Trim(),Microsoft.VisualBasic.VbStrConv.Narrow));

        }

        private void fpSpread1_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            parameter._sBrandCD = fpSpread1.Sheets[0].Cells[e.Row, 0].Text.ToString();
            parameter._sBrandNam = fpSpread1.Sheets[0].Cells[e.Row, 1].Text.ToString();
            this.Close();
        }
    }
}
