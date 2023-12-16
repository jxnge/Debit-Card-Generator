internal class Program
{
    private static void Main(string[] args)
    {
        
        CreditCardInfo();
    }

    static void CreditCardInfo()
    {
        //dodać expire date i currency
        Console.WriteLine("Pass your name");
        string name = Console.ReadLine();
        Console.WriteLine("Pass your surname");
        string surname = Console.ReadLine();
        int[] credit_cardArray = CreditCard();
        string credit_card = string.Join("", credit_cardArray.Select(x => x.ToString()).ToArray());
        string company = Company(credit_cardArray);
        int[] cvcArray = Cvc(company);
        string cvc = string.Join("", cvcArray.Select(x => x.ToString()).ToArray());
        Console.WriteLine($"Name: {name}, Surname: {surname}, Credit Card: {credit_card}, Company: {company}, CVC: {cvc}");
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
        int[] potentialNumbers = { 6, 8, 10, 12 };
        int randomNumber = rnd.Next(0, 4);
        int firstDigit = potentialNumbers[randomNumber];
        credit_card[0] = firstDigit / 2;
        if (firstDigit > 9)
        {
            firstDigit -= 9;
            
        }

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
                    credit_card[i] = (nextDigit + 9) / 2;
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


        while (restOfDigits > 0)
        {
            for (int i = 1; i < 16; i += 2)
            {
                if (restOfDigits > 0)
                {
                    if (credit_card[i] < 9)
                    {
                        credit_card[i]++;
                        restOfDigits--;
                    }
                }
            }
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

    static int[] Cvc(string company)
    {
        Random rnd = new Random();
        if (company == "American Express")
        {
            int[] cvc = new int[4];
            for (int i = 0; i < 4; i++)
            {
                cvc[i] = rnd.Next(0, 10);
            }
            return cvc;
        }
        else
        {
            int[] cvc = new int[3];
            for (int i = 0; i < 3; i++)
            {
                cvc[i] = rnd.Next(0, 10);
            }
            return cvc;
        }
    }
}