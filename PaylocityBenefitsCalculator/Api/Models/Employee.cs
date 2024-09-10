namespace Api.Models;

public class Employee
{
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public decimal Salary { get; set; }
    public DateTime DateOfBirth { get; set; }
    public ICollection<Dependent> Dependents { get; set; } = new List<Dependent>();

    public decimal CalculateBenefitsCost()
    {
        decimal baseCost = 1000 * 12; // Annual cost
        decimal dependentCost = Dependents.Sum(d => d.CalculateCost());

        decimal totalCost = baseCost + dependentCost;
        if (Salary > 80000)
        {
            totalCost += 0.02m * Salary; // Additional 2% cost for high earners
        }
        return totalCost;
    }
}
