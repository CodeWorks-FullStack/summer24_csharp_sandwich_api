
namespace sandwich_api.Services;

// services are reserved for business logic
public class SandwichesService
{
  private readonly SandwichesRepository _sandwichesRepository;

  public SandwichesService(SandwichesRepository sandwichesRepository)
  {
    _sandwichesRepository = sandwichesRepository;
  }

  public List<Sandwich> GetAllSandwiches()
  {
    List<Sandwich> sandwiches = _sandwichesRepository.GetAllSandwiches();
    return sandwiches;
  }

  public Sandwich GetSandwichById(int sandwichId)
  {
    Sandwich sandwich = _sandwichesRepository.GetSandwichById(sandwichId);

    if (sandwich == null)
    {
      throw new Exception($"No sandwich found with the id of {sandwichId}");
    }

    return sandwich;
  }

  public Sandwich CreateSandwich(Sandwich sandwichData)
  {
    Sandwich sandwich = _sandwichesRepository.CreateSandwich(sandwichData);
    return sandwich;
  }

  public string DestroySandwich(int sandwichId)
  {
    Sandwich sandwichToDestroy = GetSandwichById(sandwichId);

    _sandwichesRepository.DestroySandwich(sandwichId);

    return $"The {sandwichToDestroy.Protein} & {sandwichToDestroy.Dressing} on {sandwichToDestroy.Bread} has been deleted;";
  }
}