using FinalApp.Models;
using FinalApp.Service;

namespace FinalApp.Views;

[QueryProperty(nameof(ReceivedUser), " selectedUser ")]
public partial class UserDetailPage : ContentPage
{
    private User _receivedUser;
    public User ReceivedUser
    {
        get => _receivedUser;
        set
        {
            if (_receivedUser != value )
{
                _receivedUser = value;
                OnPropertyChanged(nameof(ReceivedUser));
                // Load user details based on the received user
                LoadUserDetails(_receivedUser);
            }
        }
    }
    private void LoadUserDetails(User user)
    {
        FirstNameEntry.Text = user.FirstName ?? string.Empty;
        LastNameEntry.Text = user.LastName ?? string.Empty;
        EmailEntry.Text = user.UEmail ?? string.Empty;
        MobileEntry.Text = user.UMobile ?? string.Empty;
    }

    private async void UpdateButton_Clicked(object sender, EventArgs e)
    {
        User user = new User
        {
            Id = ReceivedUser.Id,
            FirstName = FirstNameEntry.Text,
            LastName = LastNameEntry.Text,
            UEmail = EmailEntry.Text,
            UMobile = MobileEntry.Text
        };
        DBMokup.UpdateUser(user);
        await Shell.Current.GoToAsync("..");
        //await Navigation.PopAsync ();
    }
}