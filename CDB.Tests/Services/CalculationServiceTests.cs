using CDB.Application.Dto;
using CDB.Services.Services;

namespace CDB.Tests.Services;

[TestFixture]
public class CalculationServiceTests
{
    private CalculationService _service;

    [SetUp]
    public void SetUp()
    {
        _service = new CalculationService();
    }

    [Test]
    public void Calculate_ShouldReturnCorrectValues_ForValidInputs()
    {
        var request = new InvestmentRequestDto
        {
            InitialValue = 1000m,
            Months = 12
        };

        var response = _service.Calculate(request);

        Assert.That(decimal.Round(response.GrossReturn,2), Is.EqualTo(1123.08), "GrossReturn is incorrect.");
        Assert.That(decimal.Round(response.NetReturn, 2), Is.EqualTo(898.47), "NetReturn is incorrect.");
    }

    [Test]
    public void Calculate_ShouldThrowArgumentException_WhenInitialValueIsZero()
    {
        var request = new InvestmentRequestDto
        {
            InitialValue = 0m,
            Months = 12
        };

        Assert.Throws<ArgumentException>(() => _service.Calculate(request), "Invalid investment parameters.");
    }

    [Test]
    public void Calculate_ShouldThrowArgumentException_WhenInitialValueIsNegative()
    {
        var request = new InvestmentRequestDto
        {
            InitialValue = -1000m,
            Months = 12
        };

        Assert.Throws<ArgumentException>(() => _service.Calculate(request), "Invalid investment parameters.");
    }

    [Test]
    public void Calculate_ShouldThrowArgumentException_WhenMonthsIsLessThanOne()
    {
        var request = new InvestmentRequestDto
        {
            InitialValue = 1000m,
            Months = 0
        };

        Assert.Throws<ArgumentException>(() => _service.Calculate(request), "Invalid investment parameters.");
    }

    [Test]
    public void Calculate_ShouldThrowArgumentException_WhenMonthsIsNegative()
    {
        var request = new InvestmentRequestDto
        {
            InitialValue = 1000m,
            Months = -1
        };

        Assert.Throws<ArgumentException>(() => _service.Calculate(request), "Invalid investment parameters.");
    }

    [Test]
    public void Calculate_ShouldReturnCorrectValues_ForOneMonth()
    {
        var request = new InvestmentRequestDto
        {
            InitialValue = 1000m,
            Months = 1
        };
        var response = _service.Calculate(request);

        Assert.That(decimal.Round(response.GrossReturn,2), Is.EqualTo(1009.72), "GrossReturn is incorrect.");
        Assert.That(decimal.Round(response.NetReturn, 2), Is.EqualTo(782.53), "NetReturn is incorrect.");
    }

    [Test]
    public void Calculate_ShouldReturnCorrectValues_ForSmallInitialValueAndShortPeriod()
    {
        var request = new InvestmentRequestDto
        {
            InitialValue = 1m,
            Months = 1
        };

        var response = _service.Calculate(request);

        Assert.That(response.GrossReturn, Is.EqualTo(1m * (1 + (0.009m * 1.08m))), "GrossReturn is incorrect.");
        Assert.That(response.NetReturn, Is.EqualTo(response.GrossReturn * (1 - 0.225m)), "NetReturn is incorrect.");
    }

    [Test]
    public void Calculate_ShouldReturnCorrectValues_ForLargeInitialValueAndLongPeriod()
    {
        var request = new InvestmentRequestDto
        {
            InitialValue = 1_000_000m,
            Months = 24
        };

        var response = _service.Calculate(request);

        Assert.That(decimal.Round(response.GrossReturn,2), Is.EqualTo(1261313.39), "GrossReturn is incorrect.");
        Assert.That(decimal.Round(response.NetReturn, 2), Is.EqualTo(1040583.55), "NetReturn is incorrect.");
    }

    [Test]
    public void Calculate_ShouldReturnCorrectValues_ForLargeInitialValueAndShortPeriod()
    {
        var request = new InvestmentRequestDto
        {
            InitialValue = 1_000_000m,
            Months = 6
        };

        var response = _service.Calculate(request);

        Assert.That(decimal.Round(response.GrossReturn,2), Is.EqualTo(1059755.68), "GrossReturn is incorrect.");
        Assert.That(decimal.Round(response.NetReturn, 2), Is.EqualTo(821310.65), "NetReturn is incorrect.");
    }

    [Test]
    public void Calculate_ShouldReturnCorrectValues_ForSmallInitialValueAndLongPeriod()
    {
        var request = new InvestmentRequestDto
        {
            InitialValue = 1m,
            Months = 24
        };
        var response = _service.Calculate(request);

        Assert.That(decimal.Round(response.GrossReturn, 2), Is.EqualTo(1.26), "GrossReturn is incorrect.");
        Assert.That(decimal.Round(response.NetReturn,2), Is.EqualTo(1.04), "NetReturn is incorrect.");
    }

    [Test]
    public void Calculate_ShouldReturnCorrectValues_ForZeroMonths()
    {
        var request = new InvestmentRequestDto
        {
            InitialValue = 1000m,
            Months = 0
        };

        Assert.Throws<ArgumentException>(() => _service.Calculate(request), "Invalid investment parameters.");
    }

    [Test]
    public void Calculate_ShouldReturnCorrectValues_ForNegativeMonthsAndPositiveInitialValue()
    {
        var request = new InvestmentRequestDto
        {
            InitialValue = 1000m,
            Months = -12
        };

        Assert.Throws<ArgumentException>(() => _service.Calculate(request), "Invalid investment parameters.");
    }

    [Test]
    public void Calculate_ShouldReturnCorrectValues_ForNegativeInitialValueAndPositiveMonths()
    {
        var request = new InvestmentRequestDto
        {
            InitialValue = -1000m,
            Months = 12
        };

        Assert.Throws<ArgumentException>(() => _service.Calculate(request), "Invalid investment parameters.");
    }

    [Test]
    public void Calculate_ShouldReturnCorrectValues_ForLargeNumberOfMonths()
    {
        var request = new InvestmentRequestDto
        {
            InitialValue = 1000m,
            Months = 120
        };

        var response = _service.Calculate(request);

        Assert.That(decimal.Round(response.GrossReturn,2), Is.EqualTo(3192.38), "GrossReturn is incorrect.");
        Assert.That(decimal.Round(response.NetReturn, 2), Is.EqualTo(2713.53), "NetReturn is incorrect.");
    }

    [Test]
    public void Calculate_ShouldReturnCorrectValues_ForBoundaryTaxRate1To6Months()
    {
        var request = new InvestmentRequestDto
        {
            InitialValue = 1000m,
            Months = 6
        };

        var response = _service.Calculate(request);

        Assert.That(decimal.Round(response.GrossReturn,2), Is.EqualTo(1059.76), "GrossReturn is incorrect.");
        Assert.That(decimal.Round(response.NetReturn, 2), Is.EqualTo(821.31), "NetReturn is incorrect.");
    }

    [Test]
    public void Calculate_ShouldReturnCorrectValues_ForBoundaryTaxRate7To12Months()
    {
        var request = new InvestmentRequestDto
        {
            InitialValue = 1000m,
            Months = 12
        };

        var response = _service.Calculate(request);

        Assert.That(decimal.Round(response.GrossReturn,2), Is.EqualTo(1123.08), "GrossReturn is incorrect.");
        Assert.That(decimal.Round(response.NetReturn, 2), Is.EqualTo(898.47), "NetReturn is incorrect.");
    }

    [Test]
    public void Calculate_ShouldReturnCorrectValues_ForBoundaryTaxRate13To24Months()
    {
        var request = new InvestmentRequestDto
        {
            InitialValue = 1000m,
            Months = 24
        };

        var response = _service.Calculate(request);

        Assert.That(decimal.Round(response.GrossReturn,2), Is.EqualTo(1261.31), "GrossReturn is incorrect.");
        Assert.That(decimal.Round(response.NetReturn,2), Is.EqualTo(1040.58), "NetReturn is incorrect.");
    }    
}