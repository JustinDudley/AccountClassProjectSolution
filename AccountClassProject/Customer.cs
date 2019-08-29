using System;
using System.Collections.Generic;
using System.Text;

namespace AccountClassProject {
    class Customer {

        /*
         Class Requirements:
        int Identifier, and find a way to generate it
        string Name (of company)
        string City;   string State;    decimal Sales;   bool active

        include a default constructor
        need to provide a way to set all methods, except sales
        Sales will be set to zero initially.  AddSales method adds 100.00 to number
        Active is set to true
        Use the Program class to test it.    */

           // CLASS VARIABLES
        private static int previousId = 1000; 
           // INSTANCE VARIABLES
        private int CustId { get; set; }
        private string Name { get; set; } 
        private string City { get; set; }
        private string State { get; set; }
        public bool Active { get; set; } = true;
        private decimal Sales { get; set; } = 0.0M;


           // CONSTRUCTOR
        public Customer(string name, string city, string state) {
            Name = name;
            City = city;
            State = state;
            CustId = previousId + 13;
            previousId = previousId + 13;
        }

        // GETTER/SETTER METHODS
        public int GetCustId() {
            return CustId;
        }
        public void SetCustId(int id) {
            CustId = id;
        }
        public string GetName() {
            return Name;
        }
        public void SetName(string name) {
            Name = name;
        }
        public string GetCity() {
            return City;
        }
        public void setCity(string city) {
            City = city;
        }
        public string GetState() {
            return State;
        }
        public void SetState(string state) {
            State = state;
        }
        public bool GetActive() {
            return Active;
        }
        public void SetActive(bool active) {
            Active = active;
        }

        public decimal GetSales() {
            return Sales;
        }

        // METHOD FOR SALES
        public void AddSales() {
            Sales = Sales + 100;
        }
    }
}
