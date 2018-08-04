using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AspnetIdentityTest.Models;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Newtonsoft.Json;
using System.Linq.Dynamic;
using System.Text;
using System.Web.Script.Serialization;
using System.Data.Objects;
using System.Diagnostics;
using System.Reflection;

namespace AspnetIdentityTest.Controllers
{
    public class GridController : Controller
    {

        // GET: Grid
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetData(string sidx, string sord, int page, int rows, string searchString, string searchField,
            string searchOper)
        {
            var db = HttpContext.GetOwinContext().Get<ApplicationDbContext>().SupportRequests;
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;
            var results = db.Select(
                a => new
                {
                    a.ClientName,
                    a.Operator,
                    a.Executor,
                    a.SolutionComment,
                    a.State,
                    a.Text,
                    a.Time

                });
            int totalRecords = results.Count();
            var totalPages = (int) Math.Ceiling((float) totalRecords / (float) rows);


            //todo change sort
            var s = $"it.{sidx} {sord}";
            results = results.OrderBy(s);
            results = results.Skip(pageIndex * pageSize).Take(pageSize);


            if (!string.IsNullOrEmpty(searchString) & !string.IsNullOrEmpty(searchField) &
                !string.IsNullOrEmpty(searchOper))
            {
                if (searchOper == "eq")
                    results = results.Where($"{searchField}=@0", searchString);
                else if (searchOper == "ne")
                    results = results.Where($"{searchField}!=@0", searchString);
                else
                    results = results.Where($"{searchField}.Contains(@0)", searchString);
            }

            var jsondata = new
            {
                total = totalPages,
                page,
                records = db.Count(),
                rows = results
            };
            return Json(jsondata, JsonRequestBehavior.AllowGet);
        }

        public JsonResult CreateRequest(
            [Bind(Exclude = "Operator, Time, SolutionComment, Executor,")] RequestModel rqModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var db = HttpContext.GetOwinContext().Get<ApplicationDbContext>();
                    rqModel.Executor = "";
                    rqModel.Operator = User.Identity.Name;
                    rqModel.SolutionComment = "";
                    rqModel.State = "зарегистрирован";
                    rqModel.Time = DateTime.Now;
                    db.SupportRequests.Add(rqModel);
                    db.SaveChanges();
                    return Json("ok", JsonRequestBehavior.AllowGet);
                }
                else
                {
                    var errorList = ModelState.Where(c => c.Value.Errors.Any())
                        .Select(p => p.Value.Errors[0].ErrorMessage)
                        .ToList();
                    return Json(errorList, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                var errormessage = ex.Message;
                return Json(errormessage, JsonRequestBehavior.AllowGet);
            }
        }

        public void EditCell(string data)
        {
            Debug.WriteLine(data);
        }
    }

}