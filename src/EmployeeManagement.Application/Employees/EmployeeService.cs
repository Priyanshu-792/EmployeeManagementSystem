﻿using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using EmployeeManagement.Permissions;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;

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

    public async Task<List<EmployeeDto>> GetEmployeeByDepartmentAsync(string departmentName)
    {
        var query = await Repository.GetQueryableAsync();
        var filteredEmployees = await query.Where($"DepartmentName == \"{departmentName}\"").ToListAsync();
        return ObjectMapper.Map<List<Employee>, List<EmployeeDto>>(filteredEmployees);
    }

    public async Task<List<EmployeeDto>> GetEmployeeByNameAsync(string name)
    {
        var query = await Repository.GetQueryableAsync();
        var filteredEmployees = await query.Where($"Name == \"{name}\"").ToListAsync();
        return ObjectMapper.Map<List<Employee>, List<EmployeeDto>>(filteredEmployees);
    }
}

