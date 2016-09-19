using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace FirstApp
{
    public class App : Application
    {
        /*public static MasterDetailPage MasterDetail;
        public static NavigationPage MasterNav;
        public static NavigationPage DetailNav;*/
        public App()
        {
            /*MasterNav = new NavigationPage()
            {
                Title = "Customer"
            };
            DetailNav = new NavigationPage();

            MasterDetail = new MasterDetailPage()
            {
                Master = MasterNav,
                Detail = DetailNav
            };

            MainPage = MasterDetail;*/

            // The root page of your application
            MainPage = new ContentPage
            {
                Content = new StackLayout
                {
                    VerticalOptions = LayoutOptions.Center,
                    Children = {
                        new Label {
                            HorizontalTextAlignment = TextAlignment.Center,
                            Text = "Welcome to Xamarin Forms!"
                        }
                    }
                }
            };
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
