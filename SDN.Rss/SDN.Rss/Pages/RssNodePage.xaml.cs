using System;
using SDN.Rss.Interfaces;
using Xamarin.Forms;

namespace SDN.Rss.Pages
{
    public partial class RssNodePage : ContentPage
    {
        private readonly RssNode _selectedNode;

        public RssNodePage(RssNode rssNode)
        {
            InitializeComponent();

            _selectedNode = rssNode;
            BindingContext = _selectedNode;
        }

        private void MenuItem_OnClicked(object sender, EventArgs e)
        {
            DependencyService.Get<ITextToSpeech>().Speak(_selectedNode.Summary);
        }

        private void WebView_OnNavigating(object sender, WebNavigatingEventArgs e)
        {
            if (e.NavigationEvent == WebNavigationEvent.NewPage && !e.Url.ToLower().StartsWith("file://"))
            {
                e.Cancel = true;

                Device.OpenUri(new Uri(e.Url));
            }
        }
    }
}