
using System;
using System.ComponentModel;
using PaidExpenses;
using System.Text;
//Console section of the program.
public class Program
{
    
    public static void Main()
    {
      new DBHandling().getExpenses(); //Object establishing connection to database and getting the data from database.
         List <Expenses> expenseHandle = new List<Expenses>();
         Expenses exp2 = new();
        //Variables used to handled the description of the expenses, i.e. Rental Car, Airfare, etc.
        string expenseType;
        string confirm;
        bool checker;
        int parsedInt =0;
        //Variables in this section are used to handle employees cost amount from the expense types.
            decimal cost=0;
            bool parseCost;
            //string checker2;
       while(true)
       {
        //Input handling section for the description of the Expenses. 
             goBack:
            Console.WriteLine("Please enter your expense type");
            
            expenseType = Console.ReadLine()!;
            
            checker = int.TryParse(expenseType,out parsedInt);
            
            if(checker)
            {
            Console.WriteLine("Invalid input");
            goto goBack;
            }
            Console.WriteLine("You Entered: "+expenseType+", is this correct(y/n)"); 
             
                goAgain:
                 confirm = Console.ReadLine()!;
                if(confirm.CompareTo("y")==0)
                {
                    expenseHandle.Add(new(expenseType, 0));
                    Console.WriteLine("Do you want to add another expense?{y/n)");
                    if(Console.ReadLine().CompareTo("y")==0!){
                        goto goBack;
                    }else{
                        Console.WriteLine("Bye for now");        
                    }
                } else if(confirm.CompareTo("n")==0){
                    goto goBack;
                } else{
                    Console.WriteLine("Not valid input");
                    goto goAgain;
                } 

            // Input handling section for Cost
            foreach(Expenses e in expenseHandle) {
                do { 
                    Console.WriteLine($"Now, enter the cost for {e.expenseType}.");
                    parseCost = decimal.TryParse(Console.ReadLine(), out cost);

                    if(!parseCost)
                    {
                        Console.WriteLine("Please enter just a decimal number");
                        continue;
                    
                    }else{

                        e.Cost = cost;

                    }

                }while(!parseCost);
            }

              break;
               
        } 
        // Helps output look cleaner. 
         Console.Clear();

        //Prints the expense report entered by the user.  Data collected from user. 
        foreach(Expenses exp in expenseHandle){
            Console.WriteLine(exp.expenseType);
            Console.WriteLine(exp.Cost);
        }
        
        
        for (int i =0; i<expenseHandle.Count;i++){exp2 = expenseHandle.ElementAt(i);}
        

            new DBHandling().submitExpenses(exp2);
        
      

     }
             
    //     while(true){

    //     Console.WriteLine("Please enter the description of each meal during your trip");
        
    //     string description = Console.ReadLine();
    //     decimal cost;
    //     bool parseCost;
    //     do
    //     {
    //         Console.WriteLine("Now, Enter le cost");
    //         parseCost = decimal.TryParse(Console.ReadLine(), out cost);
    //         if(!parseCost)
    //         {
    //             Console.WriteLine("Please enter just a decimal number");
    //         }
    //     } while(!parseCost);
    //     meals.Add(new(description,cost));
    //     break;
    //     }   
    //     Console.Clear();

    //     foreach(Expenses item in meals)
    //     {
    //         Console.WriteLine(item.mealDesc);
    //         Console.WriteLine(item.mealCost);
    //     }
    // }
    }


