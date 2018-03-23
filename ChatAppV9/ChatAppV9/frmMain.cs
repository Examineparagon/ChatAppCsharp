
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
    public partial class frmMain : Form
    {
        public frmMain()//focus msg prep box, set var defined in lbluser from frmlogin
        {
            InitializeComponent();
            txtMsgPrep.Focus();
            Timer timer = new Timer();
            timer.Interval = (2000); // 1 secs = stops spamming, increase slightly? TODO add button to stop timer

            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }



        private void timer_Tick(object sender, EventArgs e)
        {
            MsgSendTimerTickEvent();
        }//end timer tick


        private void MsgSendTimerTickEvent()//cannot call timer tick as a function so seperate function to act as msg send and msg recieved checker

        {

            txtReadOnly.Clear();
            List<SqlParameter> sqlParams = new List<SqlParameter>();
         
            DataTable data = DAL.ExecStoredProcedure("spRefreshMessages");

            int i = (data.Rows.Count - 1);

            foreach (var row in data.Rows)

            {
                var Id = data.Rows[i][1].ToString();
                //var Created = Convert.ToDateTime(data.Rows[i][1]).ToString("hh:mm:ss tt");
                var Created = (data.Rows[i][3]).ToString();
                var txtMsg = data.Rows[i][2].ToString();


                txtReadOnly.Text += "[" + Id + "]" + "[" + txtMsg + "]" + Created + Environment.NewLine;

                i--;


        }//end FOREACH


            // Allows text to scroll
            txtReadOnly.Select(txtReadOnly.Text.Length - 1, txtReadOnly.Text.Length - 1);
            txtReadOnly.ScrollToCaret();

        }




        //TODO SHOW MSG IN TEXT BOX
        private void txtMsg_Click(object sender, EventArgs e)//write msgprep, send, verify box not empty DAL msg and email to tblMsg
        {

            if (txtMsgPrep.Text == "")
            {//TEXT boxes cannot be empty
                MessageBox.Show("Please enter a message");

                txtMsgPrep.Focus();
            }

            else
            {//currently max 200 chars, no need to allow more in a chat app
                //also prevents someone trying to paste war and peace in to chat field. 

                List<SqlParameter> sqlParams = new List<SqlParameter>();

                SqlParameter sqlParam1 = new SqlParameter("Id", frmLogin.SetValuetxtUser);//GET USERNAME FROM ID BOX
                SqlParameter sqlParam2 = new SqlParameter("MsgText", txtMsgPrep.Text);//send msg
                SqlParameter sqlParam3 = new SqlParameter("MachineName", Environment.MachineName);//add machine name to table

                sqlParams.Add(sqlParam1);//send to dal method and run cmd
                sqlParams.Add(sqlParam2);
                sqlParams.Add(sqlParam3);


                DataTable dt = DAL.ExecStoredProcedure("procMsgSent", sqlParams);//Send the data to the database and populates the row

                MsgSendTimerTickEvent();

                txtMsgPrep.Clear();//clear msg box and place cursor within
                txtMsgPrep.Focus();
            }//end else

        }//private void txtMsg_Click


        private void btnExit_Click(object sender, EventArgs e)//form close
        {
            this.Close();
        }

    }//end 

}//end name space






