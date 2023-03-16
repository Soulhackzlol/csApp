namespace csAppMenu
{
    partial class Form1
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
            components = new System.ComponentModel.Container();
            materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            label1 = new Label();
            materialTabControl1 = new MaterialSkin.Controls.MaterialTabControl();
            tabPage1 = new TabPage();
            materialRaisedButton2 = new MaterialSkin.Controls.MaterialRaisedButton();
            status_label = new MaterialSkin.Controls.MaterialLabel();
            materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            materialRaisedButton1 = new MaterialSkin.Controls.MaterialRaisedButton();
            materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            tabPage2 = new TabPage();
            bomb_status = new MaterialSkin.Controls.MaterialLabel();
            materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            dataGridView1 = new DataGridView();
            tabPage3 = new TabPage();
            pictureBox3 = new PictureBox();
            materialLabel7 = new MaterialSkin.Controls.MaterialLabel();
            pictureBox2 = new PictureBox();
            materialLabel6 = new MaterialSkin.Controls.MaterialLabel();
            pictureBox1 = new PictureBox();
            materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            materialTabSelector1 = new MaterialSkin.Controls.MaterialTabSelector();
            textUpd = new System.Windows.Forms.Timer(components);
            materialTabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // materialLabel1
            // 
            materialLabel1.AutoSize = true;
            materialLabel1.Depth = 0;
            materialLabel1.Font = new Font("Roboto", 11F, FontStyle.Regular, GraphicsUnit.Point);
            materialLabel1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialLabel1.Location = new Point(18, 22);
            materialLabel1.Margin = new Padding(4, 0, 4, 0);
            materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new Size(140, 19);
            materialLabel1.TabIndex = 0;
            materialLabel1.Text = "Welcome to csApp!";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(249, 414);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(138, 15);
            label1.TabIndex = 3;
            label1.Text = "made with ♥ by s1moscs";
            // 
            // materialTabControl1
            // 
            materialTabControl1.Controls.Add(tabPage1);
            materialTabControl1.Controls.Add(tabPage2);
            materialTabControl1.Controls.Add(tabPage3);
            materialTabControl1.Depth = 0;
            materialTabControl1.Dock = DockStyle.Bottom;
            materialTabControl1.Location = new Point(0, 114);
            materialTabControl1.Margin = new Padding(4, 3, 4, 3);
            materialTabControl1.MouseState = MaterialSkin.MouseState.HOVER;
            materialTabControl1.Name = "materialTabControl1";
            materialTabControl1.SelectedIndex = 0;
            materialTabControl1.Size = new Size(399, 462);
            materialTabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(materialRaisedButton2);
            tabPage1.Controls.Add(status_label);
            tabPage1.Controls.Add(materialLabel3);
            tabPage1.Controls.Add(materialRaisedButton1);
            tabPage1.Controls.Add(materialLabel2);
            tabPage1.Controls.Add(materialLabel1);
            tabPage1.Controls.Add(label1);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Margin = new Padding(4, 3, 4, 3);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(4, 3, 4, 3);
            tabPage1.Size = new Size(391, 434);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Home";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // materialRaisedButton2
            // 
            materialRaisedButton2.BackColor = Color.Lime;
            materialRaisedButton2.Depth = 0;
            materialRaisedButton2.FlatStyle = FlatStyle.Flat;
            materialRaisedButton2.Location = new Point(-11, 314);
            materialRaisedButton2.Margin = new Padding(4, 3, 4, 3);
            materialRaisedButton2.MouseState = MaterialSkin.MouseState.HOVER;
            materialRaisedButton2.Name = "materialRaisedButton2";
            materialRaisedButton2.Primary = false;
            materialRaisedButton2.Size = new Size(413, 59);
            materialRaisedButton2.TabIndex = 8;
            materialRaisedButton2.Text = "Connect";
            materialRaisedButton2.UseVisualStyleBackColor = false;
            materialRaisedButton2.Click += materialRaisedButton2_Click;
            // 
            // status_label
            // 
            status_label.AutoSize = true;
            status_label.Depth = 0;
            status_label.Font = new Font("Roboto", 11F, FontStyle.Regular, GraphicsUnit.Point);
            status_label.ForeColor = Color.FromArgb(222, 0, 0, 0);
            status_label.Location = new Point(68, 271);
            status_label.Margin = new Padding(4, 0, 4, 0);
            status_label.MouseState = MaterialSkin.MouseState.HOVER;
            status_label.Name = "status_label";
            status_label.Size = new Size(109, 19);
            status_label.TabIndex = 7;
            status_label.Text = "not connected!";
            // 
            // materialLabel3
            // 
            materialLabel3.AutoSize = true;
            materialLabel3.Depth = 0;
            materialLabel3.Font = new Font("Roboto", 11F, FontStyle.Regular, GraphicsUnit.Point);
            materialLabel3.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialLabel3.Location = new Point(18, 271);
            materialLabel3.Margin = new Padding(4, 0, 4, 0);
            materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel3.Name = "materialLabel3";
            materialLabel3.Size = new Size(56, 19);
            materialLabel3.TabIndex = 6;
            materialLabel3.Text = "Status:";
            // 
            // materialRaisedButton1
            // 
            materialRaisedButton1.Depth = 0;
            materialRaisedButton1.FlatStyle = FlatStyle.Flat;
            materialRaisedButton1.Location = new Point(-11, 379);
            materialRaisedButton1.Margin = new Padding(4, 3, 4, 3);
            materialRaisedButton1.MouseState = MaterialSkin.MouseState.HOVER;
            materialRaisedButton1.Name = "materialRaisedButton1";
            materialRaisedButton1.Primary = true;
            materialRaisedButton1.Size = new Size(413, 59);
            materialRaisedButton1.TabIndex = 5;
            materialRaisedButton1.Text = "GitHub";
            materialRaisedButton1.UseVisualStyleBackColor = true;
            materialRaisedButton1.Click += materialRaisedButton1_Click;
            // 
            // materialLabel2
            // 
            materialLabel2.AutoSize = true;
            materialLabel2.Depth = 0;
            materialLabel2.Font = new Font("Roboto", 11F, FontStyle.Regular, GraphicsUnit.Point);
            materialLabel2.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialLabel2.Location = new Point(18, 63);
            materialLabel2.Margin = new Padding(4, 0, 4, 0);
            materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel2.Name = "materialLabel2";
            materialLabel2.Size = new Size(290, 95);
            materialLabel2.TabIndex = 4;
            materialLabel2.Text = "This is a simple application that listens\r\nfor changes in a game of \r\nCounter-Strike: Global Offensive (CS:GO)\r\nand changes the RGB lighting of \r\nOpenRGB-compatible devices accordingly.";
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(bomb_status);
            tabPage2.Controls.Add(materialLabel4);
            tabPage2.Controls.Add(dataGridView1);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Margin = new Padding(4, 3, 4, 3);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(4, 3, 4, 3);
            tabPage2.Size = new Size(391, 434);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Vars";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // bomb_status
            // 
            bomb_status.AutoSize = true;
            bomb_status.Depth = 0;
            bomb_status.Font = new Font("Roboto", 11F, FontStyle.Regular, GraphicsUnit.Point);
            bomb_status.ForeColor = Color.FromArgb(222, 0, 0, 0);
            bomb_status.Location = new Point(53, 13);
            bomb_status.Margin = new Padding(4, 0, 4, 0);
            bomb_status.MouseState = MaterialSkin.MouseState.HOVER;
            bomb_status.Name = "bomb_status";
            bomb_status.Size = new Size(97, 19);
            bomb_status.TabIndex = 8;
            bomb_status.Text = "bomb status.";
            // 
            // materialLabel4
            // 
            materialLabel4.AutoSize = true;
            materialLabel4.Depth = 0;
            materialLabel4.Font = new Font("Roboto", 11F, FontStyle.Regular, GraphicsUnit.Point);
            materialLabel4.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialLabel4.Location = new Point(4, 13);
            materialLabel4.Margin = new Padding(4, 0, 4, 0);
            materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel4.Name = "materialLabel4";
            materialLabel4.Size = new Size(52, 19);
            materialLabel4.TabIndex = 7;
            materialLabel4.Text = "Bomb:";
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = Color.FromArgb(33, 33, 33);
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Bottom;
            dataGridView1.Location = new Point(4, 106);
            dataGridView1.Margin = new Padding(4, 3, 4, 3);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(383, 325);
            dataGridView1.TabIndex = 0;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(pictureBox3);
            tabPage3.Controls.Add(materialLabel7);
            tabPage3.Controls.Add(pictureBox2);
            tabPage3.Controls.Add(materialLabel6);
            tabPage3.Controls.Add(pictureBox1);
            tabPage3.Controls.Add(materialLabel5);
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new Size(391, 434);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Settings";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = Color.White;
            pictureBox3.Location = new Point(261, 92);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(113, 20);
            pictureBox3.TabIndex = 13;
            pictureBox3.TabStop = false;
            pictureBox3.Click += pictureBox3_Click;
            // 
            // materialLabel7
            // 
            materialLabel7.AutoSize = true;
            materialLabel7.Depth = 0;
            materialLabel7.Font = new Font("Roboto", 11F, FontStyle.Regular, GraphicsUnit.Point);
            materialLabel7.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialLabel7.Location = new Point(9, 92);
            materialLabel7.Margin = new Padding(4, 0, 4, 0);
            materialLabel7.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel7.Name = "materialLabel7";
            materialLabel7.Size = new Size(59, 19);
            materialLabel7.TabIndex = 12;
            materialLabel7.Text = "T Color";
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.White;
            pictureBox2.Location = new Point(261, 55);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(113, 20);
            pictureBox2.TabIndex = 11;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // materialLabel6
            // 
            materialLabel6.AutoSize = true;
            materialLabel6.Depth = 0;
            materialLabel6.Font = new Font("Roboto", 11F, FontStyle.Regular, GraphicsUnit.Point);
            materialLabel6.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialLabel6.Location = new Point(9, 55);
            materialLabel6.Margin = new Padding(4, 0, 4, 0);
            materialLabel6.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel6.Name = "materialLabel6";
            materialLabel6.Size = new Size(69, 19);
            materialLabel6.TabIndex = 10;
            materialLabel6.Text = "CT Color";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.White;
            pictureBox1.Location = new Point(261, 20);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(113, 20);
            pictureBox1.TabIndex = 9;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // materialLabel5
            // 
            materialLabel5.AutoSize = true;
            materialLabel5.Depth = 0;
            materialLabel5.Font = new Font("Roboto", 11F, FontStyle.Regular, GraphicsUnit.Point);
            materialLabel5.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialLabel5.Location = new Point(9, 20);
            materialLabel5.Margin = new Padding(4, 0, 4, 0);
            materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel5.Name = "materialLabel5";
            materialLabel5.Size = new Size(87, 19);
            materialLabel5.TabIndex = 8;
            materialLabel5.Text = "Menu Color";
            // 
            // materialTabSelector1
            // 
            materialTabSelector1.BaseTabControl = materialTabControl1;
            materialTabSelector1.Depth = 0;
            materialTabSelector1.Location = new Point(-7, 63);
            materialTabSelector1.Margin = new Padding(4, 3, 4, 3);
            materialTabSelector1.MouseState = MaterialSkin.MouseState.HOVER;
            materialTabSelector1.Name = "materialTabSelector1";
            materialTabSelector1.Size = new Size(413, 52);
            materialTabSelector1.TabIndex = 5;
            materialTabSelector1.Text = "materialTabSelector1";
            // 
            // textUpd
            // 
            textUpd.Interval = 250;
            textUpd.Tick += textUpd_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(399, 576);
            Controls.Add(materialTabSelector1);
            Controls.Add(materialTabControl1);
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "Form1";
            Sizable = false;
            Text = "csApp";
            materialTabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private System.Windows.Forms.Label label1;
        private MaterialSkin.Controls.MaterialTabControl materialTabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private MaterialSkin.Controls.MaterialTabSelector materialTabSelector1;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialRaisedButton materialRaisedButton1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private MaterialSkin.Controls.MaterialRaisedButton materialRaisedButton2;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        public MaterialSkin.Controls.MaterialLabel status_label;
        private TabPage tabPage3;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private MaterialSkin.Controls.MaterialLabel bomb_status;
        private PictureBox pictureBox1;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
        private PictureBox pictureBox2;
        private MaterialSkin.Controls.MaterialLabel materialLabel6;
        private PictureBox pictureBox3;
        private MaterialSkin.Controls.MaterialLabel materialLabel7;
        private System.Windows.Forms.Timer textUpd;
    }
}