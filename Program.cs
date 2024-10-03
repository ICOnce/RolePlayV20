
NumberGenerator theNumberGenerator = new NumberGenerator();
BattleLog theLog = new BattleLog();

//Changed both of them to be an "Entity" 
Entity theHero = new Entity(theNumberGenerator, theLog, 100, 10, 30, "Hero");
Entity theBeast = new Entity(theNumberGenerator, theLog, 80, 5, 50, "Beast");

// While none of them are dead
while (!theHero.Dead && !theBeast.Dead)
{
    //Damage values
    int beastDamage = theBeast.DealDamage();
    int heroDamage = theHero.DealDamage();
    
    //Receive Damage
    theHero.ReceiveDamage(beastDamage);
    theBeast.ReceiveDamage(heroDamage);

    //Make a clear line in the log
    theLog.Save("");
}

//Make a clear line before declaring the winner
Console.WriteLine();

//Checks who won
if (!theHero.Dead && theBeast.Dead)
{
    theLog.Save("\nThe hero has slain the mighty beast");
}
else if (theHero.Dead && !theBeast.Dead)
{
    theLog.Save("\nThe beast has beaten the hero, all hope is lost");
}
else 
{
    theLog.Save("\nThe hero gave his life defeating the beast");
}

//Print log
theLog.PrintLog();
