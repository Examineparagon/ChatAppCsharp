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

        public static string SetValuetxtUser = "";//set value for txtUser to be used accross the app
        public static string SetValuetxtPass = "";

        private void btnLog_Click(object sender, EventArgs e)
        {

            SetValuetxtUser = txtUser.Text.ToLower();//lowercase email entry, keeps things simple, removes some errors
            SetValuetxtUser = SetValuetxtUser.Trim();//trim removes blank spaces around entries
            SetValuetxtPass = txtPass.Text.Trim();

            List<SqlParameter> sqlParams = new List<SqlParameter>();


            SqlParameter param1 = new SqlParameter("@User", txtUser.Text);//take username and password, in our case an email, 
            SqlParameter param2 = new SqlParameter("@Pass", txtPass.Text);//

            sqlParams.Add(param1);
            sqlParams.Add(param2);

            DataTable dt = new DataTable();

            dt = DAL.ExecStoredProcedure("UserLogin", sqlParams);//CHECKS pass and user correct



            if (dt.Rows.Count == 1)
            {
                MessageBox.Show("Welcome, " + txtUser.Text.Trim() + ".");//Welcome and open new page. 
                frmMain objFrmMain = new frmMain();
                this.Hide();
                objFrmMain.Show();
            }
            else
                MessageBox.Show("Email/Password Incorrect.");//incorrect, show and prompt



        }
    



    

        private void btnExit_Click(object sender, EventArgs e)//exit app
        {
            this.Close();
        }

        private void btnReg_Click(object sender, EventArgs e)//got to registration page
        {
            frmRegistration objFrmMain = new frmRegistration();
            this.Hide();
            objFrmMain.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            frmMessageSearch objFrmMain = new frmMessageSearch();
            this.Hide();
            objFrmMain.Show();
        }
    }
}
