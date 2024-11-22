using CMCSProjectPART1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CMCSProjectPART1.Controllers
{
    public class ProgramCoordinatorController : Controller
    {
        private static List<ClaimModel> claims = new List<ClaimModel>
        {
            new ClaimModel { Id = 1, Description = "Claim 1", Amount = 1000, Status = "Pending" },
            new ClaimModel { Id = 2, Description = "Claim 2", Amount = 2000, Status = "Pending" }
        };

        // GET: /ProgramCoordinator
        public IActionResult Index()
        {
            return View(claims);
        }

        // POST: /ProgramCoordinator/Approve/{id}
        [HttpPost]
        public IActionResult Approve(int id)
        {
            var claim = claims.FirstOrDefault(c => c.Id == id);
            if (claim != null)
            {
                claim.Status = "Approved";
            }
            return RedirectToAction("Index");
        }

        // POST: /ProgramCoordinator/Reject/{id}
        [HttpPost]
        public IActionResult Reject(int id)
        {
            var claim = claims.FirstOrDefault(c => c.Id == id);
            if (claim != null)
            {
                claim.Status = "Rejected";
            }
            return RedirectToAction("Index");
        }
    }
}
