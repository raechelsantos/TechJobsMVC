using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechJobsMVC.Data;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechJobsMVC.Controllers
{
    public class SearchController : Controller
    {
        public object _jobs { get; private set; }

        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.columns = ListController.ColumnChoices;
            return View();
        }

        [HttpPost]
        public IActionResult Results(string searchType, string searchTerm)
        {
            //ViewBag.jobs = _jobs;

            if (String.IsNullOrEmpty(searchTerm))
            {
                ViewBag.jobs = JobData.FindAll();
            }
            else
            {
                ViewBag.jobs = JobData.FindByColumnAndValue(searchType, searchTerm);
            }

            ViewBag.Columns = ListController.ColumnChoices;

            return View("Views/Search/Index.cshtml");
        }
    }
}
