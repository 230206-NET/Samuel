namespace PaidExpenses;
//Console section of the program.
public class Program
{
    public static void Main()
    {
        //ClassLib expensePaid = new ClassLib();
        List <ClassLib> meals = new List<ClassLib>();
        bool parseAirFare;
        int planeTicket;
        goBack:
        Console.WriteLine("Please enter the Airfare cost");
        parseAirFare = int.TryParse(Console.ReadLine(), out planeTicket);
        
        if(parseAirFare)
        {
            Console.WriteLine("You entered "+planeTicket);

        }else{
            Console.WriteLine("Please enter only whole numbers");
            goto goBack;
        }   

        while(true){

        Console.WriteLine("Please enter the description of each meal during your trip");
        
        string description = Console.ReadLine();
        decimal cost;
        bool parseCost;
        do
        {
            Console.WriteLine("Now, Enter le cost");
            parseCost = decimal.TryParse(Console.ReadLine(), out cost);
            if(!parseCost)
            {
                Console.WriteLine("Please enter just a decimal number");
            }
        } while(!parseCost);
        meals.Add(new(description,cost));
        break;
        }   
        Console.Clear();

        foreach(ClassLib item in meals)
        {
            Console.WriteLine(item.mealDesc);
            Console.WriteLine(item.mealCost);
        }

        
            
    }

}

/**
    -Instance variables: 
        *int airfare. 
        *string meals. 
        *int hotelCost.
    -Functionality (MVP):
        * User should be able to log in to the system.
        * User should be able to create a new account in the system.
        * Employee should be able to submit reimbursement tickets.
        * Manager should be able to approve or reject submitted reimbursement tickets.
**/
        public class ClassLib
        {
            public int airfare {get; set;}
            public string mealDesc{get;set;}
            public decimal mealCost {get; set;}
            public int hotelCost{get; set;}

            //Constructor 

            public ClassLib(string mealDesc, decimal mealCost){
                this.mealDesc = mealDesc;
                this.mealCost = mealCost;
            }

        }