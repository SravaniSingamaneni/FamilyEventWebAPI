using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace FamilyEventWebAPI.Helpers
{
    public class SignInHCls
    {
        public DataTable CheckSignIN_UserData(string Uname, String PWD)
        {
            DataTable data = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
                {
                    con.Open();
                    var procName = "U_API_SignIn";
                    using (SqlCommand cmd = new SqlCommand(procName, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@Flag", "GUD"));
                        cmd.Parameters.Add(new SqlParameter("@Uname", Uname));
                        cmd.Parameters.Add(new SqlParameter("@Password", PWD));
                        SqlDataAdapter da= new SqlDataAdapter(cmd);

                        da.Fill(data);
                    }
                    con.Close();
                }
            }
            catch (Exception e) { throw e; }
            return data;
        }
    }
}