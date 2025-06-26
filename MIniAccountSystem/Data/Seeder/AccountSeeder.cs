using MIniAccountSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MIniAccountSystem.Data
{
    public static class AccountSeeder
    {
        public static async Task SeedAccountsAsync(IServiceProvider serviceProvider)
        {
            using var context = serviceProvider.GetRequiredService<ApplicationDbContext>();

            if (context.Accounts.Any()) return; // Already seeded

            var accounts = new List<Account>
            {
                new Account
                {
                    Name = "Assets",
                    Children = new List<Account>
                    {
                        new Account { Name = "Cash" },
                        new Account { Name = "Bank" },
                    }
                },
                new Account
                {
                    Name = "Liabilities",
                    Children = new List<Account>
                    {
                        new Account { Name = "Accounts Payable" },
                        new Account { Name = "Loans" }
                    }
                },
                new Account
                {
                    Name = "Income",
                    Children = new List<Account>
                    {
                        new Account { Name = "Sales" },
                        new Account { Name = "Interest Income" }
                    }
                },
                new Account
                {
                    Name = "Expenses",
                    Children = new List<Account>
                    {
                        new Account { Name = "Rent" },
                        new Account { Name = "Utilities" },
                        new Account { Name = "Salaries" }
                    }
                }
            };

            context.Accounts.AddRange(accounts);
            await context.SaveChangesAsync();
        }
    }
}
