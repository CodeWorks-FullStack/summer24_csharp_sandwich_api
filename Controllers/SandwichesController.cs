namespace sandwich_api.Controllers;

[ApiController]
[Route("api/sandwiches")] // super('api/sandwiches')
public class SandwichesController : ControllerBase // SandwichesController extends BaseController
{
  private readonly SandwichesService _sandwichesService;

  // constructor
  public SandwichesController(SandwichesService sandwichesService)
  {
    _sandwichesService = sandwichesService;
  }

  [HttpGet] // .get('', this.TestGet)
  // we use ActionResult as an HTTP Response type
  public ActionResult<List<Sandwich>> GetAllSandwiches()
  {
    try
    {
      List<Sandwich> sandwiches = _sandwichesService.GetAllSandwiches();
      return Ok(sandwiches); // response.send()
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message); // next(error)
    }
  }

  [HttpGet("{sandwichId}")] //.get(':sandwichId', this.getById)
  public ActionResult<Sandwich> GetSandwichById(int sandwichId) // req.params.sandwichId
  {
    try
    {
      Sandwich sandwich = _sandwichesService.GetSandwichById(sandwichId);
      return Ok(sandwich);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }

  [HttpPost]
  public ActionResult<Sandwich> CreateSandwich([FromBody] Sandwich sandwichData) // req.body
  {
    try
    {
      Sandwich sandwich = _sandwichesService.CreateSandwich(sandwichData);
      return Ok(sandwich);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }

  [HttpDelete("{sandwichId}")]
  public ActionResult<string> DestroySandwich(int sandwichId)
  {
    try
    {
      string message = _sandwichesService.DestroySandwich(sandwichId);
      return Ok(message);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }
}