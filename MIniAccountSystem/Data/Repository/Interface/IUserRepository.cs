using MIniAccountSystem.Models.Dtos;

namespace MIniAccountSystem.Data.Repository.Interface
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserResponseDto>> GetUsersWithRolesAsync();
        Task<IEnumerable<string>> GetAllRolesAsync();
        Task AssignRoleAsync(string userId, string roleName);
    }
}
