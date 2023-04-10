namespace S_D993000001
{
    partial class S_D993000001_02
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(S_D993000001_02));
            this.label3 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblStep1 = new System.Windows.Forms.Label();
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.fpSpread1 = new FarPoint.Win.Spread.FpSpread();
            this.fpSpread1_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.btnFileSel = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cboBrand = new System.Windows.Forms.ComboBox();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pgbCheckBar = new System.Windows.Forms.ProgressBar();
            this.btnCancel = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.lblMsg = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Blue;
            this.label3.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Yellow;
            this.label3.Location = new System.Drawing.Point(4, 10);
            this.label3.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(938, 29);
            this.label3.TabIndex = 118;
            this.label3.Text = "オンサイト／クラスフル CSVデータ取込";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnClose.Location = new System.Drawing.Point(952, 10);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(110, 30);
            this.btnClose.TabIndex = 125;
            this.btnClose.Text = "閉じる";
            this.toolTip1.SetToolTip(this.btnClose, "前の画面に戻ります");
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblStep1
            // 
            this.lblStep1.AutoSize = true;
            this.lblStep1.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblStep1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblStep1.Location = new System.Drawing.Point(10, 104);
            this.lblStep1.Name = "lblStep1";
            this.lblStep1.Size = new System.Drawing.Size(180, 18);
            this.lblStep1.TabIndex = 126;
            this.lblStep1.Text = "② ファイルを選択してください";
            // 
            // ofd
            // 
            this.ofd.FileName = "openFileDialog1";
            // 
            // fpSpread1
            // 
            this.fpSpread1.AccessibleDescription = "fpSpread1, Sheet1, Row 0, Column 0";
            this.fpSpread1.AllowCellOverflow = true;
            this.fpSpread1.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            this.fpSpread1.Location = new System.Drawing.Point(13, 183);
            this.fpSpread1.Name = "fpSpread1";
            this.fpSpread1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fpSpread1_Sheet1});
            this.fpSpread1.Size = new System.Drawing.Size(1049, 480);
            this.fpSpread1.TabIndex = 128;
            this.fpSpread1.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpSpread1.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpSpread1_CellDoubleClick);
            // 
            // fpSpread1_Sheet1
            // 
            this.fpSpread1_Sheet1.Reset();
            this.fpSpread1_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fpSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fpSpread1_Sheet1.ColumnCount = 9;
            this.fpSpread1_Sheet1.RowCount = 0;
            this.fpSpread1_Sheet1.ActiveColumnIndex = -1;
            this.fpSpread1_Sheet1.ActiveRowIndex = -1;
            this.fpSpread1_Sheet1.AlternatingRows.Get(1).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "重複";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "発注管理No";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "物件コード";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "完成品行No";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 4).Locked = false;
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "現場名";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "商品名称";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "発注数";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "回答納品日";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "取付位置";
            this.fpSpread1_Sheet1.Columns.Get(1).Label = "発注管理No";
            this.fpSpread1_Sheet1.Columns.Get(1).Width = 116F;
            this.fpSpread1_Sheet1.Columns.Get(2).CellType = textCellType1;
            this.fpSpread1_Sheet1.Columns.Get(2).Label = "物件コード";
            this.fpSpread1_Sheet1.Columns.Get(2).Width = 99F;
            this.fpSpread1_Sheet1.Columns.Get(3).Label = "完成品行No";
            this.fpSpread1_Sheet1.Columns.Get(3).Width = 85F;
            this.fpSpread1_Sheet1.Columns.Get(4).Label = "現場名";
            this.fpSpread1_Sheet1.Columns.Get(4).Width = 133F;
            this.fpSpread1_Sheet1.Columns.Get(5).Label = "商品名称";
            this.fpSpread1_Sheet1.Columns.Get(5).Width = 270F;
            this.fpSpread1_Sheet1.Columns.Get(6).Label = "発注数";
            this.fpSpread1_Sheet1.Columns.Get(6).Width = 76F;
            this.fpSpread1_Sheet1.Columns.Get(7).Label = "回答納品日";
            this.fpSpread1_Sheet1.Columns.Get(7).Width = 92F;
            this.fpSpread1_Sheet1.Columns.Get(8).Label = "取付位置";
            this.fpSpread1_Sheet1.Columns.Get(8).Width = 89F;
            this.fpSpread1_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.ReadOnly;
            this.fpSpread1_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.fpSpread1_Sheet1.RowHeader.Visible = false;
            this.fpSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // btnFileSel
            // 
            this.btnFileSel.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnFileSel.Location = new System.Drawing.Point(743, 99);
            this.btnFileSel.Name = "btnFileSel";
            this.btnFileSel.Size = new System.Drawing.Size(110, 30);
            this.btnFileSel.TabIndex = 129;
            this.btnFileSel.Text = "ファイルを選択";
            this.toolTip1.SetToolTip(this.btnFileSel, "オンサイト/クラスフルからダウンロードしたCSVファイルを選択してください");
            this.btnFileSel.UseVisualStyleBackColor = true;
            this.btnFileSel.Click += new System.EventHandler(this.btnFileSel_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Enabled = false;
            this.btnUpdate.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnUpdate.Location = new System.Drawing.Point(952, 96);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(110, 30);
            this.btnUpdate.TabIndex = 130;
            this.btnUpdate.Text = "取り込み開始";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(12, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 18);
            this.label1.TabIndex = 131;
            this.label1.Text = "① 受注元を選択してください";
            // 
            // cboBrand
            // 
            this.cboBrand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBrand.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cboBrand.FormattingEnabled = true;
            this.cboBrand.Location = new System.Drawing.Point(196, 56);
            this.cboBrand.Name = "cboBrand";
            this.cboBrand.Size = new System.Drawing.Size(239, 26);
            this.cboBrand.TabIndex = 132;
            this.toolTip1.SetToolTip(this.cboBrand, "今回取り込むファイルの受注元を選択してください（※必須）");
            // 
            // txtFilePath
            // 
            this.txtFilePath.Location = new System.Drawing.Point(196, 101);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(541, 25);
            this.txtFilePath.TabIndex = 127;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(884, 96);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(40, 33);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 133;
            this.pictureBox1.TabStop = false;
            // 
            // pgbCheckBar
            // 
            this.pgbCheckBar.Location = new System.Drawing.Point(15, 150);
            this.pgbCheckBar.Name = "pgbCheckBar";
            this.pgbCheckBar.Size = new System.Drawing.Size(1047, 27);
            this.pgbCheckBar.TabIndex = 135;
            this.pgbCheckBar.Visible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnCancel.Location = new System.Drawing.Point(952, 46);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(110, 30);
            this.btnCancel.TabIndex = 136;
            this.btnCancel.Text = "キャンセル";
            this.toolTip1.SetToolTip(this.btnCancel, "画面起動時の状態に戻し、選択したファイルをクリアします。");
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblMsg
            // 
            this.lblMsg.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblMsg.ForeColor = System.Drawing.Color.Red;
            this.lblMsg.Location = new System.Drawing.Point(15, 132);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(1046, 44);
            this.lblMsg.TabIndex = 137;
            this.lblMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMsg.Visible = false;
            // 
            // S_D993000001_02
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(1079, 675);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.pgbCheckBar);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.cboBrand);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnFileSel);
            this.Controls.Add(this.fpSpread1);
            this.Controls.Add(this.txtFilePath);
            this.Controls.Add(this.lblStep1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label3);
            this.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "S_D993000001_02";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "オンサイト／クラスフル CSVデータ取込";
            this.Load += new System.EventHandler(this.S_D993000001_02_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblStep1;
        private System.Windows.Forms.OpenFileDialog ofd;
        private FarPoint.Win.Spread.FpSpread fpSpread1;
        private FarPoint.Win.Spread.SheetView fpSpread1_Sheet1;
        private System.Windows.Forms.Button btnFileSel;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboBrand;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ProgressBar pgbCheckBar;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label lblMsg;
    }
}