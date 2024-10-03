
/// <summary>
/// This class implements a simple game character
/// 1) The character has a certain number of "hit points"
/// 2) The character can deal damage
/// 3) The character can receive damage, causing the hit points to decrease
/// </summary>
public class Entity
{
    #region Instance fields
    private int _hitPoints;
    private NumberGenerator _generator;
    private BattleLog _log;
    private string _name;
    #endregion

    #region Constructor
    /// <summary>
    /// Create a Hero, using references to a random number generator and a battle log
    /// </summary>
    public Entity(NumberGenerator generator, BattleLog log, int hp, int minDam, int maxDam, string name)
    {
        _generator = generator;
        _log = log;
        _name = name;
        Reset();
    }
    #endregion

    #region Properties
    /// <summary>
    /// Checks if the Hero is dead, defined as having 0 or less hit points...
    /// </summary>
    public bool Dead
    {
        get { return (_hitPoints <= 0); }
    }
    #endregion

    #region Methods
    /// <summary>
    /// Reset the Hero's state to the original state
    /// </summary>
    public void Reset()
    {
        _hitPoints = 100;
    }

    /// <summary>
    /// Returns the amount of points a Hero deals in damage.
    /// This damage could then be received by another character
    /// </summary>
    public int DealDamage()
    {
        int damage = _generator.Next(10, 30);
        string message = $"{_name} dealt {damage} damage!";
        _log.Save(message);
        return damage;
    }

    /// <summary>
    /// The Hero receives the amount of damage specified in the parameter.
    /// The number of hit points will decrease accordingly
    /// </summary>
    public void ReceiveDamage(int points)
    {
        _hitPoints = _hitPoints - points;
        string message = $"{_name} receives {points} damage, and is down to {_hitPoints} hit points";
        _log.Save(message);

        if (Dead)
        {
            _log.Save($"{_name} died!");
        }
    }
    #endregion
}
