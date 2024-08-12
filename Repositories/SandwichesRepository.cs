namespace sandwich_api.Repositories;
// repository level has access to database only
public class SandwichesRepository
{
  private readonly IDbConnection _db; // dbContext

  // DEPENDENCY INJECTION 💉
  public SandwichesRepository(IDbConnection db)
  {
    _db = db;
  }

  public List<Sandwich> GetAllSandwiches()
  {
    // our sql statement we will
    string sql = "SELECT * FROM sandwiches;";

    // dbContext.Sandwiches.find()
    // Query is a Dapper method that will return all selected rows from sql database and cast them into the supplied type (in this case, a Sandwich)
    // first argument passed to Dapper method is the SQL we want Dapper to run on our database
    // .ToList() returns the data in a List
    List<Sandwich> sandwiches = _db.Query<Sandwich>(sql).ToList();
    return sandwiches;
  }

  public Sandwich GetSandwichById(int sandwichId)
  {
    // NOTE @ will parameterize a value, dapper will look through the object that you pass it for the supplied key, and insert the value. ALWAYS DO THIS AND NEVER STRING INTERPOLATE
    string sql = "SELECT * FROM sandwiches WHERE id = @sandwichId;";

    // firstOrDefault returns the first row, or null if no rows are found
    // the second argument passed to Query can be used by Dapper to SAFELY insert values into our sql statement. It must be an object, and we can use `new {}` to create an anonymous object in C#
    //                                               {sandwichId: 1}
    Sandwich sandwich = _db.Query<Sandwich>(sql, new { sandwichId = sandwichId }).FirstOrDefault();
    return sandwich;
  }

  public Sandwich CreateSandwich(Sandwich sandwichData)
  {
    // we insert into the table and then immediately select the last inserted row with LAST_INSERT_ID()
    string sql = @"
    INSERT INTO
    sandwiches (bread, protein, dressing, calories, hasPickles)
    VALUES (@Bread, @Protein, @Dressing, @Calories, @HasPickles);
    
    SELECT * FROM sandwiches WHERE id = LAST_INSERT_ID();";

    Sandwich sandwich = _db.Query<Sandwich>(sql, sandwichData).FirstOrDefault();
    return sandwich;
  }

  // void means no return
  public void DestroySandwich(int sandwichId)
  {
    string sql = "DELETE FROM sandwiches WHERE id = @sandwichId LIMIT 1;";

    // Execute runs the supplied sql and returns the rows affected
    int rowsAffected = _db.Execute(sql, new { sandwichId });

    if (rowsAffected == 0)
    {
      throw new Exception("DELETE WAS UN-SUCCESSFUL");
    }

    if (rowsAffected > 1)
    {
      throw new Exception("DELETE WAS TOO SUCCESSFUL. CALL THE POLICE");
    }
  }
}