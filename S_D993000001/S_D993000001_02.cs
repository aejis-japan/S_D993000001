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
    public partial class S_D993000001_02 : Form
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

        public class ItemSet
        {
            // DisplayMemberとValueMemberにはプロパティで指定する仕組み
            public String ItemDisp { get; set; }
            public int ItemValue { get; set; }
            public String ItemDisp2 { get; set; }
            public String ItemDisp3 { get; set; }

            // プロパティをコンストラクタでセット
            public ItemSet(int v, String s,String u,string w)
            {
                ItemDisp = s;
                ItemValue = v;
                ItemDisp2 = u;
                ItemDisp3 = w;
            }
        }
        public S_D993000001_02()
        {
            InitializeComponent();
        }

        public enum iGrid
        {
            DoubleCheck                     = 0,            //重複
            OrderManageNo                   = 1,            //発注管理No
            BukenCD                         = 2,            //物件コード
            KanseRowNo                      = 3,            //完成品行No
            GenbaNam                        = 4,            //現場名
            ItemNam                         = 5,            //商品名
            OrderCnt                        = 6,            //発注数
            AnswerDay                       = 7,            //回答納品日
            SetPoint                        = 8,            //取付位置
        }

        public enum Lixil_csv
        {
            EMPTY1                                  = 0,    //空白
            OrderManageNo                           = 1,    //発注管理No
            TRAINJigyoCD                            = 2,    //TRAIN事業所コード
            TRAINTokuCD                             = 3,    //TRAIN得意先コード
            BukenNo                                 = 4,    //物件No
            Biko                                    = 5,    //備考
            SetNo                                   = 6,    //セットNo
            KanseiRowNo                             = 7,    //完成品行No
            DetailRowNo                             = 8,    //明細行No
            ItemCD                                  = 9,    //商品コード
            ItemNam                                 =10,    //商品名称
            Joudai                                  =11,    //上代価格
            Tanka                                   =12,    //単価
            Genka                                   =13,    //原価
            BreedCD                                 =14,    //品種内部コード
            OrderCnt                                =15,    //発注数
            AllocationsNum1                         =16,    //引当数1
            AllocationsNum2                         =17,    //引当数2
            AllocationsNum3                         =18,    //引当数3
            AllocationsNum4                         =19,    //引当数4
            AllocationsNum5                         =20,    //引当数5
            AllocationsNum6                         =21,    //引当数6
            SpecDeliDay                             =22,    //指定納品日
            AnswerDay1                              =23,    //回答納品日1
            AnswerDay2                              =24,    //回答納品日2
            AnswerDay3                              =25,    //回答納品日3
            AnswerDay4                              =26,    //回答納品日4
            AnswerDay5                              =27,    //回答納品日5
            AnswerDay6                              =28,    //回答納品日6
            AnswerKbn1                              =29,    //回答区分1
            AnswerKbn2                              =30,    //回答区分2
            AnswerKbn3                              =31,    //回答区分3
            AnswerKbn4                              =32,    //回答区分4
            AnswerKbn5                              =33,    //回答区分5
            AnswerKbn6                              =34,    //回答区分6
            CustomerOfficeCD                        =35,    //お客様事業所コード
            CustomerCD                              =36,    //お客様得意先コード
            SiteNam                                 =37,    //現場名
            OrderDay                                =38,    //発注日
            LisilDay                                =39,    //LIXIL受付日
            NumManageKbn                            =40,    //数量管理区分
            OrdertoCarryKbn                         =41,    //発注携帯区分
            StockUseKbn                             =42,    //在庫使用フラグ
            BillItemKbn                             =43,    //ビル商品区分
            AnyEntry1                               =44,    //任意項目1
            AnyEntry2                               =45,    //任意項目2
            AnyEntry3                               =46,    //任意項目3
            AnyEntry4_1                             =47,    //任意項目4-1
            AnyEntry4_2                             =48,    //任意項目4-2
            AnyEntry4_3                             =49,    //任意項目4-3
            AnyEntry5                               =50,    //任意項目5
            AnyEntry6                               =51,    //任意項目6
            Yobi1                                   =52,    //予備1
            Yobi2                                   =53,    //予備2
            Yobi3                                   =54,    //予備3
            Yobi4                                   =55,    //予備4
            Yobi5                                   =56,    //予備5
            Yobi6                                   =57,    //予備6
            Yobi7                                   =58,    //予備7
            Yobi8                                   =59,    //予備8
            Yobi9                                   =60,    //予備9
            Yobi10                                  =61,    //予備10
            OrderNo                                 =62,    //注文No
            EntrySize2                              =63,    //入力寸法2
            EntrySize1                              =64,    //入力寸法1
            SpeSpecKbn1                             =65,    //特注特別仕様区分1
            SpeSpecNam1                             =66,    //特注特別仕様名称1
            SpeSpecSize1                            =67,    //特注特別仕様寸法1
            SpeSpecKbn2                             =68,    //特注特別仕様区分2
            SpeSpecNam2                             =69,    //特注特別仕様名称2
            SpeSpecSize2                            =70,    //特注特別仕様寸法2
            SpeSpecKbn3                             =71,    //特注特別仕様区分3
            SpeSpecNam3                             =72,    //特注特別仕様名称3
            SpeSpecSize3                            =73,    //特注特別仕様寸法3
            InputKbn                                =74,    //入力区分
            AttachmentNo                            =75,    //取付位置No
            Attachment                              =76,    //取付位置
            AgencyOrderManageNo                     =77,    //代理店発注管理No
            AutoDiscountCD                          =78,    //自動値引きコード
            ItemClassCD                             =79,    //商品分類コード
            ItemSumCD                               =80,    //商品集計コード
            UniqueCD                                =81,    //ユニークコード
            UnderShopCD                             =82,    //下店コード
            TostemNo                                =83,    //トステム建物No
            TostemEstimateNo                        =84,    //トステム見積No
            OccuNo                                  =85,    //発生No
            WindowSpecValue                         =86,    //窓性能評価値
            SumKbn                                  =87,    //集計区分
            L_ItemClass                             =88,    //L品種
            L_ItemClassConvKbn                      =89,    //L品種数量換算区分
            T_ItemClass                             =90,    //T品種
            T_ItemClassConvKbn                      =91,    //T品種数量換算区分
            Q_ItemClass                             =92,    //Q品種
            Q_ItemClassConvKbn                      =93,    //Q品種数量換算区分
            Empty2                                  =94,    //空白
            Empty3                                  =95     //空白
        }
        int _iCsvColum = 95;
        string _sDSysPGID = "S_D993000001_02";
        int _iTestKbn = 1;
        string sFileName = string.Empty;
        string sTeimei = string.Empty;
        //string sFilePath = string.Empty;

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void S_D993000001_02_Load(object sender, EventArgs e)
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

                //ブランド名のプルダウンをセット
                string sSQL = string.Empty;
                SqlDbIf db = new SqlDbIf();
                DataTable tb;
                db.Connect(parameter._sDB, parameter._sCatalog, parameter._sDBID, parameter._sPass, -1);
                sSQL = "SELECT * FROM MBRAND WHERE MBrParent = 0 ORDER BY MBrBrCD";
                tb = db.ExecuteSql(sSQL, -1);
                if (tb.Rows.Count != 0)
                {
                    List<ItemSet> src = new List<ItemSet>();
                    src.Add(new ItemSet(-1, "選択してください","",""));                    
                    for (int i = 0; i <= tb.Rows.Count - 1; i++)
                    {                        
                        src.Add(new ItemSet(int.Parse(tb.Rows[i]["MBrOnKuKbn"].ToString().Trim()), 
                            tb.Rows[i]["MBrBrNam"].ToString().Trim() + " ( " + tb.Rows[i]["MBrOnKuNam"].ToString().Trim() + " )", 
                            tb.Rows[i]["MBrBrNam"].ToString().Trim(), tb.Rows[i]["MBrBrCD"].ToString().Trim()));
                    }
                    cboBrand.DataSource = src;
                    cboBrand.DisplayMember = "ItemDisp";
                    cboBrand.ValueMember = "ItemValue";  //オンサイト／クラスフルの区分がセットされる
                    
                    cboBrand.SelectedIndex = 0;
                }
                tb.Clear();
                tb.Dispose();
                db.Disconnect();
            }
            catch(Exception ex)
            {
                _sRet = log.putOpeLog(parameter._sDB, parameter._sCatalog, parameter._sDBID, parameter._sPass, _sDSysPGID, parameter._sOpeManID.ToString(), 
                    parameter._sOpeManNam, 12, _iTestKbn, "S_D993000001_02_Load", ex.ToString() ,"", Environment.UserName.ToString());
            }
            finally
            {

                _sRet = log.putOpeLog(parameter._sDB, parameter._sCatalog, parameter._sDBID, parameter._sPass, _sDSysPGID, parameter._sOpeManID.ToString(), parameter._sOpeManNam, 12, _iTestKbn,
                    "S_D993000001_02_Load", "S_D993000001_02_Load proccess end", "",Environment.UserName.ToString());
                this.Text = this.Text + "　(" + parameter._sOpeManID.ToString() + " : " + parameter._sOpeManNam + "　)";
            }
        }

        private void btnFileSel_Click(object sender, EventArgs e)
        {
            int _iErrCnt = 0;
            //受注元選択のチェック
            if (cboBrand.SelectedIndex == 0)
            {
                MessageBox.Show("受注元を選択してください","選択エラー",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            //ログ用オブジェクト作成
            DSYSLOG_SET log = new DSYSLOG_SET();
            string _sRet = string.Empty;

            ofd.FileName = "";
            //はじめに表示されるフォルダを指定する(今回はデスクトップ)
            ofd.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            //[ファイルの種類]に表示される選択肢を指定する
            ofd.Filter =
                "CSVファイル(*.csv)|*.csv;|すべてのファイル(*.*)|*.*";
            //[ファイルの種類]ではじめに
            //「すべてのファイル」が選択されているようにする
            ofd.FilterIndex = 0;
            //タイトルを設定する
            ofd.Title = "読み込むファイルを選択してください";
            //ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする
            ofd.RestoreDirectory = true;

            //存在しないパスが指定されたとき警告を表示する
            //デフォルトでTrueなので指定する必要はない
            ofd.CheckPathExists = true;
            //ダイアログを表示する
            if (ofd.ShowDialog() != DialogResult.OK)
            {
                //this.btnErrChk.Enabled = false;
                //ログセット
                _sRet = log.putOpeLog(parameter._sDB, parameter._sCatalog, parameter._sDBID, parameter._sPass, _sDSysPGID, parameter._sOpeManID.ToString(), parameter._sOpeManNam, 9, _iTestKbn,
                    "S_D9930000001_02_btnFileSel_Click", "SelectFile is Canceled" , "",Environment.UserName.ToString());
                //ファイル選択をキャンセル
                return;
            }
            sFileName = "";

            //ファイルを指定
            this.txtFilePath.Text = ofd.FileName;
            sFileName = System.IO.Path.GetFileName(ofd.FileName);


            ////////////////////////////////////////////////////////////////////////////
            ///
            //ここでファイルチェック
            //　１）フォーマットは正しいか？
            //　２）既に取込済みか？
            //
            ///////////////////////////////////////////////////////////////////////////

            Encoding sjisEnc = Encoding.GetEncoding("shift_JIS");
            StreamReader sr = new StreamReader(txtFilePath.Text.Trim(), sjisEnc);
            if (Path.GetExtension(txtFilePath.Text.Trim()).ToLower() != ".csv" )
            {
                MessageBox.Show("CSVファイルを選択してください。","ファイル種別選択エラー",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            else
            {
                //オンサイト・クラスフルのファイルか否かのチェック
                string[] lines = File.ReadAllLines(txtFilePath.Text.Trim());
                pgbCheckBar.Minimum = 0;
                pgbCheckBar.Maximum = lines.Length - 1;
                pgbCheckBar.Visible = true;
                int i = 0;
                string _sCheck = string.Empty;
                StringBuilder query = new StringBuilder();
                SqlDbIf db = new SqlDbIf();
                DataTable tb;
                db.Connect(parameter._sDB, parameter._sCatalog, parameter._sDBID, parameter._sPass, -1);
                while (!sr.EndOfStream)
                {
                    // CSVファイルの一行を読み込む
                    string _sLine = sr.ReadLine();
                    // 読み込んだ一行をカンマ毎に分けて配列に格納する                    
                    string[] sAryData = _sLine.Split(',');

                    //カラム数のチェック(カラムの数がおかしい場合は即時終了）
                    if (sAryData.Length != _iCsvColum)
                    {                       
                        MessageBox.Show("指定したCSVのカラム数がオンサイトまたはクラスフルのカラム数ではありません。\r\n再度ファイルを確認してください。", "ファイル種別選択エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        _sRet = log.putOpeLog(parameter._sDB, parameter._sCatalog, parameter._sDBID, parameter._sPass, _sDSysPGID, parameter._sOpeManID.ToString(), parameter._sOpeManNam, 9, _iTestKbn,
                            "S_D9930000001_02_btnFileSel_Click", "CSVのカラム数が違う ", txtFilePath.Text.Trim() , Environment.UserName.ToString());
                        pgbCheckBar.Visible = false;
                        db.Disconnect();
                        return;
                    }

                    this.fpSpread1_Sheet1.AddRows(i, 1);

                    //発注管理Noのチェック
                    if (sAryData[(int)Lixil_csv.OrderManageNo].ToString().Trim() == "")     
                    {
                        _iErrCnt++;
                        fpSpread1.Sheets[0].Cells[i, (int)iGrid.OrderManageNo].BackColor = Color.Red;
                        _sRet = log.putOpeLog(parameter._sDB, parameter._sCatalog, parameter._sDBID, parameter._sPass, _sDSysPGID, parameter._sOpeManID.ToString(), parameter._sOpeManNam, 9, _iTestKbn,
                            "S_D9930000001_02_btnFileSel_Click", "発注管理Noが空白 → " + i.ToString() + "行目", txtFilePath.Text.Trim(), Environment.UserName.ToString());
                    }
                    //物件Noのチェック
                    if (int.Parse(cboBrand.SelectedValue.ToString()) == 1)
                    {
                        if (sAryData[(int)Lixil_csv.BukenNo].ToString().Trim() == "")
                        {
                            _iErrCnt++;
                            fpSpread1.Sheets[0].Cells[i, (int)iGrid.BukenCD].BackColor = Color.Red;
                            _sRet = log.putOpeLog(parameter._sDB, parameter._sCatalog, parameter._sDBID, parameter._sPass, _sDSysPGID, parameter._sOpeManID.ToString(), parameter._sOpeManNam, 9, _iTestKbn,
                                "S_D9930000001_02_btnFileSel_Click", "物件Noが空白 → " + i.ToString() + "行目", txtFilePath.Text.Trim(), Environment.UserName.ToString());
                        }
                    }
                    //商品コードのチェック
                    if (sAryData[(int)Lixil_csv.ItemCD].ToString().Trim() == "")     
                    {
                        _iErrCnt++;
                        fpSpread1.Sheets[0].Cells[i, (int)iGrid.ItemNam].BackColor = Color.Red;                        
                        _sRet = log.putOpeLog(parameter._sDB, parameter._sCatalog, parameter._sDBID, parameter._sPass, _sDSysPGID, parameter._sOpeManID.ToString(), parameter._sOpeManNam, 9, _iTestKbn,
                            "S_D9930000001_02_btnFileSel_Click", "商品コードが空白 → " + i.ToString() + "行目", txtFilePath.Text.Trim(), Environment.UserName.ToString());
                    }

                    //発注数のチェック
                    if (sAryData[(int)Lixil_csv.OrderCnt].ToString().Trim() == "" || sAryData[14].ToString().Trim() =="0")
                    {
                        _iErrCnt++;
                        fpSpread1.Sheets[0].Cells[i, (int)iGrid.OrderCnt].BackColor = Color.Red;                        
                        _sRet = log.putOpeLog(parameter._sDB, parameter._sCatalog, parameter._sDBID, parameter._sPass, _sDSysPGID, parameter._sOpeManID.ToString(), parameter._sOpeManNam, 9, _iTestKbn,
                            "S_D9930000001_02_btnFileSel_Click", "発注数が空白or０である → " + i.ToString() + "行目", txtFilePath.Text.Trim(), Environment.UserName.ToString());
                    }
                    //現場名のチェック
                    if (sAryData[(int)Lixil_csv.SiteNam].ToString().Trim() == "")
                    {
                        _iErrCnt++;
                        fpSpread1.Sheets[0].Cells[i, (int)iGrid.GenbaNam].BackColor = Color.Red;                        
                        _sRet = log.putOpeLog(parameter._sDB, parameter._sCatalog, parameter._sDBID, parameter._sPass, _sDSysPGID, parameter._sOpeManID.ToString(), parameter._sOpeManNam, 9, _iTestKbn,
                            "S_D9930000001_02_btnFileSel_Click", "現場名が空白である → " + i.ToString() + "行目", txtFilePath.Text.Trim(), Environment.UserName.ToString());
                    }
                    //取付位置Noのチェック
                    if (sAryData[(int)Lixil_csv.AttachmentNo].ToString().Trim() == "")
                    {
                        _iErrCnt++;
                        fpSpread1.Sheets[0].Cells[i, (int)iGrid.SetPoint].BackColor = Color.Red;
                        _sRet = log.putOpeLog(parameter._sDB, parameter._sCatalog, parameter._sDBID, parameter._sPass, _sDSysPGID, parameter._sOpeManID.ToString(), parameter._sOpeManNam, 9, _iTestKbn,
                            "S_D9930000001_02_btnFileSel_Click", "取付位置Noが空白である → " + i.ToString() + "行目", txtFilePath.Text.Trim(), Environment.UserName.ToString());
                    }
                    //トステム建物Noのチェック
                    if (int.Parse(cboBrand.SelectedValue.ToString()) == 0)
                    {
                        if (sAryData[(int)Lixil_csv.TostemNo].ToString().Trim() == "")
                        {
                            _iErrCnt++;
                            fpSpread1.Sheets[0].Cells[i, (int)iGrid.OrderManageNo].BackColor = Color.Red;
                            _sRet = log.putOpeLog(parameter._sDB, parameter._sCatalog, parameter._sDBID, parameter._sPass, _sDSysPGID, parameter._sOpeManID.ToString(), parameter._sOpeManNam, 9, _iTestKbn,
                                "S_D9930000001_02_btnFileSel_Click", "トステム建物Noが空白である → " + i.ToString() + "行目", txtFilePath.Text.Trim(), Environment.UserName.ToString());
                        }
                    }
                    //二重取込のチェック
                    query.Clear();
                    query.AppendLine("SELECT * FROM DLIXIL WHERE ");
                    query.AppendLine("[DLixilHatyuNo] 			    = '"    + sAryData[(int)Lixil_csv.OrderManageNo].ToString().Trim() + "'");                  //発注管理No
                    query.AppendLine("AND  [DLixilTrainJIgyoCD] 	= '"    + sAryData[(int)Lixil_csv.TRAINJigyoCD].ToString().Trim() + "'");                   //TRAIN事業所コード
                    query.AppendLine("AND  [DLixilTrainTokuCD] 		= '"    + sAryData[(int)Lixil_csv.TRAINTokuCD].ToString().Trim() + "'");                    //TRAIN徳先コード
                    query.AppendLine("AND  [DLixilBukenNo] 			= '"     + sAryData[(int)Lixil_csv.BukenNo].ToString().Trim() + "'");                              //物件No
                    query.AppendLine("AND  [DLixilBiko] 			= '"    + sAryData[(int)Lixil_csv.Biko].ToString().Trim() + "'");                           //備考
                    query.AppendLine("AND  [DLixilSetNo] 			= "     + sAryData[(int)Lixil_csv.SetNo].ToString().Trim());                                //セットNo
                    query.AppendLine("AND  [DLixilKanseiGyoNo] 		= "     + sAryData[(int)Lixil_csv.KanseiRowNo].ToString().Trim());                          //完成品行No
                    query.AppendLine("AND  [DLixilMeisaiGyoNo] 		= "     + sAryData[(int)Lixil_csv.DetailRowNo].ToString().Trim());                          //明細行No
                    query.AppendLine("AND  [DLixilHinCD] 			= '"    + sAryData[(int)Lixil_csv.ItemCD].ToString().Trim() + "'");                         //商品コード
                    query.AppendLine("AND  [DLixilHinNam] 			= '"    + sAryData[(int)Lixil_csv.ItemNam].ToString().Trim() + "'");                        //商品名称
                    query.AppendLine("AND  [DLixilJodai] 			= "     + sAryData[(int)Lixil_csv.Joudai].ToString().Trim());                               //上代価格
                    query.AppendLine("AND  [DLixilTanka] 			= "     + sAryData[(int)Lixil_csv.Tanka].ToString().Trim());                                //単価
                    query.AppendLine("AND  [DLixilGenka] 			= "     + sAryData[(int)Lixil_csv.Genka].ToString().Trim());                                //原価
                    query.AppendLine("AND  [DLixilHinNaibuCD] 		= '"    + sAryData[(int)Lixil_csv.BreedCD].ToString().Trim() + "'");                        //品種内部コード
                    query.AppendLine("AND  [DLixilHatyuSu] 			= "     + sAryData[(int)Lixil_csv.OrderCnt].ToString().Trim());                             //発注数
                    query.AppendLine("AND  [DLixilHkiate1] 			= "     + sAryData[(int)Lixil_csv.AllocationsNum1].ToString().Trim());                      //引当数1
                    query.AppendLine("AND  [DLixilSiteiNouhinDay] 	= '"    + sAryData[(int)Lixil_csv.SpecDeliDay].ToString().Trim() + "'");                    //指定納品日
                    query.AppendLine("AND  [DLixilAnswerDay1] 		= '"    + sAryData[(int)Lixil_csv.AnswerDay1].ToString().Trim() + "'");                     //回答納品日1
                    query.AppendLine("AND  [DLxilAnswerKbn1] 		= "     + sAryData[(int)Lixil_csv.AnswerKbn1].ToString().Trim());                           //回答区分1
                    query.AppendLine("AND  [DLxilCustomerCD] 		= '"    + sAryData[(int)Lixil_csv.CustomerOfficeCD].ToString().Trim() + "'");               //お客様事業所コード
                    query.AppendLine("AND  [DLxilCustomerTokuiCD] 	= '"    + sAryData[(int)Lixil_csv.CustomerCD].ToString().Trim() + "'");                     //お客様得意先コード
                    query.AppendLine("AND  [DLxilGenbaNam] 			= '"    + sAryData[(int)Lixil_csv.SiteNam].ToString() + "'");                               //現場名
                    query.AppendLine("AND  [DLxilHatyuDay] 			= '"    + sAryData[(int)Lixil_csv.OrderDay].ToString().Trim() + "'");                       //発注日
                    query.AppendLine("AND  [DLixilLixilUkeDay] 		= '"    + sAryData[(int)Lixil_csv.LisilDay].ToString().Trim() + "'");                       //LIXIL受付日
                    query.AppendLine("AND  [DLixilSuKanriKbn] 		= '"    + sAryData[(int)Lixil_csv.NumManageKbn].ToString().Trim() + "'");                   //数量管理区分
                    query.AppendLine("AND  [DLixilHatyyuKeitaiKbn] 	= "     + sAryData[(int)Lixil_csv.OrdertoCarryKbn].ToString().Trim());                      //発注携帯区分
                    query.AppendLine("AND  [DLixilZaikoKbn] 		= "     + sAryData[(int)Lixil_csv.StockUseKbn].ToString().Trim());                          //在庫使用フラグ
                    query.AppendLine("AND  [DLixilBillitemKbn] 		= "     + sAryData[(int)Lixil_csv.BillItemKbn].ToString().Trim());                          //ビル商品部区分
                    query.AppendLine("AND  [DLixilNini1] 			= '"    + sAryData[(int)Lixil_csv.AnyEntry1].ToString().Trim() + "'");                      //任意入力項目１
                    query.AppendLine("AND  [DLixilYobi10] 			= '"    + sAryData[(int)Lixil_csv.Yobi10].ToString().Trim() + "'");                         //予備１０
                    query.AppendLine("AND  [DLixilTyuNo] 			= '"    + sAryData[(int)Lixil_csv.OrderNo].ToString().Trim() + "'");                        //注文No
                    query.AppendLine("AND  [DLixilSize2] 			= "     + sAryData[(int)Lixil_csv.EntrySize2].ToString().Trim());                           //入力寸法2
                    query.AppendLine("AND  [DLixilSize1] 			= "     + sAryData[(int)Lixil_csv.EntrySize1].ToString().Trim());                           //入力寸法1
                    query.AppendLine("AND  [DLixilTokutyuSiyoKbn1] 	= '"    + sAryData[(int)Lixil_csv.SpeSpecKbn1].ToString().Trim() + "'");                    //特注特別仕様区分１
                    query.AppendLine("AND  [DLixilTokutyuSiyoNam1] 	= '"    + sAryData[(int)Lixil_csv.SpeSpecNam1].ToString().Trim() + "'");                    //特注特別仕様名称１
                    query.AppendLine("AND  [DLixilTokutyuSiyoSize1] = "     + sAryData[(int)Lixil_csv.SpeSpecSize1].ToString().Trim());                         //特注特別仕様寸法１
                    query.AppendLine("AND  [DLixilInputKbn] 		= "     + sAryData[(int)Lixil_csv.InputKbn].ToString().Trim());                             //入力区分
                    query.AppendLine("AND  [DLixilToritukeNo] 		= '"    + sAryData[(int)Lixil_csv.AttachmentNo].ToString().Trim() + "'");                   //取付位置No
                    query.AppendLine("AND  [DLixilToritukeNam] 		= '"    + sAryData[(int)Lixil_csv.AttachmentNo].ToString().Trim() + "'");                   //取付位置
                    query.AppendLine("AND  [DLixilDairiHatyuKanNo] 	= '"    + sAryData[(int)Lixil_csv.AgencyOrderManageNo].ToString().Trim() + "'");            //代販店発注管理Ｎｏ
                    query.AppendLine("AND  [DLixilAutoNebikiCD] 	= '"    + sAryData[(int)Lixil_csv.AutoDiscountCD].ToString().Trim() + "'");                 //自動値引コード
                    query.AppendLine("AND  [DLixilShohinBunCD] 		= '"    + sAryData[(int)Lixil_csv.ItemClassCD].ToString().Trim() + "'");                    //商品分類コード
                    query.AppendLine("AND  [DLixilShoSyukeiCD] 		= '"    + sAryData[(int)Lixil_csv.ItemSumCD].ToString().Trim() + "'");                      //商品集計コード
                    query.AppendLine("AND  [DLixilUniqueCD] 		= '"    + sAryData[(int)Lixil_csv.UniqueCD].ToString().Trim() + "'");                       //ユニークコード
                    query.AppendLine("AND  [DLixilTostemNo] 		= '"    + sAryData[(int)Lixil_csv.TostemNo].ToString().Trim() + "'");                       //トステム建物No               
                    query.AppendLine("AND  [DLixilTostemMituNo] 	= '"    + sAryData[(int)Lixil_csv.TostemEstimateNo].ToString().Trim() + "'");               //トステム見積No
                    query.AppendLine("AND  [DLixilHaseiNo] 			= '"    + sAryData[(int)Lixil_csv.OccuNo].ToString().Trim() + "'");                         //発生No(OnSite) 
                    query.AppendLine("AND  [DLixilSyuKbn] 			= "     + sAryData[(int)Lixil_csv.SumKbn].ToString().Trim());                               //集計区分
                    query.AppendLine("AND  [DLixilLhinsyu] 			= '"    + sAryData[(int)Lixil_csv.L_ItemClass].ToString().Trim() + "'");                    //L品種
                    query.AppendLine("AND  [DLixilLHinsyuKansan] 	= '"    + sAryData[(int)Lixil_csv.L_ItemClassConvKbn].ToString().Trim() + "'");             //L品種数量換算区分
                    query.AppendLine("AND  [DLixilThinsyu] 			= '"    + sAryData[(int)Lixil_csv.T_ItemClass].ToString().Trim() + "'");                    //T品種
                    query.AppendLine("AND  [DLixilTHinsyuKansan] 	= '"    + sAryData[(int)Lixil_csv.T_ItemClassConvKbn].ToString().Trim() + "'");             //T品種数量換算区分
                    query.AppendLine("AND  [DLixilQhinsyu] 			= '"    + sAryData[(int)Lixil_csv.Q_ItemClass].ToString().Trim() + "'");                    //Q品種
                    query.AppendLine("AND  [DLixilQHinsyuKansan] 	= '"    + sAryData[(int)Lixil_csv.Q_ItemClassConvKbn].ToString().Trim() + "'");             //Q品種数量換算区分
                    tb = db.ExecuteSql(query.ToString(), -1);
                    //iRow = tb.Rows.Count;
                    if (tb.Rows.Count > 0)
                    {
                        _sCheck = "登録済み";
                        fpSpread1.Sheets[0].Cells[i, (int)iGrid.SetPoint].ForeColor = Color.Red;
                        _iErrCnt++;
                    }
                    else
                    {
                        _sCheck = "新規";
                    }

                    
                    this.fpSpread1_Sheet1.SetText(i, (int)iGrid.DoubleCheck,    _sCheck);
                    this.fpSpread1_Sheet1.SetText(i, (int)iGrid.OrderManageNo,  sAryData[(int)Lixil_csv.OrderManageNo].ToString().Trim());
                    this.fpSpread1_Sheet1.SetText(i, (int)iGrid.BukenCD,        sAryData[(int)Lixil_csv.BukenNo].ToString().Trim());
                    this.fpSpread1_Sheet1.SetText(i, (int)iGrid.KanseRowNo, sAryData[(int)Lixil_csv.KanseiRowNo].ToString().Trim());
                    this.fpSpread1_Sheet1.SetText(i, (int)iGrid.GenbaNam, sAryData[(int)Lixil_csv.SiteNam].ToString().Trim());
                    this.fpSpread1_Sheet1.SetText(i, (int)iGrid.ItemNam, sAryData[(int)Lixil_csv.ItemNam].ToString().Trim());
                    this.fpSpread1_Sheet1.SetText(i, (int)iGrid.OrderCnt, sAryData[(int)Lixil_csv.OrderCnt].ToString().Trim());
                    this.fpSpread1_Sheet1.SetText(i, (int)iGrid.AnswerDay, sAryData[(int)Lixil_csv.AnswerDay1].ToString().Trim());
                    this.fpSpread1_Sheet1.SetText(i, (int)iGrid.SetPoint, sAryData[(int)Lixil_csv.Attachment].ToString().Trim());
                    tb.Dispose();
                    pgbCheckBar.Value = i;
                    i++;
                }
                pgbCheckBar.Visible = false;
                if (_iErrCnt > 0 )
                {
                    lblMsg.Text = "指定したファイルには" + _iErrCnt.ToString() + "個のエラーが存在します。内容を確認して再度指定してください。再指定する場合は「キャンセルボタンを押してください";                    
                    btnUpdate.Enabled = false;
                }
                else
                {
                    lblMsg.Text = "指定したファイルのチェックが完了しました。問題はないので、「取込み」ボタンをクリックしてデータを取り込んでください。";
                    btnUpdate.Enabled = true;
                    cboBrand.Enabled = false;
                    txtFilePath.Enabled = false;
                    btnFileSel.Enabled = false;
                    btnUpdate.Focus();
                }
                lblMsg.Visible = true;
            }

            //ログセット
            _sRet = log.putOpeLog(parameter._sDB, parameter._sCatalog, parameter._sDBID, parameter._sPass, _sDSysPGID, parameter._sOpeManID.ToString(), parameter._sOpeManNam, 9, _iTestKbn,
                "S_D9930000001_02_btnFileSel_Click", "SelectFile is " + this.txtFilePath.Text.ToString(), txtFilePath.Text.Trim(), Environment.UserName.ToString());
            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //ログ用オブジェクト作成
            DSYSLOG_SET log = new DSYSLOG_SET();
            string _sRet = string.Empty;

            //宣言エリア
            Encoding sjisEnc = Encoding.GetEncoding("shift_JIS");
            if (this.txtFilePath.Text == string.Empty)
            {
                MessageBox.Show("ファイルが選択されていません。", "ファイル選択エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtFilePath.Focus();
                //ログセット
                _sRet = log.putOpeLog(parameter._sDB, parameter._sCatalog, parameter._sDBID, parameter._sPass, _sDSysPGID, parameter._sOpeManID.ToString(), parameter._sOpeManNam, 9, _iTestKbn,
                    "S_D9930000001_02_btnUpdate_Click", "btnUpdate_Click　→　ファイルが選択されていません。→　処理終了", "" , Environment.UserName.ToString());
                return;
            }
            else
            {
                if (MessageBox.Show("取込を開始します。よろしいでしょうか？", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                {
                    MessageBox.Show("処理を中断しました。","中断",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    return;
                }
                //取込ファイルの件数チェック
                string[] lines = File.ReadAllLines(txtFilePath.Text.Trim());
                pgbCheckBar.Minimum = 0;
                pgbCheckBar.Maximum = lines.Length - 1;
                pgbCheckBar.Visible = true;
                lblMsg.Visible = false;
                int i = 0;

                StreamReader sr = new StreamReader(txtFilePath.Text, sjisEnc);
                if (File.Exists(txtFilePath.Text))
                {
                    //現在のコンボ選択内容の取得
                    ItemSet tmp = ((ItemSet)cboBrand.SelectedItem);
                    //Console.WriteLine(tmp.ItemDisp2.ToString());
                    int iRow = 0;
                    StringBuilder query = new StringBuilder();
                    SqlDbIf db = new SqlDbIf();
                    DataTable tb;
                    db.Connect(parameter._sDB, parameter._sCatalog, parameter._sDBID, parameter._sPass, -1);
                    while (!sr.EndOfStream)
                    {
                        //CSVファイルの読込
                        var line = sr.ReadLine();
                        //CSVファイルをデリミタで分割
                        string[] sAryData = line.Split(',');
                        //ヘッダ（TLIXIL）にデータが存在するかチェック
                        //オンサイト　→　トステム建物No(sAryData[82].ToString().Trim())
                        //クラスフル　→　物件No(sAryData[3].ToString().Trim())
                        query.Clear();

                        query.AppendLine("SELECT * FROM TLIXIL WHERE ");
                        if (int.Parse(cboBrand.SelectedValue.ToString()) == 0)
                        {
                            query.AppendLine("TLixilBukenNo = '" + sAryData[(int)Lixil_csv.TostemNo].ToString().Trim() + "'");       //オンサイト
                        }
                        else
                        {
                            query.AppendLine("TLixilBukenNo = '" + sAryData[(int)Lixil_csv.BukenNo].ToString().Trim() + "'");        //クラスフル
                        }
                        tb = db.ExecuteSql(query.ToString(), -1);
                        if (tb.Rows.Count == 0)
                        {
                            //存在しないので作成する
                            query.Clear();
                            query.AppendLine("INSERT INTO TLIXIL(");
                            query.AppendLine("[TLixilBukenNo]");
                            query.AppendLine(", [TLixilDLKbn]");
                            query.AppendLine(", [TLixilNouAddress]");
                            query.AppendLine(", [TLixilNouNam]");
                            query.AppendLine(", [TLixilBrandCD]");
                            query.AppendLine(", [TLixilBrand]");
                            query.AppendLine(", [TLixilPF]");
                            query.AppendLine(", [TLixilBiko]");
                            query.AppendLine(", [TLixilTantoID]");
                            query.AppendLine(", [TLixilTanNam]");
                            query.AppendLine(", [TLixilInsDay]");
                            query.AppendLine(", [TLixilInsTim]");
                            query.AppendLine(", [TLixilInsID]");
                            query.AppendLine(", [TLixilUpDay]");
                            query.AppendLine(", [TLixilUpTim]");
                            query.AppendLine(", [TLixilUpID]");
                            query.AppendLine(", [TLixilCommitFlg]");
                            query.AppendLine(") ");
                            query.AppendLine("VALUES(");
                            if (int.Parse(cboBrand.SelectedValue.ToString()) == 0)
                            {
                                query.AppendLine("'" + sAryData[(int)Lixil_csv.TostemNo].ToString().Trim() + "'");
                            }
                            else
                            {
                                query.AppendLine("'" + sAryData[(int)Lixil_csv.BukenNo].ToString().Trim() + "'");
                            }
                            query.AppendLine("," + int.Parse(cboBrand.SelectedValue.ToString()));
                            query.AppendLine(",'未登録'");
                            //query.AppendLine(",'未登録'");
                            query.AppendLine(",'(仮名称)　" + sAryData[(int)Lixil_csv.SiteNam].ToString().Trim() + "'");
                            query.AppendLine("," + tmp.ItemDisp3.ToString().Trim());
                            query.AppendLine(",'" + tmp.ItemDisp2.ToString().Trim() + "'");
                            query.AppendLine(",'未登録'");
                            query.AppendLine(",''");
                            query.AppendLine(",'" + parameter._sOpeManID.ToString() + "'");
                            query.AppendLine(",'" + parameter._sOpeManNam.ToString() + "'");
                            query.AppendLine(",FORMAT(GETDATE(),'yyyMMdd')");
                            query.AppendLine(",FORMAT(GETDATE(),'HHmmss')");
                            query.AppendLine(",'" + parameter._sOpeManID.ToString() + "'");
                            query.AppendLine(",FORMAT(GETDATE(),'yyyMMdd')");
                            query.AppendLine(",FORMAT(GETDATE(),'HHmmss')");
                            query.AppendLine(",'" + parameter._sOpeManID.ToString() + "'");
                            query.AppendLine(",0)");
                            db.BeginTransaction();
                            db.ExecuteSql(query.ToString(), -1);
                            db.CommitTransaction();
                        }
                        tb.Dispose();

                        //二重取込のチェック
                        query.Clear();
                        query.AppendLine("SELECT * FROM DLIXIL WHERE ");
                        query.AppendLine("[DLixilHatyuNo] 			    = '" + sAryData[(int)Lixil_csv.OrderManageNo].ToString().Trim() + "'");                  //発注管理No
                        query.AppendLine("AND  [DLixilTrainJIgyoCD] 	= '" + sAryData[(int)Lixil_csv.TRAINJigyoCD].ToString().Trim() + "'");                   //TRAIN事業所コード
                        query.AppendLine("AND  [DLixilTrainTokuCD] 		= '" + sAryData[(int)Lixil_csv.TRAINTokuCD].ToString().Trim() + "'");                    //TRAIN徳先コード
                        query.AppendLine("AND  [DLixilBukenNo] 			= " + sAryData[(int)Lixil_csv.BukenNo].ToString().Trim());                              //物件No
                        query.AppendLine("AND  [DLixilBiko] 			= '" + sAryData[(int)Lixil_csv.Biko].ToString().Trim() + "'");                           //備考
                        query.AppendLine("AND  [DLixilSetNo] 			= " + sAryData[(int)Lixil_csv.SetNo].ToString().Trim());                                //セットNo
                        query.AppendLine("AND  [DLixilKanseiGyoNo] 		= " + sAryData[(int)Lixil_csv.KanseiRowNo].ToString().Trim());                          //完成品行No
                        query.AppendLine("AND  [DLixilMeisaiGyoNo] 		= " + sAryData[(int)Lixil_csv.DetailRowNo].ToString().Trim());                          //明細行No
                        query.AppendLine("AND  [DLixilHinCD] 			= '" + sAryData[(int)Lixil_csv.ItemCD].ToString().Trim() + "'");                         //商品コード
                        query.AppendLine("AND  [DLixilHinNam] 			= '" + sAryData[(int)Lixil_csv.ItemNam].ToString().Trim() + "'");                        //商品名称
                        query.AppendLine("AND  [DLixilJodai] 			= " + sAryData[(int)Lixil_csv.Joudai].ToString().Trim());                               //上代価格
                        query.AppendLine("AND  [DLixilTanka] 			= " + sAryData[(int)Lixil_csv.Tanka].ToString().Trim());                                //単価
                        query.AppendLine("AND  [DLixilGenka] 			= " + sAryData[(int)Lixil_csv.Genka].ToString().Trim());                                //原価
                        query.AppendLine("AND  [DLixilHinNaibuCD] 		= '" + sAryData[(int)Lixil_csv.BreedCD].ToString().Trim() + "'");                        //品種内部コード
                        query.AppendLine("AND  [DLixilHatyuSu] 			= " + sAryData[(int)Lixil_csv.OrderCnt].ToString().Trim());                             //発注数
                        query.AppendLine("AND  [DLixilHkiate1] 			= " + sAryData[(int)Lixil_csv.AllocationsNum1].ToString().Trim());                      //引当数1
                        query.AppendLine("AND  [DLixilSiteiNouhinDay] 	= '" + sAryData[(int)Lixil_csv.SpecDeliDay].ToString().Trim() + "'");                    //指定納品日
                        query.AppendLine("AND  [DLixilAnswerDay1] 		= '" + sAryData[(int)Lixil_csv.AnswerDay1].ToString().Trim() + "'");                     //回答納品日1
                        query.AppendLine("AND  [DLxilAnswerKbn1] 		= " + sAryData[(int)Lixil_csv.AnswerKbn1].ToString().Trim());                           //回答区分1
                        query.AppendLine("AND  [DLxilCustomerCD] 		= '" + sAryData[(int)Lixil_csv.CustomerOfficeCD].ToString().Trim() + "'");               //お客様事業所コード
                        query.AppendLine("AND  [DLxilCustomerTokuiCD] 	= '" + sAryData[(int)Lixil_csv.CustomerCD].ToString().Trim() + "'");                     //お客様得意先コード
                        query.AppendLine("AND  [DLxilGenbaNam] 			= '" + sAryData[(int)Lixil_csv.SiteNam].ToString() + "'");                               //現場名
                        query.AppendLine("AND  [DLxilHatyuDay] 			= '" + sAryData[(int)Lixil_csv.OrderDay].ToString().Trim() + "'");                       //発注日
                        query.AppendLine("AND  [DLixilLixilUkeDay] 		= '" + sAryData[(int)Lixil_csv.LisilDay].ToString().Trim() + "'");                       //LIXIL受付日
                        query.AppendLine("AND  [DLixilSuKanriKbn] 		= '" + sAryData[(int)Lixil_csv.NumManageKbn].ToString().Trim() + "'");                   //数量管理区分
                        query.AppendLine("AND  [DLixilHatyyuKeitaiKbn] 	= " + sAryData[(int)Lixil_csv.OrdertoCarryKbn].ToString().Trim());                      //発注携帯区分
                        query.AppendLine("AND  [DLixilZaikoKbn] 		= " + sAryData[(int)Lixil_csv.StockUseKbn].ToString().Trim());                          //在庫使用フラグ
                        query.AppendLine("AND  [DLixilBillitemKbn] 		= " + sAryData[(int)Lixil_csv.BillItemKbn].ToString().Trim());                          //ビル商品部区分
                        query.AppendLine("AND  [DLixilNini1] 			= '" + sAryData[(int)Lixil_csv.AnyEntry1].ToString().Trim() + "'");                      //任意入力項目１
                        query.AppendLine("AND  [DLixilYobi10] 			= '" + sAryData[(int)Lixil_csv.Yobi10].ToString().Trim() + "'");                         //予備１０
                        query.AppendLine("AND  [DLixilTyuNo] 			= '" + sAryData[(int)Lixil_csv.OrderNo].ToString().Trim() + "'");                        //注文No
                        query.AppendLine("AND  [DLixilSize2] 			= " + sAryData[(int)Lixil_csv.EntrySize2].ToString().Trim());                           //入力寸法2
                        query.AppendLine("AND  [DLixilSize1] 			= " + sAryData[(int)Lixil_csv.EntrySize1].ToString().Trim());                           //入力寸法1
                        query.AppendLine("AND  [DLixilTokutyuSiyoKbn1] 	= '" + sAryData[(int)Lixil_csv.SpeSpecKbn1].ToString().Trim() + "'");                    //特注特別仕様区分１
                        query.AppendLine("AND  [DLixilTokutyuSiyoNam1] 	= '" + sAryData[(int)Lixil_csv.SpeSpecNam1].ToString().Trim() + "'");                    //特注特別仕様名称１
                        query.AppendLine("AND  [DLixilTokutyuSiyoSize1] = " + sAryData[(int)Lixil_csv.SpeSpecSize1].ToString().Trim());                         //特注特別仕様寸法１
                        query.AppendLine("AND  [DLixilInputKbn] 		= " + sAryData[(int)Lixil_csv.InputKbn].ToString().Trim());                             //入力区分
                        query.AppendLine("AND  [DLixilToritukeNo] 		= '" + sAryData[(int)Lixil_csv.AttachmentNo].ToString().Trim() + "'");                   //取付位置No
                        query.AppendLine("AND  [DLixilToritukeNam] 		= '" + sAryData[(int)Lixil_csv.AttachmentNo].ToString().Trim() + "'");                   //取付位置
                        query.AppendLine("AND  [DLixilDairiHatyuKanNo] 	= '" + sAryData[(int)Lixil_csv.AgencyOrderManageNo].ToString().Trim() + "'");            //代販店発注管理Ｎｏ
                        query.AppendLine("AND  [DLixilAutoNebikiCD] 	= '" + sAryData[(int)Lixil_csv.AutoDiscountCD].ToString().Trim() + "'");                 //自動値引コード
                        query.AppendLine("AND  [DLixilShohinBunCD] 		= '" + sAryData[(int)Lixil_csv.ItemClassCD].ToString().Trim() + "'");                    //商品分類コード
                        query.AppendLine("AND  [DLixilShoSyukeiCD] 		= '" + sAryData[(int)Lixil_csv.ItemSumCD].ToString().Trim() + "'");                      //商品集計コード
                        query.AppendLine("AND  [DLixilUniqueCD] 		= '" + sAryData[(int)Lixil_csv.UniqueCD].ToString().Trim() + "'");                       //ユニークコード
                        query.AppendLine("AND  [DLixilTostemNo] 		= '" + sAryData[(int)Lixil_csv.TostemNo].ToString().Trim() + "'");                       //トステム建物No               
                        query.AppendLine("AND  [DLixilTostemMituNo] 	= '" + sAryData[(int)Lixil_csv.TostemEstimateNo].ToString().Trim() + "'");               //トステム見積No
                        query.AppendLine("AND  [DLixilHaseiNo] 			= '" + sAryData[(int)Lixil_csv.OccuNo].ToString().Trim() + "'");                         //発生No(OnSite) 
                        query.AppendLine("AND  [DLixilSyuKbn] 			= " + sAryData[(int)Lixil_csv.SumKbn].ToString().Trim());                               //集計区分
                        query.AppendLine("AND  [DLixilLhinsyu] 			= '" + sAryData[(int)Lixil_csv.L_ItemClass].ToString().Trim() + "'");                    //L品種
                        query.AppendLine("AND  [DLixilLHinsyuKansan] 	= '" + sAryData[(int)Lixil_csv.L_ItemClassConvKbn].ToString().Trim() + "'");             //L品種数量換算区分
                        query.AppendLine("AND  [DLixilThinsyu] 			= '" + sAryData[(int)Lixil_csv.T_ItemClass].ToString().Trim() + "'");                    //T品種
                        query.AppendLine("AND  [DLixilTHinsyuKansan] 	= '" + sAryData[(int)Lixil_csv.T_ItemClassConvKbn].ToString().Trim() + "'");             //T品種数量換算区分
                        query.AppendLine("AND  [DLixilQhinsyu] 			= '" + sAryData[(int)Lixil_csv.Q_ItemClass].ToString().Trim() + "'");                    //Q品種
                        query.AppendLine("AND  [DLixilQHinsyuKansan] 	= '" + sAryData[(int)Lixil_csv.Q_ItemClassConvKbn].ToString().Trim() + "'");             //Q品種数量換算区分
                        Console.WriteLine(query.ToString());
                        tb = db.ExecuteSql(query.ToString(), -1);
                        iRow = tb.Rows.Count;
                        tb.Dispose();                      
                        //存在しなければ、新規登録を実施する
                        if (iRow == 0)
                        {
                            query.Clear();
                            query.AppendLine("INSERT ");
                            query.AppendLine("INTO DLIXIL( ");
                            query.AppendLine("[DLixilDLKbn]");
                            query.AppendLine(", [DLixilBrandNam]");
                            query.AppendLine(", [DLixilHatyuNo]");
                            query.AppendLine(", [DLixilTrainJIgyoCD]");
                            query.AppendLine(", [DLixilTrainTokuCD]");
                            query.AppendLine(", [DLixilBukenNo]");
                            query.AppendLine(", [DLixilBiko]");
                            query.AppendLine(", [DLixilSetNo]");
                            query.AppendLine(", [DLixilKanseiGyoNo]");
                            query.AppendLine(", [DLixilMeisaiGyoNo]");
                            query.AppendLine(", [DLixilHinCD]");
                            query.AppendLine(", [DLixilHinNam]");
                            query.AppendLine(", [DLixilJodai]");
                            query.AppendLine(", [DLixilTanka]");
                            query.AppendLine(", [DLixilGenka]");
                            query.AppendLine(", [DLixilHinNaibuCD]");
                            query.AppendLine(", [DLixilHatyuSu]");
                            query.AppendLine(", [DLixilHkiate1]");
                            query.AppendLine(", [DLixilHkiate2]");
                            query.AppendLine(", [DLixilHkiate3]");
                            query.AppendLine(", [DLixilHkiate4]");
                            query.AppendLine(", [DLixilHkiate5]");
                            query.AppendLine(", [DLixilHkiate6]");
                            query.AppendLine(", [DLixilSiteiNouhinDay]");
                            query.AppendLine(", [DLixilAnswerDay1]");
                            query.AppendLine(", [DLixilAnswerDay2]");
                            query.AppendLine(", [DLixilAnswerDay3]");
                            query.AppendLine(", [DLixilAnswerDay4]");
                            query.AppendLine(", [DLixilAnswerDay5]");
                            query.AppendLine(", [DLixilAnswerDay6]");
                            query.AppendLine(", [DLxilAnswerKbn1]");
                            query.AppendLine(", [DLxilAnswerKbn2]");
                            query.AppendLine(", [DLxilAnswerKbn3]");
                            query.AppendLine(", [DLxilAnswerKbn4]");
                            query.AppendLine(", [DLxilAnswerKbn5]");
                            query.AppendLine(", [DLxilAnswerKbn6]");
                            query.AppendLine(", [DLxilCustomerCD]");
                            query.AppendLine(", [DLxilCustomerTokuiCD]");
                            query.AppendLine(", [DLxilGenbaNam]");
                            query.AppendLine(", [DLxilHatyuDay]");
                            query.AppendLine(", [DLixilLixilUkeDay]");
                            query.AppendLine(", [DLixilSuKanriKbn]");
                            query.AppendLine(", [DLixilHatyyuKeitaiKbn]");
                            query.AppendLine(", [DLixilZaikoKbn]");
                            query.AppendLine(", [DLixilBillitemKbn]");
                            query.AppendLine(", [DLixilNini1]");
                            query.AppendLine(", [DLixilNini2]");
                            query.AppendLine(", [DLixilNini3]");
                            query.AppendLine(", [DLixilNini4-1]");
                            query.AppendLine(", [DLixilNini4-2]");
                            query.AppendLine(", [DLixilNini4-3]");
                            query.AppendLine(", [DLixilNini5]");
                            query.AppendLine(", [DLixilNini6]");
                            query.AppendLine(", [DLixilYobi1]");
                            query.AppendLine(", [DLixilYobi2]");
                            query.AppendLine(", [DLixilYobi3]");
                            query.AppendLine(", [DLixilYobi4]");
                            query.AppendLine(", [DLixilYobi5]");
                            query.AppendLine(", [DLixilYobi6]");
                            query.AppendLine(", [DLixilYobi7]");
                            query.AppendLine(", [DLixilYobi8]");
                            query.AppendLine(", [DLixilYobi9]");
                            query.AppendLine(", [DLixilYobi10]");
                            query.AppendLine(", [DLixilTyuNo]");
                            query.AppendLine(", [DLixilSize2]");
                            query.AppendLine(", [DLixilSize1]");
                            query.AppendLine(", [DLixilTokutyuSiyoKbn1]");
                            query.AppendLine(", [DLixilTokutyuSiyoNam1]");
                            query.AppendLine(", [DLixilTokutyuSiyoSize1]");
                            query.AppendLine(", [DLixilTokutyuSiyoKbn2]");
                            query.AppendLine(", [DLixilTokutyuSiyoNam2]");
                            query.AppendLine(", [DLixilTokutyuSiyoSize2]");
                            query.AppendLine(", [DLixilTokutyuSiyoKbn3]");
                            query.AppendLine(", [DLixilTokutyuSiyoNam3]");
                            query.AppendLine(", [DLixilTokutyuSiyoSize3]");
                            query.AppendLine(", [DLixilInputKbn]");
                            query.AppendLine(", [DLixilToritukeNo]");
                            query.AppendLine(", [DLixilToritukeNam]");
                            query.AppendLine(", [DLixilDairiHatyuKanNo]");
                            query.AppendLine(", [DLixilAutoNebikiCD]");
                            query.AppendLine(", [DLixilShohinBunCD]");
                            query.AppendLine(", [DLixilShoSyukeiCD]");
                            query.AppendLine(", [DLixilUniqueCD]");
                            query.AppendLine(", [DLixilUnderShopCD]");
                            query.AppendLine(", [DLixilTostemNo]");
                            query.AppendLine(", [DLixilTostemMituNo]");
                            query.AppendLine(", [DLixilHaseiNo]");
                            query.AppendLine(", [DLixilWindow]");
                            query.AppendLine(", [DLixilSyuKbn]");
                            query.AppendLine(", [DLixilLhinsyu]");
                            query.AppendLine(", [DLixilLHinsyuKansan]");
                            query.AppendLine(", [DLixilThinsyu]");
                            query.AppendLine(", [DLixilTHinsyuKansan]");
                            query.AppendLine(", [DLixilQhinsyu]");
                            query.AppendLine(", [DLixilQHinsyuKansan]");
                            query.AppendLine(", [DLixilEmpty]");
                            query.AppendLine(", [DLixilInsDay]");
                            query.AppendLine(", [DLixilInsTim]");
                            query.AppendLine(", [DLixilInsID]");
                            query.AppendLine(", [DLixilUpDay]");
                            query.AppendLine(", [DLixilUpTim]");
                            query.AppendLine(", [DLixilUpID]");
                            query.AppendLine(", [DLixilCommitFlg]");
                            query.AppendLine(") ");
                            query.AppendLine("VALUES ( ");
                            query.AppendLine(cboBrand.SelectedValue.ToString());                        //ダウンロード区分
                            query.AppendLine(",'"   + tmp.ItemDisp2.ToString().Trim()                                   + "'");                 //ブランド名
                            query.AppendLine(",'"   + sAryData[(int)Lixil_csv.OrderManageNo].ToString().Trim()          + "'");                 //発注管理No
                            query.AppendLine(",'"   + sAryData[(int)Lixil_csv.TRAINJigyoCD].ToString().Trim()           + "'");                 //TRAIN事業所コード
                            query.AppendLine(",'"   + sAryData[(int)Lixil_csv.TRAINTokuCD].ToString().Trim()            + "'");                 //TRAIN徳先コード
                            query.AppendLine(","    + sAryData[(int)Lixil_csv.BukenNo].ToString().Trim());                                      //物件No
                            query.AppendLine(",'"   + sAryData[(int)Lixil_csv.Biko].ToString().Trim()                   + "'");                 //備考
                            query.AppendLine(","    + sAryData[(int)Lixil_csv.SetNo].ToString().Trim());                                        //セットNo
                            query.AppendLine(","    + sAryData[(int)Lixil_csv.KanseiRowNo].ToString().Trim());                                  //完成品行No
                            query.AppendLine(","    + sAryData[(int)Lixil_csv.DetailRowNo].ToString().Trim());                                  //明細行No
                            query.AppendLine(",'"   + sAryData[(int)Lixil_csv.ItemCD].ToString().Trim()                 + "'");                 //商品コード
                            query.AppendLine(",'"   + sAryData[(int)Lixil_csv.ItemNam].ToString()                       + "'");                 //商品名称
                            query.AppendLine(","    + sAryData[(int)Lixil_csv.Joudai].ToString().Trim());                                       //上代価格
                            query.AppendLine(","    + sAryData[(int)Lixil_csv.Tanka].ToString().Trim());                                        //単価
                            query.AppendLine(","    + sAryData[(int)Lixil_csv.Genka].ToString().Trim());                                        //原価
                            query.AppendLine(",'"   + sAryData[(int)Lixil_csv.BreedCD].ToString().Trim()                + "'");                 //品種内部コード
                            query.AppendLine(","    + sAryData[(int)Lixil_csv.OrderCnt].ToString().Trim());                                     //発注数
                            query.AppendLine(","    + sAryData[(int)Lixil_csv.AllocationsNum1].ToString().Trim());                              //引当数1
                            query.AppendLine(","    + sAryData[(int)Lixil_csv.AllocationsNum2].ToString().Trim());                              //引当数2
                            query.AppendLine(","    + sAryData[(int)Lixil_csv.AllocationsNum3].ToString().Trim());                              //引当数3
                            query.AppendLine(","    + sAryData[(int)Lixil_csv.AllocationsNum4].ToString().Trim());                              //引当数4
                            query.AppendLine(","    + sAryData[(int)Lixil_csv.AllocationsNum5].ToString().Trim());                              //引当数5
                            query.AppendLine(","    + sAryData[(int)Lixil_csv.AllocationsNum6].ToString().Trim());                              //引当数6
                            query.AppendLine(",'"   + sAryData[(int)Lixil_csv.SpecDeliDay].ToString().Trim()            + "'");                 //指定納品日
                            query.AppendLine(",'"   + sAryData[(int)Lixil_csv.AnswerDay1].ToString().Trim()             + "'");                 //回答納品日1
                            query.AppendLine(",'"   + sAryData[(int)Lixil_csv.AnswerDay2].ToString().Trim()             + "'");                 //回答納品日2
                            query.AppendLine(",'"   + sAryData[(int)Lixil_csv.AnswerDay3].ToString().Trim()             + "'");                 //回答納品日3
                            query.AppendLine(",'"   + sAryData[(int)Lixil_csv.AnswerDay4].ToString().Trim()             + "'");                 //回答納品日4
                            query.AppendLine(",'"   + sAryData[(int)Lixil_csv.AnswerDay5].ToString().Trim()             + "'");                 //回答納品日5
                            query.AppendLine(",'"   + sAryData[(int)Lixil_csv.AnswerDay6].ToString().Trim()             + "'");                 //回答納品日6
                            query.AppendLine(","    + sAryData[(int)Lixil_csv.AnswerKbn1].ToString().Trim());                                   //回答区分1
                            query.AppendLine(","    + sAryData[(int)Lixil_csv.AnswerKbn2].ToString().Trim());                                   //回答区分2
                            query.AppendLine(","    + sAryData[(int)Lixil_csv.AnswerKbn3].ToString().Trim());                                   //回答区分3
                            query.AppendLine(","    + sAryData[(int)Lixil_csv.AnswerKbn4].ToString().Trim());                                   //回答区分4
                            query.AppendLine(","    + sAryData[(int)Lixil_csv.AnswerKbn5].ToString().Trim());                                   //回答区分5
                            query.AppendLine(","    + sAryData[(int)Lixil_csv.AnswerKbn6].ToString().Trim());                                   //回答区分6
                            query.AppendLine(",'"   + sAryData[(int)Lixil_csv.CustomerOfficeCD].ToString().Trim()       + "'");                 //お客様事業所コード
                            query.AppendLine(",'"   + sAryData[(int)Lixil_csv.CustomerCD].ToString().Trim()             + "'");                 //お客様得意先コード
                            query.AppendLine(",'"   + sAryData[(int)Lixil_csv.SiteNam].ToString()                       + "'");                 //現場名(両端にスペース入ってる場合あるのでTrimはしない)
                            query.AppendLine(",'"   + sAryData[(int)Lixil_csv.OrderDay].ToString().Trim()               + "'");                 //発注日
                            query.AppendLine(",'"   + sAryData[(int)Lixil_csv.LisilDay].ToString().Trim()               + "'");                 //LIXIL受付日
                            query.AppendLine(",'"   + sAryData[(int)Lixil_csv.NumManageKbn].ToString().Trim()           + "'");                 //数量管理区分
                            query.AppendLine(","    + sAryData[(int)Lixil_csv.OrdertoCarryKbn].ToString().Trim());                              //発注携帯区分
                            query.AppendLine(","    + sAryData[(int)Lixil_csv.StockUseKbn].ToString().Trim());                                  //在庫使用フラグ
                            query.AppendLine(","    + sAryData[(int)Lixil_csv.BillItemKbn].ToString().Trim());                                  //ビル商品部区分
                            query.AppendLine(",'"   + sAryData[(int)Lixil_csv.AnyEntry1].ToString().Trim()              + "'");                 //任意入力項目１
                            query.AppendLine(",'"   + sAryData[(int)Lixil_csv.AnyEntry2].ToString().Trim()              + "'");                 //任意入力項目２
                            query.AppendLine(",'"   + sAryData[(int)Lixil_csv.AnyEntry3].ToString().Trim()              + "'");                 //任意入力項目３
                            query.AppendLine(",'"   + sAryData[(int)Lixil_csv.AnyEntry4_1].ToString().Trim()            + "'");                 //任意入力項目４ー１
                            query.AppendLine(",'"   + sAryData[(int)Lixil_csv.AnyEntry4_2].ToString().Trim()            + "'");                 //任意入力項目４ー２
                            query.AppendLine(",'"   + sAryData[(int)Lixil_csv.AnyEntry4_3].ToString().Trim()            + "'");                 //任意入力項目４ー３
                            query.AppendLine(",'"   + sAryData[(int)Lixil_csv.AnyEntry5].ToString().Trim()              + "'");                 //任意入力項目5
                            query.AppendLine(",'"   + sAryData[(int)Lixil_csv.AnyEntry6].ToString().Trim()              + "'");                 //任意入力項目6
                            query.AppendLine(",'"   + sAryData[(int)Lixil_csv.Yobi1].ToString().Trim()                  + "'");                 //予備１
                            query.AppendLine(",'"   + sAryData[(int)Lixil_csv.Yobi2].ToString().Trim()                  + "'");                 //予備２
                            query.AppendLine(",'"   + sAryData[(int)Lixil_csv.Yobi3].ToString().Trim()                  + "'");                 //予備３
                            query.AppendLine(",'"   + sAryData[(int)Lixil_csv.Yobi4].ToString().Trim()                  + "'");                 //予備４
                            query.AppendLine(",'"   + sAryData[(int)Lixil_csv.Yobi5].ToString().Trim()                  + "'");                 //予備５
                            query.AppendLine(",'"   + sAryData[(int)Lixil_csv.Yobi6].ToString().Trim()                  + "'");                 //予備６
                            query.AppendLine(",'"   + sAryData[(int)Lixil_csv.Yobi7].ToString().Trim()                  + "'");                 //予備７
                            query.AppendLine(",'"   + sAryData[(int)Lixil_csv.Yobi8].ToString().Trim()                  + "'");                 //予備８
                            query.AppendLine(",'"   + sAryData[(int)Lixil_csv.Yobi9].ToString().Trim()                  + "'");                 //予備９
                            query.AppendLine(",'"   + sAryData[(int)Lixil_csv.Yobi10].ToString().Trim()                 + "'");                 //予備１０
                            query.AppendLine(",'"   + sAryData[(int)Lixil_csv.OrderNo].ToString().Trim()                + "'");                 //注文No
                            query.AppendLine(","    + sAryData[(int)Lixil_csv.EntrySize2].ToString().Trim());                                   //入力寸法2
                            query.AppendLine(","    + sAryData[(int)Lixil_csv.EntrySize1].ToString().Trim());                                   //入力寸法1
                            query.AppendLine(",'"   + sAryData[(int)Lixil_csv.SpeSpecKbn1].ToString().Trim()            + "'");                 //特注特別仕様区分１
                            query.AppendLine(",'"   + sAryData[(int)Lixil_csv.SpeSpecNam1].ToString().Trim()            + "'");                 //特注特別仕様名称１
                            query.AppendLine(","    + sAryData[(int)Lixil_csv.SpeSpecSize1].ToString().Trim());                                 //特注特別仕様寸法１
                            query.AppendLine(",'"   + sAryData[(int)Lixil_csv.SpeSpecKbn2].ToString().Trim()            + "'");                 //特注特別仕様区分２
                            query.AppendLine(",'"   + sAryData[(int)Lixil_csv.SpeSpecNam2].ToString().Trim()            + "'");                 //特注特別仕様名称２
                            query.AppendLine(","    + sAryData[(int)Lixil_csv.SpeSpecSize3].ToString().Trim());                                 //特注特別仕様寸法２
                            query.AppendLine(",'"   + sAryData[(int)Lixil_csv.SpeSpecKbn3].ToString().Trim()            + "'");                 //特注特別仕様区分３
                            query.AppendLine(",'"   + sAryData[(int)Lixil_csv.SpeSpecNam3].ToString().Trim()            + "'");                 //特注特別仕様名称３
                            query.AppendLine(","    + sAryData[(int)Lixil_csv.SpeSpecSize3].ToString().Trim());                                 //特注特別仕様寸法３
                            query.AppendLine(","    + sAryData[(int)Lixil_csv.InputKbn].ToString().Trim());                                     //入力区分
                            query.AppendLine(",'"   + sAryData[(int)Lixil_csv.AttachmentNo].ToString().Trim()           + "'");                 //取付位置No
                            query.AppendLine(",'"   + sAryData[(int)Lixil_csv.Attachment].ToString().Trim()             + "'");                 //取付位置
                            query.AppendLine(",'"   + sAryData[(int)Lixil_csv.AgencyOrderManageNo].ToString().Trim()    + "'");                 //代販店発注管理Ｎｏ
                            query.AppendLine(",'"   + sAryData[(int)Lixil_csv.AutoDiscountCD].ToString().Trim()         + "'");                 //自動値引コード
                            query.AppendLine(",'"   + sAryData[(int)Lixil_csv.ItemClassCD].ToString().Trim()            + "'");                 //商品分類コード
                            query.AppendLine(",'"   + sAryData[(int)Lixil_csv.ItemSumCD].ToString().Trim()              + "'");                 //商品集計コード
                            query.AppendLine(",'"   + sAryData[(int)Lixil_csv.UniqueCD].ToString().Trim()               + "'");                 //ユニークコード
                            query.AppendLine(",'"   + sAryData[(int)Lixil_csv.UnderShopCD].ToString().Trim()            + "'");                 //下店コード
                            query.AppendLine(",'"   + sAryData[(int)Lixil_csv.TostemNo].ToString().Trim()               + "'");                 //トステム建物No
                            query.AppendLine(",'"   + sAryData[(int)Lixil_csv.TostemEstimateNo].ToString().Trim()       + "'");                 //トステム見積No
                            query.AppendLine(",'"   + sAryData[(int)Lixil_csv.OccuNo].ToString().Trim()                 + "'");                 //発生No(OnSite) 
                            query.AppendLine(",'"   + sAryData[(int)Lixil_csv.WindowSpecValue].ToString().Trim()        + "'");                 //窓性能評価値（星の数）
                            query.AppendLine(","    + sAryData[(int)Lixil_csv.SumKbn].ToString().Trim());                                       //集計区分
                            query.AppendLine(",'"   + sAryData[(int)Lixil_csv.L_ItemClass].ToString().Trim()            + "'");                 //L品種
                            query.AppendLine(",'"   + sAryData[(int)Lixil_csv.L_ItemClassConvKbn].ToString().Trim()     + "'");                 //L品種数量換算区分
                            query.AppendLine(",'"   + sAryData[(int)Lixil_csv.T_ItemClass].ToString().Trim()            + "'");                 //T品種
                            query.AppendLine(",'"   + sAryData[(int)Lixil_csv.T_ItemClass].ToString().Trim()            + "'");                 //T品種数量換算区分
                            query.AppendLine(",'"   + sAryData[(int)Lixil_csv.Q_ItemClass].ToString().Trim()            + "'");                 //Q品種
                            query.AppendLine(",'"   + sAryData[(int)Lixil_csv.Q_ItemClassConvKbn].ToString().Trim()     + "'");                 //Q品種数量換算区分
                            query.AppendLine(",''");                                                    //空白
                            query.AppendLine(",FORMAT(GETDATE(), 'yyyMMdd')");                          //登録日
                            query.AppendLine(",FORMAT(GETDATE(), 'HHmmss')");                           //登録時間
                            query.AppendLine(",'" + parameter._sOpeManID.ToString() + "'");             //登録者ID
                            query.AppendLine(",FORMAT(GETDATE(), 'yyyMMdd')");                          //更新日
                            query.AppendLine(",FORMAT(GETDATE(), 'HHmmss')");                           //更新時間
                            query.AppendLine(",'" + parameter._sOpeManID.ToString() + "'");             //更新者ID
                            query.AppendLine(",0");                                                     //完了フラグ
                            query.AppendLine(")");
                            Console.WriteLine(query.ToString());
                            db.BeginTransaction();
                            db.ExecuteSql(query.ToString(), -1);
                            db.CommitTransaction();
                            pgbCheckBar.Value = i;
                            i++;
                        }
                    }

                    db.Disconnect();
                }
                
                //完了処理
                MessageBox.Show("取込が完了しました。","取込完了",MessageBoxButtons.OK,MessageBoxIcon.Information);
                lblMsg.Text = "";
                lblMsg.Visible = false;
                if (MessageBox.Show("引き続き、他のファイルも取込みますか？","確認",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    btnCancel_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("画面を終了し案件管理画面にて次の処理をしてください", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtFilePath.Text = "";
            txtFilePath.Enabled = true;
            btnFileSel.Enabled = true;
            cboBrand.Enabled = true;
            cboBrand.SelectedIndex = 0;
            lblMsg.Text = "";
            pgbCheckBar.Visible = false;
            btnUpdate.Enabled = false;
            fpSpread1_Sheet1.Rows.Clear();
        }

        private void fpSpread1_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {

        }
    }
}
