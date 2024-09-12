using Blazored.LocalStorage;
using Blazored.Toast;
using DiscordBlazor;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

#region Injections
builder.Services.AddBlazoredToast();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped(sp =>
{
    return new DiscordDataOperations("https://localhost:7299/swagger/v1/swagger.json", sp.GetRequiredService<HttpClient>());
});

builder.Services.AddBlazoredLocalStorage();
#endregion

await builder.Build().RunAsync();
