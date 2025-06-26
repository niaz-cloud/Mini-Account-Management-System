using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MIniAccountSystem.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Parent-child hierarchy
        public int? ParentId { get; set; }

        [ForeignKey("ParentId")]
        public Account Parent { get; set; }

        public ICollection<Account> Children { get; set; }
    }
}
