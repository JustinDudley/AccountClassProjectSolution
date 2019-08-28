using System; 
using System.Collections.Generic;
using System.Text;

namespace AccountClassProject {
    class Account {

        private static int nextAccountNbr = 0;  //static variable, class-level, shared
        public int AccountNumber { get; private set; }  // other classes can only read
        private decimal Balance { get; set; } = 0.0M; // note the "M". Note that we set a beginning value
        public string Description { get; set; }     // user-definable description



        public void Transfer(Account acct, decimal amount) {    // "Account" is a type, just like an array...
            var withdrawSuccessful = this.Withdraw(amount);     // Here, we must use our keyword "this"
            if(withdrawSuccessful) {
                acct.Deposit(amount);
            }   
        }


        // FIRST CONSTRUCTOR
        public Account() {
            AccountNumber = ++nextAccountNbr; //increments FIRST    // which side for ++  -it matters 
        }

        // SECOND CONSTRUCTOR
        public Account(string Description) : this() {   // Here, the word "this" calls other constructors
            // can have a parameter with the same name as a property.  In order to distinguish, you use the keyword "this"
            // "this" represesnts the current fffsfss.  One points to property  ; one points to parameter  
            this.Description = Description;                 
        }


        public decimal GetBalance() {      
            return Balance;
        }
        private bool CheckAmountIsPositive(decimal amount) {    // create private method, only used INSIDE account class.
            if (amount < 0) {
                Console.WriteLine("Amount cannot be negative"); 
                return false;  // best-practice way to handle errors. Don't do an else-clause.
            }
            return true;   
        }
        public bool Deposit(decimal Amount) {
            var valid = CheckAmountIsPositive(Amount);
            if (valid == true) {
                Balance += Amount;
                return true;
            }
            return false; 
        }

        public bool Withdraw(decimal Amount) {
            var valid = CheckAmountIsPositive(Amount);
            if(valid == true) {
                if(Amount > Balance) {
                    Console.WriteLine("Insufficient funds.");
                } else {
                Balance -= Amount;
                return true;    
                }
            }
            return false; // Greg good idea:  Catch-all spot for any remaining branch
        }
    }
}
 /*
         Transfer method.  Two ways:
         (1) Transfer could be a static method.  Account.transfer(from,to, amount), where from and to are both account instances (for real, yes)
         (2) WE'LL DO IT THIS WAY: Or, if we had a "from "  account:  from.transfer(to, amount);  One parameter:  a "to" account.
        */
/*
               Here, in the SECOND CONSTRUCTOR, the word "this" does: calls other constructor?  You can only do this in constructors.
           // First, call the constructor that doesn't take ANY parameters.  That's why the () has nothing inside it, the this().
           // in constructors, when you use this" it means you're talking about another constrc.  It allows you not to duplicate code within constructors.
           // CAN pass parameters from one constructor to another, by th e way.
           */
/*
// How does the system know which constructor to call?  It looks at what parameters were passed to it.  Constructor takes one string parameter.  If call 
// has that, the system knows.  The rule is:  The types of the parameters must be uniwque for every concstructor
// one string;    two string;  int, string;     string,int    .  The position and type of the parameters has to be unique.  Can 
//CAN be string, int     and int,string     Reverse the order?  That's enough of a diff. for the system to tell
*/
