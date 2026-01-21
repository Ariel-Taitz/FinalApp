using FinalApp.Helper;
using FinalApp.Models;
using FinalApp.Service;
using FinalApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FinalApp.ViewModels
{
    public class UsersListViewModel : ViewModelBase
    {
        private bool _entryAsFilter;
        public ICommand? ShowFilterCommand { get; }

        #region Fields
        private string? _searchText; //Text entered in the search bar
        private List<User> _allUsers; //List of users to be displayed
        public string? _filterIconCode;
        #endregion
        #region Properties
        public bool EntryAsFilter
        {
            get => _entryAsFilter;
            set
            {
                if (value != _entryAsFilter)
                {
                    _entryAsFilter = value;
                    OnPropertyChanged();
                }
            }
        }
        public string? SearchText
        {
            get => _searchText;
            set
            {
                if (_searchText != value)
                {
                    _searchText = value;
                    OnPropertyChanged();
                    //Update the command state when SearchText change
                    ClearFilterCommand?.ChangeCanExecute();
                }
            }
        }
        public ObservableCollection<User> AllUsers { get; set; }
        public string? FilterIconCode
        {
            get => _filterIconCode;
            set
            {
                if (_filterIconCode != value)
                {
                    _filterIconCode = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion
        #region Commands
        public Command? SearchCommand { get; }
        public Command? ClearFilterCommand { get; }
        public Command? GetAllUsersCommand
        {
            get
            {
                return new Command(() =>
                {
                    // This command can be used to fetch all users from the database
                    // For example, it could be bound to a button to refresh the user list
                    _allUsers = new DBMokup().GetUsers();
                    AllUsers.Clear(); // Clear the existing collection
                    foreach (var user in _allUsers)
                    {
                        AllUsers.Add(user); // Add each user to the ObservableCollection
                    }
                });
            }
        }
        public Command? DeleteUserCommand { get; }
        public Command? ViewAccountPageCommand { get; }
        #endregion
        public UsersListViewModel()
        {
            //Initialize properties and commands here
            SearchCommand = new Command(OnSearch);
            ClearFilterCommand = new Command(ClearFilter, () => string.IsNullOrEmpty(SearchText));
            // Load all users from the database mockup
            //If this operation will be async, it could not be called in the constructor
            //_allUsers = new DBMokup().GetUsers();
            AllUsers = new(); // Initialize the ObservableCollection
            FilterIconCode = FontHelper.FILTER_ALT_OFF;
            ShowFilterCommand = new Command(ToggleFilterButton);
            DeleteUserCommand = new Command<User>(DeleteUser);
            _entryAsFilter = false;
        }
        private void ClearFilter()
        {

            throw new NotImplementedException();

        }
        private void ToggleFilterButton()
        {
            EntryAsFilter = !EntryAsFilter;
            if (EntryAsFilter)
                FilterIconCode = FontHelper.FILTER_ALT_OFF;
            else
                FilterIconCode = FontHelper.FILTER_ALT_ON;
        }
        private void OnSearch()
        {

            throw new NotImplementedException();

        }
        private void DeleteUser(User user)
        {
            if (user != null)
            {
                // Remove the user from the ObservableCollection
                AllUsers.Remove(user);
            }
        }
    }
}
