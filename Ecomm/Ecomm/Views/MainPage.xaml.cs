using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Ecomm
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();          
        }

        async void Button_Clicked_L(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Login());
        }

        async void Button_Clicked_R(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Register());
        }
    }
}
