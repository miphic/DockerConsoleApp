using hw4.Abstractions;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw4Sber.Domain.Entity
{
    public class Operation : BaseEntity
    {
        public Guid Account { get; set; }
        public double Delta { get; set; }
        public DateTime Date { get; set; }
    }
}
