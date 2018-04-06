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
using System.Net.Mail;//sending email 



/// <summary>
/// STEPS TAKEN TO PRODUCE DB FOR REF new items 
/// Constring held in settings.settings, 
/// system config ref added, 
/// data set added
/// procMsgSent - getdate()added to table meaning no need to affect date, upg to datetimeoffset
/// dal changed to dataset instead, windows all load from that stored proc
/// 
/// TODO ADD DICTIONARY OF CURRENT SESSION, ALLOW SEARCH
/// </summary>
namespace ChatAppV9






{
    public partial class frmRegistration : Form//REGISTRATION PAGE
    {
        public frmRegistration()
        {
            InitializeComponent();
            txtUser.Focus();

        }

        //Register user on db
        private void Register()


        {

           string SetValuetxtUser1 = txtUser.Text.ToLower();
           //SetValuetxtUser1 = SetValuetxtUser1.Trim();
           string  SetValuetxtPass1 = txtPass.Text.Trim();

            //confirm email is legit and send a confirmation email upon account creation)
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter param1 = new SqlParameter("Username", SetValuetxtUser1);//take username and pw, add them to db
            SqlParameter param2 = new SqlParameter("Password", SetValuetxtPass1);
            sqlParams.Add(param1);
            sqlParams.Add(param2);
            DataTable dt = DAL.ExecStoredProcedure("UserAdd", sqlParams);
            MessageBox.Show("Registation Successful");
            frmLogin objFrmMain1 = new frmLogin();
            this.Hide();
            objFrmMain1.Show();

        }//end registration



        private void SendEmail()//send email cofirmation method todo IMPROVE
        {

            SmtpClient client = new SmtpClient();
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            client.Timeout = 10000;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("ollysfirstemailacct@gmail.com", "brookfield136");//email credentials, TODO improve

            MailMessage mm = new MailMessage("donotreply@gmail.com", txtUser.Text.Trim(), "Registration Successful", "Registration Successful");//TXTUSER IS JUST MY EMAIL text BOX
            mm.BodyEncoding = UTF8Encoding.UTF8;
            mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

            client.Send(mm);
        }
           

        
        private bool IsValidEmail(string email)//check if email is valid
        {
            try
            {
                var addr = new MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
                
            }//end catch
        }//end isvalisemail

       
        //useful for testing, go from sub to log in page 
        private void btnLogin_Click(object sender, EventArgs e)//GO TO LOG IN SCREEN FROM REG
        {

            //return frmlogin
            frmLogin objFrmMain1 = new frmLogin();
            this.Hide();
            objFrmMain1.Show();

        }// end btn login

        //submit registration info, generate an account with ID and takes you to the main chat window
        private void btnSubmit_Click(object sender, EventArgs e)/// USING DAL , IF BOXES EMPTY, ELSE PWORD MISMATCH = ERRMSG. 
                                                                ///
        {
            if (txtUser.Text.Trim() == "" || txtPass.Text.Trim() == "")//added trim, removes CHANce space needs 
            {//TEXT boxes cannot be empty
                MessageBox.Show("Registration failure need Correct Email / password");
            }// end if txt empy

            else if (txtPass.Text.Trim() != txtConf.Text.Trim())
            {//password must match at creation
                MessageBox.Show("Registration failed passwords must match");
            }//end else if pw match



            else 

            {

                List<SqlParameter> sqlParams = new List<SqlParameter>();//sql params 
                //insert to add date range in to list
                SqlParameter sqlParam1 = new SqlParameter("Username", txtUser.Text.Trim());//take username and verify it is not duped
                sqlParams.Add(sqlParam1);

                DataTable dt = DAL.ExecStoredProcedure("GetUsers", sqlParams);
                int i = dt.Rows.Count;

                if (i == 1)//checks to see if the email already exists if id does then
                {
                    MessageBox.Show("Account has already been registered");//no dupes. 
                    txtUser.Text = "";//clear all boxes, focus on user
                    txtPass.Text = "";
                    txtConf.Text = "";
                    txtUser.Focus();
                }//end iff acct already reg'ed

                else if (IsValidEmail(txtUser.Text) == false)//confirms email is at least in a valid shape  but cannot ultimately verify without outside conf
                {

                    MessageBox.Show("Please use a Valid Email address");
                    txtUser.Clear();
                    txtPass.Clear();
                    txtConf.Clear();
                    txtUser.Focus();
                }//end else if isemailvalid
                 
                else
                {///RUN REG METHOD//Login successful msg, ok goes to mainform CHAT WINDOW
                    Register();//registration method, 
                    SendEmail();
                }//end else reg success
            }//end else get users param
        }//end btn click

      

       
    }//end form
}//end namespace

