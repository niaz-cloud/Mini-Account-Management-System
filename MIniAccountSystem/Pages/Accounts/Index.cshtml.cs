using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MIniAccountSystem.Data;
using MIniAccountSystem.Models;
using MIniAccountSystem.Models.Dtos;

public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public IndexModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public List<AccountTreeDto> AccountTree { get; set; }

    public void OnGet()
    {
        var accounts = _context.Accounts
            .Include(a => a.Children)
            .ToList();

        AccountTree = accounts
            .Where(a => a.ParentId == null)
            .Select(a => BuildTree(a))
            .ToList();
    }

    private AccountTreeDto BuildTree(Account account)
    {
        return new AccountTreeDto
        {
            Id = account.Id,
            Name = account.Name,
            Children = account.Children?.Select(BuildTree).ToList()
        };
    }
}
