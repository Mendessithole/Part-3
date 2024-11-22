using CMCSProjectPART1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CMCSProjectPART1.Controllers
{
    public class LectureController : Controller
    {
        // In-memory storage for claims (replace with database context in real-world app)
        private static List<MonthlyClaimModel> ClaimsStorage = new List<MonthlyClaimModel>();

        // GET: /Lecture/Index (Lecturer Dashboard)
        public IActionResult Index()
        {
            return View(); // Render Views/Lecture/Index.cshtml (Lecturer Dashboard)
        }

        // GET: /Lecture/SubmitClaim (Submit a new claim)
        public IActionResult SubmitClaim()
        {
            return View(); // Render Views/Lecture/SubmitClaim.cshtml (Submit Claim Form)
        }

        // POST: /Lecture/SubmitClaim (Handle claim form submission)
        [HttpPost]
        public IActionResult SubmitClaim(SubmitClaimModel model)
        {
            if (ModelState.IsValid)
            {
                // Calculate the Amount
                decimal calculatedAmount = model.HoursWorked * model.HourlyRate;

                // Create and save new claim
                var newClaim = new MonthlyClaimModel
                {
                    Id = ClaimsStorage.Count + 1,  // Unique ID generation
                    ClaimDescription = model.ClaimDescription,
                    Amount = calculatedAmount, // Store calculated amount
                    ClaimDate = model.ClaimDate,
                    DocumentPath = model.ClaimDocument?.FileName ?? "No Document",
                    HoursWorked = model.HoursWorked,  // Store HoursWorked value
                    HourlyRate = model.HourlyRate,  // Store HourlyRate value
                    Status = "Pending"  // Default status is "Pending"
                };

                ClaimsStorage.Add(newClaim);  // Save claim (in-memory storage)

                return RedirectToAction("MonthlyClaims");  // Redirect to the Monthly Claims page
            }

            // If model validation fails, return to the form
            return View(model);
        }

        // GET: /Lecture/MonthlyClaims (View all claims)
        public IActionResult MonthlyClaims()
        {
            return View(ClaimsStorage);  // Render Views/Lecture/MonthlyClaims.cshtml with claim data
        }

        // GET: /ProgramCoordinator/Index (Program Coordinator Dashboard)
        public IActionResult ProgramCoordinator()
        {
            return View(ClaimsStorage);  // Show all claims for Program Coordinator
        }

        // POST: /ProgramCoordinator/Approve (Approve a claim)
        [HttpPost]
        public IActionResult Approve(int id)
        {
            var claim = ClaimsStorage.FirstOrDefault(c => c.Id == id);
            if (claim != null)
            {
                claim.Status = "Approved"; // Change claim status to Approved
            }
            return RedirectToAction("ProgramCoordinator");  // Redirect to Program Coordinator page
        }

        // POST: /ProgramCoordinator/Reject (Reject a claim)
        [HttpPost]
        public IActionResult Reject(int id)
        {
            var claim = ClaimsStorage.FirstOrDefault(c => c.Id == id);
            if (claim != null)
            {
                claim.Status = "Rejected"; // Change claim status to Rejected
            }
            return RedirectToAction("ProgramCoordinator");  // Redirect to Program Coordinator page
        }
    }
}
