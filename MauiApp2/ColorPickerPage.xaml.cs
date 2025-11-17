namespace MauiApp2
{
    public partial class ColorPickerPage : ContentPage
    {
        private Random random = new Random();

        public ColorPickerPage()
        {
            InitializeComponent();
            UpdateColor();
        }

        // Slider hareket ettiğinde RGB değerlerini günceller
        private void OnColorChanged(object sender, ValueChangedEventArgs e)
        {
            if (sender == RedSlider)
                RedValueLabel.Text = ((int)e.NewValue).ToString();
            else if (sender == GreenSlider)
                GreenValueLabel.Text = ((int)e.NewValue).ToString();
            else if (sender == BlueSlider)
                BlueValueLabel.Text = ((int)e.NewValue).ToString();

            UpdateColor();
        }

        // Rengi hesaplar ve ekrana uygular
        private void UpdateColor()
        {
            int red = (int)RedSlider.Value;
            int green = (int)GreenSlider.Value;
            int blue = (int)BlueSlider.Value;

            Color color = Color.FromRgb(red, green, blue);

            string hex = $"#{red:X2}{green:X2}{blue:X2}";
            ColorCodeLabel.Text = hex;

            ColorPreviewFrame.BackgroundColor = color;

            // Sayfa arka planını hafif şeffaf renk yapalım
            colorPage.BackgroundColor = color.WithAlpha(0.15f);
        }

        // Renk kodunu kopyalar
        private async void OnCopyClicked(object sender, EventArgs e)
        {
            string code = ColorCodeLabel.Text;
            await Clipboard.SetTextAsync(code);
            await DisplayAlert("Kopyalandı", $"{code} panoya kopyalandı.", "Tamam");
        }

        // Rastgele renk üretir
        private void OnRandomClicked(object sender, EventArgs e)
        {
            int r = random.Next(0, 256);
            int g = random.Next(0, 256);
            int b = random.Next(0, 256);

            RedSlider.Value = r;
            GreenSlider.Value = g;
            BlueSlider.Value = b;

            UpdateColor();
        }
    }
}
