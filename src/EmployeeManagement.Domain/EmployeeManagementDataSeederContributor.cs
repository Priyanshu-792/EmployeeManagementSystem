using System;
using System.Threading.Tasks;
using EmployeeManagement.Employees;
using EmployeeManagement.Permissions;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Guids;
using Volo.Abp.Identity;
using Volo.Abp.PermissionManagement;

namespace EmployeeManagement;

public class EmployeeManagementDataSeederContributor
    : IDataSeedContributor, ITransientDependency
{
    private readonly IRepository<Employee, Guid> _employeeRepository;
    private readonly IdentityRoleManager _identityRoleManager;
    private readonly IdentityUserManager _identityUserManager;
    private readonly IPermissionManager _identityPermissionManager;
   public EmployeeManagementDataSeederContributor(
        IRepository<Employee, Guid> employeeRepository, 
        IdentityRoleManager identityRoleManager,
        IdentityUserManager identityUserManager,
        IPermissionManager identityPermissionManager
        )
    {
        _employeeRepository = employeeRepository;
        _identityRoleManager = identityRoleManager;
        _identityUserManager = identityUserManager;
        _identityPermissionManager = identityPermissionManager;
    }

    public async Task SeedAsync(DataSeedContext context)
    {


        var role = await _identityRoleManager.FindByNameAsync("HR");
        if (role == null)
        {
            var roleId = Guid.NewGuid(); // Generate a new GUID for the role ID
            role = new IdentityRole(roleId, "HR");
            await _identityRoleManager.CreateAsync(role);
        }



        // Create the "HR" user and add them to the "HR" role
        var user = await _identityUserManager.FindByEmailAsync("testhr@email.com");
        if (user == null)
        {
            user = new IdentityUser(Guid.NewGuid(), "HR", "testhr@email.com");
            await _identityUserManager.CreateAsync(user, "1q2w3E*");
        }
        await _identityUserManager.AddToRoleAsync(user, "HR");



        await _identityPermissionManager.SetForRoleAsync("HR", EmployeeManagementPermissions.Employees.Default, true);
        await _identityPermissionManager.SetForRoleAsync("HR", EmployeeManagementPermissions.Employees.Create, true);
        await _identityPermissionManager.SetForRoleAsync("HR", EmployeeManagementPermissions.Employees.Edit, true);
        await _identityPermissionManager.SetForRoleAsync("HR", EmployeeManagementPermissions.Employees.Delete, true);









        if (await _employeeRepository.GetCountAsync() > 0)
        {
            return;
        }

        await _employeeRepository.InsertAsync(
            new Employee
            {
                Name = "Priyanshu Sharma",
                Age = 21,
                Salary = 50000,
                DepartmentName = "Developer"
            },
            autoSave: true
        );

        await _employeeRepository.InsertAsync(
        new Employee
        {
            Name = "Mihir",
            Age = 22,
            Salary = 40000,
            DepartmentName = "Tester"
        },
        autoSave: true
    );
    }
}
