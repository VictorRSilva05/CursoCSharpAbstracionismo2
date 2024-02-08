using ConsoleApp13.Entities;
using System.Globalization;
namespace ConsoleApp13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the number of tax payers: ");
            int n = int.Parse(Console.ReadLine());

            List<TaxPayer> list = new List<TaxPayer>();

            for (int i = 0; i < n; i++)
            {
                string selector;

                Console.WriteLine($"\nTax payer {i + 1} data:");
                Console.Write("Individual or company (i / c) ? ");
                selector = Console.ReadLine().ToLower();

                Console.Write("Name: ");
                string name = Console.ReadLine();

                Console.Write("Annual income: ");
                double annualIncome = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                if (selector == "i")
                {
                    Console.Write("Health expenditures: ");
                    double healthExpenditures = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                    list.Add(new Individual(name, annualIncome, healthExpenditures));
                }
                else if (selector == "c")
                {
                    Console.Write("Number of employees: ");
                    int numberOfEmployees = int.Parse(Console.ReadLine());

                    list.Add(new Company(name, annualIncome, numberOfEmployees));
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }

            Console.WriteLine("\nTAXES PAID:");

            foreach (TaxPayer taxPayer in list)
            {
                Console.WriteLine(taxPayer.Name
                    + ": $ "
                    + taxPayer.Tax().ToString("F2")
                    );
            }

            double sum = default;

            foreach(TaxPayer taxPayer in list)
            {
                sum += taxPayer.Tax();
            }

            Console.WriteLine($"\nTOTAL TAXES: {sum.ToString("F2")}");
        }
    }
}
