using System;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ecomm
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Register : ContentPage
    {
        User users = new User();
        DBManager userDB = new DBManager();
        public Register()
        {
            InitializeComponent();
            useremail.ReturnCommand = new Command(() => userfullname.Focus());
            userfullname.ReturnCommand = new Command(() => userpassword.Focus());
            userpassword.ReturnCommand = new Command(() => confirmuserpassword.Focus());
            confirmuserpassword.ReturnCommand = new Command(() => userfullname.Focus());
        }

        async void Button_Clicked_Register(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(useremail.Text) || string.IsNullOrEmpty(userfullname.Text) || string.IsNullOrEmpty(userpassword.Text) || string.IsNullOrEmpty(confirmuserpassword.Text))
            {
                await DisplayAlert("Missing Information", "Please fill out all the fields", "OK");
                return;
            }
            else if (!string.Equals(userpassword.Text, confirmuserpassword.Text))
            {
                await DisplayAlert("Passwords don't match", "Please enter the same passwords", "OK");
                userpassword.Text = string.Empty;
                confirmuserpassword.Text = string.Empty;
            }
            else
            {
                users.email = useremail.Text;
                users.name = userfullname.Text;
                users.password = userpassword.Text;

                try
                {
                    var value = userDB.AddUser(users);
                    if (value == true)
                    {
                        await DisplayAlert("Welcome!", "Your account has been created", "OK");
                        await Navigation.PushAsync(new HomePage());
                    }
                }

                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
            }

            
        }

        async void Button_Clicked_Back(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
    }
}