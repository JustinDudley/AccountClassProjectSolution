using System;

namespace AccountClassProject {
    class Program {
        static void Main(string[] args) {

            //now, create an instance of the account
            var acct1 = new Account();
            acct1.AccountNumber = "12345";
            // acct1.Balance is now private :)
            // acct1.Balance has been replaced by acct1.GetBalance
            // the general rule:  You should not let other classes access your properties. Use get/set methods instead.
            // acct1.Balance = 100000M;  // You don't have to set this, AND FURTHERMORE, we should make it impossible to set the balance in this way

            acct1.Description = "Primary Checking";
            acct1.Withdraw(50000);
            Console.WriteLine($"{acct1.AccountNumber} {acct1.Description} {acct1.GetBalance()}");
            acct1.Withdraw(52000);  // the system will turn this integer into a decimal
            Console.WriteLine($"{acct1.AccountNumber} {acct1.Description} {acct1.GetBalance()}");
            acct1.Deposit(5);
            Console.WriteLine($"{acct1.AccountNumber} {acct1.Description} {acct1.GetBalance()}");

            //now we make a variable.  Not lowercase
            var balance = acct1.GetBalance();
            Console.WriteLine($"{balance}");

            // WE NEED SOME ENHANCEMENTS:
            //   - No setting the balance directly; only through deposit/withdrawal
            //   - Cannot overdraw
            //   - protect against duplicate account numbers


        }
    }
}
