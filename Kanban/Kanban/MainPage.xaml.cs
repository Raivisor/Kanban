using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Kanban
{

    public partial class MainPage : CarouselPage
    {
        private int id;

        public MainPage()
        {
            InitializeComponent();
            Show_Upcoming_Tasks();
            Show_In_progress();
            Show_Completed_tasks();
        }

        private void Create_Task(object sender, EventArgs e)
        {
            App.UpcomingRepository.SaveUpcomingTasks(new Upcoming { Name = Entry_Task_Name.Text, Description = Entry_Task_Description.Text});
            Debug.Print(App.UpcomingRepository.GetUpcomingTasks()[1].ID.ToString());
            Show_Upcoming_Tasks();
            Create_Task_Layout.IsVisible = false;
        }

        private void To_In_progress(object sender, EventArgs e)
        {
            Button but = sender as Button;
            In_Progress ip = new In_Progress()
            {
                Name = App.UpcomingRepository.GetUpcomingTask(but.TabIndex).Name,
                Description = App.UpcomingRepository.GetUpcomingTask(but.TabIndex).Description
            };
            App.UpcomingRepository.DeleteUpcomingTasks(but.TabIndex);
            App.In_ProgressRepository.SaveInProgressTasks(ip);
            Show_Upcoming_Tasks();
            Show_In_progress();
        }

        private void To_Upcoming(object sender, EventArgs e)
        {
            Button but = sender as Button;
            Upcoming up = new Upcoming()
            {
                Name = App.In_ProgressRepository.GetInProgressTask(but.TabIndex).Name,
                Description = App.In_ProgressRepository.GetInProgressTask(but.TabIndex).Description
            };
            App.UpcomingRepository.SaveUpcomingTasks(up);
            App.In_ProgressRepository.DeleteInProgressTasks(but.TabIndex);
            Show_In_progress();
            Show_Upcoming_Tasks();
        }

        private void To_Completed(object sender, EventArgs e)
        {
            Button but = sender as Button;
            Completed completed = new Completed()
            {
                Name = App.In_ProgressRepository.GetInProgressTask(but.TabIndex).Name,
                Description = App.In_ProgressRepository.GetInProgressTask(but.TabIndex).Description
            };
            App.CompletedRepository.SaveCompletedTasks(completed);
            App.In_ProgressRepository.DeleteInProgressTasks(but.TabIndex);
            Show_In_progress();
            Show_Completed_tasks();
        }

        private void To_Upcoming_From_Completed(object sender, EventArgs e)
        {
            Button but = sender as Button;
            Upcoming up = new Upcoming()
            {
                Name = App.CompletedRepository.GetCompletedTask(but.TabIndex).Name,
                Description = App.CompletedRepository.GetCompletedTask(but.TabIndex).Description
            };
            App.UpcomingRepository.SaveUpcomingTasks(up);
            App.CompletedRepository.DeleteCompletedTasks(but.TabIndex);
            Show_Completed_tasks();
            Show_Upcoming_Tasks();
        }

        private void Show_Upcoming_Tasks()
        {
            Created_Tasks.ItemsSource = App.UpcomingRepository.GetUpcomingTasks();
        }

        private void Show_In_progress()
        {
            In_Progress.ItemsSource = App.In_ProgressRepository.GetInProgressTasks();
        }

        private void Show_Completed_tasks()
        {
            Completed_Tasks.ItemsSource = App.CompletedRepository.GetCompletedTasks();
        }

        private async void Delete_Upcoming_Task(object sender, EventArgs e)
        {
            Button but = sender as Button;
            bool b = await DisplayAlert("Удаление кнопки", "Вы точно хотите удалить задачу?", "Да", "Нет");
            if (!b) return;
            App.UpcomingRepository.DeleteUpcomingTasks(but.TabIndex);
            Show_Upcoming_Tasks();
        }

        private void Show_Create_Layout(object sender, EventArgs e)
        {
            Create_Task_Layout.IsVisible = true;
        }

        private void Rollback(object sender, EventArgs e)
        {
            Create_Task_Layout.IsVisible = false;
            Change_Task_Layout.IsVisible = false;
        }

        private void Show_Change_Layout(object sender, EventArgs e)
        {
            Change_Task_Layout.IsVisible = true;
            Button but = sender as Button;
            id = but.TabIndex;
            Change_Task_Name.Text = App.UpcomingRepository.GetUpcomingTask(id).Name;
            Change_Task_Description.Text = App.UpcomingRepository.GetUpcomingTask(id).Description;
        }

        private async void Change_task_Upcoming(object sender, EventArgs e)
        {
            Button but = sender as Button;
            bool b = await DisplayAlert("Изменение кнопки", "Вы точно хотите изменить задачу?", "Да", "Нет");
            if (!b) return;
            Upcoming up = new Upcoming() { Name = Change_Task_Name.Text, Description = Change_Task_Description.Text, ID = id};
            App.UpcomingRepository.UpdateUpcomingTasks(up);
            Show_Upcoming_Tasks();
            Change_Task_Layout.IsVisible = false;
        }
    }
}
