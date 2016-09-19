using System;
using Xamarin.Forms;

namespace Phoneword
{
    // MainPage.cs
    public class MainPage : ContentPage
    {
        Entry phoneNumberText;
        Button translateButton;
        Button callButton;
        string translatedNumber = string.Empty;
        // The generic specification <T> can typically be inferred,
        // it is shown here for clarity.
        double spacing = Device.OnPlatform<double>
            (
                40, // iOS
                20, // Android
                20  // Windows Phone
            );

        public MainPage()
        {
            Padding = new Thickness(20, spacing, 20, 20);

            StackLayout panel = new StackLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Orientation = StackOrientation.Vertical,
                Spacing = 15,
            };

            var label = new Label
            {
                Text = "Enter a Phoneword:"
            };

            phoneNumberText = new Entry
            {
                Text = "1-855-XAMARIN"
            };

            translateButton = new Button
            {
                Text = "Translate"
            };

            callButton = new Button
            {
                Text = "Call",
                IsEnabled = false
            };

            panel.Children.Add(label);
            panel.Children.Add(phoneNumberText);
            panel.Children.Add(translateButton);
            panel.Children.Add(callButton);

            translateButton.Clicked += OnTranslate;
            callButton.Clicked += OnCall;

            Content = panel;
        }

        async void OnCall(object sender, EventArgs e)
        {
            if (await DisplayAlert(
                "Dial a Number",
                "Would you like to call " + translatedNumber + "?",
                "Yes",
                "No"))
            {
                var dialer = DependencyService.Get<IDialer>();
                if (dialer != null)
                {
                    await dialer.DialAsync(translatedNumber);
                }
            }
        }

        private void OnTranslate(object sender, EventArgs e)
        {
            string enteredNumber = phoneNumberText.Text;
            translatedNumber = PhonewordTranslator.ToNumber(enteredNumber);
            if (!string.IsNullOrEmpty(translatedNumber))
            {
                callButton.IsEnabled = true;
                callButton.Text = "Call " + translatedNumber;
            }
            else
            {
                callButton.IsEnabled = false;
                callButton.Text = "Call";
            }
        }
    }
}
