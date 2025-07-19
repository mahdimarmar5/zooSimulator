public abstract class Animal(MovementType movementType, string name)
{
    public int Id { get; private set; }

    public string _name = name;

    public string Name
    {
        get => _name;
        private set
        {
            _name = value;
        }
    }

    public MovementType _movementType = movementType;

    public MovementType MovementType
    {
        get => _movementType;
        private set
        {
            _movementType = value;
        }
    }

    public virtual void MakeSound() => Console.WriteLine("*Silence*");
}