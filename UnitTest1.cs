Console.Clear();
Console.WriteLine("Welcome to Hunting The Manticore");
Console.WriteLine("In this game, The Manticore(Player 1) will set a distance from the City to start at(1-100).");
Console.WriteLine("The Defender(Player 2) will then try to fire their cannon at the Manticore.");
Console.WriteLine("While the Manticore is still alive, the City will take 1 damage per turn.");
Console.WriteLine();
Console.WriteLine("Player 1")
int CityMaxHealth = 15;
int CityHealth = CityMaxHealth;
int ManticoreMaxHealth = 10;
int ManticoreHealth = ManticoreMaxHealth;
int roundNumber = 1;

while (CityHealth > 0 || ManticoreHealth > 0)
{
    int cannonDamage = HuntingTheManticore.CannonDamageMultiplier(roundNumber);
    HuntingTheManticore.RoundStatment(CityMaxHealth, CityHealth, ManticoreMaxHealth, ManticoreHealth, roundNumber, cannonDamage);
    Console.Write("Enter desired cannon range: ");
    int AttackLocation = int.Parse(Console.ReadLine());
    if (AttackLocation < 0 || AttackLocation > 100) Console.WriteLine("That is an invalid attack location");
    else
    {
        if (AttackLocation == ManticoreLocation)
        {
            
        }
        CityHealth--;
        roundNumber++;
    }
    
    break;
}
if (CityHealth == 0)
{

}
else if (ManticoreHealth == 0)
{
    
}

public class HuntingTheManticore
{
    public static void RoundStatment(int CityMax, int CityCurrent, int MantMax, int MantCurrent, int RoundNumber, int CannonDamage)
    {
        Console.WriteLine($"STATUS: Round: {RoundNumber} City: {CityCurrent}/{CityMax} Manticore: {MantCurrent}/{MantMax}");
        Console.WriteLine($"The cannon is expected to do {CannonDamage} damage this round.");
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
    public void Test1()
    {

    }
}
