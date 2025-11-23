namespace Odev2son;

public partial class Renksecme : ContentPage
{
    Random rnd = new Random();

    public Renksecme()
    {
        InitializeComponent();
        RedSlider.Value = 0;
        GreenSlider.Value = 0;
        BlueSlider.Value = 0;
        UpdateColor();
    }

    private void Rgb_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        UpdateColor();
    }

    private void UpdateColor()
    {
        int r = (int)RedSlider.Value;
        int g = (int)GreenSlider.Value;
        int b = (int)BlueSlider.Value;

        RedLabel.Text = r.ToString();
        GreenLabel.Text = g.ToString();
        BlueLabel.Text = b.ToString();

        string hex = $"#{r:X2}{g:X2}{b:X2}";
        HexLabel.Text = hex;

        PreviewFrame.BackgroundColor = new Color((float)r / 255f, (float)g / 255f, (float)b / 255f);
        this.BackgroundColor = new Color((float)r / 255f, (float)g / 255f, (float)b / 255f);

    }

    private async void CopyColor_Clicked(object sender, EventArgs e)
    {
        string renk_kodu = HexLabel.Text;
        await Clipboard.SetTextAsync(renk_kodu);
    }

    private void RandomColor_Clicked(object sender, EventArgs e)
    {
        RedSlider.Value = rnd.Next(0, 256);
        GreenSlider.Value = rnd.Next(0, 256);
        BlueSlider.Value = rnd.Next(0, 256);

    }
}