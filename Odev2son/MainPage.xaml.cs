namespace Odev2son
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void kredihesaplama(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new kredipage());


        }

        private async void Bmihesaplama(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Bmipage());


        }

        private async void renksecme(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Renksecme());

        }
    }
}
