using System;
using System.Collections.Generic;
using System.Text;

namespace Ecomm
{
    public class Book
    {
        public string isbn13 { get; set; }
        public string title { get; set; }
        public string price { get; set; }
        public string image { get; set; }      

        public Book(string i, string t, string a, string im) 
        {
            isbn13 = i;
            title = t;
            price = a;
            image = im;            
        }
    }   
}
