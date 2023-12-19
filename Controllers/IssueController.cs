using dotnet_issue_tracker.Data;
using dotnet_issue_tracker.Models;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_issue_tracker.Controllers
{
    public class IssueController(AppDbContext db) : Controller
    {
        public IActionResult Index()
        {
            List<Issue> IssueList = [.. db.Issues];

            return View(IssueList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Issue data)
        {
            if (data.Description != null && data.Title == data.Description)
            {
                ModelState.AddModelError("", "The Description can't exactly match the Title");
            }

            if (ModelState.IsValid)
            {
                db.Issues.Add(data);
                db.SaveChanges();

                TempData["success"] = "Issue Created Successfully";
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            Issue? issue = db.Issues.Find(id);

            if (issue == null) return NotFound();

            return View(issue);
        }
        [HttpPost]
        public IActionResult Edit(Issue data)
        {
            if (data.Description != null && data.Title == data.Description)
            {
                ModelState.AddModelError("", "The Description can't exactly math the Title");
            }

            Issue? issue = db.Issues.Find(data.Id);

            if (ModelState.IsValid && issue != null)
            {
                issue.Title = data.Title;
                issue.Description = data.Description;
                issue.Status = data.Status;
                issue.UpdatedAt = DateTime.UtcNow;
                db.SaveChanges();

                TempData["success"] = "Issue Updated Successfully";

                return RedirectToAction("Index");
            }

            return View();
        }
        public IActionResult Delete(Guid id)
        {

            Issue? issue = db.Issues.Find(id);

            if (issue == null) return NotFound();

            db.Issues.Remove(issue);
            db.SaveChanges();

            TempData["success"] = "Issue Deleted Successfully";

            return RedirectToAction("Index");
        }
    }
}
