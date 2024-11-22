namespace CMCSProjectPART1.Models
{
    public class SubmitClaimModel
    {
        public string ClaimDescription { get; set; }
        public decimal Amount { get; set; }
        public DateTime ClaimDate { get; set; }
        public IFormFile ClaimDocument { get; set; }
        
        // Add this property
        public decimal HoursWorked { get; set; }  // Represents hours worked
        
        public decimal HourlyRate { get; set; } // Represents hourly rate
    }
}
