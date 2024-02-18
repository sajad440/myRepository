public  class Program
{
    public static void Main(string[] args)
    {
        PosDevice pos1 = new PosDevice();
        bool exit = false ;
    
        
        while(!exit)
        {
         System.Console.WriteLine("hi \n 1 = buy \n 2 = see your transaction \n 3 = exit");
         var user = Convert.ToInt32(Console.ReadLine());
            switch (user)
            {
                case 1:
                {
                    PosDevice.Buy(pos1);
                    Console.WriteLine(" press any key to back menu ");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                }

                case 2:
                {
                    pos1.statusOfTransaction();
                    Console.WriteLine(" press any key to back menu ");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                }
            
                case 3:
                {   System.Console.WriteLine("have a good day !");
                    exit = true;
                    Console.Clear();
                    break;
                }
               default:
               System.Console.WriteLine(" error ");
               break;
                
              
            
            }
                    
        }
    }

       

}

public class PosDevice
{
    public int Price { get; set; }
    public string CardNumber { get; set; }
    public int CVV2 { get; set; }
    public string Name { get; set; }
    public string expirationDate { get; set; }
    public int DynamicCode { get; set; }
    public bool Wrong = false ;
    bool succsessTransaction;
    public void UserPrice()
    {  System.Console.WriteLine("Please enter the price");
        var userInput =Convert.ToInt32(Console.ReadLine());
        if (userInput!=0)
        {
         Price = userInput;
        }
        else {System.Console.WriteLine("error . please enter price corect"); Wrong = true ;}
        
       
    }
    public void UserCardNumer()
    {
        
         System.Console.WriteLine("please enter the card you have saved ");
        var UserCardInput =Console.ReadLine(); 
        if (UserCardInput.Length==16&&UserCardInput!=" ")
        {
            CardNumber = UserCardInput ;
        } else {System.Console.WriteLine("error . please enter your card corect");}
    }
    public void UserCvv2()
    {
        System.Console.WriteLine("enter your Cvv2");
        var UserCvv2Input =Convert.ToInt32(Console.ReadLine());
        if (UserCvv2Input>=100&&UserCvv2Input<=999)
        {
            CVV2 =UserCvv2Input;
        } else {System.Console.WriteLine("error . please enter cww2 corect"); Wrong = true ;}
        
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

        var Date =UExpirationYear+" "+UExpirationMonth;
        if ((UExpirationYear>=1402&&UExpirationYear<=1500)&&(UExpirationMonth>=1&&UExpirationMonth<=12))
        {
            expirationDate = Date;
        } else {System.Console.WriteLine("error . please enter date corect"); Wrong = true ;}
        
    }
    public void UserDynamicCode()
    {
        System.Console.WriteLine("enter your dynamic code :");
        var code =Convert.ToInt32(Console.ReadLine());
        if (code>=100000&&code<1000000)
        {
            DynamicCode= code ;
        } else {System.Console.WriteLine("error . please enter code corect"); Wrong = true ;}
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
                            succsessTransaction =true;
                            
                         }
                         else
                         {
                            System.Console.WriteLine("wrong Code");
                            Wrong =true;
                            succsessTransaction =false;
                         }
                     }
                     else 
                     {
                        System.Console.WriteLine("wrong Date");
                        Wrong =true;
                        succsessTransaction =false;
                     }
                 }
                 else
                 {
                    System.Console.WriteLine("wrong cvv2 ");
                     Wrong =true;
                     succsessTransaction =false;
                 }
             }
             else
             {
                System.Console.WriteLine("wrong name and family");
                            Wrong =true;
                            succsessTransaction =false;
             }
         }
         else
         {
            System.Console.WriteLine("wrong Card number");
            Wrong =true;
            succsessTransaction =false;
         }
    }
    
    public static void Buy(PosDevice pos1 )
    {
        
        pos1.UserPrice();
        pos1.UserCardNumer();
        pos1.Username();
        pos1.UserCvv2();
        pos1.UserExpirationDate();
        pos1.UserDynamicCode();
        System.Console.WriteLine(" please wait...");
        pos1.ValidationOfInformation();
       
    }
    public  void statusOfTransaction()
    {
        if (succsessTransaction == true )
            {
                TextWriter history = new StreamWriter("K:\\sajad\\myRepository\\Active SMS verification\\statusOftransaction.txt");
                var text = $"your transaction was succsessful . \n price : {Price} \n card number  : {CardNumber} \n name and family : {Name}  \n expiration Date : {expirationDate}  ";
                System.Console.WriteLine(text);
                history.WriteLine(text);
                history.Close();
                
            }
            else{TextWriter history = new StreamWriter("K:\\sajad\\myRepository\\Active SMS verification\\statusOftransaction.txt");
                var text =$"your transaction was not succsessful .  \n price : {Price} \n card number  : {CardNumber} \n name and family : {Name}  \n expiration Date : {expirationDate} ";
                System.Console.WriteLine(text);
                history.WriteLine(text);
                history.Close();
                
                }
    }
}
