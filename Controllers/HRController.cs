using CMCSProjectPART1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CMCSProjectPART1.Controllers
{
    public class HRController : Controller
    {
        private static List<ClaimModel> claims = new List<ClaimModel>
        {
            new ClaimModel { Id = 1, Description = "Claim 1", Amount = 1000, Status = "Approved" },
            new ClaimModel { Id = 2, Description = "Claim 2", Amount = 500, Status = "Pending" },
            new ClaimModel { Id = 3, Description = "Claim 3", Amount = 2000, Status = "Approved" }
        };

        public IActionResult GenerateReport()
        {
            var approvedClaims = claims.Where(c => c.Status == "Approved").ToList();
            return View(approvedClaims);
        }
    }
}
