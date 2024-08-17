using Microsoft.EntityFrameworkCore;
using UserDBManager.Data;

namespace UserDBManager.Model;

public class UserRepository
{
    public async Task<List<User>> GetUsersAsync()
    {
        using var userContext = new UserContext();
        return await userContext.Users.ToListAsync();
    }

    public async Task AddUserAsync(User user)
    {
        using var userContext = new UserContext();
        await userContext.Users.AddAsync(user);
        await userContext.SaveChangesAsync();
    }

    public async Task EditUserAsync(int id, User user)
    {
        using var userContext = new UserContext();

        var editableUser = await userContext.Users.FirstAsync(user => user.Id == id);

        if (editableUser == null)
        {
            throw new Exception("Не найден пользователь");
        }

        editableUser.Name = user.Name;
        editableUser.Surname = user.Surname;
        editableUser.Email = user.Email;

        await userContext.SaveChangesAsync();
    }

    public async Task RemoveUserAsync(User deletingUser)
    {
        using var userContext = new UserContext();
        
        userContext.Users.Remove(deletingUser);
        await userContext.SaveChangesAsync();
    }
}
