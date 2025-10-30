Console.Clear();
Console.WriteLine("Welcome to Hunting The Manticore");
Console.WriteLine("In this game, The Manticore(Player 1) will set a distance from the City to start at(1-100).");
Console.WriteLine("The Defender(Player 2) will then try to fire their cannon at the Manticore.");
Console.WriteLine("While the Manticore is still alive, the City will take 1 damage per turn.");
Console.WriteLine();
Console.Write("Player 1, how far away from the city do you want to station the Manticore?");
int ManticoreLocation = int.Parse(Console.ReadLine());
while (ManticoreLocation < 1 || ManticoreLocation > 100)
{
    Console.WriteLine("That is an invalid location, please try again");
    ManticoreLocation = int.Parse(Console.ReadLine());
}
int CityMaxHealth = 15;
int CityHealth = CityMaxHealth;
int ManticoreMaxHealth = 10;
int ManticoreHealth = ManticoreMaxHealth;
int roundNumber = 1;
Console.Clear();
while (CityHealth > 0 && ManticoreHealth > 0)
{
    int cannonDamage = HuntingTheManticore.CannonDamageMultiplier(roundNumber);
    Console.WriteLine($"STATUS: Round: {roundNumber} City: {CityHealth}/{CityMaxHealth} Manticore: {ManticoreHealth}/{ManticoreMaxHealth}");
    Console.WriteLine($"The cannon is expected to do {cannonDamage} damage this round.");
    Console.Write("Enter desired cannon range: ");
    int AttackLocation = int.Parse(Console.ReadLine());
    if (AttackLocation < 0 || AttackLocation > 100) Console.WriteLine("That is an invalid attack location");
    else
    {
        string outcomeOfShot = HuntingTheManticore.ShotDistance(AttackLocation, ManticoreLocation);
        Console.WriteLine($"Your shot was {outcomeOfShot}");
        if (outcomeOfShot == "Direct Hit") ManticoreHealth = ManticoreHealth - cannonDamage;
        //One way was to check if the remainder after dividing the round number by 4 was 0.
        //A second way was to have and a counter that when it reached 4 the manticore would move and the counter would reset.
        if (ManticoreHealth > 0 && roundNumber % 4 == 0)
        {
            Console.WriteLine("Manticore, you may add or subtract up to 10 from your current position.");
            int PossibleLocation = int.Parse(Console.ReadLine());
            while (PossibleLocation < -10 || PossibleLocation > 10)
            {
                Console.WriteLine("You're not allowed to move that far");
                Console.WriteLine("Please enter a new distance to move.");
                PossibleLocation = int.Parse(Console.ReadLine());
            }
            if (PossibleLocation >= -10 && PossibleLocation <= 10)
            {
                while (ManticoreLocation + PossibleLocation < 1 || ManticoreLocation + PossibleLocation > 100)
                {
                    Console.WriteLine("That is an invalid location, please try again");
                    PossibleLocation = int.Parse(Console.ReadLine());
                }
                ManticoreLocation = ManticoreLocation + PossibleLocation;
            }
            Console.Clear();
        }
        CityHealth--;
        roundNumber++;
        Console.WriteLine();
    }

}
if (CityHealth <= 0)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("The City has been destroyed. The Manticore has won.");
}
else if (ManticoreHealth <= 0)
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("The Manticore has been destroyed! The City have been saved!");
}
Console.ForegroundColor = ConsoleColor.White;

public class HuntingTheManticore
{
    public static string ShotDistance(int attackLocation, int manticoreLocation)
    {
        if (attackLocation == manticoreLocation)
        {
            return "Direct Hit";
        }
        else if (attackLocation > manticoreLocation)
        {
            return "Overshot";
        }
        else if (attackLocation < manticoreLocation)
        {
            return "Short";
        }
        else return "";
    }
    public static int CannonDamageMultiplier(int RoundNumber)
    {
        int CannonDamage = 1;
        if (RoundNumber % 3 == 0)
        {
            if (RoundNumber % 5 == 0)
            {
                CannonDamage = CannonDamage * 10;
                return CannonDamage;
            }
            CannonDamage = CannonDamage * 3;
            return CannonDamage;
        }
        if (RoundNumber % 5 == 0)
        {
            CannonDamage = CannonDamage * 3;
            return CannonDamage;
        }
        return CannonDamage;
    }
    [Fact]
    public void HitOrMiss()
    {
        Assert.Equal("Short", ShotDistance(1, 2));
        Assert.Equal("Overshot", ShotDistance(2, 1));
        Assert.Equal("Direct Hit", ShotDistance(1, 1));

    }
    [Fact]
    public void DamageMultiplication()
    {
        Assert.Equal(1, CannonDamageMultiplier(1));
        Assert.Equal(3, CannonDamageMultiplier(3));
        Assert.Equal(3, CannonDamageMultiplier(5));
        Assert.Equal(10, CannonDamageMultiplier(15));

    }
}
