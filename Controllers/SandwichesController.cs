namespace sandwich_api.Controllers;

[ApiController]
[Route("api/sandwiches")] // super('api/sandwiches')
public class SandwichesController : ControllerBase // SandwichesController extends BaseController
{
  [HttpGet] // .get('', this.TestGet)
  public string TestGet()
  {
    return "API WORKS";
  }
}