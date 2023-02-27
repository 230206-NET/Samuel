using System.Reflection;

namespace PaidExpenses;
using System.Data.SqlClient;

public class DBHandling
{
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
                        Cost = (int)reader["Cost"],
                    }
                );
                        //Debugging purposes. 
                        // Console.WriteLine("ID "+reader["ID"]);
                        // Console.WriteLine("ExpenseType "+reader["ExpenseType"]);
                        // Console.WriteLine("Cost "+reader["Cost"]);
                       
                    }
    }           
                        foreach(Expenses e in allExpenses){
                            Console.WriteLine(e.print());
                        }
           
        return allExpenses;
    }

    //Gets the name and ID of each employee
public List<Employee> GetEmployeeInfo(){

List<Employee> allEmployees = new();
        
        //Establishing the database connection
     using SqlConnection connect2 = new SqlConnection(ConnectionClass.connectStringGetter);

        connect2.Open();

       using SqlCommand command2 = new SqlCommand("SELECT * FROM Employee; ",connect2);

        using SqlDataReader reader = command2.ExecuteReader();

       if(reader.HasRows){ 
        
     while(reader.Read()){
                    allEmployees.Add (new Employee
                    {
                        EmployeeID = (int)reader["ID"],
                        FirstName = (string)reader["FirstName"],
                        LastName = (string)reader["LastName"],
                    }
                );
                       
                    }
    }           
                        foreach(Employee e in allEmployees){
                            Console.WriteLine(e.printEmployee());
                        }
           
        return allEmployees;

    }


// Allows user to submit expense tickets by writing to the PaidExpenses DataBase. 
public Expenses submitExpenses(Expenses submittedExpenses)
{

    using SqlConnection connect = new SqlConnection(ConnectionClass.connectStringGetter);
    
    connect.Open();
    
 using SqlCommand command = new SqlCommand("INSERT INTO PaidExpenses (ExpenseType,Cost,ID) Output INSERTED.ID  Values(@ID,@expenseType,@Cost)", connect);

    command.Parameters.AddWithValue("@ID",submittedExpenses.ID);
    command.Parameters.AddWithValue("@expenseType", submittedExpenses.expenseType);
    command.Parameters.AddWithValue("@Cost", submittedExpenses.Cost);

    int tableID = (int) command.ExecuteScalar();

    submittedExpenses.ID = tableID;

     foreach(Employee emp in submittedExpenses.employeeExpenses){

    using SqlCommand command2 = new SqlCommand("INSERT INTO Employee (FirstName,LastName) Output INSERTED.ID Values(@FirstName, @LastName)", connect);

    command2.Parameters.AddWithValue("@expenseType", emp.FirstName);
    command2.Parameters.AddWithValue("@Cost", emp.LastName);

    int tableID2 = (int) command.ExecuteScalar();

    emp.ID = tableID2;

   
    }

return  submittedExpenses;
}

}