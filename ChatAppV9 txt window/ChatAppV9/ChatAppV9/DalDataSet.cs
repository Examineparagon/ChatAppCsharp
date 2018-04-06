
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


using System.ComponentModel;

using System.Drawing;

using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ChatAppV9
{
    /// <summary>
    /// This is DAL.   DAL = Data Layer
    /// This object will handle all the calls to the database
    /// this is a static class.  It does not need to be initialized using "new"
    /// </summary>
    public static class DalDataSet
    {
        public static DataSet ExecStoredProc(string spName, List<SqlParameter> sqlParams = null)
        {///list of sql params, init as null, does not have to be sent. We need to send params - date to/from
         ///list sql params = new list of sql params();



            //ChatAppV9.Properties.Settings.connString9
            string strConnect = ConfigurationManager.ConnectionStrings["ChatAppV9.Properties.Settings.connString9"].ToString(); // this is the connection string
            // in solution explorer, right click references, add reference, search "config". First result should be System.Configuration, add a checkmark next to it

            SqlConnection conn1 = new SqlConnection();

            DataSet ds = new DataSet();
            try
            {
                conn1 = new SqlConnection(strConnect);
                conn1.Open();
                SqlCommand command1 = new SqlCommand(spName, conn1);
                command1.CommandType = CommandType.StoredProcedure;
                //command1.Parameters.AddRange(sqlParams.ToArray());
                SqlDataReader dr = command1.ExecuteReader();

                while (!dr.IsClosed)
                    ds.Tables.Add().Load(dr);
                //ToString(dr);

                //ds.Load.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn1.Close();
            }

            return ds;
        }
    }
}

