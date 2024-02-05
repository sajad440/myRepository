using System.Security.Cryptography.X509Certificates;

internal class Program
{
    private static void Main(string[] args)
    {
        PosDevice pos1 = new PosDevice();
        
        pos1.UserPrice();

        pos1.UserCardNumer();
        /*
        pos1.Username();
        pos1.Userfamily();
        pos1.UserCvv2();
        pos1.UserExpirationDate();
        System.Console.WriteLine("please wait");
        */
       
        
    
    }
}
public class PosDevice
{
    public int Price { get; set; }
    public string CardNumber { get; set; }
    public int CVV2 { get; set; }
    public string Name { get; set; }
    public string Family { get; set; }
    public int expirationDate { get; set; }
    public void UserPrice()
    {
    
        System.Console.WriteLine("Please enter the price");
        var userInput =Convert.ToInt32(Console.ReadLine());
        Price = userInput;
    }
    public void UserCardNumer()
    {
        System.Console.WriteLine("please enter the card you have saved ");
        var UserCardInput =Console.ReadLine(); 
        CardNumber = UserCardInput ;
    }
    public void UserCvv2()
    {
        System.Console.WriteLine("enter your Cvv2");
        var UserCvv2Input =Convert.ToInt32(Console.ReadLine());
        CVV2 =UserCvv2Input;
        
    }
    public void Username()
    {
        System.Console.WriteLine("enter your name");
        var Uname = Console.ReadLine();
          Name = Uname;
    }
    public void Userfamily()
    {
        System.Console.WriteLine("enter your family ");
        var Ufamily = Console.ReadLine();
        Family =  Ufamily;
    }

    public void UserExpirationDate()
    {
     
        System.Console.WriteLine("enter year : like (1401) ");
        int UExpirationYear =Convert.ToInt32(Console.ReadLine());

         System.Console.WriteLine("enter Month : like (12) ");
        int UExpirationMonth =Convert.ToInt32(Console.ReadLine());

        var Date =UExpirationYear+UExpirationMonth;
        expirationDate = Date;
        
    }

   
   
}
