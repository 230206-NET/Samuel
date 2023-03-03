namespace PaidExpenses;


public class User:Expenses{
    private const string V = ""!;

    public int EmployeeID {get;set;}
            public string FirstName {get; set;}
            public string LastName {get; set;}
            public string UserLogin{get;set;} // This refers to the username. 
            public string UserPassword{get;set;}
            public List<User> EmployeeList {get; set;}

            public User(){
                this.EmployeeList = new List<User>();
            }
           
            //Parameters Constructors 
              public User(string UserLogin, string UserPassword){
                this.UserLogin = UserLogin;
                this.UserPassword = UserPassword;
              }

            public User(string FirstName, string LastName, string UserLogin, string UserPassword ){
                this.FirstName = FirstName;
                this.LastName = LastName;
                this.UserLogin = UserLogin;
                this.UserPassword = UserPassword;
            }
                
            public bool CreateLogin(string userName, string password)
            {

                    bool validInput;

                    if (userName == "" || password == "")
                    {
                       validInput = false; // username and password fields cannot be empty. 
                    }
                    else
                    {
                     validInput = true; // Login created successfully. 
                    }
                    return validInput ;
            }
        
        public bool UserLoginConfirm (string username, string password)
        {

        bool response;
        if (username == this.UserLogin && password==this.UserPassword)
            {
                response = true; // username and password match user can proceed.
            }
        else
            {
             response = false; // if credentials don't match user has to try again.
            }               
        return response;
        }


            public string printEmployee(){

                return " "+this.EmployeeID+" "+this.FirstName+" "+this.LastName;
            }




}