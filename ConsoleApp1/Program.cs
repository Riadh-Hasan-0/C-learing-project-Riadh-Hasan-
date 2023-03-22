using System;

namespace consolproject
{
    public class cardHolder
    {
        String firstName, lastName,cardNumber;
        int pin;
        double balance;
        public cardHolder(String firstName, String lastName, String cardNumber,int pin,double balance)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.cardNumber = cardNumber;
            this.pin = pin;
            this.balance = balance;
        }
        public String getFirstName() { return firstName; }
        public String getLastName() { return lastName; }
        public int getPin() { return pin; }
        public double getBalance() { return balance; }
        public String getCardNumber() { return cardNumber; }
        public void setFirstName(String firstName) { this.firstName = firstName;}
        public void setLastName(String lastName) {  this.lastName = lastName;}
        public void setCardNumber(String cardNumber) {  this.cardNumber = cardNumber;}
        public void setPin(int pin) { this.pin = pin;}
        public void setBalance(double balance) { this.balance = balance;}
        public static void Main()
        {
            void printOption()
            {
                Console.WriteLine("please chose your option:");
                Console.WriteLine("1.Deposit");
                Console.WriteLine("2. Withdraw.");
                Console.WriteLine("3. Show balance.");
                Console.WriteLine("4. Exit");                
            }
            void Deposit(cardHolder user)
            {
                Console.WriteLine("Please Enter your Deposite amount: ");
                double amount = Convert.ToDouble(Console.ReadLine());
                user.setBalance(user.getBalance()+amount);
            }
            void Withdraw(cardHolder user)
            {
                Console.WriteLine("Please Enter your Withdraw amount: ");
                double amount = 0;

                while (true)
                {
                    amount = Convert.ToDouble(Console.ReadLine());
                    if (amount > user.getBalance())
                    {
                        Console.WriteLine("You have insuficiant amount!");
                        Console.WriteLine("Please emter amount again: ");
                        continue;
                    }
                    break;
                }
                user.setBalance(user.getBalance()-amount);
                Console.WriteLine("you have successfull withdraw {0}!", amount);
            }
            void ShowBalance(cardHolder user)
            {
                Console.WriteLine("Your current balace is {0}.",user.getBalance());
            }
            List<cardHolder>users= new List<cardHolder>();
            users.Add(new cardHolder("Riadh", "hasan", "12345", 1234, 200.3));
            users.Add(new cardHolder("Tausif", "hasan", "23434", 3333, 56));
            users.Add(new cardHolder("Fuad", "hasan", "66767", 1111, 77.77777777));
            Console.WriteLine("Welcome to BS23-Banking");
            Console.WriteLine("Please enter your card number:");

            cardHolder currentUser;
            while (true)
            {
                try
                {
                    String rec = Console.ReadLine();
                    currentUser = users.FirstOrDefault(a => a.cardNumber == rec);
                    if (currentUser == null)
                    {
                        Console.WriteLine("Card not found!");
                    }
                    else
                    {
                        break;
                    }
                }
                catch
                {
                    Console.WriteLine("Card not found!");
                }
            }
            while (true)
            {
                try
                {
                    Console.WriteLine("Please enter your Password:");
                    int rec = Convert.ToInt32(Console.ReadLine());
                    if (currentUser.getPin() != rec)
                    {
                        Console.WriteLine("Worng Password!!");
                    }
                    else
                    {
                        break;
                    }
                }
                catch
                {
                    Console.WriteLine("Password Error!");
                }
            }
            Console.WriteLine("Welcome" + currentUser.getFirstName() + ":)");
            while (true)
            {
                printOption();
                int option=Convert.ToInt32(Console.ReadLine());
                if (option == 1) { Deposit(currentUser); }
                else if (option == 2) { Withdraw(currentUser); }
                else if (option == 3) { ShowBalance(currentUser); }
                else if (option == 4) { break; }
                else { Console.WriteLine("Give a valid number :("); }

            }

        }
    }
}