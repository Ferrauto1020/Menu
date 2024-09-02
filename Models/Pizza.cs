using System;
using CommunityToolkit.Mvvm.ComponentModel;
namespace Menu.Models
{
    public partial class Pizza : ObservableObject 
    {
        public string Name {get; set;}
        public string Image {get;set;}
        public double Price {get;set;}
        [ObservableProperty, NotifyPropertyChangedFor(nameof(Amount))]
        private int _cartQuantity;
        public double Amount => CartQuantity * Price;
        public Pizza Clone()=> MemberwiseClone() as Pizza;
    }
}