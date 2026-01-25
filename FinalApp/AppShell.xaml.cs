using FinalApp.Views;

namespace FinalApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(UsersListPage), typeof(UsersListPage));
            Routing.RegisterRoute(nameof(UserDetailPage), typeof(UserDetailPage));
        }
    }
}
