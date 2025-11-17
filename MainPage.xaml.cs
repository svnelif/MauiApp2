namespace MauiApp2
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnExploreClicked(object sender, EventArgs e)
        {
            
            DisplayAlert("Hoşgeldiniz!", "Uygulamayı keşfetmek için alt menüden farklı sayfalar arasında geçiş yapabilirsiniz.", "Tamam");
        }
    }
}