public interface IZooService
{
    Task<List<Animal>> GetAllAnimalsFromZooAsync();

    List<Animal> GetAnimalsByMovementType(MovementType movementType);

    bool AddAnimalToZoo(Animal animal);
}