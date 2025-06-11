
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<UserContext>();
var app = builder.Build();
HttpMethod httpMethods = new HttpMethod();

app.MapGet("/", () => "Hello World!");
app.MapGet("/users", httpMethods.GetUsers);
app.MapPost("/create", httpMethods.CreateUser);
app.MapGet("/user/{id}", httpMethods.GetUser);
app.MapPut("/user/{id}", httpMethods.UpdateUser);
app.MapDelete("/user/{id}", httpMethods.DeleteUser);

app.Run();
