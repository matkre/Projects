using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace MagazynAPI
{
    /// <summary>
    /// Logika interakcji dla klasy MagazynList.xaml
    /// </summary>
    public partial class MagazynList : Page
    {
        public MagazynList()
        {
            InitializeComponent();
        }
        //Metoda GET
        private void PageGrid_Loaded(object sender, RoutedEventArgs e)
        {
            HttpClient con = new HttpClient();
            con.BaseAddress = new Uri("https://magazynserwer20190103095631.azurewebsites.net/");
            con.DefaultRequestHeaders.Accept.Clear();
            con.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            try
                {
                    HttpResponseMessage odp = con.GetAsync("api/Magazyn").Result;
                        if (odp.IsSuccessStatusCode)
                        {
                        var book = odp.Content.ReadAsAsync<IEnumerable<Magazyn>>().Result;
                        ListGrid.ItemsSource = book;
                        }
                    }
                    catch (Exception ex)
                    {
                        label.Content = ex.Message;
                    }
        }

        private void addBut_Click(object sender, RoutedEventArgs e)
        {
            int i = int.Parse(iloText.Text);
            decimal p = decimal.Parse(cenaText.Text);

            Magazyn m = new Magazyn()
            {
                Nazwa = nazwaText.Text,
                Kategoria = katText.Text,
                Producent = prodText.Text,
                Ilość = i,
                Samochód = samoText.Text,
                Silnik = silnikText.Text,
                Cena = p
            };
            HttpClient con = new HttpClient();
            con.BaseAddress = new Uri("https://magazynserwer20190103095631.azurewebsites.net/");
            var odp = con.PostAsJsonAsync("api/Magazyn", m).Result;
        }

        private void aktBut_Click(object sender, RoutedEventArgs e)
        {
            int i = int.Parse(iloText.Text);
            decimal p = decimal.Parse(cenaText.Text);
            int id = int.Parse(AktText.Text);
            Magazyn m = new Magazyn()
            {
                ID = id,
                Nazwa = nazwaText.Text,
                Kategoria = katText.Text,
                Producent = prodText.Text,
                Ilość = i,
                Samochód = samoText.Text,
                Silnik = silnikText.Text,
                Cena = p
            };
            HttpClient con = new HttpClient();
            con.BaseAddress = new Uri("https://magazynserwer20190103095631.azurewebsites.net/");
            con.DefaultRequestHeaders.Accept.Clear();
            con.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            try
              {
                 HttpResponseMessage odp = con.PutAsJsonAsync($"api/Magazyn/" + AktText.Text, m).Result;
                 odp.EnsureSuccessStatusCode();
                 m = odp.Content.ReadAsAsync<Magazyn>().Result;
              }
            catch (Exception ex)
              {
                label.Content = ex.Message;
              }
        }
        private void usuBut_Click(object sender, RoutedEventArgs e)
        {
            HttpClient con = new HttpClient();
            con.BaseAddress = new Uri("https://magazynserwer20190103095631.azurewebsites.net/");
            con.DefaultRequestHeaders.Accept.Clear();
            con.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            try
              {
                  HttpResponseMessage odp = con.DeleteAsync("api/Magazyn/" + DelText.Text).Result;
                  odp.Content.ReadAsStringAsync();
              }
            catch (Exception ex)
              {
                  label.Content = ex.Message;
              }
        }
     
        private void odsBut_Click(object sender, RoutedEventArgs e)
        {
            HttpClient con = new HttpClient();
            con.BaseAddress = new Uri("https://magazynserwer20190103095631.azurewebsites.net/");
            con.DefaultRequestHeaders.Accept.Clear();
            con.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            try
            {
                HttpResponseMessage odp = con.GetAsync("api/Magazyn").Result;
                if (odp.IsSuccessStatusCode)
                {
                    var book = odp.Content.ReadAsAsync<IEnumerable<Magazyn>>().Result;
                    ListGrid.ItemsSource = book;
                }
            }
            catch (Exception ex)
            {
                label.Content = ex.Message;
            }
        }
    }
}
