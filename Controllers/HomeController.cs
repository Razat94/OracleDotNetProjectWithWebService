using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

// Add Model
using OracleDotNetProjectwithWebService.Models;

namespace OracleDotNetProjectwithWebService.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "The table below shows content in the 'Employees' table.";
            Model sqldata = new Model();
            sqldata.ModelWebService.getSQLList();
            ViewBag.sqldata = sqldata;
            return View();
        }

        public ActionResult Form()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Form(FormCollection form)
        {
            /*
              Check out this page for various ways to get the view's data in the controller action. 
              https://www.c-sharpcorner.com/UploadFile/3d39b4/getting-data-from-view-to-controller-in-mvc/
            */

            if (String.IsNullOrEmpty(form["FirstName"].ToString()))
            {
                ViewBag.Message = "Error: Don't submit an empty value.";
                return View();
            }
            else
            {
                ViewBag.Message = "Success: Value will be inserted into database";

                Model getFormData = new Model();
                getFormData.ModelWebService.insertIntoSQLLIST(form["FirstName"].ToString());

                return View();
            }
        } // End of Form Post Method
    }
}