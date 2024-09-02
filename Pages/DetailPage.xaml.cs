#if IOS
using UIKit;
#endif
namespace Menu.Pages;

public partial class DetailPage : ContentPage
{
	private readonly DetailsViewModel _detailViewModel;
	public DetailPage(DetailsViewModel detailViewModel)
	{
		InitializeComponent();
		_detailViewModel = detailViewModel;
		BindingContext = _detailViewModel;
	}
	protected override void OnAppearing()
	{
		base.OnAppearing();
		#if IOS
		var bottom = UIApplication.SharedApplication.Delegate.GetWindow().SafeAreaInsets.Bottom;
		bottomBox.Margin = new Thickness(-1,0,-1,(bottom+1)*-1);
		#endif
	}
	async void ImageButton_Clicked (System.Object sender, System.EventArgs e)
	{
		await Shell.Current.GoToAsync("..", animate:true);
	}
	protected override void OnNavigatingFrom(NavigatingFromEventArgs args)
	{	
		base.OnNavigatingFrom(args);
		Behaviors.Add(new CommunityToolkit.Maui.Behaviors.StatusBarBehavior{
			StatusBarColor=Colors.DarkGoldenrod,
			StatusBarStyle= CommunityToolkit.Maui.Core.StatusBarStyle.LightContent
		});
	}
}