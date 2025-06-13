using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

public class HttpMethod()
{
    
    public async Task<Results<NotFound<string>, Ok<User>>> GetUser(int id)
    {
        UserContext db = new UserContext();
        var user = await db.Users.FindAsync(id);
        return user is null
        ? TypedResults.NotFound("Not found.")
        : TypedResults.Ok(user);
    }

    public async Task<List<User>> GetUsers()
    {
        UserContext db = new UserContext();
        List<User> users = await db.Users.ToListAsync();
        return users;
    }

    public async Task<Results<NotFound<string>, Ok<User>>> UpdateUser(int id, User inputUser)
    {
        UserContext db = new UserContext();
        var user = await db.Users.FindAsync(id);
        if (user == null)
        {
            return TypedResults.NotFound("Not found");
        }

        user.Username = inputUser.Username ?? user.Username;
        user.Email = inputUser.Email ?? user.Email;
        user.Password = inputUser.Password ?? user.Password;

        //User in database has been updated

        await db.SaveChangesAsync();

        Console.WriteLine("User data has been updated");
        return TypedResults.Ok(user);
    }

    public async Task<User> CreateUser(User user)
    {
        UserContext db = new UserContext();
        db.Users.Add(user);
        await db.SaveChangesAsync();
        Console.WriteLine("User added to database");
        return user;

    }

    public async Task<string> DeleteUser(int id)
    {
        UserContext db = new UserContext();
        var user = await db.Users.FindAsync(id);
        if (user == null)
        {
            return "Not found";

        }
        else
        {
            db.Users.Remove(user);
            await db.SaveChangesAsync();
            Console.WriteLine($"{user.Username} has been deleted ");
            return "user has been deleted ";
        }
    }


}