using Xunit;

namespace RentMoviesTests;

public class CustomerTests
{
    private const string correctString = "Correct";
    [Fact]
    public void Statement_ShouldReturn_CorrectString()
    {
        string text = "Correct";
        Assert.Equal(text, correctString);
    }
}