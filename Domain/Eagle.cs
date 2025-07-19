public class Eagle(MovementType movementType) : Animal(movementType, nameof(Eagle))
{
    public override void MakeSound()
    {
        Console.WriteLine("Screeeeeeeech!!!");
    }
}