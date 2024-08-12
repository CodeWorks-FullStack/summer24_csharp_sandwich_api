namespace sandwich_api.Controllers;

[ApiController]
[Route("api/sandwiches")] // super('api/sandwiches')
public class SandwichesController : ControllerBase // SandwichesController extends BaseController
{
  [HttpGet] // .get('', this.TestGet)
  // we use ActionResult as an HTTP Response type
  public ActionResult<List<Sandwich>> GetAllSandwiches()
  {
    try
    {
      List<Sandwich> sandwiches = [];
      return Ok(sandwiches); // response.send()
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message); // next(error)
    }
  }
}