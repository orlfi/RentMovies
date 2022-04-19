namespace RentMoviesConsoleApp.Models;

public class Customer
{
    private string _name;
    private ICollection<Rental> _rentals = new List<Rental>();

    public Customer(string name)
    {
        _name = name;
    }

    public void AddRental(Rental rental)
    {
        _rentals.Add(rental);
    }

    public string GetName()
    {
        return _name;
    }

    public string Statement()
    {
        double totalAmount = 0;
        int frequentRenterPoints = 0;
        string result = "Учет аренды для " + GetName() + "\r\n";

        foreach (var each in _rentals)
        {
            double thisAmount = AmountFor(each);

            // добавить очки для активного арендатора
            frequentRenterPoints++;

            // бонус за аренду новинки на два дня
            if (each.GetMovie().GetPriceCode() == Movie.NEW_RELEASE &&
                each.GetDaysRented() > 1)
                frequentRenterPoints++;

            //показать результаты для этой аренды
            result += "\t" + each.GetMovie().GetTitle() + "\t" + thisAmount + "\r\n";
            totalAmount += thisAmount;
        }

        //добавить нижний колонтитул
        result += "Сумма задолженности составляет " + totalAmount + "\r\n";
        result += "Вы заработали " + frequentRenterPoints + " очков за активность";
        return result;
    }

    private double AmountFor(Rental each)
    {
        double thisAmount = 0;

        //определить сумму для каждой строки
        var code = each.GetMovie().GetPriceCode();
        switch (code)
        {
            case Movie.REGULAR:
                thisAmount += 2;
                if (each.GetDaysRented() > 2)
                    thisAmount += (each.GetDaysRented() - 2) * 1.5;
                break;
            case Movie.NEW_RELEASE:
                thisAmount += each.GetDaysRented() * 3;
                break;
            case Movie.CHILDRENS:
                thisAmount += 1.5;
                if (each.GetDaysRented() > 3)
                    thisAmount += (each.GetDaysRented() - 3) * 1.5;
                break;
        }

        return thisAmount;
    }
}