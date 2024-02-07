namespace GIFToSpriteSheet
{
    public partial class MainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtbox_Import = new TextBox();
            txtbox_Export = new TextBox();
            btn_Import = new Button();
            btn_Export = new Button();
            scrollbar_Columns = new HScrollBar();
            btn_Convert = new Button();
            label_Columns = new Label();
            pbox_SpriteSheet = new PictureBox();
            loadingBar = new ProgressBar();
            ((System.ComponentModel.ISupportInitialize)pbox_SpriteSheet).BeginInit();
            SuspendLayout();
            // 
            // txtbox_Import
            // 
            txtbox_Import.Enabled = false;
            txtbox_Import.Location = new Point(12, 12);
            txtbox_Import.Name = "txtbox_Import";
            txtbox_Import.Size = new Size(449, 23);
            txtbox_Import.TabIndex = 0;
            // 
            // txtbox_Export
            // 
            txtbox_Export.Enabled = false;
            txtbox_Export.Location = new Point(12, 41);
            txtbox_Export.Name = "txtbox_Export";
            txtbox_Export.Size = new Size(449, 23);
            txtbox_Export.TabIndex = 0;
            // 
            // btn_Import
            // 
            btn_Import.Location = new Point(467, 13);
            btn_Import.Name = "btn_Import";
            btn_Import.Size = new Size(101, 23);
            btn_Import.TabIndex = 1;
            btn_Import.Text = "Import GIF";
            btn_Import.UseVisualStyleBackColor = true;
            btn_Import.Click += btn_Import_Click;
            // 
            // btn_Export
            // 
            btn_Export.Location = new Point(467, 41);
            btn_Export.Name = "btn_Export";
            btn_Export.Size = new Size(101, 23);
            btn_Export.TabIndex = 1;
            btn_Export.Text = "Export";
            btn_Export.UseVisualStyleBackColor = true;
            btn_Export.Click += btn_Export_Click;
            // 
            // scrollbar_Columns
            // 
            scrollbar_Columns.LargeChange = 1;
            scrollbar_Columns.Location = new Point(12, 70);
            scrollbar_Columns.Maximum = 15;
            scrollbar_Columns.Minimum = 1;
            scrollbar_Columns.Name = "scrollbar_Columns";
            scrollbar_Columns.Size = new Size(317, 17);
            scrollbar_Columns.TabIndex = 1;
            scrollbar_Columns.Value = 1;
            scrollbar_Columns.ValueChanged += scrollbar_Columns_ValueChanged;
            // 
            // btn_Convert
            // 
            btn_Convert.Enabled = false;
            btn_Convert.Location = new Point(467, 70);
            btn_Convert.Name = "btn_Convert";
            btn_Convert.Size = new Size(101, 53);
            btn_Convert.TabIndex = 1;
            btn_Convert.Text = "Convert";
            btn_Convert.UseVisualStyleBackColor = true;
            btn_Convert.Click += btn_Convert_Click;
            // 
            // label_Columns
            // 
            label_Columns.AutoSize = true;
            label_Columns.Location = new Point(332, 73);
            label_Columns.Name = "label_Columns";
            label_Columns.Size = new Size(94, 15);
            label_Columns.TabIndex = 2;
            label_Columns.Text = "No. of Columns:";
            // 
            // pbox_SpriteSheet
            // 
            pbox_SpriteSheet.Location = new Point(12, 142);
            pbox_SpriteSheet.Name = "pbox_SpriteSheet";
            pbox_SpriteSheet.Size = new Size(556, 436);
            pbox_SpriteSheet.TabIndex = 3;
            pbox_SpriteSheet.TabStop = false;
            // 
            // loadingBar
            // 
            loadingBar.Location = new Point(12, 100);
            loadingBar.Name = "loadingBar";
            loadingBar.Size = new Size(449, 23);
            loadingBar.TabIndex = 4;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(580, 590);
            Controls.Add(loadingBar);
            Controls.Add(pbox_SpriteSheet);
            Controls.Add(label_Columns);
            Controls.Add(scrollbar_Columns);
            Controls.Add(btn_Convert);
            Controls.Add(btn_Export);
            Controls.Add(btn_Import);
            Controls.Add(txtbox_Export);
            Controls.Add(txtbox_Import);
            Name = "MainWindow";
            Text = "GIF to Spritesheet";
            Load += MainWindow_Load;
            ((System.ComponentModel.ISupportInitialize)pbox_SpriteSheet).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public TextBox txtbox_Import;
        public TextBox txtbox_Export;
        public Button btn_Import;
        public Button btn_Export;
        public HScrollBar scrollbar_Columns;
        public Button btn_Convert;
        public Label label_Columns;
        public PictureBox pbox_SpriteSheet;
        public ProgressBar loadingBar;
    }
}