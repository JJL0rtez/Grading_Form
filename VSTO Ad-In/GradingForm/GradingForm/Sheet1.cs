using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml;
using Devart.Data.MySql;
using Microsoft.Office.Interop.Excel;
using Microsoft.Vbe.Interop;
using Microsoft.VisualStudio.Tools.Applications.Runtime;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using Excel = Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;

namespace GradingForm
{
    public partial class Sheet1
    {
        // Create Toolbox object for use in classes
        Toolbox toolbox = new Toolbox();

        private void Sheet1_Startup(object sender, System.EventArgs e)
        {
            // Create student form
            CreateStudentForm();
            // Create grading form

            // Create techniques/technique types Form

            // Create options form

        }
           
        private void Sheet1_Shutdown(object sender, System.EventArgs e)
        {

        }

        #region VSTO Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(Sheet1_Startup);
            this.Shutdown += new System.EventHandler(Sheet1_Shutdown);
        }


        private void CreateStudentForm()
        {
            try {
                // Helper Varibles to be used throughout function
                Excel.Range range;

                // Create worksheet
                Excel.Worksheet studentWorksheet;
                studentWorksheet = (Excel.Worksheet)Globals.ThisWorkbook.Worksheets.Add();
                studentWorksheet.Name = "Students";
                studentWorksheet.Visible = Microsoft.Office.Interop.Excel.XlSheetVisibility.xlSheetVisible;
                studentWorksheet.Activate();

                // Format worksheet
                //  Set background and line color of all shown cells to "Dark Gray"
                range = studentWorksheet.get_Range("A1", "Z100");
                range.Interior.Color = System.Drawing.Color.DarkGray;

                //  Set and format text headers using toolbox.FormatCell function
                toolbox.FormatCell("B2", studentWorksheet, "Students", true, System.Drawing.Color.Black, 20, Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter);
                toolbox.FormatCell("B4", studentWorksheet, "Name", true, System.Drawing.Color.Black, 14, Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter);
                toolbox.FormatCell("C4", studentWorksheet, "Belt Level", true, System.Drawing.Color.Black, 14, Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter);
                toolbox.FormatCell("D4", studentWorksheet, "Email", true, System.Drawing.Color.Black, 14, Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter);
                toolbox.FormatCell("E4", studentWorksheet, "Phone #", true, System.Drawing.Color.Black, 14, Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter);
                toolbox.FormatCell("F4", studentWorksheet, "Date Of Birth", true, System.Drawing.Color.Black, 14, Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter);

                studentWorksheet.get_Range("B4", "F4").Borders.Color = System.Drawing.Color.Black;

                // Populate data from persons table


                /*
                 * 
                 * Database reference
                 * 
                 * CREATE TABLE Persons(
                 *    personID INT AUTO_INCREMENT PRIMARY KEY,
                 *     firstName VARCHAR(100),
                 *     lastName VARCHAR(100),
                 *     beltLevelID INT,
                 *     email VARCHAR(100),
                 *     phonenumber VARCHAR(20),
                 *     dateOfBirth DATE,
                 *     canGradeStudents BOOLEAN,
                 *     FOREIGN KEY(beltLevelID) REFERENCES BeltLevel(beltLevelID)
                 * );
                 * 
                 * CREATE TABLE BeltLevel(
                 *     beltLevelID INT AUTO_INCREMENT PRIMARY KEY,
                 *     name VARCHAR(100) NOT NULL,
                 *     beltRank INT NOT NULL UNIQUE
                 *  );
                 * 
                 *  SELECT firstName, lastName, BeltLevel.name, email, phonenumber, dateOfBirth
                 *  FROM Persons
                 *   INNER JOIN BeltLevel ON Persons.beltLevelID = BeltLevel.beltLevelID;
                 *
                 */

                string query = "SELECT firstName, lastName, BeltLevel.name, email, phonenumber, dateOfBirth FROM Persons INNER JOIN BeltLevel ON Persons.beltLevelID = BeltLevel.beltLevelID;";
                MySqlDataReader mySqlDataReader = toolbox.GetDataFromDatabase(query);

                // Data printing starts on row 5 of the worksheet
                int rowIndex = 5;
                // Keep looping till data is exausted
                while (mySqlDataReader.Read())
                {
                    // Lastname, Firstname
                    studentWorksheet.get_Range("B" + rowIndex.ToString()).Value = mySqlDataReader.GetString(1) + ", " + mySqlDataReader.GetString(0);
                    // Belt level name
                    studentWorksheet.get_Range("C" + rowIndex.ToString()).Value = mySqlDataReader.GetString(2);
                    // Email
                    studentWorksheet.get_Range("D" + rowIndex.ToString()).Value = mySqlDataReader.GetString(3);
                    // Phone Number
                    studentWorksheet.get_Range("E" + rowIndex.ToString()).Value = mySqlDataReader.GetString(4);
                    studentWorksheet.get_Range("E" + rowIndex.ToString()).NumberFormat = "[<= 9999999]###-####;###-###-####";
                    // Date of birth
                    studentWorksheet.get_Range("F" + rowIndex.ToString()).Value = mySqlDataReader.GetString(5);
                    studentWorksheet.get_Range("F" + rowIndex.ToString()).NumberFormat = "[$-x-sysdate]dddd, mmmm dd, yyyy";

                    // Apply alternating colors to data
                    if (rowIndex % 2 == 0)
                    {
                        studentWorksheet.get_Range("B" + rowIndex.ToString(), "G" + rowIndex.ToString()).Interior.Color = System.Drawing.Color.LightBlue;
                    }
                    else
                    {
                        studentWorksheet.get_Range("B" + rowIndex.ToString(), "G" + rowIndex.ToString()).Interior.Color = System.Drawing.Color.Gold;
                    }
                    rowIndex++;
                }

                // Add formatting that is consistant across all of the data cells
                range = studentWorksheet.get_Range("B5", "F" + (rowIndex - 1).ToString());
                range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                range.Font.Size = 12;
                range.Font.Bold = false; // This really shouldn't be needed if document is locked out correctly
                range.Borders.Color = System.Drawing.Color.Black;
                range.Columns.AutoFit();



                //ActiveSheet.Shapes.AddShape(msoShapeRectangle, Left:= Range("E2").Left, Top:= Range("E2").Top, Width:= Range("E2").Width, Height:= Range("E2").Height).Select
                //With Selection
                //    .HorizontalAlignment = xlCenter
                //    .VerticalAlignment = xlCenter
                //    .ShapeRange.ShapeStyle = msoShapeStylePreset25
                //    .OnAction = "AddStudentButton"
                //    .ShapeRange(1).TextFrame2.TextRange.Characters.Text = "Add Student"
                //    .ShapeRange.TextFrame2.MarginLeft = 2
                //    .ShapeRange.TextFrame2.MarginRight = 2
                //    .ShapeRange.AlternativeText = "AddStudent"

                // Add "Add student" button
                Shape button = studentWorksheet.Shapes.AddShape(
                    Office.MsoAutoShapeType.msoShapeRectangle,
                    studentWorksheet.get_Range("F2").Left,
                    studentWorksheet.get_Range("F2").Top,
                    studentWorksheet.get_Range("F2").Width,
                    studentWorksheet.get_Range("F2").Height);
                // -1 Will indicate to the click handler that this is the "Add student" button and therefore don't populate the popup
                // window with any data.
                button.AlternativeText = "-1";
                button.OnAction = "HandleUserButtonClick";
                button.TextFrame2.TextRange.Characters.Text = "Add Student";
                // Add "Edit" buttom



                // Add a white Border around the contents
                //     Top Border
                studentWorksheet.get_Range("B1", "G4").Interior.Color = System.Drawing.Color.White;
                //     Left Border
                studentWorksheet.get_Range("A1", "A" + rowIndex.ToString()).Interior.Color = System.Drawing.Color.White;
                //     Right Border
                studentWorksheet.get_Range("H1", "H" + rowIndex.ToString()).Interior.Color = System.Drawing.Color.White;
                //     Bottom Border
                studentWorksheet.get_Range("B" + rowIndex.ToString(), "G" + rowIndex.ToString()).Interior.Color = System.Drawing.Color.White;
            }catch(Exception ex)
            {
                // Add some propper error handling later
                throw ex;
            }
            } 



    
        private void CreateGradingForm()
        {

        }

        private void CreateOptionsForm()
        {

        }

        private void CreateTechniqueForm()
        {

        }


        private void HandleUserButtonClick()
        { 
            EditUser editUser = new EditUser();
            editUser.ShowDialog();
        }
        #endregion

    }
}
