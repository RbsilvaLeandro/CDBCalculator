using CDB.Domain.Entities;

namespace CDB.Tests.Domain;

[TestFixture]
public class TaxRateTests
{
    [Test]
    public void GetRate_ShouldReturnCorrectRate_ForMonthsInRange1To6()
    {
        int months = 6;
        var rate = TaxRate.GetRate(months);
        Assert.That(rate, Is.EqualTo(0.225m));
    }

    [Test]
    public void GetRate_ShouldReturnCorrectRate_ForMonthsInRange7To12()
    {
        int months = 12;
        var rate = TaxRate.GetRate(months);
        Assert.That(rate, Is.EqualTo(0.20m));
    }

    [Test]
    public void GetRate_ShouldReturnCorrectRate_ForMonthsInRange13To24()
    {
        int months = 24;
        var rate = TaxRate.GetRate(months);
        Assert.That(rate, Is.EqualTo(0.175m));
    }

    [Test]
    public void GetRate_ShouldReturnCorrectRate_ForMonthsAbove24()
    {
        int months = 25;
        var rate = TaxRate.GetRate(months);
        Assert.That(rate, Is.EqualTo(0.15m));
    }

    [Test]
    public void GetRate_ShouldThrowArgumentException_ForInvalidMonthsValue()
    {
        int months = 0;
        Assert.Throws<ArgumentException>(() => TaxRate.GetRate(months), "Invalid months value.");
    }

    [Test]
    public void GetRate_ShouldThrowArgumentException_ForNegativeMonthsValue()
    {
        int months = -5;
        Assert.Throws<ArgumentException>(() => TaxRate.GetRate(months), "Invalid months value.");
    }
}