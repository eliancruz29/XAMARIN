using System;
using Microsoft.Phone.Controls;
using Tasky.Core;

namespace TaskyPro
{
    public partial class TaskDetailsPage : PhoneApplicationPage
    {
        public TaskDetailsPage()
        {
            InitializeComponent();
        }

        protected async override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (e.NavigationMode == System.Windows.Navigation.NavigationMode.New)
            {
                var vm = new TaskViewModel();
                var task = default(TodoTask);

                if (NavigationContext.QueryString.ContainsKey("id"))
                {
                    var id = int.Parse(NavigationContext.QueryString["id"]);
                    task = await TodoManager.GetTaskAsync(id);
                }

                if (task != null)
                {
                    vm.Update(task);
                }

                DataContext = vm;
            }
        }

        private async void HandleSave(object sender, EventArgs e)
        {
            var taskvm = (TaskViewModel)DataContext;
            var task = taskvm.GetTask();
            await TodoManager.SaveTaskAsync(task);

            NavigationService.GoBack();
        }

        private async void HandleDelete(object sender, EventArgs e)
        {
            var taskvm = (TaskViewModel)DataContext;
            if (taskvm.ID >= 0)
            {
                await TodoManager.DeleteTaskAsync(taskvm.GetTask());
            }

            NavigationService.GoBack();
        }
    }
}