internal class Program
{
    private static void Main(string[] args)
    {
        CreditCard card1 =new CreditCard();
        card1.AddCard();
        card1.ShowCards();
       
        
    }
}
public class CreditCard
{
  
  TextWriter CardNumber1 = new StreamWriter("K:\\sajad\\myRepository\\Active SMS verification\\CardList.txt");
  
public void AddCard()
 {
    System.Console.WriteLine("enter your card number (16 digits)");
    var usercard = Console.ReadLine();
    if(usercard.Length==16)
    {
        CardNumber1.WriteLine("Card number :" + usercard);
    }
    else{System.Console.WriteLine("error");}

    System.Console.WriteLine("enter your name and family");
    var userName = Console.ReadLine();
    var userFamilly = Console.ReadLine();
    CardNumber1.WriteLine("name : "+userName + " " + userFamilly);
     //user Expiration will write in a .txt 
     System.Console.WriteLine("enter your expirtion date with this format : yy/mm} example ==> 04/02");
    var userED = Console.ReadLine();
    if(userED.Substring(2,1)=="/")
    {
        CardNumber1.WriteLine("Expiration date : "+userED);
        CardNumber1.Close();
    }
     else{System.Console.WriteLine("error");}

 }
 
 public void ShowCards()
 {
    string text =@"K:\\sajad\\myRepository\\Active SMS verification\\CardList.txt";
    string t = File.ReadAllText(text);
   Console.WriteLine("your info"+"\n"+t);
 }
}