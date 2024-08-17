

using System.ComponentModel;
using System.Runtime.CompilerServices;
using UserDBManager.Core;
using UserDBManager.Model;

namespace UserDBManager.ViewModel;

public class EditViewModel : INotifyPropertyChanged
{
    private User? editingUser;
    public User? EditingUser 
    {
        get => editingUser;
        set
        {
            editingUser = value;
            OnPropertyChanged();
        }
    }

    public RelayCommand EditUserCommand { get; set; }
    private readonly UserRepository userRepository = new();
    public EditViewModel()
    {
        EditUserCommand = new(EditUser);
    }
    public async void EditUser(object obj)
    {
        if (EditingUser is not null)
        {
            await userRepository.EditUserAsync(EditingUser.Id, EditingUser);
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    public void OnPropertyChanged([CallerMemberName] string propertyName = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}
