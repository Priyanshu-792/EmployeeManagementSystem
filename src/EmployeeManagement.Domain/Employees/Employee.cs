using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;


namespace EmployeeManagement.Employees;

public class Employee : AuditedAggregateRoot<Guid>
{
    [Required]
    [StringLength(50)]
    public string Name { get; set; }

    [Range(21, 100)]
    public int Age { get; set; }

     public int Salary { get; set; }
     public string DepartmentName { get; set; }

}
