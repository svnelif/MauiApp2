namespace MauiApp2
{
    public partial class BMICalculatorPage : ContentPage
    {
        public BMICalculatorPage()
        {
            InitializeComponent();
            CalculateBMI();  // Sayfa açıldığında ilk hesaplama yapılır
        }

        // Hem kilo hem boy değişince çalışan event
        private void OnWeightOrHeightChanged(object sender, ValueChangedEventArgs e)
        {
            if (sender == WeightSlider)
                WeightValueLabel.Text = ((int)e.NewValue).ToString();

            if (sender == HeightSlider)
                HeightValueLabel.Text = ((int)e.NewValue).ToString();

            CalculateBMI(); // Değerler değiştikçe anlık hesap
        }

        // VKİ = Kilo / (Boy * Boy)
        // Boy metreye çevrilir → cm / 100
        private void CalculateBMI()
        {
            double weight = WeightSlider.Value;
            double height = HeightSlider.Value / 100;

            double bmi = weight / (height * height);

            BMIValueLabel.Text = bmi.ToString("F2");

            string category;
            Color indicatorColor;

            if (bmi < 16)
            {
                category = "İleri Düzeyde Zayıf";
                indicatorColor = Colors.DodgerBlue;
            }
            else if (bmi < 17)
            {
                category = "Orta Düzeyde Zayıf";
                indicatorColor = Colors.LightBlue;
            }
            else if (bmi < 18.5)
            {
                category = "Hafif Düzeyde Zayıf";
                indicatorColor = Colors.Cyan;
            }
            else if (bmi < 25)
            {
                category = "Normal Kilolu";
                indicatorColor = Colors.Green;
            }
            else if (bmi < 30)
            {
                category = "Hafif Şişman / Fazla Kilolu";
                indicatorColor = Colors.Orange;
            }
            else if (bmi < 35)
            {
                category = "1. Derecede Obez";
                indicatorColor = Colors.OrangeRed;
            }
            else if (bmi < 40)
            {
                category = "2. Derecede Obez";
                indicatorColor = Colors.Red;
            }
            else
            {
                category = "3. Derecede Obez / Morbid Obez";
                indicatorColor = Colors.DarkRed;
            }

            BMICategoryLabel.Text = category;
            BMIColorIndicator.Color = indicatorColor;
        }
    }
}