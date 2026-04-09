using BlazorApp.Components;
using MudBlazor;
using MudBlazor.Services;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddMudServices();
builder.Services.AddTransient<BlazorApp.Features.Services.Interfaces.IUserService, BlazorApp.Features.Services.Implementations.UserService>();
builder.Services.AddTransient<BlazorApp.Features.Services.Implementations.UserService>();
builder.Services.AddTransient<BlazorApp.Features.Services.Interfaces.IBookService, BlazorApp.Features.Services.Implementations.BookService>();
builder.Services.AddTransient<BlazorApp.Features.Services.Implementations.BookService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
