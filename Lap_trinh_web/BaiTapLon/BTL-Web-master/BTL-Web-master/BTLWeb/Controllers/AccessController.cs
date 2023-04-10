﻿using Microsoft.AspNetCore.Mvc;
using BTLWeb.Models;

namespace BTLWeb.Controllers
{
    public class AccessController : Controller
    {
        QlbanMayAnhContext db = new QlbanMayAnhContext();
        [HttpGet]
        public ActionResult Login()
        {
            if (HttpContext.Session.GetString("Username") == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(TUser user)
        {
            if (HttpContext.Session.GetString("Username")==null)
            {


                /*var f_password = GetMD5(password);*/
                var data = db.TUsers.Where(s => s.Username.Equals(user.Username) && s.Password.Equals(user.Password)).FirstOrDefault();
                if (data != null)
                {
                    //add session

                    HttpContext.Session.SetString("Username", data.Username.ToString());
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.error = "Login failed";
                    return RedirectToAction("Login", "Access");
                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        //POST: Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(TUser user)
        {
            if (ModelState.IsValid)
            {
                var check = db.TUsers.FirstOrDefault(s => s.Username == user.Username);
                if (check == null)
                {
                    db.TUsers.Add(user);
                    db.SaveChanges();
                    return RedirectToAction("Login", "Access");
                }
                else
                {
                    ViewBag.error = "Username already exists";
                    return View();
                }


            }
            return View();


        }
        public ActionResult Logout()
        {
            HttpContext.Session.Clear();//remove session
            HttpContext.Session.Remove("Username");
            return RedirectToAction("Login", "Access");
        }
    }
}
