using hw4.Abstractions;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw4Sber.Domain.Entity
{
    public class Account : BaseEntity
    {
        public string strNumber { get; set; } = string.Empty;
        public Guid UserId { get; set;}

        public decimal Ballance { get; set;} 

    }
}
