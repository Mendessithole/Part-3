namespace CMCSProjectPART1.Models
{
    public class MonthlyClaimModel
    {
        public int Id { get; set; }
        public string ClaimDescription { get; set; }
        public decimal Amount { get; set; }  // Amount should be decimal
        public DateTime ClaimDate { get; set; }
        public string DocumentPath { get; set; }
        public decimal HoursWorked { get; set; }  // Hours worked should be decimal
        public decimal HourlyRate { get; set; }  // Hourly rate should be decimal
        public string Status { get; set; } = "Pending";  // Default status is "Pending"
    }
}