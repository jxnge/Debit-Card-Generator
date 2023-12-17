# Debit-Card-Generator
This C# program generates fictitious debit card information, including the cardholder's name, surname, chosen currency, card company, debit card number, expiration date, and CVC. It offers a basic command-line interface for user interaction.

## Getting Started
To run the program, follow these steps:

1. Clone or download the repository to your local machine.
2. Open the project in your preferred C# development environment.
3. Compile and run the program.

# Usage
1. Run the program, and you will be prompted to enter your name, surname, chosen currency, and card company.
2. The program will validate the input and generate fictitious debit card information if the input is valid.
3. If any input is invalid or missing, the program will notify you.
   
# Supported Currencies
* USD - US dollar
* EUR - euro
* GBP - British pound
* CHF - Swiss franc
* PLN - Polish złoty
* JPY - Japanese yen
* CNY - Chinese yuan
* RUB - Russian ruble
  
# Supported Card Companies
* AMEX (American Express)
* VISA
* MASTERCARD
* DISCOVER
  
# Debit Card Generation Algorithm
The program uses a pseudo-random algorithm to generate a 16-digit debit card number based on the chosen card company. It also generates a corresponding expiration date and CVC.

# Sample Output
Pass your name
John
Pass your surname
Doe
Choose currency: USD / EUR / GBP / CHF / PLN / JPY / CNY / RUB
USD
Choose card company: AMEX (American Express) / VISA / MASTERCARD / DISCOVER
VISA

Name: John
Surname: Doe
Currency: USD
Card Company: VISA
Debit Card: 4920 4175 3735 9010
Expiration Date: 12/28
CVC: 123

# Note
This program is for educational and entertainment purposes only. The generated debit card information is not valid for any real-world transactions.
