using FinalApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FinalApp.Service
{
    public class ObservableUser : INotifyPropertyChanged
    {
        User _user;
        public event PropertyChangedEventHandler? PropertyChanged;
        public string? FirstName;
        public string? LastName;
        public string? UEmail;
        public string? UPassword;
        public string? UMobile;
        public DateTime UBDate;
        public DateTime RegDate;
        public bool IsAdmin;
        public User User
        {
            get => _user;
        }
        public int Id
        {
            get => _user.Id;
            set
            {
                if (_user.Id != value )
{
                    _user.Id = value;
                    OnPropertyChanged();
                }
            }
        }

        public ObservableUser(User user)
        {
            _user = user;
        }
        protected virtual void OnPropertyChanged([ CallerMemberName ] string ?
        propertyName =null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //private void AddUser()
        //{

        //    _allUsers[0].FirstName = " Fname Changed";

        //}
    }
}
