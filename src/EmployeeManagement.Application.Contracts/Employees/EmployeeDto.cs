using System;
using Volo.Abp.Application.Dtos;
namespace EmployeeManagement.Employees;

public class EmployeeDto : AuditedEntityDto<Guid>
{
    public string Name { get; set; }

    public int Age { get; set; }

    public int Salary { get; set; }
    public string DepartmentName { get; set; }
}
