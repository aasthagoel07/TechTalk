using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TechTalk.Models;

namespace TechTalk.Controllers
{
    public class LoginController : ApiController
    {
        private TechtalkDbEntities db = new TechtalkDbEntities();

        public IHttpActionResult Login(Admin_Login user)
        {
            Admin_Login foundUser = db.Admin_Login.Where(a => a.Username.Equals(user.Username)).FirstOrDefault();
            if (foundUser == null)
            {
                return NotFound();
            }
            else if (foundUser != null && user.Password.Equals(foundUser.Password))
            {
                //if (foundUser.UserType == "admin")
                //{
                //    //Return admin
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.Accepted, "admin"));
                //        }
                //        else
                //            return ResponseMessage(Request.CreateResponse(HttpStatusCode.Accepted, "presenter"));
                //    }
                //    else // When user found but password incorrect
               //       return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.Ambiguous, "Password Incorrect"));
            }
            else
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.Ambiguous, "Password Incorrect"));
            }
        }
    }
}
