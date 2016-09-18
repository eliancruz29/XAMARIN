using System;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Phone.Controls;

namespace TaskyPro {
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            DataContext = new TaskListViewModel();
            Loaded += MainPage_Loaded;
        }

        async void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            await ((TaskListViewModel)DataContext).BeginUpdate();
        }

        private void HandleAdd(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/TaskDetailsPage.xaml?id=-1", UriKind.RelativeOrAbsolute));
        }

        private void HandleTaskTap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            var item = ((Grid)sender).DataContext as TaskViewModel;

            if (item != null) {
                NavigationService.Navigate(new Uri("/TaskDetailsPage.xaml?id=" + item.ID, UriKind.RelativeOrAbsolute));
            }
        }
    }
}