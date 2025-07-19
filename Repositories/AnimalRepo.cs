using Microsoft.EntityFrameworkCore;

public class AnimalRepo(AppDbContext context) : IAnimalRepo
{
    public async Task<List<Animal>> GetAllAnimalsAsync()
    {
        var animals = context
        .Animals
        .OrderBy(o => o.Name)
        .ToList();

        return animals;
    }

    public List<Animal> GetAnimalsByMovementType(MovementType movementType)
    {
        var animals = context
                      .Animals
                      .Where(a => a.MovementType == movementType)
                      .ToList();
        return animals;
    }

    public void AddAnimalToZoo(Animal animal)
    {
        context.Animals.Add(animal);
        context.SaveChanges();
    }

    public bool AnimalExist(string name)
    {
        return context.Animals.Any(a => string.Equals(a.Name, name));
    }
}