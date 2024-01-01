using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Kanban
{
    public partial class App : Application
    {
        private static UpcomingRepository upcomingRepository;

        public static UpcomingRepository UpcomingRepository 
        {
            get 
            {
                if (upcomingRepository == null) 
                {
                    upcomingRepository = new UpcomingRepository(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Upcoming.db"));
                }
                return upcomingRepository;
            }
        }

        private static In_ProgressRepository in_ProgressRepository;

        public static In_ProgressRepository In_ProgressRepository 
        {
            get 
            {
                if (in_ProgressRepository == null) 
                {
                    in_ProgressRepository = new In_ProgressRepository(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "In_Progress.db"));
                }
                return in_ProgressRepository;
            }
        }

        private static CompletedRepository completedRepository;
        public static CompletedRepository CompletedRepository 
        {
            get 
            {
                if (completedRepository == null) 
                {
                    completedRepository = new CompletedRepository(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Completed.db"));
                }
                return completedRepository;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
