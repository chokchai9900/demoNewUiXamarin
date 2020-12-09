using demoNewUiXamarin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Shapes;
using Xamarin.Forms.Xaml;

namespace demoNewUiXamarin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DangAndDropDemo : ContentPage
    {
        const double area = 200 * 200;
        public DangAndDropDemo()
        {
            InitializeComponent();
        }

        private void DragGestureRecognizer_DragStarting(object sender, DragStartingEventArgs e)
        {
            Shape shape = (sender as Element).Parent as Shape;
            e.Data.Properties.Add("Square", new Square(shape.Width, shape.Height));
        }

        async void DropGestureRecognizer_Drop(object sender, DropEventArgs e)
        {
            Square square = (Square)e.Data.Properties["Square"];

            if (square.Area.Equals(area))
            {
                await DisplayAlert("Correct", "Congratulations!", "OK");
            }
            else
            {
                await DisplayAlert("Incorrect", "Try again.", "OK");
            }
        }
    }
}