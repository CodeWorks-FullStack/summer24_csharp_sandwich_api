
namespace sandwich_api.Repositories;
// repository level has access to database only
public class SandwichesRepository
{
  private readonly IDbConnection _db; // dbContext

  public SandwichesRepository(IDbConnection db)
  {
    _db = db;
  }

  public List<Sandwich> GetAllSandwiches()
  {
    string sql = "SELECT * FROM sandwiches;";

    // dbContext.Sandwiches.find()
    List<Sandwich> sandwiches = _db.Query<Sandwich>(sql).ToList();
    return sandwiches;
  }
}