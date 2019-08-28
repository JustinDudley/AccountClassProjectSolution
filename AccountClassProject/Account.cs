using System; 
using System.Collections.Generic;
using System.Text;

namespace AccountClassProject {
    class Account {

        // private int nextAccountNbr = 0; 
        // if you do this, every instance of a new account starts with the same account number, 0.  That's bad. 
        // So, you want to create a property that only fffffflkjl
        private static int nextAccountNbr = 0;  //static:  This says:  Don't create a new one of these for every instrance.  That variable belongs to the CLASS, all the
            // instances share it.  If any instance changes it, it stays changed for all instances.  
            // ex. of "class-level properties"


        public int AccountNumber { get; private set; }  // other classes can't change the number, can only read it
        // Balance has a private set, so can't set it by accident.  Also, note we have set a beginning balance
        // public decimal Balance { get; private set; }     // Note:  public property with a private set.  You can do this if desired.
        private decimal Balance { get; set; } = 0.0M; // note the "M".  "Treat this as a decimal, not a double.
        public string Description { get; set; }     // user-definable description



        // Here is the new method, written about in comments near the bottom of this page
        public void Transfer(Account acct, decimal amount) {    // "Account", seen at left, is a type.  Because a class is a type, just like an array.
            // Here, we must use our keyword "this"
            var withdrawSuccessful = this.Withdraw(amount);

            //NOT newbie code:
            if(withdrawSuccessful) {
                acct.Deposit(amount);
            }

            /*
             * NEWBIE CODE !!!!!!!!!!!!!!!!!!!!! :
            if (withdrawSuccessful == true) {
                acct.Deposit(amount);

            }*/
        }





        //CONSTRUCTOR
        public Account() {
            AccountNumber = ++nextAccountNbr; //increments FIRST    // this is the tricky thing where it matters which side of the var you put your ++ on
            Console.WriteLine("Call the Account Constructor"); // this is just here to show where/when this happens
        }

        // SECOND CONSTRUCTOR
        public Account(string Description) : this() {   // Here, the word "this" does: calls other constructor?  You can only do this in constructors.
            // First, call the constructor that doesn't take ANY parameters.  That's why the () has nothing inside it, the this().
            // in constructors, when you use this" it means you're talking about another constrc.  It allows you not to duplicate code within constructors.
            // CAN pass parameters from one constructor to another, by th e way.
            // 

            this.Description = Description;      // can have a papmeter with the same name as a property.  In order to distinguish, you use the keyword "this"
            // "this" represesnts the current 
            // one points to property  ; one points to parameter  
            //you can always say this.    prop name    or method name.
            // 


            //
            //

            // How does the system know which constructor to call?  It looks at what parameters were passed to it.  Constructor takes one string parameter.  If call 
            // has that, the system knows.  The rule is:  The types of the parameters must be uniwque for every concstructor
            // one string;    two string;  int, string;     string,int    .  The position and type of the parameters has to be unique.  Can 
            //CAN be string, int     and int,string     Reverse the order?  That's enough of a diff. for the system to tell
        }


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
        public bool Deposit(decimal Amount) {
            var valid = CheckAmountIsPositive(Amount);
            if (valid == true) {
                Balance += Amount;
                return true; // see notes below on technique
            }
            return false; // see notes below on technique
        }


        // What can we do to our Withdraw method so it knows that things didn't go through.  We've written a console message
        // to user, but Withdraw doesn't know. Is it that transfer didn't go through?  I don't know what didn't go through.
        // The strategy:  Return a boolean from Transfer method.  Whether it worked or not. 
        public bool Withdraw(decimal Amount) {
            // need to guard against overdraws:
            var valid = CheckAmountIsPositive(Amount);
            if(valid == true) {
                if(Amount > Balance) {
                    Console.WriteLine("Insufficient funds.");
                } else {
                Balance -= Amount;
                // See comments below.  We put return true here, and then return false below it
                return true; 
                }
            }
            return false; // if the method gets to this point, something somewhere didn't work.  This is a powerful concept, says Greg.  Good technique,
                // to put this here at the end.     It's a catch-all, for all the branching possibilities that didn't work. This is a simple 
                // way for other developers to understnad what's going on.  It's a good technique.  Avoids a bunch of "return false" stmts throughout, which
                // means you have a hard path to follow to figure it all out. 
                // We have lots of situations where the above method wont work.  Only one situation where it DOES work.  
                // This is ALSO good because if there are future changes to the method, you can maintain just the one false at end.

            // So, now we've allowed the withdraw method to return some information about whether it did or did not work. 

        }

        // Here's another method:  Transfer
        //two ways: (1) Transfer could be a static method.  Account.transfer(from,to, amount), where from and to are both account instances (for real, yes)
        // (2) Or, if we had a "from "  account:  from.transfer(to, amount);  One parameter:  a "to" account.
        // 
        // We'll do it the second way.  Might be better.
        //BUT:  Look above, we're going to put it up above the constructor(s).  Don't know why...


        
        // Time to refactor.  Same functionality, streamlined
    }
}
