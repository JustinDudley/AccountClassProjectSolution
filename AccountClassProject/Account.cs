using System;
using System.Collections.Generic;
using System.Text;

namespace AccountClassProject {
    class Account {

        public string AccountNumber { get; set; }
        // we can set a beginning balance, like this, if we want: (see the stuff after the = )
        public decimal Balance { get; set; } = 0.0M; // note the "M".  "Treat this as a decimal, not a double. 
        public string Description { get; set; }     // user-definable description

        // need to get used to this:    var   Get(  <void>  )   [empty parenths]
        //                              void  Set(  var  )
        public decimal GetBalance() {       
            return Balance;
        }
        public void Deposit(decimal Amount) {
            Balance += Amount;
        }
        public void Withdraw(decimal Amount) {
            Balance -= Amount;
        }
        

    }
}
