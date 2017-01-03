namespace PCB_Documenter
{
    partial class Form1
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
            this.cBoxName = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPhoneOffice = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPCBTitle = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPCBPartNumber = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtRevision = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtX = new System.Windows.Forms.TextBox();
            this.txtY = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cBoxLayers = new System.Windows.Forms.ComboBox();
            this.cBoxPCBThickness = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtPhoneCell = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.buttonSelectInputFolder = new System.Windows.Forms.Button();
            this.txtInputDirectory = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtOutputDirectory = new System.Windows.Forms.TextBox();
            this.buttonSelectOutputFolder = new System.Windows.Forms.Button();
            this.buttonBack = new System.Windows.Forms.Button();
            this.buttonNext = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.buttonInclude = new System.Windows.Forms.Button();
            this.listViewExclude = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.buttonExclude = new System.Windows.Forms.Button();
            this.listViewInclude = new System.Windows.Forms.ListView();
            this.FileName = new System.Windows.Forms.ColumnHeader();
            this.Directory = new System.Windows.Forms.ColumnHeader();
            this.Description = new System.Windows.Forms.ColumnHeader();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.buttonGenerate = new System.Windows.Forms.Button();
            this.buttonMoveRowDown = new System.Windows.Forms.Button();
            this.buttonMoveRowUp = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exiitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cBoxName
            // 
            this.cBoxName.FormattingEnabled = true;
            this.cBoxName.Items.AddRange(new object[] {
            "Tom Schneider",
            "Nik Shaffer",
            "Jerry Joseph"});
            this.cBoxName.Location = new System.Drawing.Point(85, 35);
            this.cBoxName.Name = "cBoxName";
            this.cBoxName.Size = new System.Drawing.Size(121, 21);
            this.cBoxName.TabIndex = 0;
            this.cBoxName.SelectedIndexChanged += new System.EventHandler(this.cBoxName_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name";
            // 
            // txtPhoneOffice
            // 
            this.txtPhoneOffice.Location = new System.Drawing.Point(85, 63);
            this.txtPhoneOffice.Name = "txtPhoneOffice";
            this.txtPhoneOffice.Size = new System.Drawing.Size(121, 20);
            this.txtPhoneOffice.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Phone (office)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Email";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(85, 117);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(121, 20);
            this.txtEmail.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(124, 159);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "PCB Title";
            // 
            // txtPCBTitle
            // 
            this.txtPCBTitle.Location = new System.Drawing.Point(184, 152);
            this.txtPCBTitle.Name = "txtPCBTitle";
            this.txtPCBTitle.Size = new System.Drawing.Size(121, 20);
            this.txtPCBTitle.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(118, 185);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "PCB Part #";
            // 
            // txtPCBPartNumber
            // 
            this.txtPCBPartNumber.Location = new System.Drawing.Point(184, 178);
            this.txtPCBPartNumber.Name = "txtPCBPartNumber";
            this.txtPCBPartNumber.Size = new System.Drawing.Size(121, 20);
            this.txtPCBPartNumber.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(106, 211);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "PCB Revision";
            // 
            // txtRevision
            // 
            this.txtRevision.Location = new System.Drawing.Point(184, 204);
            this.txtRevision.Name = "txtRevision";
            this.txtRevision.Size = new System.Drawing.Size(121, 20);
            this.txtRevision.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(250, 44);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Dimensions";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(332, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(14, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "X";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(374, 21);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(14, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "Y";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(408, 21);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 13);
            this.label10.TabIndex = 15;
            this.label10.Text = "Thickness";
            // 
            // txtX
            // 
            this.txtX.Location = new System.Drawing.Point(317, 37);
            this.txtX.Name = "txtX";
            this.txtX.Size = new System.Drawing.Size(40, 20);
            this.txtX.TabIndex = 16;
            // 
            // txtY
            // 
            this.txtY.Location = new System.Drawing.Point(362, 37);
            this.txtY.Name = "txtY";
            this.txtY.Size = new System.Drawing.Size(40, 20);
            this.txtY.TabIndex = 17;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(247, 74);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(64, 13);
            this.label12.TabIndex = 21;
            this.label12.Text = "Layer Count";
            // 
            // cBoxLayers
            // 
            this.cBoxLayers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxLayers.FormattingEnabled = true;
            this.cBoxLayers.Items.AddRange(new object[] {
            "2",
            "4",
            "6",
            "8",
            "10",
            "12",
            "14",
            "16"});
            this.cBoxLayers.Location = new System.Drawing.Point(317, 66);
            this.cBoxLayers.Name = "cBoxLayers";
            this.cBoxLayers.Size = new System.Drawing.Size(54, 21);
            this.cBoxLayers.TabIndex = 27;
            // 
            // cBoxPCBThickness
            // 
            this.cBoxPCBThickness.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxPCBThickness.FormattingEnabled = true;
            this.cBoxPCBThickness.Items.AddRange(new object[] {
            "0.031\"",
            "0.063\"",
            "0.093\"",
            "0.125\""});
            this.cBoxPCBThickness.Location = new System.Drawing.Point(408, 38);
            this.cBoxPCBThickness.Name = "cBoxPCBThickness";
            this.cBoxPCBThickness.Size = new System.Drawing.Size(56, 21);
            this.cBoxPCBThickness.TabIndex = 28;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(17, 94);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(63, 13);
            this.label18.TabIndex = 33;
            this.label18.Text = "Phone (cell)";
            // 
            // txtPhoneCell
            // 
            this.txtPhoneCell.Location = new System.Drawing.Point(85, 91);
            this.txtPhoneCell.Name = "txtPhoneCell";
            this.txtPhoneCell.Size = new System.Drawing.Size(121, 20);
            this.txtPhoneCell.TabIndex = 32;
            // 
            // buttonSelectInputFolder
            // 
            this.buttonSelectInputFolder.Location = new System.Drawing.Point(22, 236);
            this.buttonSelectInputFolder.Name = "buttonSelectInputFolder";
            this.buttonSelectInputFolder.Size = new System.Drawing.Size(90, 39);
            this.buttonSelectInputFolder.TabIndex = 34;
            this.buttonSelectInputFolder.Text = "Select Input Folder";
            this.buttonSelectInputFolder.UseVisualStyleBackColor = true;
            this.buttonSelectInputFolder.Click += new System.EventHandler(this.buttonSelectInputFolder_Click);
            // 
            // txtInputDirectory
            // 
            this.txtInputDirectory.Location = new System.Drawing.Point(127, 247);
            this.txtInputDirectory.Name = "txtInputDirectory";
            this.txtInputDirectory.Size = new System.Drawing.Size(324, 20);
            this.txtInputDirectory.TabIndex = 35;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtOutputDirectory);
            this.groupBox1.Controls.Add(this.buttonSelectOutputFolder);
            this.groupBox1.Controls.Add(this.txtInputDirectory);
            this.groupBox1.Controls.Add(this.cBoxName);
            this.groupBox1.Controls.Add(this.buttonSelectInputFolder);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.txtPhoneOffice);
            this.groupBox1.Controls.Add(this.txtPhoneCell);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtEmail);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtPCBTitle);
            this.groupBox1.Controls.Add(this.cBoxPCBThickness);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cBoxLayers);
            this.groupBox1.Controls.Add(this.txtPCBPartNumber);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtRevision);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.txtX);
            this.groupBox1.Controls.Add(this.txtY);
            this.groupBox1.Location = new System.Drawing.Point(12, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(547, 329);
            this.groupBox1.TabIndex = 36;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Screen #1";
            // 
            // txtOutputDirectory
            // 
            this.txtOutputDirectory.Location = new System.Drawing.Point(127, 295);
            this.txtOutputDirectory.Name = "txtOutputDirectory";
            this.txtOutputDirectory.Size = new System.Drawing.Size(324, 20);
            this.txtOutputDirectory.TabIndex = 37;
            // 
            // buttonSelectOutputFolder
            // 
            this.buttonSelectOutputFolder.Location = new System.Drawing.Point(22, 284);
            this.buttonSelectOutputFolder.Name = "buttonSelectOutputFolder";
            this.buttonSelectOutputFolder.Size = new System.Drawing.Size(90, 39);
            this.buttonSelectOutputFolder.TabIndex = 36;
            this.buttonSelectOutputFolder.Text = "Select Output Folder";
            this.buttonSelectOutputFolder.UseVisualStyleBackColor = true;
            this.buttonSelectOutputFolder.Click += new System.EventHandler(this.buttonSelectOutputFolder_Click);
            // 
            // buttonBack
            // 
            this.buttonBack.Enabled = false;
            this.buttonBack.Location = new System.Drawing.Point(139, 378);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(75, 23);
            this.buttonBack.TabIndex = 37;
            this.buttonBack.Text = "Back";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // buttonNext
            // 
            this.buttonNext.Location = new System.Drawing.Point(329, 378);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(75, 23);
            this.buttonNext.TabIndex = 38;
            this.buttonNext.Text = "Next";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.buttonInclude);
            this.groupBox2.Controls.Add(this.listViewExclude);
            this.groupBox2.Controls.Add(this.buttonExclude);
            this.groupBox2.Controls.Add(this.listViewInclude);
            this.groupBox2.Location = new System.Drawing.Point(12, 34);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(547, 329);
            this.groupBox2.TabIndex = 37;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Screen #2";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(25, 172);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(96, 16);
            this.label17.TabIndex = 5;
            this.label17.Text = "Excluded Files";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(25, 22);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(91, 16);
            this.label19.TabIndex = 4;
            this.label19.Text = "Included Files";
            // 
            // buttonInclude
            // 
            this.buttonInclude.Location = new System.Drawing.Point(283, 162);
            this.buttonInclude.Name = "buttonInclude";
            this.buttonInclude.Size = new System.Drawing.Size(75, 23);
            this.buttonInclude.TabIndex = 3;
            this.buttonInclude.Text = "Include";
            this.buttonInclude.UseVisualStyleBackColor = true;
            this.buttonInclude.Click += new System.EventHandler(this.buttonInclude_Click);
            // 
            // listViewExclude
            // 
            this.listViewExclude.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.listViewExclude.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listViewExclude.FullRowSelect = true;
            this.listViewExclude.GridLines = true;
            this.listViewExclude.Location = new System.Drawing.Point(20, 191);
            this.listViewExclude.Name = "listViewExclude";
            this.listViewExclude.Size = new System.Drawing.Size(507, 132);
            this.listViewExclude.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listViewExclude.TabIndex = 2;
            this.listViewExclude.UseCompatibleStateImageBehavior = false;
            this.listViewExclude.View = System.Windows.Forms.View.Details;
            this.listViewExclude.DoubleClick += new System.EventHandler(this.listViewExclude_DoubleClick);
            this.listViewExclude.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listViewExclude_KeyDown);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "FileName";
            this.columnHeader1.Width = 79;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Directory";
            this.columnHeader2.Width = 194;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Description";
            this.columnHeader3.Width = 218;
            // 
            // buttonExclude
            // 
            this.buttonExclude.Location = new System.Drawing.Point(148, 162);
            this.buttonExclude.Name = "buttonExclude";
            this.buttonExclude.Size = new System.Drawing.Size(75, 23);
            this.buttonExclude.TabIndex = 1;
            this.buttonExclude.Text = "Exclude";
            this.buttonExclude.UseVisualStyleBackColor = true;
            this.buttonExclude.Click += new System.EventHandler(this.buttonExclude_Click);
            // 
            // listViewInclude
            // 
            this.listViewInclude.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.listViewInclude.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.FileName,
            this.Directory,
            this.Description});
            this.listViewInclude.FullRowSelect = true;
            this.listViewInclude.GridLines = true;
            this.listViewInclude.Location = new System.Drawing.Point(20, 41);
            this.listViewInclude.Name = "listViewInclude";
            this.listViewInclude.Size = new System.Drawing.Size(507, 115);
            this.listViewInclude.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listViewInclude.TabIndex = 0;
            this.listViewInclude.UseCompatibleStateImageBehavior = false;
            this.listViewInclude.View = System.Windows.Forms.View.Details;
            this.listViewInclude.DoubleClick += new System.EventHandler(this.listViewInclude_DoubleClick);
            this.listViewInclude.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listViewInclude_KeyDown);
            // 
            // FileName
            // 
            this.FileName.Text = "FileName";
            this.FileName.Width = 79;
            // 
            // Directory
            // 
            this.Directory.Text = "Directory";
            this.Directory.Width = 194;
            // 
            // Description
            // 
            this.Description.Text = "Description";
            this.Description.Width = 218;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.buttonGenerate);
            this.groupBox3.Controls.Add(this.buttonMoveRowDown);
            this.groupBox3.Controls.Add(this.buttonMoveRowUp);
            this.groupBox3.Controls.Add(this.dataGridView1);
            this.groupBox3.Location = new System.Drawing.Point(12, 34);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(547, 329);
            this.groupBox3.TabIndex = 38;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Screen #3";
            // 
            // buttonGenerate
            // 
            this.buttonGenerate.Location = new System.Drawing.Point(409, 273);
            this.buttonGenerate.Name = "buttonGenerate";
            this.buttonGenerate.Size = new System.Drawing.Size(98, 44);
            this.buttonGenerate.TabIndex = 3;
            this.buttonGenerate.Text = "Generate Documentation";
            this.buttonGenerate.UseVisualStyleBackColor = true;
            this.buttonGenerate.Click += new System.EventHandler(this.buttonGenerate_Click);
            // 
            // buttonMoveRowDown
            // 
            this.buttonMoveRowDown.Location = new System.Drawing.Point(37, 299);
            this.buttonMoveRowDown.Name = "buttonMoveRowDown";
            this.buttonMoveRowDown.Size = new System.Drawing.Size(104, 23);
            this.buttonMoveRowDown.TabIndex = 2;
            this.buttonMoveRowDown.Text = "Move Row Down";
            this.buttonMoveRowDown.UseVisualStyleBackColor = true;
            this.buttonMoveRowDown.Click += new System.EventHandler(this.buttonMoveRowDown_Click);
            // 
            // buttonMoveRowUp
            // 
            this.buttonMoveRowUp.Location = new System.Drawing.Point(37, 270);
            this.buttonMoveRowUp.Name = "buttonMoveRowUp";
            this.buttonMoveRowUp.Size = new System.Drawing.Size(104, 23);
            this.buttonMoveRowUp.TabIndex = 1;
            this.buttonMoveRowUp.Text = "Move Row Up";
            this.buttonMoveRowUp.UseVisualStyleBackColor = true;
            this.buttonMoveRowUp.Click += new System.EventHandler(this.buttonMoveRowUp_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(37, 39);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(470, 218);
            this.dataGridView1.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(589, 24);
            this.menuStrip1.TabIndex = 39;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.exiitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.openToolStripMenuItem.Text = "Open...";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.saveToolStripMenuItem.Text = "Save...";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // exiitToolStripMenuItem
            // 
            this.exiitToolStripMenuItem.Name = "exiitToolStripMenuItem";
            this.exiitToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.exiitToolStripMenuItem.Text = "Exit";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem1});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.aboutToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem1
            // 
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(116, 22);
            this.aboutToolStripMenuItem1.Text = "About...";
            this.aboutToolStripMenuItem1.Click += new System.EventHandler(this.aboutToolStripMenuItem1_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "xml";
            this.saveFileDialog1.Filter = "XML files (*.xml|*.xml";
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "xml";
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "XML files (*.xml|*.xml";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 413);
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "PCB Document Creator";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cBoxName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPhoneOffice;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPCBTitle;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPCBPartNumber;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtRevision;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtX;
        private System.Windows.Forms.TextBox txtY;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cBoxLayers;
        private System.Windows.Forms.ComboBox cBoxPCBThickness;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtPhoneCell;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button buttonSelectInputFolder;
        private System.Windows.Forms.TextBox txtInputDirectory;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button buttonInclude;
        private System.Windows.Forms.ListView listViewExclude;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button buttonExclude;
        private System.Windows.Forms.ListView listViewInclude;
        private System.Windows.Forms.ColumnHeader FileName;
        private System.Windows.Forms.ColumnHeader Directory;
        private System.Windows.Forms.ColumnHeader Description;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonMoveRowDown;
        private System.Windows.Forms.Button buttonMoveRowUp;
        private System.Windows.Forms.Button buttonGenerate;
        private System.Windows.Forms.TextBox txtOutputDirectory;
        private System.Windows.Forms.Button buttonSelectOutputFolder;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exiitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

