namespace WeeklyPlanner2
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
            this.lblLayoutType = new System.Windows.Forms.Label();
            this.cBLayoutType = new System.Windows.Forms.ComboBox();
            this.tBTaskHeight = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tBTaskOffset = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tBRoleWidthToPoint = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tBRoleWidthToEdge = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.tBRoleLineWidth = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.tBRoleHeight = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.tBRoleTaskOverlap = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.tBTaskHeadingHeight = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.tBTaskHeadingOffset = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnClearEvents = new System.Windows.Forms.Button();
            this.chBLinesOnHour = new System.Windows.Forms.CheckBox();
            this.btnInputEvent = new System.Windows.Forms.Button();
            this.cBWeekly = new System.Windows.Forms.ComboBox();
            this.cBEndTime = new System.Windows.Forms.ComboBox();
            this.cBStartTime = new System.Windows.Forms.ComboBox();
            this.dTPEventDate = new System.Windows.Forms.DateTimePicker();
            this.tBEventName = new System.Windows.Forms.TextBox();
            this.dGVEvents = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblEndWeek = new System.Windows.Forms.Label();
            this.lblStartWeek = new System.Windows.Forms.Label();
            this.dTPEndWeek = new System.Windows.Forms.DateTimePicker();
            this.dTPStartWeek = new System.Windows.Forms.DateTimePicker();
            this.btnCreate = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tBDayAboveOffset = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.tBWeekendOffset = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.tBBorderOffset = new System.Windows.Forms.TextBox();
            this.tBSpineOffset = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tBHourWidth = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tBTaskNoteOffset = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tBPageWidth = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tBPageHeight = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tBFontMultiplier = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tBThinLineweight = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tBThickLineweight = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tBDPI = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVEvents)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblLayoutType
            // 
            this.lblLayoutType.AutoSize = true;
            this.lblLayoutType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLayoutType.Location = new System.Drawing.Point(94, 9);
            this.lblLayoutType.Name = "lblLayoutType";
            this.lblLayoutType.Size = new System.Drawing.Size(95, 20);
            this.lblLayoutType.TabIndex = 41;
            this.lblLayoutType.Text = "Layout Type";
            // 
            // cBLayoutType
            // 
            this.cBLayoutType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cBLayoutType.FormattingEnabled = true;
            this.cBLayoutType.Items.AddRange(new object[] {
            "Separation",
            "No Separation"});
            this.cBLayoutType.Location = new System.Drawing.Point(197, 6);
            this.cBLayoutType.Name = "cBLayoutType";
            this.cBLayoutType.Size = new System.Drawing.Size(205, 28);
            this.cBLayoutType.TabIndex = 40;
            this.cBLayoutType.SelectedIndexChanged += new System.EventHandler(this.cBLayoutType_SelectedIndexChanged);
            // 
            // tBTaskHeight
            // 
            this.tBTaskHeight.Location = new System.Drawing.Point(380, 273);
            this.tBTaskHeight.Name = "tBTaskHeight";
            this.tBTaskHeight.Size = new System.Drawing.Size(69, 20);
            this.tBTaskHeight.TabIndex = 39;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(231, 276);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(90, 13);
            this.label11.TabIndex = 38;
            this.label11.Text = "Task Height (mm)";
            // 
            // tBTaskOffset
            // 
            this.tBTaskOffset.Location = new System.Drawing.Point(380, 247);
            this.tBTaskOffset.Name = "tBTaskOffset";
            this.tBTaskOffset.Size = new System.Drawing.Size(69, 20);
            this.tBTaskOffset.TabIndex = 37;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(231, 250);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(87, 13);
            this.label12.TabIndex = 36;
            this.label12.Text = "Task Offset (mm)";
            // 
            // tBRoleWidthToPoint
            // 
            this.tBRoleWidthToPoint.Location = new System.Drawing.Point(380, 221);
            this.tBRoleWidthToPoint.Name = "tBRoleWidthToPoint";
            this.tBRoleWidthToPoint.Size = new System.Drawing.Size(69, 20);
            this.tBRoleWidthToPoint.TabIndex = 35;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(231, 224);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(142, 13);
            this.label13.TabIndex = 34;
            this.label13.Text = "Role Width to the Point (mm)";
            // 
            // tBRoleWidthToEdge
            // 
            this.tBRoleWidthToEdge.Location = new System.Drawing.Point(380, 195);
            this.tBRoleWidthToEdge.Name = "tBRoleWidthToEdge";
            this.tBRoleWidthToEdge.Size = new System.Drawing.Size(69, 20);
            this.tBRoleWidthToEdge.TabIndex = 33;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(231, 198);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(143, 13);
            this.label14.TabIndex = 32;
            this.label14.Text = "Role Width to the Edge (mm)";
            // 
            // tBRoleLineWidth
            // 
            this.tBRoleLineWidth.Location = new System.Drawing.Point(380, 169);
            this.tBRoleLineWidth.Name = "tBRoleLineWidth";
            this.tBRoleLineWidth.Size = new System.Drawing.Size(69, 20);
            this.tBRoleLineWidth.TabIndex = 31;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(231, 172);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(108, 13);
            this.label15.TabIndex = 30;
            this.label15.Text = "Role Line Width (mm)";
            // 
            // tBRoleHeight
            // 
            this.tBRoleHeight.Location = new System.Drawing.Point(380, 143);
            this.tBRoleHeight.Name = "tBRoleHeight";
            this.tBRoleHeight.Size = new System.Drawing.Size(69, 20);
            this.tBRoleHeight.TabIndex = 29;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(231, 146);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(88, 13);
            this.label16.TabIndex = 28;
            this.label16.Text = "Role Height (mm)";
            // 
            // tBRoleTaskOverlap
            // 
            this.tBRoleTaskOverlap.Location = new System.Drawing.Point(380, 117);
            this.tBRoleTaskOverlap.Name = "tBRoleTaskOverlap";
            this.tBRoleTaskOverlap.Size = new System.Drawing.Size(69, 20);
            this.tBRoleTaskOverlap.TabIndex = 25;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(231, 120);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(121, 13);
            this.label18.TabIndex = 24;
            this.label18.Text = "Role Task Overlap (mm)";
            // 
            // tBTaskHeadingHeight
            // 
            this.tBTaskHeadingHeight.Location = new System.Drawing.Point(380, 91);
            this.tBTaskHeadingHeight.Name = "tBTaskHeadingHeight";
            this.tBTaskHeadingHeight.Size = new System.Drawing.Size(69, 20);
            this.tBTaskHeadingHeight.TabIndex = 23;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(231, 94);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(133, 13);
            this.label19.TabIndex = 22;
            this.label19.Text = "Task Heading Height (mm)";
            // 
            // tBTaskHeadingOffset
            // 
            this.tBTaskHeadingOffset.Location = new System.Drawing.Point(380, 65);
            this.tBTaskHeadingOffset.Name = "tBTaskHeadingOffset";
            this.tBTaskHeadingOffset.Size = new System.Drawing.Size(69, 20);
            this.tBTaskHeadingOffset.TabIndex = 21;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(231, 68);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(130, 13);
            this.label20.TabIndex = 20;
            this.label20.Text = "Task Heading Offset (mm)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 302);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Border Offset (mm)";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(533, 571);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.btnClearEvents);
            this.tabPage1.Controls.Add(this.chBLinesOnHour);
            this.tabPage1.Controls.Add(this.btnInputEvent);
            this.tabPage1.Controls.Add(this.cBWeekly);
            this.tabPage1.Controls.Add(this.cBEndTime);
            this.tabPage1.Controls.Add(this.cBStartTime);
            this.tabPage1.Controls.Add(this.dTPEventDate);
            this.tabPage1.Controls.Add(this.tBEventName);
            this.tabPage1.Controls.Add(this.dGVEvents);
            this.tabPage1.Controls.Add(this.lblEndWeek);
            this.tabPage1.Controls.Add(this.lblStartWeek);
            this.tabPage1.Controls.Add(this.dTPEndWeek);
            this.tabPage1.Controls.Add(this.dTPStartWeek);
            this.tabPage1.Controls.Add(this.btnCreate);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(525, 545);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Main";
            // 
            // btnClearEvents
            // 
            this.btnClearEvents.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearEvents.Location = new System.Drawing.Point(8, 197);
            this.btnClearEvents.Name = "btnClearEvents";
            this.btnClearEvents.Size = new System.Drawing.Size(153, 49);
            this.btnClearEvents.TabIndex = 37;
            this.btnClearEvents.Text = "Clear Events";
            this.btnClearEvents.UseVisualStyleBackColor = true;
            this.btnClearEvents.Click += new System.EventHandler(this.btnClearEvents_Click);
            // 
            // chBLinesOnHour
            // 
            this.chBLinesOnHour.AutoSize = true;
            this.chBLinesOnHour.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chBLinesOnHour.Location = new System.Drawing.Point(207, 58);
            this.chBLinesOnHour.Name = "chBLinesOnHour";
            this.chBLinesOnHour.Size = new System.Drawing.Size(135, 24);
            this.chBLinesOnHour.TabIndex = 36;
            this.chBLinesOnHour.Text = "Lines on Hours";
            this.chBLinesOnHour.UseVisualStyleBackColor = true;
            // 
            // btnInputEvent
            // 
            this.btnInputEvent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInputEvent.Location = new System.Drawing.Point(234, 196);
            this.btnInputEvent.Name = "btnInputEvent";
            this.btnInputEvent.Size = new System.Drawing.Size(153, 49);
            this.btnInputEvent.TabIndex = 35;
            this.btnInputEvent.Text = "Input Event";
            this.btnInputEvent.UseVisualStyleBackColor = true;
            this.btnInputEvent.Click += new System.EventHandler(this.btnInputEvent_Click);
            // 
            // cBWeekly
            // 
            this.cBWeekly.FormattingEnabled = true;
            this.cBWeekly.Items.AddRange(new object[] {
            "Yes",
            "No"});
            this.cBWeekly.Location = new System.Drawing.Point(393, 224);
            this.cBWeekly.Name = "cBWeekly";
            this.cBWeekly.Size = new System.Drawing.Size(104, 21);
            this.cBWeekly.TabIndex = 34;
            this.cBWeekly.Text = "No";
            // 
            // cBEndTime
            // 
            this.cBEndTime.FormattingEnabled = true;
            this.cBEndTime.Location = new System.Drawing.Point(393, 197);
            this.cBEndTime.Name = "cBEndTime";
            this.cBEndTime.Size = new System.Drawing.Size(104, 21);
            this.cBEndTime.TabIndex = 33;
            this.cBEndTime.Text = "8:30";
            // 
            // cBStartTime
            // 
            this.cBStartTime.FormattingEnabled = true;
            this.cBStartTime.Location = new System.Drawing.Point(393, 170);
            this.cBStartTime.Name = "cBStartTime";
            this.cBStartTime.Size = new System.Drawing.Size(104, 21);
            this.cBStartTime.TabIndex = 32;
            this.cBStartTime.Text = "7:30";
            // 
            // dTPEventDate
            // 
            this.dTPEventDate.Location = new System.Drawing.Point(393, 144);
            this.dTPEventDate.Name = "dTPEventDate";
            this.dTPEventDate.Size = new System.Drawing.Size(104, 20);
            this.dTPEventDate.TabIndex = 31;
            // 
            // tBEventName
            // 
            this.tBEventName.Location = new System.Drawing.Point(393, 118);
            this.tBEventName.Name = "tBEventName";
            this.tBEventName.Size = new System.Drawing.Size(104, 20);
            this.tBEventName.TabIndex = 30;
            this.tBEventName.Text = "Stuff";
            // 
            // dGVEvents
            // 
            this.dGVEvents.AllowUserToAddRows = false;
            this.dGVEvents.AllowUserToDeleteRows = false;
            this.dGVEvents.AllowUserToResizeColumns = false;
            this.dGVEvents.AllowUserToResizeRows = false;
            this.dGVEvents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVEvents.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column5,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dGVEvents.Location = new System.Drawing.Point(8, 251);
            this.dGVEvents.Name = "dGVEvents";
            this.dGVEvents.ReadOnly = true;
            this.dGVEvents.RowHeadersVisible = false;
            this.dGVEvents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dGVEvents.Size = new System.Drawing.Size(495, 291);
            this.dGVEvents.TabIndex = 29;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Event";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Date";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 160;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Start Time";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 80;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "End Time";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 80;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Weekly";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 50;
            // 
            // lblEndWeek
            // 
            this.lblEndWeek.AutoSize = true;
            this.lblEndWeek.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEndWeek.Location = new System.Drawing.Point(204, 32);
            this.lblEndWeek.Name = "lblEndWeek";
            this.lblEndWeek.Size = new System.Drawing.Size(71, 16);
            this.lblEndWeek.TabIndex = 28;
            this.lblEndWeek.Text = "End Week";
            // 
            // lblStartWeek
            // 
            this.lblStartWeek.AutoSize = true;
            this.lblStartWeek.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStartWeek.Location = new System.Drawing.Point(201, 6);
            this.lblStartWeek.Name = "lblStartWeek";
            this.lblStartWeek.Size = new System.Drawing.Size(74, 16);
            this.lblStartWeek.TabIndex = 27;
            this.lblStartWeek.Text = "Start Week";
            // 
            // dTPEndWeek
            // 
            this.dTPEndWeek.Location = new System.Drawing.Point(281, 32);
            this.dTPEndWeek.Name = "dTPEndWeek";
            this.dTPEndWeek.Size = new System.Drawing.Size(110, 20);
            this.dTPEndWeek.TabIndex = 26;
            // 
            // dTPStartWeek
            // 
            this.dTPStartWeek.Location = new System.Drawing.Point(281, 6);
            this.dTPStartWeek.Name = "dTPStartWeek";
            this.dTPStartWeek.Size = new System.Drawing.Size(110, 20);
            this.dTPStartWeek.TabIndex = 25;
            this.dTPStartWeek.ValueChanged += new System.EventHandler(this.dTPStartWeek_ValueChanged);
            // 
            // btnCreate
            // 
            this.btnCreate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreate.Location = new System.Drawing.Point(8, 6);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(153, 49);
            this.btnCreate.TabIndex = 24;
            this.btnCreate.Text = "Create Planner";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.tBDayAboveOffset);
            this.tabPage2.Controls.Add(this.label21);
            this.tabPage2.Controls.Add(this.tBWeekendOffset);
            this.tabPage2.Controls.Add(this.label17);
            this.tabPage2.Controls.Add(this.lblLayoutType);
            this.tabPage2.Controls.Add(this.cBLayoutType);
            this.tabPage2.Controls.Add(this.tBTaskHeight);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.tBTaskOffset);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.tBRoleWidthToPoint);
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Controls.Add(this.tBRoleWidthToEdge);
            this.tabPage2.Controls.Add(this.label14);
            this.tabPage2.Controls.Add(this.tBRoleLineWidth);
            this.tabPage2.Controls.Add(this.label15);
            this.tabPage2.Controls.Add(this.tBRoleHeight);
            this.tabPage2.Controls.Add(this.label16);
            this.tabPage2.Controls.Add(this.tBRoleTaskOverlap);
            this.tabPage2.Controls.Add(this.label18);
            this.tabPage2.Controls.Add(this.tBTaskHeadingHeight);
            this.tabPage2.Controls.Add(this.label19);
            this.tabPage2.Controls.Add(this.tBTaskHeadingOffset);
            this.tabPage2.Controls.Add(this.label20);
            this.tabPage2.Controls.Add(this.tBBorderOffset);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.tBSpineOffset);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.tBHourWidth);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.tBTaskNoteOffset);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.tBPageWidth);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.tBPageHeight);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.tBFontMultiplier);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.tBThinLineweight);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.tBThickLineweight);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.tBDPI);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(525, 545);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Dimensions";
            // 
            // tBDayAboveOffset
            // 
            this.tBDayAboveOffset.Location = new System.Drawing.Point(124, 325);
            this.tBDayAboveOffset.Name = "tBDayAboveOffset";
            this.tBDayAboveOffset.Size = new System.Drawing.Size(69, 20);
            this.tBDayAboveOffset.TabIndex = 45;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(8, 328);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(116, 13);
            this.label21.TabIndex = 44;
            this.label21.Text = "Day Above Offset (mm)";
            // 
            // tBWeekendOffset
            // 
            this.tBWeekendOffset.Location = new System.Drawing.Point(380, 299);
            this.tBWeekendOffset.Name = "tBWeekendOffset";
            this.tBWeekendOffset.Size = new System.Drawing.Size(69, 20);
            this.tBWeekendOffset.TabIndex = 43;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(231, 302);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(110, 13);
            this.label17.TabIndex = 42;
            this.label17.Text = "Weekend Offset (mm)";
            // 
            // tBBorderOffset
            // 
            this.tBBorderOffset.Location = new System.Drawing.Point(124, 299);
            this.tBBorderOffset.Name = "tBBorderOffset";
            this.tBBorderOffset.Size = new System.Drawing.Size(69, 20);
            this.tBBorderOffset.TabIndex = 19;
            // 
            // tBSpineOffset
            // 
            this.tBSpineOffset.Location = new System.Drawing.Point(124, 273);
            this.tBSpineOffset.Name = "tBSpineOffset";
            this.tBSpineOffset.Size = new System.Drawing.Size(69, 20);
            this.tBSpineOffset.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 276);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Spine Offset (mm)";
            // 
            // tBHourWidth
            // 
            this.tBHourWidth.Location = new System.Drawing.Point(124, 247);
            this.tBHourWidth.Name = "tBHourWidth";
            this.tBHourWidth.Size = new System.Drawing.Size(69, 20);
            this.tBHourWidth.TabIndex = 15;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 250);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(86, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "Hour Width (mm)";
            // 
            // tBTaskNoteOffset
            // 
            this.tBTaskNoteOffset.Location = new System.Drawing.Point(124, 221);
            this.tBTaskNoteOffset.Name = "tBTaskNoteOffset";
            this.tBTaskNoteOffset.Size = new System.Drawing.Size(69, 20);
            this.tBTaskNoteOffset.TabIndex = 13;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 224);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(113, 13);
            this.label10.TabIndex = 12;
            this.label10.Text = "Task Note Offset (mm)";
            // 
            // tBPageWidth
            // 
            this.tBPageWidth.Location = new System.Drawing.Point(124, 195);
            this.tBPageWidth.Name = "tBPageWidth";
            this.tBPageWidth.Size = new System.Drawing.Size(69, 20);
            this.tBPageWidth.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 198);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Page Width (mm)";
            // 
            // tBPageHeight
            // 
            this.tBPageHeight.Location = new System.Drawing.Point(124, 169);
            this.tBPageHeight.Name = "tBPageHeight";
            this.tBPageHeight.Size = new System.Drawing.Size(69, 20);
            this.tBPageHeight.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 172);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Page Height (mm)";
            // 
            // tBFontMultiplier
            // 
            this.tBFontMultiplier.Location = new System.Drawing.Point(124, 143);
            this.tBFontMultiplier.Name = "tBFontMultiplier";
            this.tBFontMultiplier.Size = new System.Drawing.Size(69, 20);
            this.tBFontMultiplier.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 146);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Font Multiplier";
            // 
            // tBThinLineweight
            // 
            this.tBThinLineweight.Location = new System.Drawing.Point(124, 117);
            this.tBThinLineweight.Name = "tBThinLineweight";
            this.tBThinLineweight.Size = new System.Drawing.Size(69, 20);
            this.tBThinLineweight.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Thin Lineweight";
            // 
            // tBThickLineweight
            // 
            this.tBThickLineweight.Location = new System.Drawing.Point(124, 91);
            this.tBThickLineweight.Name = "tBThickLineweight";
            this.tBThickLineweight.Size = new System.Drawing.Size(69, 20);
            this.tBThickLineweight.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Thick Lineweight";
            // 
            // tBDPI
            // 
            this.tBDPI.Location = new System.Drawing.Point(124, 65);
            this.tBDPI.Name = "tBDPI";
            this.tBDPI.Size = new System.Drawing.Size(69, 20);
            this.tBDPI.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "DPI";
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(525, 545);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Roles";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 570);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVEvents)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblLayoutType;
        private System.Windows.Forms.ComboBox cBLayoutType;
        private System.Windows.Forms.TextBox tBTaskHeight;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tBTaskOffset;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tBRoleWidthToPoint;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tBRoleWidthToEdge;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox tBRoleLineWidth;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox tBRoleHeight;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox tBRoleTaskOverlap;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox tBTaskHeadingHeight;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox tBTaskHeadingOffset;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.CheckBox chBLinesOnHour;
        private System.Windows.Forms.Button btnInputEvent;
        private System.Windows.Forms.ComboBox cBWeekly;
        private System.Windows.Forms.ComboBox cBEndTime;
        private System.Windows.Forms.ComboBox cBStartTime;
        private System.Windows.Forms.DateTimePicker dTPEventDate;
        private System.Windows.Forms.TextBox tBEventName;
        private System.Windows.Forms.DataGridView dGVEvents;
        private System.Windows.Forms.Label lblEndWeek;
        private System.Windows.Forms.Label lblStartWeek;
        private System.Windows.Forms.DateTimePicker dTPEndWeek;
        private System.Windows.Forms.DateTimePicker dTPStartWeek;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox tBBorderOffset;
        private System.Windows.Forms.TextBox tBSpineOffset;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tBHourWidth;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tBTaskNoteOffset;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tBPageWidth;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tBPageHeight;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tBFontMultiplier;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tBThinLineweight;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tBThickLineweight;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tBDPI;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tBWeekendOffset;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.TextBox tBDayAboveOffset;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Button btnClearEvents;
        private System.Windows.Forms.TabPage tabPage3;
    }
}

