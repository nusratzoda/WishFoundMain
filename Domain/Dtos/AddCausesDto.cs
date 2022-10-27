namespace Domain.Dtos;

public class AddCausesDto
{
    public int Id { get; set; }
  public string? Header { get; set; }
    public int Goal { get; set; }
    public int Raised { get; set; }
    public string? Explanation { get; set; }
    public string? Image { get; set; }
}
