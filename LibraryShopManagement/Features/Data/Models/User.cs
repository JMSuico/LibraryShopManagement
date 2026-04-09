using BlazorApp.Features.Data.Enums;

namespace BlazorApp.Features.Data.Models;

public class User
{
    public int Id { get; set; }
    public UserRole Role { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
