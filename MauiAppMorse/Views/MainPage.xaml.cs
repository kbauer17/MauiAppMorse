using System.Reflection;

namespace MauiAppMorse.Views
{
    public partial class MainPage : ContentPage
    {
        private string dotsNDashes;
        private string message;
        
        public MainPage()
        {
            InitializeComponent();
            var version = typeof(MauiApp).Assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>()
                ?.InformationalVersion;
            VersionLabel.Text = $".NET MAUI ver. {version?[..version.IndexOf('+')]}";
            dotsNDashes = "";
            message = "";
        }

        private void Dash_Clicked(object sender, EventArgs e)
        {
            dotsNDashes += "-";
            DotsAndDashes.Text = dotsNDashes;
        }
        
        private void Dot_Clicked(object sender, EventArgs e)
        {
            dotsNDashes += ".";
            DotsAndDashes.Text = dotsNDashes;
        }
        
        private void Space_Clicked(object sender, EventArgs e)
        {
            char letter = Morse.MorseCoder(dotsNDashes);
            message += letter;
            Letters.Text = message;
            dotsNDashes = "";
        }
    }
}