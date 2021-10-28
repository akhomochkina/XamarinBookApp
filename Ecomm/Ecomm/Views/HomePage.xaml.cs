using Ecomm.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ecomm
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        string query;
        ObservableCollection<Book> books;        
        NetworkingManager manager = new NetworkingManager();
        public HomePage()
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, false);                        
        }

        //logout
        async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }       

        protected override void OnAppearing()
        {
           base.OnAppearing();
        }

        async void SearchBar_SearchButtonPressed(object sender, EventArgs e)
        {
            var listFromAPI = await manager.getBook(query);
            books = new ObservableCollection<Book>();
      
            foreach (Book b in listFromAPI)
            {               
                books.Add(new Book(b.isbn13, b.title, b.price, b.image));               
            }

            bookList.ItemsSource = books;
        }

        void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            query = e.NewTextValue;
        }

        //favorites
        async void ToolbarItem_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Favorites());
        }

        //save button clicked
        async void Button_Clicked(object sender, EventArgs e)
        {
            if (bookList.SelectedItem == null)
            {
                await DisplayAlert("Error!", "Please select a book you want to save", "OK");
                return;
            }

            var book = bookList.SelectedItem as Book;
            DBManager bookDB = new DBManager();
            BookFav fav = new BookFav()
            {
                isbn13 = book.isbn13,
                title = book.title,
                price = book.price,
                image = book.image
            };

            bookDB.AddBook(fav);
            await DisplayAlert("Saved", "Selected book has been saved to favorites", "OK");
            bookList.SelectedItem = null;
        }       
    }
}