using System;
namespace Menu.ViewModel
{
    [QueryProperty(nameof(Pizza), nameof(Pizza))]
    public partial class DetailsViewModel : ObservableObject, IDisposable
    {
        private readonly CartViewModel _cartVieModel;
        public DetailsViewModel(CartViewModel cartVieModel)
        {
            _cartVieModel = cartVieModel;
            _cartVieModel.CartCleared += OnCartCleared;
            _cartVieModel.CartItemRemoved += OnCartItemRemoved;
            _cartVieModel.CartItemUptated += OnCartItemUptated;
        }
        private void OnCartCleared(object? _, EventArgs e) => Pizza.CartQuantity = 0;
        private void OnCartItemRemoved(object? _, Pizza p) => OnCartItemChanged(p,0);
                private void OnCartItemUptated(object? _, Pizza p) => OnCartItemChanged(p,p.CartQuantity);

        private void OnCartItemChanged(Pizza p, int quantity)
        {
            if (p.Name == Pizza.Name)
            {
                Pizza.CartQuantity = quantity;
            }
        }
        [ObservableProperty]
        private Pizza _pizza;

        [RelayCommand]
        private void AddToCart()
        {
            Pizza.CartQuantity++;
            _cartVieModel.UpdateCartItemCommand.Execute(Pizza);
        }
        [RelayCommand]
        private void RemoveFromCart()
        {
            if (Pizza.CartQuantity > 0)
                Pizza.CartQuantity--;
            _cartVieModel.RemoveCartItemCommand.Execute(Pizza);
        }
        [RelayCommand]
        private async Task ViewCart()
        {
            if (Pizza.CartQuantity > 0)
            {
                await Shell.Current.GoToAsync(nameof(CartPage), animate: true);
            }
            else
            {
                Toast.Make("Please select the quantity using the plus(+) button", ToastDuration.Short).Show();
            }
        }
        public void Dispose()
        {
            
            _cartVieModel.CartCleared -= OnCartCleared;
            _cartVieModel.CartItemRemoved -= OnCartItemRemoved;
            _cartVieModel.CartItemUptated -= OnCartItemUptated;
        }
    }
}