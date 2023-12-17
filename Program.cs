internal class Program
{
    private static void Main(string[] args)
    {
        
        DebitCardInfo();
    }

    static void DebitCardInfo()
    {
        string[] currencies = { "USD", "EUR", "GBP", "CHF", "PLN", "JPY", "CNY", "RUB" };
        string[] companies = { "AMEX", "VISA", "MASTERCARD", "DISCOVER" };

        //dodać expire date i currency
        Console.WriteLine("Pass your name");
        string name = Console.ReadLine();
        Console.WriteLine("Pass your surname");
        string surname = Console.ReadLine();
        Console.WriteLine("Choose currency: USD / EUR / GBP / CHF / PLN / JPY / CNY / RUB");
        string currency = Console.ReadLine().ToUpper();
        Console.WriteLine("Choose card company: AMEX (American Express) / VISA / MASTERCARD / DISCOVER");
        string company = Console.ReadLine().ToUpper();
        Console.WriteLine("\n");
        if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(surname) && companies.Contains(company) && currencies.Contains(currency))
        {
                name = char.ToUpper(name[0]) + name.Substring(1);
                surname = char.ToUpper(surname[0]) + surname.Substring(1);
                int[] debit_cardArray = DebitCard(company);
                string debit_card = string.Join("", debit_cardArray.Select(x => x.ToString()).ToArray());
                debit_card = debit_card.Insert(4, " ");
                debit_card = debit_card.Insert(9, " ");
                debit_card = debit_card.Insert(14, " ");
                int[] cvcArray = Cvc(company);
                string cvc = string.Join("", cvcArray.Select(x => x.ToString()).ToArray());
                string expiration_date = expirationDate();
                Console.WriteLine($"Name: {name}\nSurname: {surname}\nCurrency: {currency}\nCard Company: {company}\nDebit Card: {debit_card}\nExpiration Date: {expiration_date}\nCVC: {cvc}");
        }else
        {
            Console.WriteLine("Something went wrong. You haven't passed your name, surname, valid currency or valid card company.");
        }
    }   


    static int[] DebitCard(string company)
    {
        //card example: 1234 5678 9012 3456

        int[] debit_card = new int[16];

        Random rnd = new Random();
        int sumOfDigits = 1;
        while (sumOfDigits % 10 != 0)
        {
            sumOfDigits = rnd.Next(20, 121);
        }
        int[] potentialNumbers = { 6, 8, 10, 12 };
        int firstDigit = 0;
        if (company == "AMEX") 
        {   
            firstDigit = 6;
        }
        else if (company == "VISA")
        {
            firstDigit = 8;
        }
        else if (company == "MASTERCARD")
        {
            firstDigit = 10;
        }
        else if (company == "DISCOVER")
        {
            firstDigit = 12;
        }
        debit_card[0] = firstDigit / 2;
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
                debit_card[i] = nextDigit;
                restOfDigits -= nextDigit;
            }
            else
            {
                debit_card[i] = 0;
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
                    debit_card[i] = (nextDigit + 9) / 2;
                }
                else
                {
                    debit_card[i] = nextDigit / 2;
                }   
            }
            else
            {
                debit_card[i] = 0;
            }
        }


        while (restOfDigits > 0)
        {
            for (int i = 1; i < 16; i += 2)
            {
                if (restOfDigits > 0)
                {
                    if (debit_card[i] < 9)
                    {
                        debit_card[i]++;
                        restOfDigits--;
                    }
                }
            }
        }   
        return debit_card;
    }

    static int[] Cvc(string company)
    {
        Random rnd = new Random();
        if (company == "AMEX")
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

    static string expirationDate()
    {
        Random rnd = new Random();
        DateTime currentDateTime = DateTime.Now;
        string month = DateTime.Now.ToString("MM");
        string year = DateTime.Now.ToString("yy");
        int yearInt = Int32.Parse(year) + 5;
        return $"{month}/{yearInt}";
    }
}
