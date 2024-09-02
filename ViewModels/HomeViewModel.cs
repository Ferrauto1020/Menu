using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using Menu.Models;
using Menu.Services;
namespace Menu.ViewModel
{
    public partial class HomeViewModel : ObservableObject
    {
        private readonly PizzaService _pizzaService;
        public HomeViewModel(PizzaService pizzaService)
        {
            _pizzaService = pizzaService;
            Pizzas = new(_pizzaService.GetPopularPizzas());
        }
        public ObservableCollection<Pizza> Pizzas { get; set; }
        [RelayCommand]
        private async Task GoToAllPizzasPage(bool fromSearch = false)
        {
            var parameters = new Dictionary<string, object>
            {
                [nameof(AllPizzaViewModel.FromSearch)] = fromSearch
            };
            await Shell.Current.GoToAsync(nameof(AllPizzaPage), animate: true, parameters);
        }
        [RelayCommand]
        private async Task GoToDetailsPage(Pizza pizza)
        {
            var parameters = new Dictionary<string, object>
            {
                [nameof(DetailsViewModel.Pizza)] = pizza
            };
            await Shell.Current.GoToAsync(nameof(DetailPage), animate: true, parameters);
        }
    }
}