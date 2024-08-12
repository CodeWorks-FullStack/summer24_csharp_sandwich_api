// all files should have a namespace
namespace sandwich_api.Models; // export

// public allows us to use this class if we are using this namespace in another module
public class Sandwich
{
  // this class should support all columns from the respective SQL table we will use it with
  public int Id { get; set; }
  public string Bread { get; set; }
  public string Protein { get; set; }
  public string Dressing { get; set; }
  public int Calories { get; set; }
  public bool HasPickles { get; set; }
}