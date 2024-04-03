using EmployeeManagement.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace EmployeeManagement.Permissions;

public class EmployeeManagementPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(EmployeeManagementPermissions.GroupName);

        myGroup.AddPermission(EmployeeManagementPermissions.Dashboard.Host, L("Permission:Dashboard"), MultiTenancySides.Host);
        myGroup.AddPermission(EmployeeManagementPermissions.Dashboard.Tenant, L("Permission:Dashboard"), MultiTenancySides.Tenant);

        var booksPermission = myGroup.AddPermission(EmployeeManagementPermissions.Employees.Default, L("Permission:Employees"));
        booksPermission.AddChild(EmployeeManagementPermissions.Employees.Create, L("Permission:Employees.Create"));
        booksPermission.AddChild(EmployeeManagementPermissions.Employees.Edit, L("Permission:Employees.Edit"));
        booksPermission.AddChild(EmployeeManagementPermissions.Employees.Delete, L("Permission:Employees.Delete"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<EmployeeManagementResource>(name);
    }
}
