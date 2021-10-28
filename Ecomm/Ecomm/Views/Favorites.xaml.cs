using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ecomm.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Favorites : ContentPage
    {
        DBManager books = new DBManager();
        public Favorites()
        {
            InitializeComponent();
            var data = books.GetBook();
            listBook.ItemsSource = data;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        //delete
        async private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            if (listBook.SelectedItem == null)
            {
                await DisplayAlert("Error!", "Please select a book you want to delete", "OK");
                return;
            }

            //var book = listBook.SelectedItem as BookFav;
            var book = (BookFav)listBook.SelectedItem;
            books.DeleteBook(book);

           

            await DisplayAlert("Deleted", "Selected book has removed from your favorites", "OK");           

            var newlist = books.GetBook();
            if (newlist != null)
            {
                listBook.ItemsSource = newlist;
            }      
     
            else await DisplayAlert("No Books", "You have no books saved", "OK");
 
        }
    }
}