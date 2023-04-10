namespace S_D993000001
{
    partial class S_D993000001_05
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
            FarPoint.Win.Spread.CellType.TextCellType textCellType3 = new FarPoint.Win.Spread.CellType.TextCellType();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdoSortCD = new System.Windows.Forms.RadioButton();
            this.rdoSortKana = new System.Windows.Forms.RadioButton();
            this.fpSpread1 = new FarPoint.Win.Spread.FpSpread();
            this.fpSpread1_Sheet2 = new FarPoint.Win.Spread.SheetView();
            this.txtKanaSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnKanaSearch = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(306, 6);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(90, 26);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "閉じる";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnKanaSearch);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtKanaSearch);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(22, 38);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(374, 116);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "絞り込み・並び替え";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdoSortCD);
            this.groupBox2.Controls.Add(this.rdoSortKana);
            this.groupBox2.Location = new System.Drawing.Point(45, 18);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(270, 43);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // rdoSortCD
            // 
            this.rdoSortCD.AutoSize = true;
            this.rdoSortCD.Checked = true;
            this.rdoSortCD.Location = new System.Drawing.Point(6, 18);
            this.rdoSortCD.Name = "rdoSortCD";
            this.rdoSortCD.Size = new System.Drawing.Size(127, 16);
            this.rdoSortCD.TabIndex = 1;
            this.rdoSortCD.TabStop = true;
            this.rdoSortCD.Text = "コード順で並び替え";
            this.rdoSortCD.UseVisualStyleBackColor = true;
            // 
            // rdoSortKana
            // 
            this.rdoSortKana.AutoSize = true;
            this.rdoSortKana.Location = new System.Drawing.Point(148, 18);
            this.rdoSortKana.Name = "rdoSortKana";
            this.rdoSortKana.Size = new System.Drawing.Size(106, 16);
            this.rdoSortKana.TabIndex = 0;
            this.rdoSortKana.Text = "ｶﾅ順で並び替え";
            this.rdoSortKana.UseVisualStyleBackColor = true;
            this.rdoSortKana.CheckedChanged += new System.EventHandler(this.rdoSortKana_CheckedChanged);
            // 
            // fpSpread1
            // 
            this.fpSpread1.AccessibleDescription = "";
            this.fpSpread1.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            this.fpSpread1.Location = new System.Drawing.Point(22, 160);
            this.fpSpread1.Name = "fpSpread1";
            this.fpSpread1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fpSpread1_Sheet2});
            this.fpSpread1.Size = new System.Drawing.Size(374, 355);
            this.fpSpread1.TabIndex = 2;
            this.fpSpread1.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpSpread1.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpSpread1_CellDoubleClick);
            this.fpSpread1.SetActiveViewport(0, -1, -1);
            // 
            // fpSpread1_Sheet2
            // 
            this.fpSpread1_Sheet2.Reset();
            this.fpSpread1_Sheet2.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fpSpread1_Sheet2.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fpSpread1_Sheet2.ColumnCount = 2;
            this.fpSpread1_Sheet2.RowCount = 0;
            this.fpSpread1_Sheet2.RowHeader.ColumnCount = 0;
            this.fpSpread1_Sheet2.ActiveColumnIndex = -1;
            this.fpSpread1_Sheet2.ActiveRowIndex = -1;
            this.fpSpread1_Sheet2.AlternatingRows.Get(1).BackColor = System.Drawing.Color.Honeydew;
            this.fpSpread1_Sheet2.ColumnHeader.Cells.Get(0, 0).Value = "コード";
            this.fpSpread1_Sheet2.ColumnHeader.Cells.Get(0, 1).Value = "ビルダー名";
            this.fpSpread1_Sheet2.Columns.Get(0).CellType = textCellType3;
            this.fpSpread1_Sheet2.Columns.Get(0).Label = "コード";
            this.fpSpread1_Sheet2.Columns.Get(0).Width = 78F;
            this.fpSpread1_Sheet2.Columns.Get(1).Label = "ビルダー名";
            this.fpSpread1_Sheet2.Columns.Get(1).Width = 270F;
            this.fpSpread1_Sheet2.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
            this.fpSpread1_Sheet2.RowHeader.Columns.Default.Resizable = false;
            this.fpSpread1_Sheet2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(231)))), ((int)(((byte)(206)))));
            this.fpSpread1_Sheet2.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.fpSpread1_Sheet2.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.fpSpread1_Sheet2.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // txtKanaSearch
            // 
            this.txtKanaSearch.Font = new System.Drawing.Font("BIZ UDPゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtKanaSearch.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf;
            this.txtKanaSearch.Location = new System.Drawing.Point(45, 90);
            this.txtKanaSearch.Name = "txtKanaSearch";
            this.txtKanaSearch.Size = new System.Drawing.Size(194, 20);
            this.txtKanaSearch.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "◆ｶﾅで絞り込む";
            // 
            // btnKanaSearch
            // 
            this.btnKanaSearch.Location = new System.Drawing.Point(271, 84);
            this.btnKanaSearch.Name = "btnKanaSearch";
            this.btnKanaSearch.Size = new System.Drawing.Size(90, 26);
            this.btnKanaSearch.TabIndex = 3;
            this.btnKanaSearch.Text = "絞り込み";
            this.btnKanaSearch.UseVisualStyleBackColor = true;
            this.btnKanaSearch.Click += new System.EventHandler(this.btnKanaSearch_Click);
            // 
            // S_D993000001_05
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(413, 527);
            this.Controls.Add(this.fpSpread1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnClose);
            this.Font = new System.Drawing.Font("BIZ UDPゴシック", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "S_D993000001_05";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ビルダー選択画面";
            this.Load += new System.EventHandler(this.S_D993000001_05_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox groupBox1;
        private FarPoint.Win.Spread.FpSpread fpSpread1;
        private FarPoint.Win.Spread.SheetView fpSpread1_Sheet2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdoSortCD;
        private System.Windows.Forms.RadioButton rdoSortKana;
        private System.Windows.Forms.Button btnKanaSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtKanaSearch;
    }
}