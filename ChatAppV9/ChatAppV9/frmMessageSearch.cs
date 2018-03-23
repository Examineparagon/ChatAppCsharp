using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/// <summary>
/// 1. Create Dictionary from database / DT or DS
/// 2. per session OR all entries.
/// 3. Join all tables and columns in DGV
/// </summary>

namespace ChatAppV9
{
    public partial class frmMessageSearch : Form
    {
        public frmMessageSearch()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();//

            DataTable dt = DAL.ExecStoredProcedure("spMsgSearch", sqlParams);//run dal , get a dt back

            //DataSet dr = DalDataSet.ExecStoredProc("spMsgSearch", sqlParams);

            Dictionary<string, string> dic = new Dictionary<string, string>();//create new dict

            foreach (DataRow dr1 in dt.Rows)//for each row in the datatable add a row from the entries within
            {
                string key = dr1[0].ToString() + "-" + dr1[0].ToString();
                string value = dr1[0].ToString() + "-" + dr1[0].ToString();
                if (!dic.ContainsKey(key))
                {
                    dic.Add(key, value);
                }

            }//end foreach

            dataGridView1.DataSource = dic.ToList();



        }////button1_Click

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }// public partial class frmMessageSearch : Form
}//namespace ChatAppV9

//CREATE PROCEDURE[dbo].[GetSalesByDateRange]
//@dateFrom DATETIME,
//   @dateTo DATETIME
//AS
//BEGIN
//SELECT
//    S.Id,
//    S.Date,
//    I.Name,
//    I.Price
//FROM tblSIASales S
//INNER JOIN tblSIAInventory I
//    ON S.InventoryId = I.Id
//WHERE
//    S.Date BETWEEN @dateFrom AND @dateTo
//END