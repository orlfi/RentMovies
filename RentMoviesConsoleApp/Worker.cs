using RentMoviesConsoleApp.Models;

namespace RentMoviesConsoleApp;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;

    public Worker(ILogger<Worker> logger)
    {
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
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

        Console.WriteLine(customer.Statement());

        // while (!stoppingToken.IsCancellationRequested)
        // {
        //     _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
        //     await Task.Delay(1000, stoppingToken);
        // }
    }
}
