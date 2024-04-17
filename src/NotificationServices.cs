namespace LibraryApp;


public interface INotificationService
{
    void SendNotificationOnSuccess(string successMsg);
    void SendNotificationOnFailure(string failureMsg);
}

public class EmailNotificationService : INotificationService
{
    public void SendNotificationOnSuccess(string successMsg)
    {
        Console.WriteLine($"Email on sucess {successMsg}");

    }
    public void SendNotificationOnFailure(string failureMsg)
    {

        Console.WriteLine($"Email on failure {failureMsg}");
    }

}

public class SMSNotificationService : INotificationService
{
    public void SendNotificationOnSuccess(string successMsg)
    {
        Console.WriteLine($"SMS on sucess {successMsg}");

    }
    public void SendNotificationOnFailure(string failureMsg)
    {

        Console.WriteLine($"SMS on failure {failureMsg}");
    }
}