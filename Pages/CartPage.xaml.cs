namespace Menu.Pages;

public partial class CartPage : ContentPage
{
	private readonly CartViewModel _cartViewModel;
	public CartPage(CartViewModel cartViewModel)
	{
		InitializeComponent();
		_cartViewModel = cartViewModel;
		BindingContext = _cartViewModel;
	}
	async void Button_Clicked(System.Object sender, System.EventArgs e)
	{
		await  Shell.Current.GoToAsync(nameof(AllPizzaPage));
	}
}