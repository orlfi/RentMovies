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
            // добавить очки для активного арендатора
            frequentRenterPoints++;

            // бонус за аренду новинки на два дня
            if (each.GetMovie().GetPriceCode() == Movie.NEW_RELEASE &&
                each.GetDaysRented() > 1)
                frequentRenterPoints++;

            //показать результаты для этой аренды
            result += "\t" + each.GetMovie().GetTitle() + "\t" + each.GetCharge() + "\r\n";
            totalAmount += each.GetCharge();
        }

        //добавить нижний колонтитул
        result += "Сумма задолженности составляет " + totalAmount + "\r\n";
        result += "Вы заработали " + frequentRenterPoints + " очков за активность";
        return result;
    }
}