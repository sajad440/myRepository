using System.IO;

internal class Program
{
    private static void Main(string[] args)
    {
        CreditCard card1 =new CreditCard();
        bool exit = false;
        while (exit==false)
        {
          
          System.Console.WriteLine("hi \n 1 = add new card \n 2 = show your card \n 3 = make dynamic code for purchase \n 4 = exit");
          var UserSelect = Console.ReadLine();
          switch(UserSelect)
          {
            case "1":
            {
              Console.Clear();
              card1.AddCard();
              System.Console.WriteLine("press any key for back to menu");
              Console.ReadKey();
              Console.Clear();
              break;
            }
            case "2":
            {
              Console.Clear();
              card1.ShowCards();
               System.Console.WriteLine("press any key for back to menu");
              Console.ReadKey();
              Console.Clear();
              break;
            }
            case "3":
            {
              Console.Clear();
              card1.CodeMaker();
              System.Console.WriteLine("press any key for back to menu");
              Console.ReadKey();
              Console.Clear();
              break;
            }
            case "4":
            {
              Console.Clear();
              System.Console.WriteLine("have a nice day");
              exit=true;
              break;
            }


          }
        }
      
    }

}
public class CreditCard
{
  TextWriter CardNumber = new StreamWriter("K:\\sajad\\myRepository\\Active SMS verification\\CardList.txt");
  TextWriter NameAndFamily = new StreamWriter("K:\\sajad\\myRepository\\Active SMS verification\\NameAndFamily.txt");
  TextWriter Cvv2 = new StreamWriter("K:\\sajad\\myRepository\\Active SMS verification\\cv2.txt");
  TextWriter ExpirationDate = new StreamWriter("K:\\sajad\\myRepository\\Active SMS verification\\expiration.txt");
  TextWriter DCode = new StreamWriter("K:\\sajad\\myRepository\\Active SMS verification\\dynamicCode.txt");
  
public void AddCard()
 {  bool wrongInput = false;
   if(wrongInput==false)
   {
     System.Console.WriteLine("enter your card number (16 digits)");
    var usercard = Console.ReadLine();
    var alphabet = new char[]{'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q'};
    if(usercard.Length==16)
    {
       
        CardNumber.WriteLine(usercard);
        CardNumber.Close();
    }
    else
    {
      System.Console.WriteLine("error");
      wrongInput=true;
    }

    if (wrongInput==false)
    {
      System.Console.WriteLine("enter your name :");
    var userName = Console.ReadLine();

    System.Console.WriteLine("enter your family :");
    var userFamilly = Console.ReadLine();
   
    NameAndFamily.WriteLine(userName + " " +  userFamilly);
    NameAndFamily.Close();
    System.Console.WriteLine("enter your cvv2 ( 3 <= cvv2 <= 5 ) ");
    var cvv2 = Convert.ToInt32(Console.ReadLine());
    if  (cvv2>99&&cvv2<999)
    { 
      Cvv2.WriteLine(cvv2);
      Cvv2.Close();
    }
    else
    {System.Console.WriteLine("error please enter cvv2 in correct form");
      wrongInput = true;
    }
     //user Expiration will write in a .txt 
    System.Console.WriteLine("enter your expiration year :");
    var Expirationy = (Console.ReadLine());
    var ExpirationYear = int.Parse(Expirationy);
    
    System.Console.WriteLine("enter your expiration month : ");
    var ExpirationMonth = Convert.ToInt32(Console.ReadLine());

    if(ExpirationYear<1500&&ExpirationYear>=1400)
        {
           if(ExpirationMonth<=12&&ExpirationMonth>=1)
           {
           ExpirationDate.WriteLine(ExpirationYear + ExpirationMonth);
            
            ExpirationDate.Close();

           }
           
                    
        }
        else 
        { System.Console.WriteLine("please write date in correct form => example ( year :1401 month :12 ) "); 
          wrongInput=true;
        }
        Console.Clear();
        System.Console.WriteLine("your card info was saved succses !");
   }
    
    
   }
 }
 
 public void ShowCards()
 {
    string text =@"K:\\sajad\\myRepository\\Active SMS verification\\CardList.txt";
    string t = File.ReadAllText(text);
    
   Console.WriteLine("your info"+"\n"+t);
 }
public  void CodeMaker()
{
  System.Console.WriteLine("please wait a few ...");
  
  Random randomCode = new Random();
  var result = randomCode.Next(100000,1000000);
  DCode.WriteLine(result);
  DCode.Close();
  System.Console.WriteLine($"your code is : {result} \n dont share this code ! ");

  



}

}