using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorApp.Features.Data.Enums;

namespace BlazorApp.Features.Helpers;

public class CustomAuthenticationStateProvider
{
    public static bool IsAuthenticated { get; private set; }
    public static string CurrentUsername { get; private set; } = string.Empty;
    public static UserRole CurrentUserRole { get; private set; } = UserRole.Staff;

    private static readonly List<AuthAccount> Accounts = new()
    {
        new AuthAccount
        {
            Username = "admin",
            Email = "admin@libraryshop.com",
            Password = "Admin123!",
            Role = UserRole.Admin
        }
    };

    public Task<AuthActionResult> LoginAsync(string usernameOrEmail, string password, UserRole role)
    {
        if (string.IsNullOrWhiteSpace(usernameOrEmail) || string.IsNullOrWhiteSpace(password))
        {
            return Task.FromResult(new AuthActionResult
            {
                Success = false,
                Message = "Enter your username or email and password."
            });
        }

        var account = Accounts.FirstOrDefault(x =>
            string.Equals(x.Username, usernameOrEmail, StringComparison.OrdinalIgnoreCase) ||
            string.Equals(x.Email, usernameOrEmail, StringComparison.OrdinalIgnoreCase));

        if (account is null || !string.Equals(account.Password, password, StringComparison.Ordinal))
        {
            return Task.FromResult(new AuthActionResult
            {
                Success = false,
                Message = "Invalid login credentials."
            });
        }

        if (account.Role != role)
        {
            return Task.FromResult(new AuthActionResult
            {
                Success = false,
                Message = "The selected role does not match this account."
            });
        }

        IsAuthenticated = true;
        CurrentUsername = account.Username;
        CurrentUserRole = account.Role;

        return Task.FromResult(new AuthActionResult
        {
            Success = true,
            Message = $"Welcome back, {account.Username}."
        });
    }

    public Task<AuthActionResult> RegisterAsync(string username, string email, string password, UserRole role)
    {
        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
        {
            return Task.FromResult(new AuthActionResult
            {
                Success = false,
                Message = "Complete username, email, and password to create an account."
            });
        }

        if (username.Trim().Length < 3)
        {
            return Task.FromResult(new AuthActionResult
            {
                Success = false,
                Message = "Username must be at least 3 characters."
            });
        }

        if (!email.Contains("@", StringComparison.Ordinal))
        {
            return Task.FromResult(new AuthActionResult
            {
                Success = false,
                Message = "Enter a valid email address."
            });
        }

        if (password.Length < 6)
        {
            return Task.FromResult(new AuthActionResult
            {
                Success = false,
                Message = "Password must be at least 6 characters."
            });
        }

        var normalizedUsername = username.Trim();
        var normalizedEmail = email.Trim();

        if (Accounts.Any(x => string.Equals(x.Username, normalizedUsername, StringComparison.OrdinalIgnoreCase)))
        {
            return Task.FromResult(new AuthActionResult
            {
                Success = false,
                Message = "That username is already taken."
            });
        }

        if (Accounts.Any(x => string.Equals(x.Email, normalizedEmail, StringComparison.OrdinalIgnoreCase)))
        {
            return Task.FromResult(new AuthActionResult
            {
                Success = false,
                Message = "That email is already registered."
            });
        }

        Accounts.Add(new AuthAccount
        {
            Username = normalizedUsername,
            Email = normalizedEmail,
            Password = password,
            Role = role
        });

        return Task.FromResult(new AuthActionResult
        {
            Success = true,
            Message = $"Account created for {normalizedUsername}."
        });
    }

    public Task LogoutAsync()
    {
        IsAuthenticated = false;
        CurrentUsername = string.Empty;
        CurrentUserRole = UserRole.Staff;
        return Task.CompletedTask;
    }

    private sealed class AuthAccount
    {
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public UserRole Role { get; set; }
    }
}

public sealed class AuthActionResult
{
    public bool Success { get; set; }
    public string Message { get; set; } = string.Empty;
}
