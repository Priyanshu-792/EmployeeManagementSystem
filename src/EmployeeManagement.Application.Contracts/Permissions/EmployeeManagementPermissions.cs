namespace EmployeeManagement.Permissions;

public static class EmployeeManagementPermissions
{
    public const string GroupName = "EmployeeManagement";
    public static class Dashboard
    {
        public const string DashboardGroup = GroupName + ".Dashboard";
        public const string Host = DashboardGroup + ".Host";
        public const string Tenant = GroupName + ".Tenant";
    }

    // Added items
    public static class Employees
    {
        public const string Default = GroupName + ".Employees";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
    }
}
