public class ZooService(IAnimalRepo animalRepo) : IZooService
{
    private IAnimalRepo _animalRepo = animalRepo;
    public async Task<List<Animal>> GetAllAnimalsFromZooAsync()
    {
        return await _animalRepo.GetAllAnimalsAsync();
    }

    public List<Animal> GetAnimalsByMovementType(MovementType movementType)
    {
        return _animalRepo.GetAnimalsByMovementType(movementType);
    }

    public bool AddAnimalToZoo(Animal animal)
    {
        var isAnimalPresent = _animalRepo.AnimalExist(animal.Name);

        if (!isAnimalPresent)
        {
            _animalRepo.AddAnimalToZoo(animal);
            return true;
        }
        return false;
    }
}