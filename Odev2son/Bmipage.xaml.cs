namespace Odev2son;

public partial class Bmipage : ContentPage
{
    public Bmipage()
    {
        InitializeComponent();
        WeightSlider.Value = 70;
        HeightSlider.Value = 170;
        UpdateBmi();
    }

    private void WeightSlider_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        WeightLabel.Text = $"Kilo: {(int)e.NewValue} kg";
        UpdateBmi();
    }

    private void HeightSlider_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        HeightLabel.Text = $"Boy: {(int)e.NewValue} cm";
        UpdateBmi();
    }

    private void UpdateBmi()
    {
        double kg = WeightSlider.Value;
        double cm = HeightSlider.Value;
        double m = cm / 100.0;
        if (m <= 0) return;

        double bmi = kg / (m * m);
        BmiLabel.Text = $"VKİ: {bmi:F2}";

        string cat;
        if (bmi < 18.5) cat = "Zayıf";
        else if (bmi < 25) cat = "Normal";
        else if (bmi < 30) cat = "Fazla Kilolu";
        else cat = "Obez";

        BmiCategoryLabel.Text = $"Kategori: {cat}";
    }
}

