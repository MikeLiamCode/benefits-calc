namespace Api.Models;

public class Dependent
{
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public Relationship Relationship { get; set; }
    public int EmployeeId { get; set; }
    public Employee? Employee { get; set; }

    public decimal CalculateCost()
    {
        decimal cost = 600 * 12; // Annual cost
        if (DateTime.Now.Year - DateOfBirth.Year > 50)
        {
            cost += 200 * 12; // Additional annual cost for dependents over 50
        }
        return cost;
    }
}
