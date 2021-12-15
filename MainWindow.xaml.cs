using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
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

namespace Homework_HTTP
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //public ObservableCollection<Hero> Heros { set; get; } = new ObservableCollection<Hero>();
        public MainWindow()
        {
            InitializeComponent();
           // DataContext = this;
            var herous = UsingHttpWebRequest();
            foreach (var item in herous)
            {
                lbHero.Items.Add(item);// Heros.Add(item);
            }

        }

        private static List<Hero> UsingHttpWebRequest()
        {
            const string url = "http://hp-api.herokuapp.com/api/characters";
            HttpWebRequest request = WebRequest.CreateHttp(url); //створюємо обєкт класа HttpWebRequest
            var responce = (HttpWebResponse)request.GetResponse(); //отримуємо відповідь від request і розпарсуємо її до HttpWebRequest
            var stream = responce.GetResponseStream();//повертає потік, який використовується для читання відповіді

            var reader = new StreamReader(stream); //считуємо stream
            var json = reader.ReadToEnd(); // і поміщаємо його в json

            List<Hero> items = JsonConvert.DeserializeObject<List<Hero>>(json);//десереалізуємо у список Hero
            return items;

        }
    }
}
