using FinalApp.Models;
using FinalApp.ViewModels;

namespace FinalApp.Views;

public partial class UsersListPage : ContentPage
{
    public UsersListPage()
    {
        InitializeComponent();
        BindingContext = new UsersListViewModel();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        // Optionally, you can call a method to load data when the page appears
        if (BindingContext is UsersListViewModel viewModel)
        {

            viewModel.GetAllUsersCommand?.Execute(null);

        }
    }
}