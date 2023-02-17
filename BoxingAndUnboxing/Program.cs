
double a = 230.123;
int b = 120;
decimal c = 158;
string demo = "Boxing and Unboxing";

List<object> obj = new List<object>();

obj.Add(a);
obj.Add(b);
obj.Add(c);
obj.Add(demo);

//From line 15 to 19 it shows how different value type values can be boxed into the Class Object. 
foreach(var item in obj){

    Console.WriteLine(item);

}

//As per Unboxing, if we want to perform some math operation on the data types like int, double, etc found in the object obj, such value types need to be explicitly unboxed. 

double sum =0; 

sum+= (double)obj[0]*(int)obj[1];

Console.WriteLine("The sum is "+sum);