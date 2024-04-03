using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Employees;

public class CreateUpdateEmployeeDto
{

    [Required]
    [StringLength(128)]
    public string Name { get; set; } = string.Empty;

    [Required]
    public int Age { get; set; }

    [Required]
    public int Salary { get; set; }

    [Required]
    public string DepartmentName { get; set; }
}
