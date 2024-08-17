using UserDBManager.Core;
using UserDBManager.Model;

namespace UserDBManager.ViewModel;

public class AddUserViewModel
{
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? Email { get; set; }

    public RelayCommand AddUserCommand { get; set; }

    private readonly UserRepository userRepository = new();

    public AddUserViewModel()
    {
        AddUserCommand = new(AddUser);
    }

    public async void AddUser(object? obj)
    {
        var user = new User()
        {
            Name = Name,
            Surname = Surname,
            Email = Email
        };

        await userRepository.AddUserAsync(user);
    }
}
