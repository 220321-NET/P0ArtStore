using Models;
using BL;

namespace UI;

public class ArtHome
{

    private readonly IAsbl _bl;
    public ArtHome(IAsbl bl)
    {
        _bl = bl;
    }



    public void Home()
    {
        Console.WriteLine("Welcome to The Art Shop!");
        Console.WriteLine("What would you like to do?");
        Console.WriteLine("[1] Create an Account");
        Console.WriteLine("[2] Login into existing account");

        Login:
        string reply = Console.ReadLine().Trim();
        Customer Customer = new Customer();

        if (reply == "1")
        {
            Customer = Login();
        }
        else if (reply == "2")
        {
            Customer = Account();

        }
        else if (reply.ToLower() == "x")
        {
            return;
        }
        else
        {
            Console.WriteLine("Invalid Input");
            goto Login;
        }

        if (Customer == null)
        {
            return;
        }
        else 
        {
            if (Customer.IsManager == true)
            {
                Manager manager = (Manager)Customer;
                ManagerView managerView = new ManagerView();

            }

            new CustomerView(_bl, Customer).ArtHome();

        }
        Console.WriteLine("Logged Out.");
    }

    private Customer Login()
    {

        Login:
        Console.WriteLine("Please enter your customer");
        string cName = Console.ReadLine().Trim();

        List<Customer> Customers = _bl.GetAllCustomers();

        foreach (Customer Customer in Customers)
        {
            if (Customer.cName == cName)
            {
                Cpassword:
                Console.WriteLine("Enter your corresponding password: ");
                string Cpassword = Console.ReadLine().Trim();

                if (Customer.Cpassword == Cpassword)
                {
                    Console.WriteLine("Logged In.");
                    Customer loggedIn = Customer;
                    return loggedIn;
                }
                else
                {
                    Cpasswordtry:
                    Console.WriteLine("Incorrect input. Please Try Again. [Y/N]");
                    string CcustInput = Console.ReadLine().Trim().ToUpper();

                    if (CcustInput == "Y")
                    {
                        goto Cpassword;
                    }
                    else if (CcustInput == "N")
                    {
                        goto AltOption;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Input");
                        goto Cpasswordtry;
                    }
                }
            }
        }

        Console.WriteLine("Could not find an account with that customer name.");
        AltOption:
        Console.WriteLine("Would you like to try again? [1] Yes [2] No.");
        string Option = Console.ReadLine().Trim();

        if (Option == "1")
        {
            goto Login;
        }
        else
        {
            Console.WriteLine("Invalid Input");
            goto AltOption;
        }
    }
    public Customer Account()
    {
        Account:
        Console.WriteLine("Enter Customer name: ");
        string cName = Console.ReadLine().Trim();

        List<Customer> Customers = _bl.GetAllCustomers();

        foreach (Customer Customer in Customers)
        {
            if (Customer.cName == cName)
            {
                CustInput:
                Console.WriteLine("That Customer cName is already taken. Try Again?[Y/N]");
                string custInput = Console.ReadLine().Trim().ToUpper();

                if (custInput == "N")
                {
                    return null;
                }
                else if (custInput == "Y")
                {
                    goto Account;
                }
                else
                {
                    Console.WriteLine("Invalid input");
                    goto CustInput;
                }
            }
        }

        Console.WriteLine("Enter a password");
        string Cpassword = Console.ReadLine().Trim();

        Customer newCustomer = new Customer();

        _bl.addCustomer(newCustomer);

        return newCustomer;
    }
}

public class NewBaseType
{
    public object Manager { get; internal set; }
}

public class Manager : NewBaseType
{

    public Manager(IAsbl bl, Manager manager)
    {
    }

    public static explicit operator Manager(Customer v)
    {
        throw new NotImplementedException();
    }
}