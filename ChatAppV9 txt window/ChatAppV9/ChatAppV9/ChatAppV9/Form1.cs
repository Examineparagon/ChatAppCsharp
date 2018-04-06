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

///set up account NEED ELSE IF TO CHECK IF USERNAME HAS @
///ADD ID PK LOGIN TO ID FK TBLMSG
// frmLogin = dal , Currently in code connstring. 
///Constring held in settings.settings, system config added, data set added
///



{
    public partial class Form1 : Form//REGISTRATION PAGE
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)//GO TO LOG IN SCREEN FROM REG
        {

            //return frmlogin
            frmLogin objFrmMain1 = new frmLogin();
            this.Hide();
            objFrmMain1.Show();

        }// end btn login

        private void btnSubmit_Click(object sender, EventArgs e)/// USING DAL , IF BOXES EMPTY, ELSE PWORD MISMATCH = ERRMSG. 
        ///
        {
            if (txtUser.Text == "" || txtPass.Text == "")
            {//TEXT boxes cannot be empty
                MessageBox.Show("reg fail need user / pass");
            }

            else if (txtPass.Text != txtConf.Text)
            {//password must match at creation
                MessageBox.Show("reg fail pass must match");
            }

            else//set up account NEED ELSE IF TO CHECK IF USERNAME HAS @ "split"?

            {
                ///
                //****************************************************
                
                    //****************************************************

                    List<SqlParameter> sqlParams = new List<SqlParameter>();
                SqlParameter sqlParam1 = new SqlParameter("Username", txtUser.Text.Trim());
                SqlParameter sqlParam2 = new SqlParameter("Password", txtPass.Text.Trim());
                sqlParams.Add(sqlParam1);
                sqlParams.Add(sqlParam2);
                DataTable dt = DAL.ExecStoredProcedure("UserAdd", sqlParams);


                //Login successful msg, ok goes to mainform
                {///
                    MessageBox.Show("Registation Successful");

                    frmLogin objFrmMain1 = new frmLogin();
                    this.Hide();
                    objFrmMain1.Show();
 }
            }//end else
        }//end btnsub

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'chattAppV9DbDataSet.TblLogin' table. You can move, or remove it, as needed.
            this.tblLoginTableAdapter.Fill(this.chattAppV9DbDataSet.TblLogin);

        }
    }//end form
}//end namespace
