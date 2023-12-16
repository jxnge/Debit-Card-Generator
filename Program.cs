internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Pass your name");
        string name = Console.ReadLine();
        Console.WriteLine("Pass your surname");
        string surname = Console.ReadLine();
        Console.WriteLine(CreditCard(name, surname));
    }

    static string[] CreditCard(string name, string surname)
    {
        return new string[] { name, surname };
    }
}