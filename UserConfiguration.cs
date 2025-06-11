using Microsoft.EntityFrameworkCore;
class UserContext() : DbContext
{
    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var builder = WebApplication.CreateBuilder();
        var server = builder.Configuration["SERVER_NAME"];
        var password = builder.Configuration["PASSWORD"];
        var databaseName = builder.Configuration["DATABASE_NAME"];
        var username = builder.Configuration["USERNAME"];

        optionsBuilder.UseMySQL($"server={server}; user={username}; database={databaseName}; password={password};");
    }
    

}