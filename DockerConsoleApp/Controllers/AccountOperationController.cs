using hw4.Abstractions;
using hw4Sber.Abstractions;
using hw4Sber.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw4Sber.Controlllers
{
    public class AccountOperationController : ControllerBase<Operation>
    {
        public AccountOperationController(IRepository<Operation> repo) : base(repo)
        {
        }
    }
}
