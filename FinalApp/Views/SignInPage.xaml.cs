using FinalApp.Helper;
using FinalApp.Service;
using FinalApp.ViewModels;

namespace FinalApp.Views;

public partial class SignInPage : ContentPage
{
    private DBMokup _db;
    private string _userName;
    private string _password;
    private string _loginMessage;
    private bool _signInMessageVisible;
    private Color _signInMessageColor;

    private bool _entryAsPassword;
    private string _passwordIconCode;

    public SignInPage()
    {
        InitializeComponent();
        BindingContext = new SignInViewModel();
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
    public string UserName
    {
        get { return _userName; }
        set
        {
            _userName = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(IsSignInButtonEnabled));
        }

    }
    public string UserPassword
    {
        get { return _password; }
        set
        {
            _password = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(IsSignInButtonEnabled));
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
    private void OnSignInButtonClick(object sender, EventArgs e)
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
    private void TogglePassordButton_Clicked(object sender, EventArgs e)
    {
        EntryAsPassword = !EntryAsPassword;
        if (EntryAsPassword)
            PasswordIconCode = FontHelper.CLOSED_EYE_ICON;
        else
            PasswordIconCode = FontHelper.OPEN_EYE_ICON;

    }
}