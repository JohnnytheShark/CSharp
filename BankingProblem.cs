using System;
/*
Linkedin Learning Banking Problem 
Implement a class hierarchy that represents basic banking operations for a checking and savings account.

You should have a base class that implements basic operations

A constructor that accepts the first and last name of the of the account holder as strings along with a decimal value for the starting balance, witha default value of 0.0m
Balance: A decimal read and write property that contains the account balance
Account Owner: A get-only string that returns the full name of the account owner for example= "John, Doe"
Deposit: A function that accepts a decimal argument, the amount to deposit
Withdraw: A function that accepts a decimal argument, the amount ot withdraw

There should be two subclasses of your base class: CheckingAcct and SavingsAcct

CheckingAcct should have: 
A constructor that accepts the same arguments as the base account class
An override of Withdraw, which checks to see if the amount being withdrawn exceeds the current balance, if so, the account is charged a $35 fee and the withdrawl is allowed

SavingsAcct should have: 
A constructor that accepts the same args as the base acct class
InterestRate: A Read and Write decimal property that contains the interest rate
ApplyInterest: A function that applies the interest rate to the current balance
Withdraw: An override of the Withdraw function that checks to see if the withdrawal amount exceeds the balance
and prevents the withdrawal; if there are more than three withdrawals, then the account is charged a withdrawal charge of $2

*/

public class Answer {

    // Change these Boolean values to control whether you see 
    // the expected result and/or hints.
   public  static Boolean ShowExpectedResult = true;
   public  static Boolean ShowHints = true;

}

public class BankAccount {
    private string _firstname; 
    private string _lastname;
    public decimal Balance {get; set;}

    public BankAccount(string firstname,string lastname, decimal balance=0.0m){
        _firstname = firstname;
        _lastname = lastname;
        Balance = balance;
    }

    public string AccountOwner{
       get => $"{_firstname} {_lastname}";
    }

    public virtual decimal Deposit(decimal amount){
    Balance += amount;
    return Balance;
    }
    public virtual decimal Withdraw(decimal amount){
        Balance -= amount;
        return Balance;
    }

}

public class CheckingAcct : BankAccount {


    public CheckingAcct(string firstname, string lastname, decimal balance) : base(firstname,lastname,balance)
    {
    }


    public override decimal Withdraw(decimal amount){
        if (amount > Balance){
            amount += 35.0m;
        }
        base.Withdraw(amount);
        return Balance;
    }
}

public class SavingsAcct : BankAccount {
    private int _withdrawcount = 0;
    private const int WLimit = 3;
    public decimal InterestRate {
        get; set;
    }


    public SavingsAcct(string firstname, string lastname,decimal interest, decimal balance) : base(firstname,lastname,balance)
    {
        InterestRate = interest;
    }
    public decimal ApplyInterest(){
        Balance += (Balance*InterestRate);
        return Balance;
    }
    public override decimal Withdraw(decimal amount){
        if (amount > Balance){
            Console.WriteLine("Attempt to overdraw savings - denied");
            return Balance;
        }else{
            base.Withdraw(amount);
            _withdrawcount++;
            if (_withdrawcount > WLimit){
                Console.WriteLine("More than 3 withdrawals - extra charge");
                base.Withdraw(2.0m);
                return Balance;
            }
            return Balance;
        }
    }

}