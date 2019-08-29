using System;

namespace AccountClassProject {
    class Program {
        static void Main(string[] args) {

            var acct1 = new Account();  //  Call to CONSTRUCTOR 
            acct1.Deposit(1000);
            Console.WriteLine($"{acct1.AccountNumber} {acct1.Description} {acct1.GetBalance()}");
            acct1.Withdraw(5000);    // the system will turn this integer into a decimal
            Console.WriteLine($"{acct1.AccountNumber} {acct1.Description} {acct1.GetBalance()}");
            acct1.Deposit(5);
            Console.WriteLine($"{acct1.AccountNumber} {acct1.Description} {acct1.GetBalance()}");

            var balance = acct1.GetBalance();
            Console.WriteLine($"{balance}");
            acct1.Withdraw(-1000000);
            Console.WriteLine($"{acct1.AccountNumber} {acct1.Description} {acct1.GetBalance()}");

            var acct2 = new Account("Secondary Checking");
            acct1.Transfer(acct2, 1000);
            Console.WriteLine($"{acct1.AccountNumber} {acct1.Description} {acct1.GetBalance()}");
            Console.WriteLine($"{acct2.AccountNumber} {acct2.Description} {acct2.GetBalance()}");
            Console.WriteLine();
            // WE MADE SOME ENHANCEMENTS:
            //   - No setting the balance directly; only through deposit/withdrawal
            //   - Cannot overdraw
            //   - protect against duplicate account numbers


            // TESTING THE CUSTOMER CLASS:
            Customer James = new Customer("Jim", "Norwood", "Ohio");
            Console.WriteLine(James.GetName());
            James.SetName("Jimmy");
            Console.WriteLine(James.GetName());
            Console.WriteLine(James.GetCustId());
            Console.WriteLine(James.GetActive());
            James.SetActive(false);
            Console.WriteLine(James.GetActive());
            Console.WriteLine(James.GetSales());
            James.AddSales();
            James.AddSales();
            Console.WriteLine(James.GetSales());

            Customer Daija = new Customer("Daija", "Cincinnati", "Ohio");
            Console.WriteLine();
            Console.WriteLine(Daija.GetName());
            Console.WriteLine(Daija.GetCustId());








        }
    }
}
