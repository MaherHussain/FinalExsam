using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalEksamen.Controllers
{
    public class LogIndController : Controller
    {
        private FinalEksamenDbEntities db = new FinalEksamenDbEntities();
        // GET: LogInd
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(UserTb Myuser)
        {
            UserTb TjekUser = db.UserTbs.Where(u => u.UserName == Myuser.UserName).FirstOrDefault();
            if (TjekUser != null)
            {
                string PassWord = Mycrypt.HashPassword(Myuser.Password, TjekUser.Salt);
                UserTb NewUser = db.UserTbs.Where(u => u.UserName == TjekUser.UserName && u.Password == PassWord).FirstOrDefault();

                if (NewUser != null)
                {
                    Session["UserId"] = NewUser.Id;
                    Session["UserName"] = NewUser.UserName;
                    Session["UserPassword"] = NewUser.Password;
                    Session["UserRole"] = NewUser.Fk_Role;

                    Response.Redirect("~/EventsTbs");
                }
            }
            return View();
        }
    }
}