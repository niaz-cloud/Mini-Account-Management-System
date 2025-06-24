using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using MIniAccountSystem.Data.Repository.Interface;
using MIniAccountSystem.Models.Dtos;


namespace MIniAccountSystem.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly string _connectionString;

        public UserRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new Exception("Connection string not configured properly");
        }

        public async Task<IEnumerable<UserResponseDto>> GetUsersWithRolesAsync()
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            return await db.QueryAsync<UserResponseDto>(
                "sp_GetUsersWithRoles",
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<IEnumerable<string>> GetAllRolesAsync()
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            return await db.QueryAsync<string>(
                "sp_GetAllRoles",
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task AssignRoleAsync(string userId, string roleName)
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            await db.ExecuteAsync(
                "sp_AssignUserRole", // You'd need to define this SP
                new { UserId = userId, RoleName = roleName },
                commandType: CommandType.StoredProcedure
            );
        }
    }
}
