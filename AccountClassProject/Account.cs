using System;
using System.Collections.Generic;
using System.Text;

namespace AccountClassProject {
    class Account {

        public string AccountNumber { get; set; }
        // Balance has a private set, so can't set it by accident.  Also, note we have set a beginning balance
        // public decimal Balance { get; private set; }     // Note:  public property with a private set.  You can do this if desired.
        private decimal Balance { get; set; } = 0.0M; // note the "M".  "Treat this as a decimal, not a double.
        public string Description { get; set; }     // user-definable description

        // need to get used to this:    var   Get(  <void>  )   [empty parenths]
        //                              void  Set(  var  )

        // we don't want just anyone to get a balance.  We use a get method, and we make Balance PRIVATE. Outside the class, no one can see Account.Balance (?)
        public decimal GetBalance() {      
            return Balance;
        }
        // create private method, only used INSIDE account class.
        private bool CheckAmountIsPositive(decimal amount) {
            if (amount < 0) {
                Console.WriteLine("Amount cannot be negative"); // msg to user is handled inside this method, like I did with HamiltonDb
                return false;  // this is usually the best-practice way to handle errors.  Just "return".  Don't do an else-clause.
            }
            return true;
            
        }
        // scope: When "Deposit" is called, a variable of type decimal is created.  It only exists within that method. And I assume
        // it lasts for a very short time?  It is given a location in RAM, a value, and a name, for just a moment?  Hmm, after CheckAmountIsPositive
        // is called, and control is returned to Account.Deposit, the variable still exists.  So it doesn't get destroyed when CheckAmount.. is called.
        // Maybe it gets destroyed when we return;.
        public void Deposit(decimal Amount) {
            var valid = CheckAmountIsPositive(Amount);
            if (valid == true) {
                Balance += Amount;
            }
        }
        public void Withdraw(decimal Amount) {
            // need to guard against overdraws:
            var valid = CheckAmountIsPositive(Amount);
            if(valid == true) {
                if(Amount > Balance) {
                    Console.WriteLine("Insufficient funds.");
                } else {
                Balance -= Amount;
                }
            }
        }
        
        // Time to refactor.  Same functionality, streamlined
    }
}
