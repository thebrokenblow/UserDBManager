using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using UserDBManager.Core;
using UserDBManager.Model;

namespace UserDBManager.ViewModel;

public class UserViewModel : INotifyPropertyChanged
{
    private ObservableCollection<User>? users;
    public ObservableCollection<User>? Users 
    {
        get => users;
        set
        {
            users = value;
            OnPropertyChanged();
        }
    }

    private User? selectedUser;
    public User? SelectedUser
    {
        get => selectedUser;
        set
        {
            selectedUser = value;
        }
    }

    public RelayCommand RemoveUserCommand { get; set; }

    private readonly UserRepository userRepository = new();

    public UserViewModel()
    {
        SetUser();
        RemoveUserCommand = new(RemoveUser);
    }

    public async void RemoveUser(object? obj)
    {
        if (selectedUser != null && Users != null)
        {
            await userRepository.RemoveUserAsync(selectedUser);
            Users.Remove(selectedUser);
        }
    }

    public async void SetUser()
    {
        var users = await userRepository.GetUsersAsync();
        Users = new(users);
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    public void OnPropertyChanged([CallerMemberName] string propertyName = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}
