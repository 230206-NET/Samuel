
namespace PaidExpenses;

internal  class ConnectionClass

{
    private const string connectString ="Server=tcp:paidexpensesserver.database.windows.net,1433;Initial Catalog=PaidExpensesSystem;Persist Security Info=False;User ID=admin1010;Password=MacBookPro2021$$;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

    public static string connectStringGetter{get => connectString;}
}