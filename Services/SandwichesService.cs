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
}