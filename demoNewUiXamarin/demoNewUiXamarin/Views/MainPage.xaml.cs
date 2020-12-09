using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.CommunityToolkit;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.CommunityToolkit.UI.Views.Options;
using System.Diagnostics;

namespace demoNewUiXamarin
{
    public partial class MainPage : ContentPage
    {
        public ICommand NavigateCommand { get; private set; }

        public MainPage()
        {
            InitializeComponent();

            NavigateCommand = new Command<Type>(
                async (Type pageType) =>
                {
                    Page page = (Page)Activator.CreateInstance(pageType);
                    await Navigation.PushAsync(page);
                });

            BindingContext = this;
        }

        async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            var messageOptions = new MessageOptions
            {
                Foreground = Color.Black,
                Message = "My text"
            };
            var options = new ToastOptions
            {
                MessageOptions = messageOptions,
                BackgroundColor = Color.Gray,
                IsRtl = false,
            };
            await this.DisplayToastAsync(options);
        }

        async void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {

            var messageOptions = new MessageOptions
            {
                Foreground = Color.Black,
                Message = "My text"
            };
            var actionOptions = new List<SnackBarActionOptions>
            {
                new SnackBarActionOptions
                {
                    ForegroundColor = Color.Black,
                    BackgroundColor = Color.White,
                    Text = "My text",
                    Action = () => // null by default
                    {
                        Debug.WriteLine("1");
                        return Task.CompletedTask;
                    }
                }
            };
            var options = new SnackBarOptions
            {
                MessageOptions = messageOptions,
                BackgroundColor = Color.Default,
                IsRtl = false,
                Actions = actionOptions
            };
            await this.DisplayToastAsync(options);
        }
    }
}
