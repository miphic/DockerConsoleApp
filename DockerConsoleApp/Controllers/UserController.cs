using hw4Sber.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hw4.Abstractions;
using System.Diagnostics;
using hw4Sber.Repos;
using hw4Sber.Domain.Entity;
using hw4.Domain;
using Microsoft.EntityFrameworkCore;

namespace hw4Sber.Controlllers
{
    [DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
    public class UserController<T> : ControllerBase<T> where T: BaseEntity,new()
    {
        public UserController(IRepository<T> repo):base(repo)           
        {
        }

        private string? GetDebuggerDisplay()
        {
            return ToString();
        }
    }
}
