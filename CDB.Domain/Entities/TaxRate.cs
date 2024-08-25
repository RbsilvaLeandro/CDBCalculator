namespace CDB.Domain.Entities;

public class TaxRate
{
    private static readonly Dictionary<(int, int), decimal> Rates = new()
    {
        { (1, 6), 0.225m },
        { (7, 12), 0.20m },
        { (13, 24), 0.175m },
        { (25, int.MaxValue), 0.15m }
    };

    public static decimal GetRate(int months)
    {
        foreach (var rate in Rates)
        {
            if (months >= rate.Key.Item1 && months <= rate.Key.Item2)
            {
                return rate.Value;
            }
        }
        throw new ArgumentException("Invalid months value.");
    }
}