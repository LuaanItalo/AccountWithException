using ContaComException.Entities.Exceptions;
using ContaComException.Entities;
using System.Globalization;

internal class Program
{
    private static void Main(string[] args)
    {
        try
        {
            Console.WriteLine("Enter sccount data: ");
            Console.Write("Number: ");
            int number = int.Parse(Console.ReadLine()!);
            Console.Write("Holder: ");
            string holder = Console.ReadLine()!;
            Console.Write("Initial balance: ");
            double initialBalance = double.Parse(Console.ReadLine()!, CultureInfo.InvariantCulture);
            Console.Write("Withdraw limit: ");
            double withDrawLimit = double.Parse(Console.ReadLine()!, CultureInfo.InvariantCulture);

            Account account = new Account(number, holder, initialBalance, withDrawLimit);

            Console.WriteLine();
            Console.Write("Enter amount for withdraw: ");
            double amount = double.Parse(Console.ReadLine()!, CultureInfo.InvariantCulture);
            account.Withdraw(amount);
           

        }
        catch (DomainException e)
        {
            Console.WriteLine($"Withdraw error: {e.Message}");
        }
    }
}