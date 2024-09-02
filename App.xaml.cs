namespace Menu;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(CartPage),typeof(CartPage));
		Routing.RegisterRoute(nameof(CheckoutPage),typeof(CheckoutPage));
		MainPage = new AppShell();
	}
}
