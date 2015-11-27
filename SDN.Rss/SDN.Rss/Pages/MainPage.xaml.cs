using System.Linq;
using Xamarin.Forms;

namespace SDN.Rss.Pages
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
                RssList.ItemsSource = ((RssViewModel)BindingContext).RssNodes.Where(n => n.Title.ToLower().Contains(e.NewTextValue.ToLower()));
        }

        private async void RssList_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedNode = e.SelectedItem as RssNode;

            if (selectedNode == null)
                return;

            await Navigation.PushAsync(new RssNodePage(selectedNode), true);

            RssList.SelectedItem = null;
        }
    }
}