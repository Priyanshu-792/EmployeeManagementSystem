using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Authorization;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Identity;
using Volo.Abp.Users;

namespace EmployeeManagement;

[Dependency(ReplaceServices = true)]
public class UserAppService : IdentityUserAppService
{
    private readonly ICurrentUser _currentUser;
    public UserAppService(
        IdentityUserManager userManager,
        IIdentityUserRepository userRepository,
        IIdentityRoleRepository roleRepository,
        IOptions<IdentityOptions> options,
        ICurrentUser currentUser) : base(
            userManager,
            userRepository,
            roleRepository,
             options
            )
    {
        _currentUser = currentUser;
    }

    public override async Task<IdentityUserDto> CreateAsync(IdentityUserCreateDto input)
    {
        var isAdmin = _currentUser.IsInRole("admin");
        var role = input.RoleNames.Any(x => x != "HR");
        if (isAdmin == true && role == false)
        {

            return await base.CreateAsync(input);
        }
        else
        {
            throw new AbpAuthorizationException("Admin can create HR role user only");
        }

    }
    public override async Task<IdentityUserDto> UpdateAsync(Guid id, IdentityUserUpdateDto input)
    {
        var isAdmin = _currentUser.IsInRole("admin");
        var role = input.RoleNames.Any(x => x != "HR");
        if (isAdmin == true && role == false)
        {

            return await base.UpdateAsync(id, input);
        }
        else
        {
            throw new AbpAuthorizationException("Admin can update role to HR only");
        }

    }
}