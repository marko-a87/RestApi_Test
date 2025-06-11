using Microsoft.EntityFrameworkCore;
using DotNetEnv;
class UserContext() : DbContext
{
    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        DotNetEnv.Env.Load();
        var server = Environment.GetEnvironmentVariable("SERVER_NAME");
        var password = Environment.GetEnvironmentVariable("PASSWORD");
        var databaseName = Environment.GetEnvironmentVariable("DATABASE_NAME");
        var username = Environment.GetEnvironmentVariable("USERNAME");
        optionsBuilder.UseMySQL($"server={server}; user={username}; database={databaseName}; password={password};");
    }
    

}