namespace Menu.Pages;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
	}

	async void TapGestureRecognize(System.Object sender, Microsoft.Maui.Controls.TappedEventArgs e)
	{
		await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
	}
}

