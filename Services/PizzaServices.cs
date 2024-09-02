
using Menu.Models;
namespace Menu.Services
{
    public class PizzaService
    {
        private readonly static IEnumerable<Pizza> _pizzas = new List<Pizza>
        {
            new Pizza{
                Name="Pizza 1",
                Image = "pizza1",
                Price=5.1
            },
            new Pizza{
                Name="Pizza 2",
                Image = "pizza2",
                Price=2.7
            },
            new Pizza{
                Name="Pizza 3",
                Image = "pizza1",
                Price=4.1
            },
            new Pizza{
                Name="Pizza 4",
                Image = "pizza2",
                Price=7.0
            },
            new Pizza{
                Name="Pizza 5",
                Image = "pizza1",
                Price=3.6
            },
            new Pizza{
                Name="Pizza 6",
                Image = "pizza2",
                Price=4.5
            },
            new Pizza{
                Name="Pizza 7",
                Image = "pizza1",
                Price=5.2
            },
            new Pizza{
                Name="Pizza 8",
                Image = "pizza1",
                Price=3.6
            },
            new Pizza{
                Name="Pizza 9",
                Image = "pizza2",
                Price=3.6
            },
            new Pizza{
                Name="Pizza 10",
                Image = "pizza1",
                Price=3.6
            },
        };

        public IEnumerable<Pizza> GetAllPizzas() => _pizzas;
        public IEnumerable<Pizza> GetPopularPizzas(int count = 6) => _pizzas.OrderBy(p => Guid.NewGuid()).Take(count);
        public IEnumerable<Pizza> SearchPizzas(String searchTerm) => string.IsNullOrWhiteSpace(searchTerm) ? _pizzas : _pizzas.Where(p => p.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));
    }
}