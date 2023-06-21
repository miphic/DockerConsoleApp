using hw4.Abstractions;
using hw4Sber.Abstractions;
using hw4Sber.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw4Sber.Controlllers
{
    [DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
    public class AccountController : ControllerBase<Account>
    {
        public AccountController(IRepository<Account> repo) : base(repo)
        {
        }


        


        private string? GetDebuggerDisplay()
        {
            return ToString();
        }
    }
}
