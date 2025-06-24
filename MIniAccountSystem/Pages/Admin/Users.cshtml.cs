using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MIniAccountSystem.Data.Repository.Interface;
using MIniAccountSystem.Models.Dtos;

namespace MIniAccountSystem.Pages.Admin
{
    public class UserModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IUserRepository userRepository;

        public UserModel(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IUserRepository userRepository)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            this.userRepository = userRepository;
        }

        public IList<UserResponseDto> Users { get; set; }

        public async Task OnGetAsync()
        {
            Users = (await userRepository.GetUsersWithRolesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAssignRoleAsync(string userId, string role)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null && await _roleManager.RoleExistsAsync(role))
            {
                await _userManager.AddToRoleAsync(user, role);
            }
            return RedirectToPage();
        }

    }
}
