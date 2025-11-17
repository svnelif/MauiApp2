using System;

namespace MauiApp2
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
        }

        // 🔹 ToolbarItem Clicked event'i buraya bağlı
        private async void OnMenuClicked(object sender, EventArgs e)
        {
            string result = await DisplayActionSheet(
                "Menü",
                "Kapat",
                null,
                "Ana Sayfa",
                "Kredi Hesaplama",
                "VKİ Hesaplama",
                "Renk Seçici"
            );

            switch (result)
            {
                case "Ana Sayfa":
                    await Shell.Current.GoToAsync("//MainPage");
                    break;

                case "Kredi Hesaplama":
                    await Shell.Current.GoToAsync("//CreditCalculatorPage");
                    break;

                case "VKİ Hesaplama":
                    await Shell.Current.GoToAsync("//BMICalculatorPage");
                    break;

                case "Renk Seçici":
                    await Shell.Current.GoToAsync("//ColorPickerPage");
                    break;
            }
        }
    }
}
