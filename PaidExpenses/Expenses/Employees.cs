namespace PaidExpenses;


public class Employee:Expenses{


            public int EmployeeID {get;set;}
            public string FirstName {get; set;}
            public string LastName {get; set;}
        
            public List<Employee> EmployeeList {get; set;}

            public Employee(){
                this.EmployeeList = new List<Employee>();
            }
           
            //Parameters Constructor 
            public Employee(string FirstName, string LastName ){
                this.FirstName = FirstName;
                this.LastName = LastName;
            }
                
            public string printEmployee(){

                return " "+this.EmployeeID+" "+this.FirstName+" "+this.LastName;
            }




}