using System.Globalization;
using System;
using System.Text;
namespace PaidExpenses;


/**
    -Instance variables: 
        *int airfare. 
        *string meals. 
        *int hotelCost.
    -Functionality (MVP):
        * User should be able to log in to the system.
        * User should be able to create a new account in the system.
        * Employee should be able to submit reimbursement tickets. (explained on 02/21/23)
        * Manager should be able to approve or reject submitted reimbursement tickets.
**/
        public class Expenses
        {
            public int ID {get;set;}
            public string expenseType {get; set;}
            public decimal Cost {get; set;}
            public List<Expenses> employeeExpenses{get; set;}
        
            public Expenses(){
                employeeExpenses = new List<Expenses>();
            }

            //Parameters Constructor 
            public Expenses(string expense, decimal Cost ){
                this.expenseType = expense;
                this.Cost = Cost;
            }
                
            public string print(){

                return " "+this.ID+" "+this.expenseType+" "+this.Cost;
            }

        }