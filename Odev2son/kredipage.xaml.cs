namespace Odev2son;

public partial class kredipage : ContentPage
{
    public kredipage()
    {
        InitializeComponent();
        TermSlider.Value = 12;
        TermLabel.Text = $"Vade: {(int)TermSlider.Value} ay";
    }

    private void TermSlider_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        TermLabel.Text = $"Vade: {(int)e.NewValue} ay";
    }

    private void CalculateButton_Clicked(object sender, EventArgs e)
    {
        // Geçersiz giriş kontrolü (ALERTSİZ)
        if (string.IsNullOrWhiteSpace(AmountEntry.Text) ||
            string.IsNullOrWhiteSpace(RateEntry.Text))
        {
            ResultLabel.Text = "❗ Lütfen kredi tutarı ve faiz oranını girin.";
            return;
        }

        if (!double.TryParse(AmountEntry.Text, out double principal))
        {
            ResultLabel.Text = "❗ Kredi tutarı sayısal olmalı.";
            return;
        }

        if (!double.TryParse(RateEntry.Text, out double annualRate))
        {
            ResultLabel.Text = "❗ Faiz oranı sayısal olmalı.";
            return;
        }

        int months = (int)TermSlider.Value;
        if (months <= 0)
        {
            ResultLabel.Text = "❗ Lütfen geçerli bir vade seçin.";
            return;
        }

        // Aylık faiz oranı
        double i = annualRate / 100.0 / 12.0;
        double monthlyPayment;

        if (i == 0)
        {
            monthlyPayment = principal / months;
        }
        else
        {
            monthlyPayment = principal * i / (1 - Math.Pow(1 + i, -months));
        }

        double totalPayment = monthlyPayment * months;
        double totalInterest = totalPayment - principal;

        ResultLabel.Text =
            $"Seçilen kredi: {CreditPicker.SelectedItem ?? "Belirtilmedi"}\n" +
            $"Aylık ödeme: {monthlyPayment:F2} TL\n" +
            $"Toplam ödeme: {totalPayment:F2} TL\n" +
            $"Toplam faiz: {totalInterest:F2} TL\n" +
            $"Vade: {months} ay";
    }
}
