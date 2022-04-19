namespace RentMoviesConsoleApp.Models;

public class Rental
{
    private Movie _movie;
    private int _daysRented;

    public Rental(Movie movie, int daysRented)
    {
        _movie = movie;
        _daysRented = daysRented;
    }

    public int GetDaysRented()
    {
        return _daysRented;
    }

    public Movie GetMovie()
    {
        return _movie;
    }

    public double GetCharge()
    {
        double result = 0;

        //определить сумму для каждой строки
        var code = GetMovie().GetPriceCode();
        switch (code)
        {
            case Movie.REGULAR:
                result += 2;
                if (GetDaysRented() > 2)
                    result += (GetDaysRented() - 2) * 1.5;
                break;
            case Movie.NEW_RELEASE:
                result += GetDaysRented() * 3;
                break;
            case Movie.CHILDRENS:
                result += 1.5;
                if (GetDaysRented() > 3)
                    result += (GetDaysRented() - 3) * 1.5;
                break;
        }

        return result;
    }
}