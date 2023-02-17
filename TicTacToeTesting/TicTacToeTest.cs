using TicTacToe;
using Xunit;
namespace TicTacToeTesting;

public class Test{
    
    [Fact]

    public void TicTacToeTest ()
    {
        MainMenu test = new MainMenu();
        string testStr = "1";
         Assert.True(test.IsValidMove(testStr));
    }

}