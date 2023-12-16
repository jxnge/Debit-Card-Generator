internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Pass your name");
        string name = Console.ReadLine();
        Console.WriteLine("Pass your surname");
        string surname = Console.ReadLine();
        Console.WriteLine(Company(CreditCard()));
    }

    static int[] CreditCard()
    {
        //card example: 1234 5678 9012 3456

        int[] credit_card = new int[16];

        Random rnd = new Random();
        int sumOfDigits = 1;
        while (sumOfDigits % 10 != 0)
        {
            sumOfDigits = rnd.Next(10, 141);
        }   

        int firstDigit = rnd.Next(3, 7);
        credit_card[0] = firstDigit;
        int restOfDigits = sumOfDigits - firstDigit;
        for (int i = 1; i < 16; i += 2)
        {
            int nextDigit = rnd.Next(0, 10);
            if (nextDigit <= restOfDigits)
            {
                credit_card[i] = nextDigit;
                restOfDigits -= nextDigit;
            }
            else
            {
                credit_card[i] = 0;
            }   
        }

        for (int i = 2; i < 16; i += 2)
        {
            int nextDigit = rnd.Next(0, 10);
            if (nextDigit <= restOfDigits)
            {
                restOfDigits -= nextDigit;
                if (nextDigit % 2 != 0)
                {
                    credit_card[i] = (nextDigit + 2) / 2;
                }
                else
                {
                    credit_card[i] = nextDigit / 2;
                }   
            }
            else
            {
                credit_card[i] = 0;
            }
        }

        foreach (int digit in credit_card)
        {
            Console.Write(digit);
        }   

        return credit_card;
    }

    static string Company(int[] credit_card)
    {   
        int firstDigit = credit_card[0];

        if (firstDigit == 3)
        {
            return "American Express";
        }
        else if (firstDigit == 4)
        {
            return "Visa";
        }
        else if (firstDigit == 5)
        {
            return "MasterCard";
        }
        else if (firstDigit == 6)
        {
            return "Discover";
        }
        else
        {
            return "Unknown";
        }   
    }
}