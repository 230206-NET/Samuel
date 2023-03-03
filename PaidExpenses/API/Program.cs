
using PaidExpenses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<DBHandling>();
builder.Services.AddScoped<User>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapPost("/expenses", ([FromBody]Expenses exp,DBHandling data)=> {
    return data.submitExpenses(exp);
});


app.MapGet("/expenses",(DBHandling expenses)=>{
    return expenses.getExpenses();
});



app.MapGet("/Users",(DBHandling output )=>{
    return output.GetEmployeeInfo();
});

app.MapPost("/Users",([FromQuery]string?username,[FromQuery]string?password)=>
{
        if(new User().CreateLogin(username,password)==false){
        return  Results.BadRequest("username and password fields cannot be empty");
        }
        else
        {
        return Results.Ok("Login created successfully"); 
        }  
});

app.MapPut("/Users",([FromBody]User u, DBHandling userData)=>
{
    return Results.Created("/Users",userData.submitUserInfo(u));
});

 app.Run();


// app.MapGet("/", () => "Hello World!");
// app.MapGet("/greet", ([FromQuery]string? name, [FromQuery]string? country)=> $"Hello my name is {name??"blank"} from {country ??"USA"}!");
