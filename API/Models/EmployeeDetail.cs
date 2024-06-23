using System;
using System.Collections.Generic;

namespace API.Models;

public partial class EmployeeDetail
{
    public int EmployeeId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateTime DateofBirth { get; set; }

    public string Department { get; set; } = null!;
}
