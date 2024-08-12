


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

  public Sandwich GetSandwichById(int sandwichId)
  {
    // NOTE @ will parameterize a value, dapper will look through the object that you pass it for the supplied key, and insert the value. ALWAYS DO THIS AND NEVER STRING INTERPOLATE
    string sql = "SELECT * FROM sandwiches WHERE id = @sandwichId;";

    //                                               {sandwichId: 1}
    // firstOrDefault returns the first row, or null if no rows are found
    Sandwich sandwich = _db.Query<Sandwich>(sql, new { sandwichId = sandwichId }).FirstOrDefault();
    return sandwich;
  }

  internal Sandwich CreateSandwich(Sandwich sandwichData)
  {
    string sql = @"
    INSERT INTO
    sandwiches (bread, protein, dressing, calories, hasPickles)
    VALUES (@Bread, @Protein, @Dressing, @Calories, @HasPickles);
    
    SELECT * FROM sandwiches WHERE id = LAST_INSERT_ID();";

    Sandwich sandwich = _db.Query<Sandwich>(sql, sandwichData).FirstOrDefault();
    return sandwich;
  }
}