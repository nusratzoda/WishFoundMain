using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Causes
{
    public int Id { get; set; }
    [Required, MaxLength(100)]
    public string? Header { get; set; }
    public string? Image { get; set; }
    public int Goal { get; set; }
    public int Raised { get; set; }
    public string? Explanation { get; set; }
}
