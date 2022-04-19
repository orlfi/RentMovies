using System.Collections.Generic;
using RentMoviesConsoleApp.Models;
using Xunit;

namespace RentMoviesTests;

public class CustomerTests
{
    private const string correctString = "Correct";
    [Fact]
    public void Statement_ShouldReturn_CorrectString()
    {
        var properText = @"Учет аренды для Иванов Иван
	Рембо	6
	Терминатор	5
	Король лев	1,5
Сумма задолженности составляет 12,5
Вы заработали 4 очков за активность";

        var movies = new List<Movie>()
        {
            new Movie("Рембо", Movie.NEW_RELEASE),
            new Movie("Терминатор", Movie.REGULAR),
            new Movie("Король лев", Movie.CHILDRENS),
        };
        Customer customer = new("Иванов Иван");
        customer.AddRental(new Rental(movies[0], 2));
        customer.AddRental(new Rental(movies[1], 4));
        customer.AddRental(new Rental(movies[2], 1));

        var result = customer.Statement();

        Assert.Equal(properText, result);
    }
}