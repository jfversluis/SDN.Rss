using System.Linq;
using Xamarin.Forms;

namespace SDN.Rss
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BindingContext = new RssViewModel();
        }

        private void SearchBar_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(e.NewTextValue))
                RssList.ItemsSource = ((RssViewModel)BindingContext).RssNodes;
            else
                RssList.ItemsSource = ((RssViewModel)BindingContext).RssNodes.Where(n => n.Title.Contains(e.NewTextValue));
        }
    }
}