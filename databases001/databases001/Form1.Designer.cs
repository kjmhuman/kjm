namespace databases001
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
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("ListViewGroup", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("ListViewGroup", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("ListViewGroup", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup4 = new System.Windows.Forms.ListViewGroup("ListViewGroup", System.Windows.Forms.HorizontalAlignment.Left);
            this.primary_la = new System.Windows.Forms.Label();
            this.name_la = new System.Windows.Forms.Label();
            this.insert_bt = new System.Windows.Forms.Button();
            this.update_bt = new System.Windows.Forms.Button();
            this.name_txt = new System.Windows.Forms.TextBox();
            this.primary_txt = new System.Windows.Forms.TextBox();
            this.humen_la = new System.Windows.Forms.Label();
            this.date_la = new System.Windows.Forms.Label();
            this.Author_txt = new System.Windows.Forms.TextBox();
            this.date_txt = new System.Windows.Forms.TextBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.primary_co = new System.Windows.Forms.ColumnHeader();
            this.name_co = new System.Windows.Forms.ColumnHeader();
            this.humen_co = new System.Windows.Forms.ColumnHeader();
            this.date_co = new System.Windows.Forms.ColumnHeader();
            this.button3 = new System.Windows.Forms.Button();
            this.ip_txt = new System.Windows.Forms.TextBox();
            this.server_txt = new System.Windows.Forms.TextBox();
            this.con_bt = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // primary_la
            // 
            this.primary_la.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.primary_la.Location = new System.Drawing.Point(21, 31);
            this.primary_la.Name = "primary_la";
            this.primary_la.Size = new System.Drawing.Size(59, 21);
            this.primary_la.TabIndex = 0;
            this.primary_la.Text = "ISBN";
            this.primary_la.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // name_la
            // 
            this.name_la.AutoSize = true;
            this.name_la.Location = new System.Drawing.Point(41, 63);
            this.name_la.Name = "name_la";
            this.name_la.Size = new System.Drawing.Size(39, 15);
            this.name_la.TabIndex = 1;
            this.name_la.Text = "Name";
            // 
            // insert_bt
            // 
            this.insert_bt.Location = new System.Drawing.Point(263, 31);
            this.insert_bt.Name = "insert_bt";
            this.insert_bt.Size = new System.Drawing.Size(79, 41);
            this.insert_bt.TabIndex = 2;
            this.insert_bt.Text = "입력";
            this.insert_bt.UseVisualStyleBackColor = true;
            this.insert_bt.Click += new System.EventHandler(this.insert_bt_Click);
            // 
            // update_bt
            // 
            this.update_bt.Location = new System.Drawing.Point(356, 31);
            this.update_bt.Name = "update_bt";
            this.update_bt.Size = new System.Drawing.Size(81, 41);
            this.update_bt.TabIndex = 3;
            this.update_bt.Text = "수정";
            this.update_bt.UseVisualStyleBackColor = true;
            this.update_bt.Click += new System.EventHandler(this.update_bt_Click);
            // 
            // name_txt
            // 
            this.name_txt.Location = new System.Drawing.Point(79, 60);
            this.name_txt.Name = "name_txt";
            this.name_txt.Size = new System.Drawing.Size(155, 23);
            this.name_txt.TabIndex = 6;
            // 
            // primary_txt
            // 
            this.primary_txt.Location = new System.Drawing.Point(79, 31);
            this.primary_txt.Name = "primary_txt";
            this.primary_txt.Size = new System.Drawing.Size(155, 23);
            this.primary_txt.TabIndex = 5;
            // 
            // humen_la
            // 
            this.humen_la.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.humen_la.Location = new System.Drawing.Point(21, 93);
            this.humen_la.Name = "humen_la";
            this.humen_la.Size = new System.Drawing.Size(59, 18);
            this.humen_la.TabIndex = 7;
            this.humen_la.Text = "Author";
            this.humen_la.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // date_la
            // 
            this.date_la.AutoSize = true;
            this.date_la.Location = new System.Drawing.Point(48, 121);
            this.date_la.Name = "date_la";
            this.date_la.Size = new System.Drawing.Size(32, 15);
            this.date_la.TabIndex = 8;
            this.date_la.Text = "Date";
            // 
            // Author_txt
            // 
            this.Author_txt.Location = new System.Drawing.Point(79, 89);
            this.Author_txt.Name = "Author_txt";
            this.Author_txt.Size = new System.Drawing.Size(155, 23);
            this.Author_txt.TabIndex = 9;
            // 
            // date_txt
            // 
            this.date_txt.Location = new System.Drawing.Point(79, 118);
            this.date_txt.Name = "date_txt";
            this.date_txt.Size = new System.Drawing.Size(155, 23);
            this.date_txt.TabIndex = 10;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.primary_co,
            this.name_co,
            this.humen_co,
            this.date_co});
            listViewGroup1.Header = "ListViewGroup";
            listViewGroup1.Name = "listViewGroup1";
            listViewGroup2.Header = "ListViewGroup";
            listViewGroup2.Name = "listViewGroup2";
            listViewGroup3.Header = "ListViewGroup";
            listViewGroup3.Name = "listViewGroup3";
            listViewGroup4.Header = "ListViewGroup";
            listViewGroup4.Name = "listViewGroup4";
            this.listView1.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2,
            listViewGroup3,
            listViewGroup4});
            this.listView1.Location = new System.Drawing.Point(20, 160);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(484, 184);
            this.listView1.TabIndex = 11;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView1_ColumnClick);
            this.listView1.Click += new System.EventHandler(this.list_MouseClick);
            // 
            // primary_co
            // 
            this.primary_co.Text = "ISBN";
            this.primary_co.Width = 100;
            // 
            // name_co
            // 
            this.name_co.Text = "Name";
            this.name_co.Width = 100;
            // 
            // humen_co
            // 
            this.humen_co.Text = "Author";
            this.humen_co.Width = 100;
            // 
            // date_co
            // 
            this.date_co.Text = "Date";
            this.date_co.Width = 100;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(263, 89);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(174, 23);
            this.button3.TabIndex = 12;
            this.button3.Text = "BOOK/CAR";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // ip_txt
            // 
            this.ip_txt.Location = new System.Drawing.Point(20, 501);
            this.ip_txt.Name = "ip_txt";
            this.ip_txt.Size = new System.Drawing.Size(373, 23);
            this.ip_txt.TabIndex = 13;
            this.ip_txt.Text = "192.168.201.73";
            // 
            // server_txt
            // 
            this.server_txt.Location = new System.Drawing.Point(20, 376);
            this.server_txt.Multiline = true;
            this.server_txt.Name = "server_txt";
            this.server_txt.ReadOnly = true;
            this.server_txt.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.server_txt.Size = new System.Drawing.Size(484, 105);
            this.server_txt.TabIndex = 14;
            // 
            // con_bt
            // 
            this.con_bt.Location = new System.Drawing.Point(410, 501);
            this.con_bt.Name = "con_bt";
            this.con_bt.Size = new System.Drawing.Size(94, 23);
            this.con_bt.TabIndex = 15;
            this.con_bt.Text = "연결";
            this.con_bt.UseVisualStyleBackColor = true;
            this.con_bt.Click += new System.EventHandler(this.con_bt_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(263, 118);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(174, 23);
            this.button1.TabIndex = 16;
            this.button1.Text = "새로고침";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(527, 543);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.con_bt);
            this.Controls.Add(this.server_txt);
            this.Controls.Add(this.ip_txt);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.date_txt);
            this.Controls.Add(this.Author_txt);
            this.Controls.Add(this.date_la);
            this.Controls.Add(this.humen_la);
            this.Controls.Add(this.primary_txt);
            this.Controls.Add(this.name_txt);
            this.Controls.Add(this.update_bt);
            this.Controls.Add(this.insert_bt);
            this.Controls.Add(this.name_la);
            this.Controls.Add(this.primary_la);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label primary_la;
        private Label name_la;
        private Button insert_bt;
        private Button update_bt;
        private TextBox name_txt;
        private TextBox primary_txt;
        private Label humen_la;
        private Label date_la;
        private TextBox Author_txt;
        private TextBox date_txt;
        private ListView listView1;
        private Button button3;
        private ColumnHeader primary_co;
        private ColumnHeader name_co;
        private ColumnHeader humen_co;
        private ColumnHeader date_co;
        private TextBox ip_txt;
        private TextBox server_txt;
        private Button con_bt;
        private Button button1;
    }
}