public  class Program
{
    public static void Main(string[] args)
    {
        PosDevice pos1 = new PosDevice();
        bool exit = false ;
        
        pos1.UserPrice();
        pos1.UserCardNumer();
        pos1.Username();
        pos1.UserCvv2();
        pos1.UserExpirationDate();
        pos1.UserDynamicCode();
        System.Console.WriteLine(" please wait...");
        pos1.ValidationOfInformation();
        
        
       
        
    
    }
}
public class PosDevice
{
    public int Price { get; set; }
    public string CardNumber { get; set; }
    public int CVV2 { get; set; }
    public string Name { get; set; }
    public int expirationDate { get; set; }
    public int DynamicCode { get; set; }
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
    
        System.Console.WriteLine("enter your family ");
        var Ufamily = Console.ReadLine();
        
        var NF = Uname + " " + Ufamily; 
        Name = NF;
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
    public void UserDynamicCode()
    {
        System.Console.WriteLine("enter your dynamic code :");
        var code =Convert.ToInt32(Console.ReadLine());
        DynamicCode =code;
    }
    public void ValidationOfInformation()
    {

       StreamReader cardnumberReader = new StreamReader($"K:\\sajad\\myRepository\\Active SMS verification\\CardList.txt");
        var cardnumberResult = cardnumberReader.ReadLine();
        cardnumberReader.Close();

        StreamReader cvv2Reader = new StreamReader($"K:\\sajad\\myRepository\\Active SMS verification\\cv2.txt");
        var cvv2Result = cvv2Reader.ReadLine();
        cvv2Reader.Close();

        StreamReader nameReader = new StreamReader($"K:\\sajad\\myRepository\\Active SMS verification\\NameAndFamily.txt");
        var nameResult = nameReader.ReadLine();
        nameReader.Close();

        StreamReader ExpirationDateReader = new StreamReader($"K:\\sajad\\myRepository\\Active SMS verification\\expiration.txt");
        var ExpirationDateResult = ExpirationDateReader.ReadLine();
        ExpirationDateReader.Close();

        StreamReader DynamicCodeReader = new StreamReader($"K:\\sajad\\myRepository\\Active SMS verification\\dynamicCode.txt");
        var DynamicCodeResult =DynamicCodeReader.ReadLine();
        DynamicCodeReader.Close();
        bool Wrong = false;

        if(CardNumber==cardnumberResult)
         {
            if (Name ==nameResult)
             {
                if(CVV2.ToString()==cvv2Result)
                 {
                    if (expirationDate.ToString()==ExpirationDateResult)
                     {
                        if(DynamicCode.ToString()==DynamicCodeResult)
                         {
                            System.Console.WriteLine("Successful transaction");
                         }
                         else
                         {
                            System.Console.WriteLine("wrong Code");
                            Wrong =true;
                         }
                     }
                     else 
                     {
                        System.Console.WriteLine("wrong Date");
                            Wrong =true;
                     }
                 }
                 else
                 {
                    System.Console.WriteLine("wrong cvv2 ");
                     Wrong =true;
                 }
             }
             else
             {
                System.Console.WriteLine("wrong name and family");
                            Wrong =true;
             }
         }
         else
         {
            System.Console.WriteLine("wrong Card number");
            Wrong =true;
         }
    }
   
   
}
