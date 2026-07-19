/*
 * Name: Reuben J Elie
 * Date: July 2026
 * Assignment: SDC220 Performance Assessment - Account Balance Calculations
 * Description:
 * This application demonstrates the use of a user-defined exception
 * to prevent an account balance from becoming negative. It also
 * handles invalid user input using a FormatException.
 */

using System;

// User-defined exception
class AmountException : Exception
{
    public AmountException(string message) : base(message)
    {
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Reuben J Elie - Week 4 PA Account Balance Calculations");
        Console.WriteLine();

        Console.Write("Please enter the starting balance: ");

        double balance;

        while (!double.TryParse(Console.ReadLine(), out balance) || balance < 0)
        {
            Console.Write("Invalid balance. Please enter a valid starting balance: ");
        }

        while (true)
        {
            try
            {
                Console.Write("\nPlease enter a credit or debit amount (0 to quit): ");

                string input = Console.ReadLine();

                double amount = Convert.ToDouble(input);

                if (amount == 0)
                {
                    break;
                }

                // Check if debit makes balance negative
                if (balance + amount < 0)
                {
                    throw new AmountException("Amount entered will cause account to be negative.");
                }

                // Update balance
                balance += amount;

                Console.WriteLine($"The updated balance is: {balance:F2}");
            }
            catch (AmountException ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("The account balance cannot be negative.");
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("Please enter a numeric value.");
            }
        }

        Console.WriteLine($"\nFinal account balance: {balance:F2}");
    }
}