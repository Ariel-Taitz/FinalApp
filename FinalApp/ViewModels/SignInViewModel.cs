using FinalApp.Helper;
using FinalApp.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FinalApp.ViewModels
{
    public class SignInViewModel : ViewModelBase
    {
        private DBMokup _db;
        private string _userName;
        private string _password;
        private string _loginMessage;
        private bool _signInMessageVisible;
        private Color _signInMessageColor;

        private bool _entryAsPassword;
        private string _passwordIconCode;

        public SignInViewModel()
        {
            _entryAsPassword = true;
            _passwordIconCode = FontHelper.CLOSED_EYE_ICON;
            _signInMessageVisible = false;
            _loginMessage = String.Empty;
            _db = new DBMokup();

            ShowPasswordCommand = new Command(TogglePassordButton_Clicked);
            SignInCommand = new Command(OnSignInButtonClick, () =>
                        !(string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(UserPassword)));
        }
        public bool EntryAsPassword
        {
            get => _entryAsPassword;
            set
            {

                if (_entryAsPassword != value)
                {
                    _entryAsPassword = value;
                    OnPropertyChanged();
                }

            }
        }
        public string PasswordIconCode
        {
            get => _passwordIconCode;
            set
            {
                if (_passwordIconCode != value)
                {
                    _passwordIconCode = value;
                    OnPropertyChanged();
                }
            }
        }
        public ICommand ShowPasswordCommand { get; }
        public ICommand SignInCommand { get; }
        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
                OnPropertyChanged();
                (SignInCommand as Command).ChangeCanExecute();
            }

        }
        public string UserPassword
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged();
                (SignInCommand as Command).ChangeCanExecute();
            }

        }
        public string LoginMessage
        {
            get => _loginMessage;
            set
            {
                if (_loginMessage != value)
                {
                    _loginMessage = value;
                    OnPropertyChanged();
                }
            }
        }
        public Color SignInMessageColor
        {
            get => _signInMessageColor;
            set
            {
                if (value != _signInMessageColor)
                {
                    _signInMessageColor = value;
                    OnPropertyChanged();
                }

            }
        }
        public bool SignInMessageVisible
        {
            get => _signInMessageVisible;
            set
            {

                if (_signInMessageVisible != value)
                {
                    _signInMessageVisible = value;
                    OnPropertyChanged();
                }

            }
        }

        public bool IsSignInButtonEnabled
        {

            get => !(string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(UserPassword));

        }
        private void OnSignInButtonClick()
        {
            SignInMessageVisible = true;
            if (_db.isExist(UserName, UserPassword))
            {
                LoginMessage = AppMessages.loginMessage;
                SignInMessageColor = Colors.Green;
                //Navigate to MainPage
            }
            else
            {
                LoginMessage = AppMessages.loginErrorMessage;
                SignInMessageColor = Colors.Red;
            }
        }
        private void TogglePassordButton_Clicked()
        {
            EntryAsPassword = !EntryAsPassword;
            if (EntryAsPassword)
                PasswordIconCode = FontHelper.CLOSED_EYE_ICON;
            else
                PasswordIconCode = FontHelper.OPEN_EYE_ICON;

        }
    }
}
