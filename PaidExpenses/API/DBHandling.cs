using System.Data;
using System.Reflection;

namespace PaidExpenses;
using System.Data.SqlClient;

public class DBHandling
{
    //string DBstring {get;set;}
    // public DBHandling(string connectStr){

    //     this.DBstring =connectStr;

    // }
    //Establishes the connection to Azure DB and gets Current Data in the Database. 
    public List<Expenses> getExpenses()
    {
        List<Expenses> allExpenses = new();
        
        //Establishing the database connection
     using SqlConnection connect = new SqlConnection(ConnectionClass.connectStringGetter);

        connect.Open();

       using SqlCommand command = new SqlCommand("SELECT * FROM PaidExpenses; ",connect);

        using SqlDataReader reader = command.ExecuteReader();

       if(reader.HasRows){ 
        
     while(reader.Read()){
                    allExpenses.Add (new Expenses
                    {
                        ID = (int)reader["ID"],
                        expenseType = (string)reader["ExpenseType"],
                        Cost = (decimal)reader["Cost"],
                        ExpenseStatus = (string)reader["ExpenseStatus"]
                    }
                );
                        
                    }
    }           
                        foreach(Expenses e in allExpenses){
                            Console.WriteLine(e.print());
                        }
           
        return allExpenses;
    }

    //Gets the name and ID of each employee
public List<User> GetEmployeeInfo(){

List<User> allEmployees = new();
        
        //Establishing the database connection
     using SqlConnection connect2 = new SqlConnection(ConnectionClass.connectStringGetter);

        connect2.Open();

       using SqlCommand command2 = new SqlCommand("SELECT * FROM Employee; ",connect2);

        using SqlDataReader reader = command2.ExecuteReader();

       if(reader.HasRows){ 
        
     while(reader.Read()){
                    allEmployees.Add (new User
                    {
                        EmployeeID = (int)reader["ID"],
                        FirstName = (string)reader["FirstName"],
                        LastName = (string)reader["LastName"],
                        UserLogin = (string)reader["UserName"],
                        UserPassword = (string)reader["UserPassword"]
                    }
                );
                       
                    }
    }           
                        foreach(User e in allEmployees){
                            Console.WriteLine(e.printEmployee());
                        }
           
        return allEmployees;

    }
// Allows user to submit expense tickets by writing to the PaidExpenses DataBase. 
public Expenses submitExpenses(Expenses submittedExpenses)
{

    using SqlConnection connect = new SqlConnection(ConnectionClass.connectStringGetter);
    
    connect.Open();
    
 using SqlCommand command = new SqlCommand("INSERT INTO PaidExpenses(ExpenseType,Cost,ExpenseStatus ,EmployeeID) VALUES(@expenseType,@Cost,@ExpenseStatus,@EmployeeID)", connect);

    command.Parameters.AddWithValue("@expenseType", submittedExpenses.expenseType);
    command.Parameters.AddWithValue("@Cost", submittedExpenses.Cost);
    command.Parameters.AddWithValue("@ExpenseStatus", submittedExpenses.ExpenseStatus);
    command.Parameters.AddWithValue("@EmployeeID",submittedExpenses.ID);

    command.ExecuteNonQuery();

return  submittedExpenses;
}

public User submitUserInfo(User submittedInfo){

     using SqlConnection connect = new SqlConnection(ConnectionClass.connectStringGetter);
    
    connect.Open();
    
 using SqlCommand command = new SqlCommand("INSERT INTO Employee(FirstName,LastName,UserName,UserPassword)        VALUES (@FirstName,@LastName,@UserName,@UserPassword)", connect);

 command.Parameters.AddWithValue("@FirstName", submittedInfo.FirstName);
 command.Parameters.AddWithValue("@LastName",submittedInfo.LastName);
 command.Parameters.AddWithValue("@UserName", submittedInfo.UserLogin);
 command.Parameters.AddWithValue("@UserPassword", submittedInfo.UserPassword);

command.ExecuteNonQuery();

    
return submittedInfo;
}


}