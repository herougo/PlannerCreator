using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Globalization;
using iTextSharp.text.pdf;
using System.IO;
using System.Diagnostics;

namespace WeeklyPlanner2
{
    public partial class Form1 : Form
    {
        // A polygon region.
        GraphicsPath myPath = new GraphicsPath();

        // Did they click on an image?
        private bool isImageClicked = false;

        string[,] table = new string[5, 100];

        string plannerPath = AppDomain.CurrentDomain.BaseDirectory + "Planner.pdf";
        string dGVRecordPath = AppDomain.CurrentDomain.BaseDirectory + "DGV Record.txt";
        string imageLocation = AppDomain.CurrentDomain.BaseDirectory;

        string fileFormat = ".png";

        string[] DGVline = new string[500];

        TextBox[] tbRoleName = new TextBox[7];
        Label[] lblRoleLabel = new Label[7];

        int RoleNum;
        int RoleLineNum;
        int RoleSpacing;

        public Form1()
        {
            InitializeComponent();

            // Add times to combo boxes
            string stringMinutes;
            for (int hour = 7; hour < 22; hour++)
            {
                for (int minutes = 0; minutes < 60; minutes += 15)
                {
                    stringMinutes = minutes.ToString();
                    if (stringMinutes.Length < 2) stringMinutes = "0" + stringMinutes;

                    cBStartTime.Items.Add(hour.ToString() + ":" + stringMinutes);
                    cBEndTime.Items.Add(hour.ToString() + ":" + stringMinutes);
                }
            }
            cBStartTime.Items.Add("22:00");
            cBEndTime.Items.Add("22:00");

            cBLayoutType.SelectedIndex = 0;

            // Load DGV from txt file
            TxtFileToStringArray(dGVRecordPath, DGVline);
            int counter = 0;
            while (DGVline[counter] != null)
            {
                dGVEvents.Rows.Add(DGVline[counter], DGVline[counter + 1], DGVline[counter + 2], DGVline[counter + 3], DGVline[counter + 4]);
                counter += 5;
            }

            // Draw Roles
            #region Label
            for (int a = 0; a < 7; a++)
            {
                lblRoleLabel[a] = new Label();

                lblRoleLabel[a].Location = new Point(10 + (a % 4) * 130, 20 + 70 * (a / 4));
                lblRoleLabel[a].Text = "Role " + (a + 1).ToString() + ":";

                tabPage3.Controls.Add(lblRoleLabel[a]);
            }
            #endregion

            #region Textbox
            for (int a = 0; a < 7; a++)
            {
                tbRoleName[a] = new TextBox();
            }

            tbRoleName[0].Text = "Calculus";
            tbRoleName[1].Text = "Actuarial Science";
            tbRoleName[2].Text = "English";
            tbRoleName[3].Text = "Linear Algebra";
            tbRoleName[4].Text = "Probability";
            tbRoleName[5].Text = "Co-op";
            tbRoleName[6].Text = "Clubs";

            for (int a = 0; a < 7; a++)
            {
                tbRoleName[a].Location = new Point(10 + (a % 4) * 130, 45 + 70 * (a / 4));
                tbRoleName[a].Size = new Size(120, 20);
                tbRoleName[a].Refresh();

                tabPage3.Controls.Add(tbRoleName[a]);
            }
            #endregion
        }

        public int InString(string text, string substring)
        {
            // gives position of substring the first time it occurs in the text

            int position = -1;

            for (int a = 0; a <= text.Length - substring.Length; a++)
            {
                if (text.Substring(a, substring.Length) == substring && position == -1) position = a;
            }

            return position;
        }

        public int DayGivenNumber(string day)
        {
            int dayOfTheWeek = 0;

            if (day == "Sunday") dayOfTheWeek = 1;
            else if (day == "Monday") dayOfTheWeek = 2;
            else if (day == "Tuesday") dayOfTheWeek = 3;
            else if (day == "Wednesday") dayOfTheWeek = 4;
            else if (day == "Thursday") dayOfTheWeek = 5;
            else if (day == "Friday") dayOfTheWeek = 6;
            else if (day == "Saturday") dayOfTheWeek = 7;

            return dayOfTheWeek;
        }

        public string DayFromNumber(int dayOfTheWeek)
        {
            dayOfTheWeek = dayOfTheWeek % 7;
            if (dayOfTheWeek == 0) dayOfTheWeek = 7;

            string day = "Tuesday";

            if (dayOfTheWeek == 1) day = "Sunday";
            else if (dayOfTheWeek == 2) day = "Monday";
            else if (dayOfTheWeek == 3) day = "Tuesday";
            else if (dayOfTheWeek == 4) day = "Wednesday";
            else if (dayOfTheWeek == 5) day = "Thursday";
            else if (dayOfTheWeek == 6) day = "Friday";
            else if (dayOfTheWeek == 7) day = "Saturday";

            return day;
        }

        public string MonthFromNumber(int monthNum)
        {
            string month = "January";

            if (monthNum == 1) month = "January";
            else if (monthNum == 2) month = "February";
            else if (monthNum == 3) month = "March";
            else if (monthNum == 4) month = "April";
            else if (monthNum == 5) month = "May";
            else if (monthNum == 6) month = "June";
            else if (monthNum == 7) month = "July";
            else if (monthNum == 8) month = "August";
            else if (monthNum == 9) month = "September";
            else if (monthNum == 10) month = "October";
            else if (monthNum == 11) month = "November";
            else if (monthNum == 12) month = "December";

            return month;
        }

        public DateTime DateTimeFromString(string stringDate)
        {
            DateTime date;

            int month = DateTime.ParseExact(stringDate.Substring(0, InString(stringDate, "-")), "MMMM", CultureInfo.CurrentCulture).Month;
            stringDate = stringDate.Substring(InString(stringDate, "-") + 1, stringDate.Length - (InString(stringDate, "-") + 1));

            int day = Convert.ToInt32(stringDate.Substring(0, InString(stringDate, "-")));

            int year = Convert.ToInt32(stringDate.Substring(InString(stringDate, "-") + 1, stringDate.Length - InString(stringDate, "-") - 1)) + 2000;

            date = new DateTime(year, month, day);

            return date;
        }

        public string StringFromDateTime(DateTime date)
        {
            string stringDate;

            string month = MonthFromNumber(date.Month);
            string day = date.Day.ToString();
            if (day.Length < 2) day = "0" + day;
            string year = date.Year.ToString().Substring(date.Year.ToString().Length - 2, 2);

            stringDate = month + "-" + day + "-" + year;

            return stringDate;
        }

        public int fontNumber(int dpi, int mmHeight)
        {
            int fontNum;

            int fullPixelHeight = fontPixelHeight(dpi, mmHeight);
            fontNum = fullPixelHeight * 1000 / 1213;

            return fontNum;
        }

        public int fontPixelHeight(int dpi, int mmHeight)
        {
            return (dpi * mmHeight * 10 / 254);
        }

        private void btnInputEvent_Click(object sender, EventArgs e)
        {
            dGVEvents.Rows.Add(tBEventName.Text, dTPEventDate.Text, cBStartTime.Text, cBEndTime.Text, cBWeekly.Text);

            // Write to txt file
            FileStream fs = new FileStream(dGVRecordPath, FileMode.Append);
            StreamWriter sw = new StreamWriter(fs);

            sw.WriteLine(tBEventName.Text);
            sw.WriteLine(dTPEventDate.Text);
            sw.WriteLine(cBStartTime.Text);
            sw.WriteLine(cBEndTime.Text);
            sw.WriteLine(cBWeekly.Text);

            sw.Close();
            fs.Close();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            isImageClicked = true;

            // Load Table
            for (int row = 0; row < dGVEvents.Rows.Count; row++)
            {
                for (int column = 0; column < 5; column++)
                {
                    table[column, row] = dGVEvents.Rows[row].Cells[column].Value.ToString(); ;
                }
            }

            // Fix Weeks
            DateTime StartWeekDate = DateTimeFromString(dTPStartWeek.Text);
            DateTime EndWeekDate = DateTimeFromString(dTPEndWeek.Text);

            // Shift the StartWeekDate to Sunday
            StartWeekDate = StartWeekDate.AddDays(-1 * (DayGivenNumber(StartWeekDate.DayOfWeek.ToString()) - 1));

            // Shift the EndWeekDate to Sunday
            EndWeekDate = EndWeekDate.AddDays(7 - DayGivenNumber(EndWeekDate.DayOfWeek.ToString()));

            dTPStartWeek.Text = StringFromDateTime(StartWeekDate);
            dTPEndWeek.Text = StringFromDateTime(EndWeekDate);

            // Count Roles
            int counter = 6;
            while (tbRoleName[counter].Text == "")
            {
                counter--;
            }
            RoleNum = counter + 1;

            // Count Number of Lines per Role
            RoleLineNum = 37 / RoleNum;

            // Calculate the Spacing of the Roles
            RoleSpacing = (37 % RoleNum);
        }

        private void Form1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            int counter;

            // Draw outline (if clicked...)
            if (isImageClicked == true)
            {
                #region Dimensions
                int dpi = Convert.ToInt32(tBDPI.Text);
                int lineweight = dpi * Convert.ToInt32(10 * Convert.ToDouble(tBThickLineweight.Text)) / 254;
                int lineweight2 = dpi * Convert.ToInt32(10 * Convert.ToDouble(tBThinLineweight.Text)) / 254;
                float fontMultiplier = dpi / 100f;

                int pageBorderHeight = dpi * Convert.ToInt32(tBPageHeight.Text) * 10 / 254;
                int pageBorderWidth = dpi * Convert.ToInt32(tBPageWidth.Text) * 10 / 254;

                int borderOffset = dpi * Convert.ToInt32(tBBorderOffset.Text) * 10 / 254;
                int spineOffset = dpi * Convert.ToInt32(tBSpineOffset.Text) * 10 / 254;
                // fix spineOffset
                while ((pageBorderWidth - borderOffset - spineOffset) % 3 != 0)
                {
                    spineOffset--;
                }
                int hourWidth = dpi * Convert.ToInt32(tBHourWidth.Text) * 10 / 254;
                int taskNoteOffset = dpi * Convert.ToInt32(tBTaskNoteOffset.Text) * 10 / 254;

                int taskHeight = dpi * Convert.ToInt32(tBTaskHeight.Text) * 10 / 254;
                int taskOffset = dpi * Convert.ToInt32(tBTaskOffset.Text) * 10 / 254;

                int roleWidthToPoint = dpi * Convert.ToInt32(tBRoleWidthToPoint.Text) * 10 / 254;
                int roleWidthToEdge = dpi * Convert.ToInt32(tBRoleWidthToEdge.Text) * 10 / 254;
                int roleLineWidth = dpi * Convert.ToInt32(tBRoleLineWidth.Text) * 10 / 254;
                int roleHeight = dpi * Convert.ToInt32(tBRoleHeight.Text) * 10 / 254;
                int roleOffset = taskHeight + taskOffset - roleHeight;

                int roleTaskOverlap = dpi * Convert.ToInt32(tBRoleTaskOverlap.Text) * 10 / 254;

                int taskHeadingHeight = dpi * Convert.ToInt32(tBTaskHeadingHeight.Text) * 10 / 254;
                int taskHeadingOffset = dpi * Convert.ToInt32(tBTaskHeadingOffset.Text) * 10 / 254;

                int weekendOffset = dpi * Convert.ToInt32(tBWeekendOffset.Text) * 10 / 254;
                int dayAboveOffset = dpi * Convert.ToInt32(tBDayAboveOffset.Text) * 10 / 254;

                float rowHeight = (pageBorderHeight - 2 * borderOffset - dayAboveOffset) / 43f;
                int columnWidth = (pageBorderWidth - borderOffset - spineOffset - weekendOffset) / 4;
                int noteWidth = columnWidth + weekendOffset - hourWidth - taskNoteOffset;
                int taskWidth = (pageBorderWidth - spineOffset - columnWidth - hourWidth - noteWidth - taskNoteOffset)
                    - (borderOffset + roleWidthToPoint - roleTaskOverlap);
                #endregion

                // Get Weeks
                DateTime StartWeekDate = DateTimeFromString(dTPStartWeek.Text);
                DateTime EndWeekDate = DateTimeFromString(dTPEndWeek.Text);
                DateTime CurrentWeekDate = DateTimeFromString(dTPStartWeek.Text);

                int pageCount = 0;

                while (CurrentWeekDate <= EndWeekDate)
                {
                    #region Drawing Variables
                    Bitmap bm = new Bitmap(pageBorderWidth, pageBorderHeight);
                    g = Graphics.FromImage(bm);

                    Pen lightPen = new Pen(Color.Gray, 1);
                    Pen ThinBlackPen = new Pen(Color.Black, lineweight2);
                    Pen mainPen = new Pen(Color.Black, lineweight);

                    int lineweightOverlap = (lineweight - 1) / 2;
                    int lineweight2Overlap = (lineweight2 - 1) / 2;
                    Brush b = new LinearGradientBrush(new Point(1, 1),
                             new Point(600, 600), Color.Black, Color.Black);
                    #endregion

                    // PNG  drawing co-ordinates \/  >

                    #region Fonts
                    // Font * 0.87 = pixel height

                    // set string StringFormats
                    StringFormat format1 = new StringFormat(StringFormatFlags.NoClip);

                    // Set the LineAlignment and Alignment properties for 
                    // both StringFormat objects to different values.
                    format1.LineAlignment = StringAlignment.Center;
                    format1.Alignment = StringAlignment.Center;

                    StringFormat format2 = new StringFormat(StringFormatFlags.NoClip);

                    // Set the LineAlignment and Alignment properties for 
                    // both StringFormat objects to different values.
                    format2.LineAlignment = StringAlignment.Near;
                    format2.Alignment = StringAlignment.Near;

                    StringFormat format3 = new StringFormat(StringFormatFlags.NoClip);

                    // Set the LineAlignment and Alignment properties for 
                    // both StringFormat objects to different values.
                    format3.LineAlignment = StringAlignment.Center;
                    format3.Alignment = StringAlignment.Far;

                    StringFormat format4 = new StringFormat(StringFormatFlags.NoClip);

                    // Set the LineAlignment and Alignment properties for 
                    // both StringFormat objects to different values.
                    format4.LineAlignment = StringAlignment.Center;
                    format4.Alignment = StringAlignment.Near;
                    #endregion

                    #region Page 1

                    #region Outline
                    // Set background to white
                    g.FillPolygon(new LinearGradientBrush(new Point(1, 1), new Point(600, 600), Color.White, Color.White),
                        new Point[] { new Point(0, 0), new Point(0, pageBorderHeight), 
                        new Point(pageBorderWidth, pageBorderHeight), new Point(pageBorderWidth, 0)});

                    #region Draw Grey
                    // Draw Definite Horizontal Grey Lines

                    // Monday Lines
                    // Tasks
                    for (int a = 37; a <= 42; a++)
                    {
                        myPath.Reset();
                        myPath.AddLine(
                            new Point(pageBorderWidth - spineOffset - 3 * columnWidth - lineweightOverlap,
                                borderOffset + dayAboveOffset + Convert.ToInt32(a * rowHeight)),
                            new Point(
                                pageBorderWidth - spineOffset + lineweightOverlap,
                                borderOffset + dayAboveOffset + Convert.ToInt32(a * rowHeight)));
                        g.DrawPath(lightPen, myPath);
                    }
                    // all of ones in between
                    for (int a = 2; a <= 36; a += 2)
                    {
                        myPath.Reset();
                        myPath.AddLine(
                            new Point(pageBorderWidth - spineOffset - 3 * columnWidth - lineweightOverlap,
                                borderOffset + dayAboveOffset + Convert.ToInt32(a * rowHeight)),
                            new Point(
                                pageBorderWidth - spineOffset + lineweightOverlap,
                                borderOffset + dayAboveOffset + Convert.ToInt32(a * rowHeight)));
                        g.DrawPath(lightPen, myPath);
                    }

                    // Notes
                    for (int role = 0; role < RoleNum; role++)
                    {
                        for (int a = 2; a < RoleLineNum; a++)
                        {
                            myPath.Reset();
                            myPath.AddLine(
                                new Point(borderOffset - lineweightOverlap,
                                    borderOffset + dayAboveOffset + Convert.ToInt32((a + 6) * rowHeight)
                                    + Convert.ToInt32(role * rowHeight * RoleLineNum) + Convert.ToInt32(role * rowHeight * RoleSpacing / (RoleNum - 1))),
                                new Point(
                                    pageBorderWidth - spineOffset - 3 * columnWidth - taskNoteOffset - hourWidth + lineweightOverlap,
                                    borderOffset + dayAboveOffset + Convert.ToInt32((a + 6) * rowHeight)
                                    + Convert.ToInt32(role * rowHeight * RoleLineNum) + Convert.ToInt32(role * rowHeight * RoleSpacing / (RoleNum - 1))));
                            g.DrawPath(lightPen, myPath);
                        }
                    }

                    #endregion

                    #region Draw Thick Black

                    // Draw Definite Black Lines

                    #region Part of 7 Day

                    // Draw Vertical Black Lines

                    // right
                    for (int a = 0; a <= 3; a++)
                    {
                        myPath.Reset();
                        myPath.AddLine(
                            new Point(pageBorderWidth - (3 - a) * columnWidth - spineOffset,
                                borderOffset + dayAboveOffset - lineweightOverlap),
                            new Point(
                                pageBorderWidth - (3 - a) * columnWidth - spineOffset,
                                borderOffset + dayAboveOffset + Convert.ToInt32(rowHeight * 43) + lineweightOverlap));
                        g.DrawPath(mainPen, myPath);
                    }

                    // Draw Horizontal Black Lines
                    // bottom
                    myPath.Reset();
                    myPath.AddLine(
                        new Point(pageBorderWidth - 3 * columnWidth - spineOffset - lineweightOverlap,
                            borderOffset + dayAboveOffset + Convert.ToInt32(43 * rowHeight)),
                        new Point(
                            pageBorderWidth - spineOffset + lineweightOverlap,
                            borderOffset + dayAboveOffset + Convert.ToInt32(43 * rowHeight)));
                    g.DrawPath(mainPen, myPath);

                    // 2nd from bottom
                    myPath.Reset();
                    myPath.AddLine(
                        new Point(pageBorderWidth - 3 * columnWidth - spineOffset - lineweightOverlap,
                            borderOffset + dayAboveOffset + Convert.ToInt32(36 * rowHeight)),
                        new Point(
                            pageBorderWidth - spineOffset + lineweightOverlap,
                            borderOffset + dayAboveOffset + Convert.ToInt32(36 * rowHeight)));
                    g.DrawPath(mainPen, myPath);

                    // 3rd from bottom
                    myPath.Reset();
                    myPath.AddLine(
                        new Point(pageBorderWidth - 3 * columnWidth - spineOffset - lineweightOverlap,
                            borderOffset + dayAboveOffset + Convert.ToInt32(35 * rowHeight)),
                        new Point(
                            pageBorderWidth - spineOffset + lineweightOverlap,
                            borderOffset + dayAboveOffset + Convert.ToInt32(35 * rowHeight)));
                    g.DrawPath(mainPen, myPath);

                    // top
                    myPath.Reset();
                    myPath.AddLine(
                        new Point(pageBorderWidth - 3 * columnWidth - spineOffset - lineweightOverlap,
                            borderOffset + dayAboveOffset),
                        new Point(
                            pageBorderWidth - spineOffset + lineweightOverlap,
                            borderOffset + dayAboveOffset));
                    g.DrawPath(mainPen, myPath);

                    // 2nd from top
                    myPath.Reset();
                    myPath.AddLine(
                        new Point(pageBorderWidth - 3 * columnWidth - spineOffset - lineweightOverlap,
                            borderOffset + dayAboveOffset + Convert.ToInt32(rowHeight)),
                        new Point(
                            pageBorderWidth - spineOffset + lineweightOverlap,
                            borderOffset + dayAboveOffset + Convert.ToInt32(rowHeight)));
                    g.DrawPath(mainPen, myPath);

                    #endregion

                    #region Roles
                    for (int a = 0; a < RoleNum; a++)
                    {
                        // Vertical Lines
                        // furthest left
                        myPath.Reset();
                        myPath.AddLine(
                            new Point(borderOffset,
                                borderOffset + dayAboveOffset + Convert.ToInt32(rowHeight * 6) - lineweightOverlap
                                + Convert.ToInt32(a * rowHeight * RoleLineNum) + Convert.ToInt32(a * rowHeight * RoleSpacing / (RoleNum - 1))),
                            new Point(
                                borderOffset,
                                borderOffset + dayAboveOffset + Convert.ToInt32(rowHeight * 6) + lineweightOverlap
                                + Convert.ToInt32((a + 1) * rowHeight * RoleLineNum) + Convert.ToInt32(a * rowHeight * RoleSpacing / (RoleNum - 1))));
                        g.DrawPath(mainPen, myPath);

                        // 2nd furthest left
                        myPath.Reset();
                        myPath.AddLine(
                            new Point(borderOffset + noteWidth, 
                                borderOffset + dayAboveOffset + Convert.ToInt32(rowHeight * 6) - lineweightOverlap
                                + Convert.ToInt32(a * rowHeight * RoleLineNum) + Convert.ToInt32(a * rowHeight * RoleSpacing / (RoleNum - 1))),
                            new Point(
                                borderOffset + noteWidth,
                                borderOffset + dayAboveOffset + Convert.ToInt32(rowHeight * 6) + lineweightOverlap
                                + Convert.ToInt32((a + 1) * rowHeight * RoleLineNum) + Convert.ToInt32(a * rowHeight * RoleSpacing / (RoleNum - 1))));
                        g.DrawPath(mainPen, myPath);

                        // Horizontal Lines

                        // top
                        myPath.Reset();
                        myPath.AddLine(
                            new Point(borderOffset - lineweightOverlap,
                                borderOffset + dayAboveOffset + Convert.ToInt32(6 * rowHeight)
                                + Convert.ToInt32(a * rowHeight * RoleLineNum) + Convert.ToInt32(a * rowHeight * RoleSpacing / (RoleNum - 1))),
                            new Point(
                                borderOffset + noteWidth + lineweightOverlap,
                                borderOffset + dayAboveOffset + Convert.ToInt32(6 * rowHeight)
                                + Convert.ToInt32(a * rowHeight * RoleLineNum) + Convert.ToInt32(a * rowHeight * RoleSpacing / (RoleNum - 1))));
                        g.DrawPath(mainPen, myPath);

                        // 2nd from top
                        myPath.Reset();
                        myPath.AddLine(
                            new Point(borderOffset - lineweightOverlap,
                                borderOffset + dayAboveOffset + Convert.ToInt32(7 * rowHeight)
                                + Convert.ToInt32(a * rowHeight * RoleLineNum) + Convert.ToInt32(a * rowHeight * RoleSpacing / (RoleNum - 1))),
                            new Point(
                                borderOffset + noteWidth + lineweightOverlap,
                                borderOffset + dayAboveOffset + Convert.ToInt32(7 * rowHeight)
                                + Convert.ToInt32(a * rowHeight * RoleLineNum) + Convert.ToInt32(a * rowHeight * RoleSpacing / (RoleNum - 1))));
                        g.DrawPath(mainPen, myPath);

                        // bottom
                        myPath.Reset();
                        myPath.AddLine(
                            new Point(borderOffset - lineweightOverlap,
                                borderOffset + dayAboveOffset + Convert.ToInt32(6 * rowHeight)
                                + Convert.ToInt32((a + 1) * rowHeight * RoleLineNum) + Convert.ToInt32(a * rowHeight * RoleSpacing / (RoleNum - 1))),
                            new Point(
                                borderOffset + noteWidth + lineweightOverlap,
                                borderOffset + dayAboveOffset + Convert.ToInt32(6 * rowHeight)
                                + Convert.ToInt32((a + 1) * rowHeight * RoleLineNum) + Convert.ToInt32(a * rowHeight * RoleSpacing / (RoleNum - 1))));
                        g.DrawPath(mainPen, myPath);
                    }

                    #endregion

                    #endregion

                    #region Thin Black Lines

                    // all of ones in between for the part of the 7 day
                    // Monday to Wednesday
                    for (int a = 1; a <= 16; a++)
                    {
                        myPath.Reset();
                        myPath.AddLine(
                            new Point(pageBorderWidth - spineOffset - 3 * columnWidth - lineweight2Overlap,
                                borderOffset + dayAboveOffset + Convert.ToInt32((1 + 2 * a) * rowHeight)),
                            new Point(
                                pageBorderWidth - spineOffset + lineweight2Overlap,
                                borderOffset + dayAboveOffset + Convert.ToInt32((1 + 2 * a) * rowHeight)));
                        g.DrawPath(ThinBlackPen, myPath);
                    }
                    
                    /*
                    
                    // Hours
                    if (chBLinesOnHour.Checked)
                    {
                        for (int a = 1; a <= 16; a++)
                        {
                            myPath.Reset();
                            myPath.AddLine(
                                new Point(pageBorderWidth - spineOffset - columnWidth - hourWidth - lineweight2Overlap,
                                    borderOffset + Convert.ToInt32((1 + 2 * a) * rowHeight)),
                                new Point(
                                    pageBorderWidth - spineOffset - columnWidth + lineweight2Overlap,
                                    borderOffset + Convert.ToInt32((1 + 2 * a) * rowHeight)));
                            g.DrawPath(ThinBlackPen, myPath);
                        }
                    }

                    #region Role Tags

                    // large left line
                    myPath.Reset();
                    myPath.AddLine(
                        new Point(borderOffset,
                            pageBorderHeight - borderOffset - taskHeight / 2 + roleHeight / 2 - 7 * roleHeight - 6 * roleOffset
                            - lineweight2Overlap),
                        new Point(
                            borderOffset,
                            pageBorderHeight - borderOffset - taskHeight / 2 + roleHeight / 2
                            + lineweight2Overlap));
                    g.DrawPath(ThinBlackPen, myPath);

                    // 7th tag bottom line section
                    myPath.Reset();
                    myPath.AddLine(
                        new Point(borderOffset - lineweight2Overlap,
                            pageBorderHeight - borderOffset - taskHeight / 2 + roleHeight / 2),
                        new Point(
                            borderOffset + roleLineWidth + lineweight2Overlap,
                            pageBorderHeight - borderOffset - taskHeight / 2 + roleHeight / 2));
                    g.DrawPath(ThinBlackPen, myPath);

                    // 1st tag top line section
                    myPath.Reset();
                    myPath.AddLine(
                        new Point(borderOffset - lineweight2Overlap,
                            pageBorderHeight - borderOffset - taskHeight / 2 + roleHeight / 2 - 7 * roleHeight - 6 * roleOffset),
                        new Point(
                            borderOffset + roleLineWidth + lineweight2Overlap,
                            pageBorderHeight - borderOffset - taskHeight / 2 + roleHeight / 2 - 7 * roleHeight - 6 * roleOffset));
                    g.DrawPath(ThinBlackPen, myPath);

                    // Tags
                    for (int a = 0; a < 7; a++)
                    {
                        // top line
                        myPath.Reset();
                        myPath.AddLine(
                            new Point(borderOffset + roleLineWidth - lineweight2Overlap,
                                pageBorderHeight - borderOffset - taskHeight / 2 + roleHeight / 2 - 7 * roleHeight - 6 * roleOffset
                                + a * (roleHeight + roleOffset)),
                            new Point(
                                borderOffset + roleWidthToEdge + lineweight2Overlap,
                                pageBorderHeight - borderOffset - taskHeight / 2 + roleHeight / 2 - 7 * roleHeight - 6 * roleOffset
                                + a * (roleHeight + roleOffset)));
                        g.DrawPath(ThinBlackPen, myPath);

                        // bottom line
                        myPath.Reset();
                        myPath.AddLine(
                            new Point(borderOffset + roleLineWidth - lineweight2Overlap,
                                pageBorderHeight - borderOffset - taskHeight / 2 + roleHeight / 2 - 7 * roleHeight - 6 * roleOffset
                                + roleHeight + a * (roleHeight + roleOffset)),
                            new Point(
                                borderOffset + roleWidthToEdge + lineweight2Overlap,
                                pageBorderHeight - borderOffset - taskHeight / 2 + roleHeight / 2 - 7 * roleHeight - 6 * roleOffset
                                + roleHeight + a * (roleHeight + roleOffset)));
                        g.DrawPath(ThinBlackPen, myPath);

                        // top diagonal line
                        myPath.Reset();
                        myPath.AddLine(
                            new Point(borderOffset + roleWidthToEdge,
                                pageBorderHeight - borderOffset - taskHeight / 2 + roleHeight / 2 - 7 * roleHeight - 6 * roleOffset
                                + a * (roleHeight + roleOffset)),
                            new Point(
                                borderOffset + roleWidthToPoint,
                                pageBorderHeight - borderOffset - taskHeight / 2 + roleHeight / 2 - 7 * roleHeight - 6 * roleOffset
                                + roleHeight / 2 + a * (roleHeight + roleOffset)));
                        g.DrawPath(ThinBlackPen, myPath);

                        // bottom diagonal line
                        myPath.Reset();
                        myPath.AddLine(
                            new Point(borderOffset + roleWidthToEdge,
                                pageBorderHeight - borderOffset - taskHeight / 2 + roleHeight / 2 - 7 * roleHeight - 6 * roleOffset
                                + roleHeight + a * (roleHeight + roleOffset)),
                            new Point(
                                borderOffset + roleWidthToPoint,
                                pageBorderHeight - borderOffset - taskHeight / 2 + roleHeight / 2 - 7 * roleHeight - 6 * roleOffset
                                + roleHeight / 2 + a * (roleHeight + roleOffset)));
                        g.DrawPath(ThinBlackPen, myPath);
                    }

                    // In-between vertical lines
                    for (int a = 0; a < 6; a++)
                    {
                        myPath.Reset();
                        myPath.AddLine(
                            new Point(borderOffset + roleLineWidth,
                                pageBorderHeight - borderOffset - taskHeight / 2 + roleHeight / 2 - 7 * roleHeight - 6 * roleOffset
                                + roleHeight + a * (roleHeight + roleOffset) - lineweight2Overlap),
                            new Point(
                                borderOffset + roleLineWidth,
                                pageBorderHeight - borderOffset - taskHeight / 2 + roleHeight / 2 - 7 * roleHeight - 6 * roleOffset
                                + roleHeight + roleOffset + a * (roleHeight + roleOffset) + lineweight2Overlap));
                        g.DrawPath(ThinBlackPen, myPath);
                    }

                    #endregion

                    #region Tasks
                    
                    int taskShortVertical = taskHeight / 2 - roleTaskOverlap * (roleHeight / 2)
                        / (roleWidthToPoint - roleWidthToEdge);

                    // Task boxes
                    for (int a = 0; a < 7; a++)
                    {
                        // top line
                        myPath.Reset();
                        myPath.AddLine(
                            new Point(borderOffset + roleWidthToPoint - roleTaskOverlap - lineweight2Overlap,
                                pageBorderHeight - borderOffset - a * (taskHeight + taskOffset) - taskHeight),
                            new Point(
                                pageBorderWidth - spineOffset - columnWidth - hourWidth - noteWidth - taskNoteOffset + lineweight2Overlap,
                                pageBorderHeight - borderOffset - a * (taskHeight + taskOffset) - taskHeight));
                        g.DrawPath(ThinBlackPen, myPath);

                        // bottom line
                        myPath.Reset();
                        myPath.AddLine(
                            new Point(borderOffset + roleWidthToPoint - roleTaskOverlap - lineweight2Overlap,
                                pageBorderHeight - borderOffset - a * (taskHeight + taskOffset)),
                            new Point(
                                pageBorderWidth - spineOffset - columnWidth - hourWidth - noteWidth - taskNoteOffset + lineweight2Overlap,
                                pageBorderHeight - borderOffset - a * (taskHeight + taskOffset)));
                        g.DrawPath(ThinBlackPen, myPath);

                        // top left
                        myPath.Reset();
                        myPath.AddLine(
                            new Point(borderOffset + roleWidthToPoint - roleTaskOverlap,
                                pageBorderHeight - borderOffset - a * (taskHeight + taskOffset) - taskHeight - lineweight2Overlap),
                            new Point(
                                borderOffset + roleWidthToPoint - roleTaskOverlap,
                                pageBorderHeight - borderOffset - a * (taskHeight + taskOffset) - taskHeight + taskShortVertical));
                        g.DrawPath(ThinBlackPen, myPath);

                        // bottom left
                        myPath.Reset();
                        myPath.AddLine(
                            new Point(borderOffset + roleWidthToPoint - roleTaskOverlap,
                                pageBorderHeight - borderOffset - a * (taskHeight + taskOffset) - taskShortVertical),
                            new Point(
                                borderOffset + roleWidthToPoint - roleTaskOverlap,
                                pageBorderHeight - borderOffset - a * (taskHeight + taskOffset) + lineweight2Overlap));
                        g.DrawPath(ThinBlackPen, myPath);

                        // right line
                        myPath.Reset();
                        myPath.AddLine(
                            new Point(pageBorderWidth - spineOffset - columnWidth - hourWidth - noteWidth - taskNoteOffset,
                                pageBorderHeight - borderOffset - a * (taskHeight + taskOffset) - taskHeight - lineweight2Overlap),
                            new Point(
                                pageBorderWidth - spineOffset - columnWidth - hourWidth - noteWidth - taskNoteOffset,
                                pageBorderHeight - borderOffset - a * (taskHeight + taskOffset) + lineweight2Overlap));
                        g.DrawPath(ThinBlackPen, myPath);
                    }

                    #endregion

                    */
                    #endregion

                    #endregion

                    #region Text

                    // Month
                    g.DrawString(MonthFromNumber(CurrentWeekDate.Month), new Font("Times New Roman", fontNumber(dpi, 8)),
                        b, new Rectangle(borderOffset, borderOffset,
                            noteWidth + taskNoteOffset, Convert.ToInt32(24f * fontMultiplier)), format1);

                    // Week days
                    int ambiguous = dpi * 180 / 254; //**********
                    string weekSpan = MonthFromNumber(CurrentWeekDate.AddDays(1).Month) + " " + CurrentWeekDate.AddDays(1).Day.ToString() + "\nto\n"
                        + MonthFromNumber(CurrentWeekDate.AddDays(7).Month) + " " + CurrentWeekDate.AddDays(7).Day.ToString();

                    g.DrawString(weekSpan, new Font("Times New Roman", fontNumber(dpi, 4)),
                        b, new Rectangle(borderOffset, borderOffset + ambiguous,
                            noteWidth, Convert.ToInt32(45f * fontMultiplier)), format1);

                    // Role Text
                    for (int a = 0; a < RoleNum; a++)
                    {
                        g.DrawString((a + 1).ToString() + ") " + tbRoleName[a].Text, new Font("Times New Roman", fontNumber(dpi, 4)),
                              b, new Rectangle(borderOffset, borderOffset + dayAboveOffset + Convert.ToInt32(6 * rowHeight)
                                + Convert.ToInt32(a * rowHeight * RoleLineNum) + Convert.ToInt32(a * rowHeight * RoleSpacing / (RoleNum - 1)),
                                  noteWidth, Convert.ToInt32(rowHeight)), format4);
                    }

                    // Monday to Wednesday
                    for (int a = 2; a <= 4; a++)
                    {
                        g.DrawString(DayFromNumber(a), new Font("Times New Roman", fontNumber(dpi, 5)),
                           b, new Rectangle(pageBorderWidth - spineOffset - (5 - a) * columnWidth, borderOffset + dayAboveOffset, columnWidth, Convert.ToInt32(rowHeight)), format1);
                    }

                    // Hour Text
                    //*** 100 & 200

                    // AM
                    for (int a = 7; a <= 12; a++)
                    {
                        g.DrawString(a.ToString(), new Font("Times New Roman", fontNumber(dpi, 4)),
                           b, new Rectangle(pageBorderWidth - spineOffset - 3 * columnWidth - hourWidth - 200, borderOffset + dayAboveOffset + Convert.ToInt32((2 * a - 12) * rowHeight),
                               hourWidth + 200, Convert.ToInt32(2 * rowHeight)), format3);
                    }
                    // PM
                    for (int a = 1; a <= 10; a++)
                    {
                        g.DrawString(a.ToString(), new Font("Times New Roman", fontNumber(dpi, 4)),
                           b, new Rectangle(pageBorderWidth - spineOffset - 3 * columnWidth - hourWidth - 200, borderOffset + dayAboveOffset + Convert.ToInt32((2 * a + 12) * rowHeight),
                               hourWidth + 200, Convert.ToInt32(2 * rowHeight)), format3);
                    }

                    // Tasks
                    for (int a = 0; a < 3; a++)
                    {
                        g.DrawString("Tasks", new Font("Times New Roman", fontNumber(dpi, 5)),
                           b, new Rectangle(pageBorderWidth - spineOffset - (3 - a) * columnWidth, borderOffset + dayAboveOffset + Convert.ToInt32(35 * rowHeight),
                               columnWidth, Convert.ToInt32(rowHeight)), format1);
                    }

                    // Date Above
                    for (int a = 2; a <= 4; a++)
                    {
                        g.DrawString(MonthFromNumber(CurrentWeekDate.AddDays(a - 1).Month) + " " + CurrentWeekDate.AddDays(a - 1).Day.ToString(), 
                            new Font("Times New Roman", fontNumber(dpi, 3)),
                           b, new Rectangle(pageBorderWidth - spineOffset - (5 - a) * columnWidth, borderOffset, columnWidth, dayAboveOffset), format1);
                    }

                    #endregion

                    #region Events

                    counter = 0;
                    while (table[0, counter] != null)
                    {
                        for (int a = 1; a <= 3; a++)
                        {
                            // Monday to Wednesday

                            // If it is the specific day OR if it is a weekly event
                            if ((table[1, counter] == StringFromDateTime(CurrentWeekDate.AddDays(a))) ||
                                (DateTimeFromString(table[1, counter]).DayOfWeek == CurrentWeekDate.AddDays(a).DayOfWeek
                                && table[4, counter] == "Yes") && CurrentWeekDate.AddDays(a) > DateTimeFromString(table[1, counter]))
                            {
                                // Get Top Height
                                int hour = Convert.ToInt32(table[2, counter].Substring(0, InString(table[2, counter], ":")));
                                int minute = Convert.ToInt32(table[2, counter].Substring(InString(table[2, counter], ":") + 1,
                                    table[2, counter].Length - (InString(table[2, counter], ":") + 1)));
                                int eventTopHeight = Convert.ToInt32(borderOffset + dayAboveOffset + rowHeight * ((3f + 2f * hour - 14f) + (2f * minute / 60f)));

                                // Get Bottom Height
                                hour = Convert.ToInt32(table[3, counter].Substring(0, InString(table[3, counter], ":")));
                                minute = Convert.ToInt32(table[3, counter].Substring(InString(table[3, counter], ":") + 1,
                                    table[3, counter].Length - (InString(table[3, counter], ":") + 1)));
                                int eventBottomHeight = Convert.ToInt32(borderOffset + dayAboveOffset + rowHeight * ((3f + 2f * hour - 14f) + (2f * minute / 60f)));

                                // Grey Rectangle
                                g.FillRectangle(new SolidBrush(Color.LightGray), new Rectangle(pageBorderWidth - spineOffset - (4 - a) * columnWidth + lineweightOverlap,
                                        eventTopHeight, columnWidth - 2 * lineweightOverlap, eventBottomHeight - eventTopHeight + 1));

                                // Black Lines
                                // Top Black Line
                                myPath.Reset();
                                myPath.AddLine(
                                    new Point(pageBorderWidth - spineOffset - (4 - a) * columnWidth - lineweightOverlap,
                                        eventTopHeight),
                                    new Point(
                                        pageBorderWidth - spineOffset - (3 - a) * columnWidth + lineweightOverlap,
                                        eventTopHeight));
                                g.DrawPath(ThinBlackPen, myPath);
                                // Bottom Black Line
                                myPath.Reset();
                                myPath.AddLine(
                                    new Point(pageBorderWidth - spineOffset - (4 - a) * columnWidth - lineweightOverlap,
                                        eventBottomHeight),
                                    new Point(
                                        pageBorderWidth - spineOffset - (3 - a) * columnWidth + lineweightOverlap,
                                        eventBottomHeight));
                                g.DrawPath(ThinBlackPen, myPath);

                                // Name
                                g.DrawString(table[0, counter], new Font("Times New Roman", Convert.ToInt32(800f / 87f * fontMultiplier)),
                                   b, new Rectangle(pageBorderWidth - spineOffset - (4 - a) * columnWidth,
                                        eventTopHeight, columnWidth, Convert.ToInt32(rowHeight)), format2);
                            }
                        }

                        counter++;
                    }

                    #endregion

                    pageCount++;
                    bm.Save(imageLocation + "page" + pageCount.ToString() + fileFormat, ImageFormat.Png);


                    #endregion


                    #region Page 2

                    #region Outline
                    Bitmap bm1 = new Bitmap(pageBorderWidth, pageBorderHeight);
                    g = Graphics.FromImage(bm1);

                    // Set background to white
                    g.FillPolygon(new LinearGradientBrush(new Point(1, 1), new Point(600, 600), Color.White, Color.White),
                        new Point[] { new Point(0, 0), new Point(0, pageBorderHeight), 
                        new Point(pageBorderWidth, pageBorderHeight), new Point(pageBorderWidth, 0)});

                    #region Draw Grey

                    // Draw Definite Horizontal Grey Lines

                    // Tasks
                    // Left
                    for (int a = 37; a <= 42; a++)
                    {
                        myPath.Reset();
                        myPath.AddLine(
                            new Point(spineOffset - lineweightOverlap,
                                borderOffset + dayAboveOffset + Convert.ToInt32(a * rowHeight)),
                            new Point(
                                spineOffset + 2 * columnWidth + lineweightOverlap,
                                borderOffset + dayAboveOffset + Convert.ToInt32(a * rowHeight)));
                        g.DrawPath(lightPen, myPath);
                    }
                    // Right
                    for (int a = 37; a <= 42; a++)
                    {
                        myPath.Reset();
                        myPath.AddLine(
                            new Point(spineOffset + weekendOffset + 2 * columnWidth - lineweightOverlap,
                                borderOffset + dayAboveOffset + Convert.ToInt32(a * rowHeight)),
                            new Point(
                                spineOffset + weekendOffset + 4 * columnWidth + lineweightOverlap,
                                borderOffset + dayAboveOffset + Convert.ToInt32(a * rowHeight)));
                        g.DrawPath(lightPen, myPath);
                    }

                    // all of ones in between
                    // Left
                    for (int a = 2; a <= 36; a += 2)
                    {
                        myPath.Reset();
                        myPath.AddLine(
                            new Point(spineOffset - lineweightOverlap,
                                borderOffset + dayAboveOffset + Convert.ToInt32(a * rowHeight)),
                            new Point(
                                spineOffset + 2 * columnWidth + lineweightOverlap,
                                borderOffset + dayAboveOffset + Convert.ToInt32(a * rowHeight)));
                        g.DrawPath(lightPen, myPath);
                    }
                    // Right
                    for (int a = 2; a <= 36; a += 2)
                    {
                        myPath.Reset();
                        myPath.AddLine(
                            new Point(spineOffset + weekendOffset + 2 * columnWidth - lineweightOverlap,
                                borderOffset + dayAboveOffset + Convert.ToInt32(a * rowHeight)),
                            new Point(
                                spineOffset + weekendOffset + 4 * columnWidth + lineweightOverlap,
                                borderOffset + dayAboveOffset + Convert.ToInt32(a * rowHeight)));
                        g.DrawPath(lightPen, myPath);
                    }

                    #endregion

                    #region Draw Thick Black Lines

                    // Draw Definite Black Lines

                    // Draw Vertical Black Lines
                    // First 3
                    for (int a = 0; a <= 2; a++)
                    {
                        myPath.Reset();
                        myPath.AddLine(
                            new Point(spineOffset + a * columnWidth,
                                borderOffset + dayAboveOffset - lineweightOverlap),
                            new Point(
                                spineOffset + a * columnWidth,
                                borderOffset + dayAboveOffset + Convert.ToInt32(rowHeight * 43) + lineweightOverlap));
                        g.DrawPath(mainPen, myPath);
                    }
                    // 4th Line
                    myPath.Reset();
                    myPath.AddLine(
                        new Point(spineOffset + 2 * columnWidth + weekendOffset,
                            borderOffset + dayAboveOffset - lineweightOverlap),
                        new Point(
                            spineOffset + 2 * columnWidth + weekendOffset,
                            borderOffset + dayAboveOffset + Convert.ToInt32(rowHeight * 43) + lineweightOverlap));
                    g.DrawPath(mainPen, myPath);
                    // Next Small One
                    myPath.Reset();
                    myPath.AddLine(
                        new Point(spineOffset + 3 * columnWidth + weekendOffset,
                            borderOffset + dayAboveOffset - lineweightOverlap),
                        new Point(
                            spineOffset + 3 * columnWidth + weekendOffset,
                            borderOffset + dayAboveOffset + Convert.ToInt32(rowHeight * 35) + lineweightOverlap));
                    g.DrawPath(mainPen, myPath);
                    // Last Long One
                    myPath.Reset();
                    myPath.AddLine(
                        new Point(spineOffset + 4 * columnWidth + weekendOffset,
                            borderOffset + dayAboveOffset - lineweightOverlap),
                        new Point(
                            spineOffset + 4 * columnWidth + weekendOffset,
                            borderOffset + dayAboveOffset + Convert.ToInt32(rowHeight * 43) + lineweightOverlap));
                    g.DrawPath(mainPen, myPath);

                    // Draw Horizontal Black Lines
                    // bottom
                    // left
                    myPath.Reset();
                    myPath.AddLine(
                        new Point(spineOffset - lineweightOverlap,
                            borderOffset + dayAboveOffset + Convert.ToInt32(43 * rowHeight)),
                        new Point(
                            spineOffset + 2 * columnWidth + lineweightOverlap,
                            borderOffset + dayAboveOffset + Convert.ToInt32(43 * rowHeight)));
                    g.DrawPath(mainPen, myPath);
                    // right
                    myPath.Reset();
                    myPath.AddLine(
                        new Point(spineOffset + 2 * columnWidth + weekendOffset - lineweightOverlap,
                            borderOffset + dayAboveOffset + Convert.ToInt32(43 * rowHeight)),
                        new Point(
                            spineOffset + 4 * columnWidth + weekendOffset + lineweightOverlap,
                            borderOffset + dayAboveOffset + Convert.ToInt32(43 * rowHeight)));
                    g.DrawPath(mainPen, myPath);

                    // 2nd from bottom
                    // left
                    myPath.Reset();
                    myPath.AddLine(
                        new Point(spineOffset - lineweightOverlap,
                            borderOffset + dayAboveOffset + Convert.ToInt32(36 * rowHeight)),
                        new Point(
                            spineOffset + 2 * columnWidth + lineweightOverlap,
                            borderOffset + dayAboveOffset + Convert.ToInt32(36 * rowHeight)));
                    g.DrawPath(mainPen, myPath);
                    // right
                    myPath.Reset();
                    myPath.AddLine(
                        new Point(spineOffset + 2 * columnWidth + weekendOffset - lineweightOverlap,
                            borderOffset + dayAboveOffset + Convert.ToInt32(36 * rowHeight)),
                        new Point(
                            spineOffset + 4 * columnWidth + weekendOffset + lineweightOverlap,
                            borderOffset + dayAboveOffset + Convert.ToInt32(36 * rowHeight)));
                    g.DrawPath(mainPen, myPath);

                    // 3rd from bottom
                    // left
                    myPath.Reset();
                    myPath.AddLine(
                        new Point(spineOffset - lineweightOverlap,
                            borderOffset + dayAboveOffset + Convert.ToInt32(35 * rowHeight)),
                        new Point(
                            spineOffset + 2 * columnWidth + lineweightOverlap,
                            borderOffset + dayAboveOffset + Convert.ToInt32(35 * rowHeight)));
                    g.DrawPath(mainPen, myPath);
                    // right
                    myPath.Reset();
                    myPath.AddLine(
                        new Point(spineOffset + 2 * columnWidth + weekendOffset - lineweightOverlap,
                            borderOffset + dayAboveOffset + Convert.ToInt32(35 * rowHeight)),
                        new Point(
                            spineOffset + 4 * columnWidth + weekendOffset + lineweightOverlap,
                            borderOffset + dayAboveOffset + Convert.ToInt32(35 * rowHeight)));
                    g.DrawPath(mainPen, myPath);

                    // top
                    // left
                    myPath.Reset();
                    myPath.AddLine(
                        new Point(spineOffset - lineweightOverlap,
                            borderOffset + dayAboveOffset),
                        new Point(
                            spineOffset + 2 * columnWidth + lineweightOverlap,
                            borderOffset + dayAboveOffset));
                    g.DrawPath(mainPen, myPath);
                    // right
                    myPath.Reset();
                    myPath.AddLine(
                        new Point(spineOffset + 2 * columnWidth + weekendOffset - lineweightOverlap,
                            borderOffset + dayAboveOffset),
                        new Point(
                            spineOffset + 4 * columnWidth + weekendOffset + lineweightOverlap,
                            borderOffset + dayAboveOffset));
                    g.DrawPath(mainPen, myPath);

                    // 2nd from top
                    // left
                    myPath.Reset();
                    myPath.AddLine(
                        new Point(spineOffset - lineweightOverlap,
                            borderOffset + dayAboveOffset + Convert.ToInt32(rowHeight)),
                        new Point(
                            spineOffset + 2 * columnWidth + lineweightOverlap,
                            borderOffset + dayAboveOffset + Convert.ToInt32(rowHeight)));
                    g.DrawPath(mainPen, myPath);
                    // right
                    myPath.Reset();
                    myPath.AddLine(
                        new Point(spineOffset + 2 * columnWidth + weekendOffset - lineweightOverlap,
                            borderOffset + dayAboveOffset + Convert.ToInt32(rowHeight)),
                        new Point(
                            spineOffset + 4 * columnWidth + weekendOffset + lineweightOverlap,
                            borderOffset + dayAboveOffset + Convert.ToInt32(rowHeight)));
                    g.DrawPath(mainPen, myPath);

                    #endregion

                    #region Thin Black Lines
                    // all of ones in between
                    // left
                    for (int a = 1; a <= 16; a++)
                    {
                        myPath.Reset();
                        myPath.AddLine(
                            new Point(spineOffset - lineweight2Overlap,
                                borderOffset + dayAboveOffset + Convert.ToInt32((1 + 2 * a) * rowHeight)),
                            new Point(
                                spineOffset + 2 * columnWidth + lineweight2Overlap,
                                borderOffset + dayAboveOffset + Convert.ToInt32((1 + 2 * a) * rowHeight)));
                        g.DrawPath(ThinBlackPen, myPath);
                    }
                    // right
                    for (int a = 1; a <= 16; a++)
                    {
                        myPath.Reset();
                        myPath.AddLine(
                            new Point(spineOffset + 2 * columnWidth + weekendOffset - lineweight2Overlap,
                                borderOffset + dayAboveOffset + Convert.ToInt32((1 + 2 * a) * rowHeight)),
                            new Point(
                                spineOffset + 4 * columnWidth + weekendOffset + lineweight2Overlap,
                                borderOffset + dayAboveOffset + Convert.ToInt32((1 + 2 * a) * rowHeight)));
                        g.DrawPath(ThinBlackPen, myPath);
                    }
                    #endregion

                    #endregion

                    #region Text
                    // Tasks
                    for (int a = 0; a < 2; a++)
                    {
                        g.DrawString("Tasks", new Font("Times New Roman", fontNumber(dpi, 5)),
                           b, new Rectangle(spineOffset + a * columnWidth, borderOffset + dayAboveOffset + Convert.ToInt32(35 * rowHeight),
                               columnWidth, Convert.ToInt32(rowHeight)), format1);
                    }
                    g.DrawString("Tasks", new Font("Times New Roman", fontNumber(dpi, 5)),
                           b, new Rectangle(spineOffset + 2 * columnWidth + weekendOffset, borderOffset + dayAboveOffset + Convert.ToInt32(35 * rowHeight),
                               columnWidth * 2, Convert.ToInt32(rowHeight)), format1);

                    // Days of the Week
                    // left
                    for (int a = 5; a <= 6; a++)
                    {
                        g.DrawString(DayFromNumber(a), new Font("Times New Roman", fontNumber(dpi, 5)),
                           b, new Rectangle(spineOffset + (a - 5) * columnWidth, borderOffset + dayAboveOffset, columnWidth, Convert.ToInt32(rowHeight)), format1);
                    }
                    // right
                    for (int a = 7; a <= 8; a++)
                    {
                        g.DrawString(DayFromNumber(a), new Font("Times New Roman", fontNumber(dpi, 5)),
                           b, new Rectangle(spineOffset + (a - 5) * columnWidth + weekendOffset, borderOffset + dayAboveOffset, columnWidth, Convert.ToInt32(rowHeight)), format1);
                    }

                    // Date Above
                    // left
                    for (int a = 5; a <= 6; a++)
                    {
                        g.DrawString(MonthFromNumber(CurrentWeekDate.AddDays(a - 1).Month) + " " + CurrentWeekDate.AddDays(a - 1).Day.ToString(), 
                            new Font("Times New Roman", fontNumber(dpi, 3)),
                           b, new Rectangle(spineOffset + (a - 5) * columnWidth, borderOffset, columnWidth, dayAboveOffset), format1);
                    }
                    // right
                    for (int a = 7; a <= 8; a++)
                    {
                        g.DrawString(MonthFromNumber(CurrentWeekDate.AddDays(a - 1).Month) + " " + CurrentWeekDate.AddDays(a - 1).Day.ToString(), 
                            new Font("Times New Roman", fontNumber(dpi, 3)),
                           b, new Rectangle(spineOffset + (a - 5) * columnWidth + weekendOffset, borderOffset, columnWidth, dayAboveOffset), format1);
                    }
                    #endregion

                    #region Events

                    counter = 0;
                    while (table[0, counter] != null)
                    {
                        for (int a = 4; a <= 5; a++)
                        {
                            // Thursday to Friday

                            // If it is the specific day OR if it is a weekly event
                            if ((table[1, counter] == StringFromDateTime(CurrentWeekDate.AddDays(a))) ||
                                (DateTimeFromString(table[1, counter]).DayOfWeek == CurrentWeekDate.AddDays(a).DayOfWeek
                                && table[4, counter] == "Yes") && CurrentWeekDate.AddDays(a) > DateTimeFromString(table[1, counter]))
                            {
                                // Get Top Height
                                int hour = Convert.ToInt32(table[2, counter].Substring(0, InString(table[2, counter], ":")));
                                int minute = Convert.ToInt32(table[2, counter].Substring(InString(table[2, counter], ":") + 1,
                                    table[2, counter].Length - (InString(table[2, counter], ":") + 1)));
                                int eventTopHeight = Convert.ToInt32(borderOffset + dayAboveOffset + rowHeight * ((3f + 2f * hour - 14f) + (2f * minute / 60f)));

                                // Get Bottom Height
                                hour = Convert.ToInt32(table[3, counter].Substring(0, InString(table[3, counter], ":")));
                                minute = Convert.ToInt32(table[3, counter].Substring(InString(table[3, counter], ":") + 1,
                                    table[3, counter].Length - (InString(table[3, counter], ":") + 1)));
                                int eventBottomHeight = Convert.ToInt32(borderOffset + dayAboveOffset + rowHeight * ((3f + 2f * hour - 14f) + (2f * minute / 60f)));

                                // Grey Rectangle
                                g.FillRectangle(new SolidBrush(Color.LightGray), new Rectangle(spineOffset + (a - 4) * columnWidth + lineweightOverlap,
                                        eventTopHeight, columnWidth - 2 * lineweightOverlap, eventBottomHeight - eventTopHeight + 1));

                                // Black Lines
                                // Top Black Line
                                myPath.Reset();
                                myPath.AddLine(
                                    new Point(spineOffset + (a - 4) * columnWidth - lineweightOverlap,
                                        eventTopHeight),
                                    new Point(
                                        spineOffset + (a - 3) * columnWidth + lineweightOverlap,
                                        eventTopHeight));
                                g.DrawPath(ThinBlackPen, myPath);
                                // Bottom Black Line
                                myPath.Reset();
                                myPath.AddLine(
                                    new Point(spineOffset + (a - 4) * columnWidth,
                                        eventBottomHeight),
                                    new Point(
                                        spineOffset + (a - 3) * columnWidth,
                                        eventBottomHeight));
                                g.DrawPath(ThinBlackPen, myPath);

                                // Name
                                g.DrawString(table[0, counter], new Font("Times New Roman", Convert.ToInt32(800f / 87f * fontMultiplier)),
                                   b, new Rectangle(spineOffset + (a - 4) * columnWidth,
                                        eventTopHeight, columnWidth, Convert.ToInt32(rowHeight)), format2);
                            }
                        }

                        for (int a = 6; a <= 7; a++)
                        {
                            // Saturday to Sunday

                            // If it is the specific day OR if it is a weekly event
                            if ((table[1, counter] == StringFromDateTime(CurrentWeekDate.AddDays(a))) ||
                                (DateTimeFromString(table[1, counter]).DayOfWeek == CurrentWeekDate.AddDays(a).DayOfWeek
                                && table[4, counter] == "Yes") && CurrentWeekDate.AddDays(a) > DateTimeFromString(table[1, counter]))
                            {
                                // Get Top Height
                                int hour = Convert.ToInt32(table[2, counter].Substring(0, InString(table[2, counter], ":")));
                                int minute = Convert.ToInt32(table[2, counter].Substring(InString(table[2, counter], ":") + 1,
                                    table[2, counter].Length - (InString(table[2, counter], ":") + 1)));
                                int eventTopHeight = Convert.ToInt32(borderOffset + dayAboveOffset + rowHeight * ((3f + 2f * hour - 14f) + (2f * minute / 60f)));

                                // Get Bottom Height
                                hour = Convert.ToInt32(table[3, counter].Substring(0, InString(table[3, counter], ":")));
                                minute = Convert.ToInt32(table[3, counter].Substring(InString(table[3, counter], ":") + 1,
                                    table[3, counter].Length - (InString(table[3, counter], ":") + 1)));
                                int eventBottomHeight = Convert.ToInt32(borderOffset + dayAboveOffset + rowHeight * ((3f + 2f * hour - 14f) + (2f * minute / 60f)));

                                // Grey Rectangle
                                g.FillRectangle(new SolidBrush(Color.LightGray), new Rectangle(spineOffset + weekendOffset + (a - 4) * columnWidth + lineweightOverlap,
                                        eventTopHeight, columnWidth - 2 * lineweightOverlap, eventBottomHeight - eventTopHeight + 1));

                                // Black Lines
                                // Top Black Line
                                myPath.Reset();
                                myPath.AddLine(
                                    new Point(spineOffset + weekendOffset + (a - 4) * columnWidth - lineweightOverlap,
                                        eventTopHeight),
                                    new Point(
                                        spineOffset + weekendOffset + (a - 3) * columnWidth + lineweightOverlap,
                                        eventTopHeight));
                                g.DrawPath(ThinBlackPen, myPath);
                                // Bottom Black Line
                                myPath.Reset();
                                myPath.AddLine(
                                    new Point(spineOffset + weekendOffset + (a - 4) * columnWidth,
                                        eventBottomHeight),
                                    new Point(
                                        spineOffset + weekendOffset + (a - 3) * columnWidth,
                                        eventBottomHeight));
                                g.DrawPath(ThinBlackPen, myPath);

                                // Name
                                g.DrawString(table[0, counter], new Font("Times New Roman", Convert.ToInt32(800f / 87f * fontMultiplier)),
                                   b, new Rectangle(spineOffset + weekendOffset + (a - 4) * columnWidth,
                                        eventTopHeight, columnWidth, Convert.ToInt32(rowHeight)), format2);
                            }
                        }

                        counter++;
                    }

                    #endregion


                    pageCount++;
                    bm1.Save(imageLocation + "page" + pageCount.ToString() + fileFormat, ImageFormat.Png);
                    #endregion

                    // Edit date
                    CurrentWeekDate = CurrentWeekDate.AddDays(7);
                }

                //**
                #region Make PDF

                /*
                // Eliminate planner if one already exists
                FileStream fs;
                if (File.Exists(plannerPath) == true)
                {
                    File.Delete(plannerPath);
                }
                */
                int pageNum = pageCount;
                pageCount = 0;

                // load the tiff image and count the total pages  
                Bitmap bitmap;
                int total;

                iTextSharp.text.Document doc = new iTextSharp.text.Document(iTextSharp.text.PageSize.LETTER, 0, 0, 0, 0);
                FileStream fs = new FileStream(plannerPath, FileMode.Create);
                PdfWriter writer = PdfWriter.GetInstance(doc, fs);

                doc.Open();

                // First page is blank for printing reasons
                doc.Add(new iTextSharp.text.Chunk(""));

                while (pageCount < pageNum)
                {

                    #region Page 1

                    doc.NewPage();
                    pageCount++;

                    bitmap = new Bitmap(imageLocation + "page" + pageCount.ToString() + fileFormat);
                    total = bitmap.GetFrameCount(System.Drawing.Imaging.FrameDimension.Page);

                    iTextSharp.text.Image img;
                    for (int k = 0; k < total; ++k)
                    {
                        bitmap.SelectActiveFrame(System.Drawing.Imaging.FrameDimension.Page, k);
                        img = iTextSharp.text.Image.GetInstance(bitmap, ImageFormat.Bmp);
                        // scale the image to fit in the page  
                        img.ScaleToFit(doc.PageSize.Width, doc.PageSize.Height);
                        img.SetAbsolutePosition(0, 0);
                        doc.Add(img);
                    }
                    #endregion

                    #region Page 2

                    doc.NewPage();
                    pageCount++;

                    bitmap = new Bitmap(imageLocation + "page" + pageCount.ToString() + fileFormat);
                    total = bitmap.GetFrameCount(System.Drawing.Imaging.FrameDimension.Page);

                    for (int k = 0; k < total; ++k)
                    {
                        bitmap.SelectActiveFrame(System.Drawing.Imaging.FrameDimension.Page, k);
                        img = iTextSharp.text.Image.GetInstance(bitmap, ImageFormat.Bmp);
                        // scale the image to fit in the page  
                        img.ScaleToFit(doc.PageSize.Width, doc.PageSize.Height);
                        img.SetAbsolutePosition(0, 0);
                        doc.Add(img);
                    }
                    #endregion

                }

                doc.Close();

                Process.Start(plannerPath);

                #endregion

                isImageClicked = false;
            }
        }

        private void dTPStartWeek_ValueChanged(object sender, EventArgs e)
        {
            DateTime StartWeekDate = DateTimeFromString(dTPStartWeek.Text);
            DateTime EndWeekDate = DateTimeFromString(dTPEndWeek.Text);

            if (StartWeekDate > EndWeekDate) dTPEndWeek.Text = dTPStartWeek.Text;
        }

        private void cBLayoutType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cBLayoutType.SelectedItem == "Separation")
            {
                tBDPI.Text = "381";
                tBThickLineweight.Text = ".6";
                tBThinLineweight.Text = ".3";
                tBFontMultiplier.Text = ""; //****

                tBPageHeight.Text = "279";
                tBPageWidth.Text = "216";

                tBBorderOffset.Text = "10";
                tBSpineOffset.Text = "20";
                tBHourWidth.Text = "6";
                tBTaskNoteOffset.Text = "5";

                tBTaskHeight.Text = "24";
                tBTaskOffset.Text = "6";

                tBRoleWidthToPoint.Text = "44";
                tBRoleWidthToEdge.Text = "34";
                tBRoleLineWidth.Text = "6";
                tBRoleHeight.Text = "18";

                tBRoleTaskOverlap.Text = "4";
                tBTaskHeadingHeight.Text = "6";
                tBTaskHeadingOffset.Text = "3";

                tBWeekendOffset.Text = "10";
                tBDayAboveOffset.Text = "6";
            }
            else if (cBLayoutType.SelectedItem == "No Separation")
            {
                tBDPI.Text = "381";
                tBThickLineweight.Text = ".6";
                tBThinLineweight.Text = ".3";
                tBFontMultiplier.Text = ""; //****

                tBPageHeight.Text = "279";
                tBPageWidth.Text = "216";

                tBBorderOffset.Text = "10";
                tBSpineOffset.Text = "20";
                tBHourWidth.Text = "6";
                tBTaskNoteOffset.Text = "5";

                tBTaskHeight.Text = "24";
                tBTaskOffset.Text = "6";

                tBRoleWidthToPoint.Text = "44";
                tBRoleWidthToEdge.Text = "34";
                tBRoleLineWidth.Text = "6";
                tBRoleHeight.Text = "18";

                tBRoleTaskOverlap.Text = "4";
                tBTaskHeadingHeight.Text = "6";
                tBTaskHeadingOffset.Text = "3";

                tBWeekendOffset.Text = "0";
                tBDayAboveOffset.Text = "6";
            }

        }

        private void btnClearEvents_Click(object sender, EventArgs e)
        {
            dGVEvents.Rows.Clear();

            // Txt file
            FileStream fs = File.Create(dGVRecordPath);
            fs.Close();
        }

        public void TxtFileToStringArray(string txtFilePath, string[] stringArray)
        {
            int counter = 0;

            FileStream fs = new FileStream(txtFilePath, FileMode.Open);
            StreamReader sr = new StreamReader(fs);

            while (sr.Peek() != -1)
            {
                stringArray[counter] = sr.ReadLine();
                counter++;
            }

            sr.Close();
            fs.Close();
        }


    }
}
