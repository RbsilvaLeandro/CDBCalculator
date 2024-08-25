using CDB.Domain.Entities;

namespace CDB.Tests.Domain;

[TestFixture]
public class InvestmentTests
{
    [Test]
    public void Investment_ShouldBeCreatedWithDefaultValues()
    {
        var investment = new Investment();

        Assert.That(investment.InitialValue, Is.EqualTo(0), "InitialValue should be initialized to 0.");
        Assert.That(investment.Months, Is.EqualTo(0), "Months should be initialized to 0.");
    }

    [Test]
    public void Investment_ShouldSetAndGetInitialValueCorrectly()
    {
        var investment = new Investment();
        var expectedInitialValue = 1000m;

        investment.InitialValue = expectedInitialValue;
        Assert.That(investment.InitialValue, Is.EqualTo(expectedInitialValue), "InitialValue was not set correctly.");
    }

    [Test]
    public void Investment_ShouldSetAndGetMonthsCorrectly()
    {
        var investment = new Investment();
        var expectedMonths = 12;

        investment.Months = expectedMonths;
        Assert.That(investment.Months, Is.EqualTo(expectedMonths), "Months was not set correctly.");
    }

    [Test]
    public void Investment_ShouldAllowSettingInitialValueToNegative()
    {
        var investment = new Investment();
        var negativeInitialValue = -500m;

        investment.InitialValue = negativeInitialValue;
        Assert.That(investment.InitialValue, Is.EqualTo(negativeInitialValue), "InitialValue should allow negative values.");
    }

    [Test]
    public void Investment_ShouldAllowSettingMonthsToNegative()
    {
        var investment = new Investment();
        var negativeMonths = -6;

        investment.Months = negativeMonths;
        Assert.That(investment.Months, Is.EqualTo(negativeMonths), "Months should allow negative values.");
    }
}