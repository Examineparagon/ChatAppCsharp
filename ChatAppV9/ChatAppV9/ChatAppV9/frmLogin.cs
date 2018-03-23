using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;//NECESSARY FOR SQL USE

namespace ChatAppV9
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            {//TODO GO THRU DAL 
                SqlConnection sqlcon = new SqlConnection(@"Data Source=LAPTOP-M80T9HMI\SQLEXPRESS;Initial Catalog=pip;
                Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;
                ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

                string query = "Select * from tblLogin Where username = '" + txtUser.Text.Trim() + "'and " +
                    "password = '" + txtPass.Text.Trim() + "' ";


                SqlDataAdapter sda = new SqlDataAdapter(query, sqlcon);

                DataTable dtbl = new DataTable();//Create a data table
                sda.Fill(dtbl);// fill the dtble if both text boxes are accurate 
                               //found in relation to password and username

                if (dtbl.Rows.Count == 1)

                {
                    //MessageBox.Show("Username + Password");//Test purposes only
                    frmMain objFrmMain = new frmMain();
                    this.Hide();
                    objFrmMain.Show();
                }

                else
                {
                    MessageBox.Show("Username or Password failed");
                }
            }

        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'chattAppV9DbDataSet.TblLogin' table. You can move, or remove it, as needed.
            this.tblLoginTableAdapter.Fill(this.chattAppV9DbDataSet.TblLogin);

        }
    }
}
