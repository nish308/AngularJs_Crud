using AngularJs_Crud.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AngularJs_Crud.Controllers
{
    public class HomeController : Controller
    {
        DataAccess Objda = new DataAccess();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ShowData()
        {
            return View();
        }

        public ActionResult UpdateData(int id)
        {

            return View();
        }

        public JsonResult Add_Record(Register rs)
        {
            string res = string.Empty;

            try
            {
                Objda.Add_record(rs);
                res = "Inserted";
            }
            catch (Exception)
            {
                res = "Failed";
            }
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        //public JsonResult UpdateRecord(Register rs)
        //{
        //    string res = string.Empty;

        //    try
        //    {
        //        Objda.update_record(rs);
        //        res = "Updated";
        //    }
        //    catch (Exception)
        //    {
        //        res = "Failed";
        //    }
        //    return Json(res, JsonRequestBehavior.AllowGet);
        //}

        [HttpPost]
        public ActionResult UpdateRecord(Register rs)
        {
            if (ModelState.IsValid)
            {
                DataAccess objDB = new DataAccess();
                string result = objDB.update_record(rs);
                TempData["result2"] = result;
                ModelState.Clear();
                return RedirectToAction("Get_Data");
            }
            else
            {
                ModelState.AddModelError("", "Error in saving data");
                return View();
            }
        }

        public JsonResult DeleteRecord(int id)
        {
            string res = string.Empty;

            try
            {
                Objda.deletedata(id);
                res = "Data Deleted";
            }
            catch (Exception)
            {
                res = "Failed";
            }
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Get_Data()
        {
            DataSet ds = Objda.get_record();
            List<Register> registers = new List<Register>();
            foreach(DataRow dr in ds.Tables[0].Rows)
            {
                registers.Add(new Register
                {
                    Sr_no = Convert.ToInt32(dr["Sr_no"]),
                    Email = dr["Email"].ToString(),
                    Password = dr["Password"].ToString(),
                    Name = dr["Name"].ToString(),
                    Address = dr["Address"].ToString(),
                    City = dr["City"].ToString()
                });
            }
            return Json(registers, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Get_DataBy_Id(int id)
        {
            DataSet ds = Objda.get_recordbyid(id);
            List<Register> registers = new List<Register>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                registers.Add(new Register
                {
                    Sr_no = Convert.ToInt32(dr["Sr_no"]),
                    Email = dr["Email"].ToString(),
                    Password = dr["Password"].ToString(),
                    Name = dr["Name"].ToString(),
                    Address = dr["Address"].ToString(),
                    City = dr["City"].ToString()
                });
            }
            return Json(registers, JsonRequestBehavior.AllowGet);
        }
    }
}