namespace MauiApp2
{
    public partial class CreditCalculatorPage : ContentPage
    {
        public CreditCalculatorPage()
        {
            InitializeComponent();
        }

        // Kullanıcıya kredi türü seçimi için modern bir ActionSheet menüsü açar.
        private async void OpenCreditTypeMenu(object sender, EventArgs e)
        {
            string action = await DisplayActionSheet(
                "Kredi Türünü Seçin",
                "İptal",
                null,
                "İhtiyaç Kredisi",
                "Konut Kredisi",
                "Ticari Kredi",
                "Taşıt Kredisi");

            if (action != null && action != "İptal")
            {
                CreditTypeLabel.Text = action;
                CreditTypeLabel.TextColor = Colors.Black;
            }
        }

        // Slider değeri değiştikçe etiketi günceller
        private void OnTermSliderValueChanged(object sender, ValueChangedEventArgs e)
        {
            TermValueLabel.Text = ((int)e.NewValue).ToString();
        }

        // Hesaplama işlemi
        private void OnCalculateClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(CreditAmountEntry.Text) ||
                string.IsNullOrEmpty(InterestRateEntry.Text) ||
                CreditTypeLabel.Text == "Kredi Türünü Seçin")
            {
                DisplayAlert("Hata", "Lütfen tüm alanları doldurun.", "Tamam");
                return;
            }

            try
            {
                double tutar = double.Parse(CreditAmountEntry.Text);

                // Hoca: Oran = Yıllık / 100 → formülde yüzdelik olacak
                double oran = double.Parse(InterestRateEntry.Text);

                int vade = (int)TermSlider.Value;

                double bsmv = 0;
                double kkdf = 0;

                string krediTuru = CreditTypeLabel.Text;

                if (krediTuru == "İhtiyaç Kredisi")
                {
                    bsmv = 10;
                    kkdf = 15;
                }
                else if (krediTuru == "Konut Kredisi")
                {
                    bsmv = 0;
                    kkdf = 0;
                }
                else if (krediTuru == "Ticari Kredi")
                {
                    bsmv = 5;
                    kkdf = 0;
                }
                else if (krediTuru == "Taşıt Kredisi")
                {
                    bsmv = 5;
                    kkdf = 15;
                }

                // brutFaiz = ((Oran + (Oran * BSMV ) + (Oran * KKDF )) / 100);
                double brutFaiz = (oran + (oran * bsmv / 100) + (oran * kkdf / 100)) / 100;

                // taksit = (Pow(1+brutFaiz, vade) * brutFaiz) / (Pow(1+brutFaiz, vade) - 1) * tutar;
                double taksit =
                    (Math.Pow(1 + brutFaiz, vade) * brutFaiz) /
                    (Math.Pow(1 + brutFaiz, vade) - 1) * tutar;

                double toplamOdeme = taksit * vade;
                double toplamFaiz = toplamOdeme - tutar;

                MonthlyPaymentLabel.Text = $"Aylık Taksit: {taksit:N2} TL";
                TotalPaymentLabel.Text = $"Toplam Ödeme: {toplamOdeme:N2} TL";
                TotalInterestLabel.Text = $"Toplam Faiz: {toplamFaiz:N2} TL";
            }
            catch
            {
                DisplayAlert("Hata", "Lütfen geçerli değerler girin.", "Tamam");
            }
        }
    }
}
