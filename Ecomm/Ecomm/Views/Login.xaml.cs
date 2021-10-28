using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ecomm
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        DBManager userDB;
        public Login()
        {
            InitializeComponent();
            userDB = new DBManager();
            useremail.ReturnCommand = new Command(() => userpassword.Focus());            
        }

        async void Button_Clicked_Login(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(useremail.Text) || string.IsNullOrEmpty(userpassword.Text))
            {
                await DisplayAlert("Login Failed", "Make sure all the information is correct!", "OK");
                return;
            }
            
            var data = userDB.LoginValidate(useremail.Text, userpassword.Text);
            if (data == true)
                await Navigation.PushAsync(new HomePage());
            else await DisplayAlert("Login failed", "Make sure the informationis correct", "OK");

        }

        async void Button_Clicked_Back(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
    }
}