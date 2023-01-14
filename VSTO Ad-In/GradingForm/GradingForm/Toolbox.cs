using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using Devart.Data.MySql;
using Microsoft.Office.Interop.Excel;

namespace GradingForm
{
    /*
     *  This class contains a ton of helper functions to be used in main sheet
     * 
     * 
     */

    public class Toolbox
    {
        /*
         *  Name: FormatCell
         *  Created: Jan-13-2023
         *  Description: This function takes basic values for fromatting string then formats that string. 
         * 
         */
        public void FormatCell(string cell, Excel.Worksheet worksheet, string value, Boolean isbold, System.Drawing.Color color, int textSize, Microsoft.Office.Interop.Excel.XlHAlign allignment )
        {
            Excel.Range range;
            range = worksheet.get_Range(cell);
            range.Value = value;
            range.Font.Bold = isbold;
            range.Font.Color = color;
            range.Font.Size = textSize;
            range.HorizontalAlignment = allignment;
        }

    public Excel.Worksheet GetActiveSheet()
    {
        Excel.Application application = new Excel.Application();
        Excel.Workbook workbook = application.ActiveSheet as Excel.Workbook;
        return (Excel.Worksheet)workbook.ActiveSheet;
    }

    public MySqlDataReader GetDataFromDatabase(string queryString)
        {
            // Could do this in a single line but this is easier to read
            MySqlConnection connection = new MySqlConnection();
            connection.Host = "mtl104.greengeeks.net";
            connection.Port = 3306;
            connection.UserId = "jaronlor_gradingform_user";
            connection.Password = "$@IkxECNPzr,";
            connection.Database = "jaronlor_Grading_Form";

            MySqlCommand mySqlCommand = new MySqlCommand(queryString, connection);

            MySqlDataReader mySqlDataReader;
            try
            {
                connection.Open();
                mySqlCommand.ExecuteNonQuery();
                mySqlDataReader = mySqlCommand.ExecuteReader();
            }
            catch (MySqlException MySqlError)
            {
                mySqlDataReader = null;
                Console.WriteLine(MySqlError.Message);
            }
            return mySqlDataReader;
        }


    }
}
