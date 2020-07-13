using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechJobsMVC.Data;
using TechJobsMVC.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechJobsMVC.Controllers
{
    
    public class SearchController : Controller
    {
        public static string Key { get; set; }

        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.columns = ListController.ColumnChoices;
            ViewBag.key = Key; 
            return View();
        }

        // TODO #3: Create an action method to process a search request and render the updated search view.

        
        public IActionResult Results(string searchType, string searchTerm)
        {
            ViewBag.columns = ListController.ColumnChoices;
            List<Job> jobs;
            if (searchTerm == null)
            {
                jobs = JobData.FindAll();
                ViewBag.title = "All Jobs";
            }
            else if (searchType.ToLower() == "all")
            {
                jobs = JobData.FindByValue(searchTerm);
                ViewBag.title = "Jobs with " + ListController.ColumnChoices[searchType] + ": " + searchTerm;
            }

            else
            {
                jobs = JobData.FindByColumnAndValue(searchType, searchTerm);
                ViewBag.title = "Jobs with " + ListController.ColumnChoices[searchType] + ": " + searchTerm;
            }
            Key = searchType;
            ViewBag.jobs = jobs;
            return View();
        }
    }
}
