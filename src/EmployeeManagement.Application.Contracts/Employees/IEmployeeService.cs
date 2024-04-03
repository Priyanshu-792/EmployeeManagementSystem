
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace EmployeeManagement.Employees;

public interface IEmployeeService :
    ICrudAppService< 
        EmployeeDto, 
        Guid, 
        PagedAndSortedResultRequestDto, 
        CreateUpdateEmployeeDto> 
{
    Task<List<EmployeeDto>> GetEmployeeByDepartmentAsync(String departmentName);
    Task<List<EmployeeDto>> GetEmployeeByNameAsync(String name);
}
