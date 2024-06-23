using System.ComponentModel.DataAnnotations;

namespace Utility
{
    public class Employee
    {
        public int EmployeeId { get; set; } 
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }
        [Required]
        public DateTime? DateOfBrith { get; set; }
        [Required]
        public string Department { get; set; }
    }
}
