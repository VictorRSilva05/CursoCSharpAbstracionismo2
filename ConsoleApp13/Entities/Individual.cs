using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp13.Entities
{
    internal class Individual : TaxPayer
    {
        public double HealthExpenditures { get; set; }
        public Individual() { }

        public Individual(string name, double annualIncome, double healthExpenditures) : base(name, annualIncome)
        {
            HealthExpenditures = healthExpenditures;
        }

        public override sealed double Tax()
        {
            double sum = default;

            sum = AnnualIncome < 20000.00 ? AnnualIncome * 0.15 : AnnualIncome * 0.25;

            return sum - (HealthExpenditures * 0.5);
        }
    }
}
