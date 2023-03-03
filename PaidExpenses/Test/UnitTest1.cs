using System.Reflection;
namespace Test;
using PaidExpenses;
public class UnitTest1
 {
    [Fact]
    public void CreateLoginTest()
    {
        User u = new();
       
       Assert.True(u.CreateLogin("Sam12345","OkPass"));
        Assert.False(u.CreateLogin("","123456"));
    }

    // [Fact]
    // public void UserLoginConfirmTest(){

    //     string user = "Sam1990";
    //     string password = "AppleWatch7$";

    //     User user2 = new User(user,password);


    //     Assert.False(user2.UserLoginConfirm("Sam10", "AppleWach7$"));

    // }
}