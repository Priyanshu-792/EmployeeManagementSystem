using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using EmployeeManagement.Permissions;
using Microsoft.AspNetCore.Authorization;

namespace EmployeeManagement.Employees;


[Authorize]
public class EmployeeService :
    CrudAppService<
        Employee,
        EmployeeDto,
        Guid, //Primary key
        PagedAndSortedResultRequestDto,
        CreateUpdateEmployeeDto>,
    IEmployeeService
{
    public EmployeeService(IRepository<Employee, Guid> repository)
        : base(repository)
    {
        GetPolicyName = EmployeeManagementPermissions.Employees.Default;
        GetListPolicyName = EmployeeManagementPermissions.Employees.Default;
        CreatePolicyName = EmployeeManagementPermissions.Employees.Create;
        UpdatePolicyName = EmployeeManagementPermissions.Employees.Edit;
        DeletePolicyName = EmployeeManagementPermissions.Employees.Delete;
    }
}

