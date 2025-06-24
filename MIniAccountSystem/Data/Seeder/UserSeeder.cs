using Microsoft.AspNetCore.Identity;

public static class UserSeeder
{
    public static async Task SeedUsersAsync(IServiceProvider serviceProvider)
    {
        var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
        var users = new[]
        {
            new { Username = "admin@example.com", Password = "Admin@123", Role = "Admin" },
            new { Username = "accountant@example.com", Password = "Account@123", Role = "Accountant" },
            new { Username = "viewer@example.com", Password = "Viewer@123", Role = "Viewer" }
        };

        foreach (var userInfo in users)
        {
            var existingUser = await userManager.FindByEmailAsync(userInfo.Username);
            if (existingUser == null)
            {
                var user = new IdentityUser { UserName = userInfo.Username, Email = userInfo.Username, EmailConfirmed = true };
                var result = await userManager.CreateAsync(user, userInfo.Password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, userInfo.Role);
                }
                // You could add logging here for failures
            }
        }
    }
}