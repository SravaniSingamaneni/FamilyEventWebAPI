using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using FamilyEventWebAPI.Models;
using FamilyEventWebAPI.Helpers;
using System.Data;


namespace FamilyEventWebAPI.Controllers
{
    public class SignInController : ApiController
    {
        // GET: SignIn
        [HttpGet]
        [Route("API/CheckUserData")]
        public IHttpActionResult SignInData(string UName, string PassWD)
        {
            ResponseMCls resCls = new ResponseMCls();
            try
            {
                SignInHCls InHCls = new SignInHCls();
                DataTable dt = new DataTable();

                dt = InHCls.CheckSignIN_UserData(UName, PassWD);
                resCls.ResponseCode = dt.Rows[0]["ResponseCode"].ToString();
                resCls.ResponseStatus = dt.Rows[0]["ResponseStatus"].ToString();
                resCls.ResponseMessage = dt.Rows[0]["ResponseMessage"].ToString();
                if (resCls.ResponseStatus == "Error")
                {
                    PostUserData_Into_Login_TB(UName, PassWD);
                }
                if (resCls.ResponseStatus == "Success")
                {
                    PostUserData_Into_Login_TB(UName,PassWD);
                }
            }
            catch (Exception e) { throw e; }

            return Ok(resCls);
        }

        // POST: User login data
        [HttpPost]
        [Route("API/SaveUserLoginData")]
        public IHttpActionResult PostUserData_Into_Login_TB(string UName, string PassWD)
        {
            return Ok();
        }
    }
}