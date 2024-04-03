using AutoMapper;
using EmployeeManagement.Employees;
namespace EmployeeManagement;

public class EmployeeManagementApplicationAutoMapperProfile : Profile
{
    public EmployeeManagementApplicationAutoMapperProfile()
    {
        

        CreateMap<Employee, EmployeeDto>();
        CreateMap<CreateUpdateEmployeeDto, Employee>();
    }
}
