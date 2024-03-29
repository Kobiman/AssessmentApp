using AssessmentApp.Client;
using AssessmentApp.Client.Events;
using AssessmentApp.Client.Service;
using Blazored.Modal;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddSingleton<IAssementFormNotifier, AssementFormNotifier>(); 
builder.Services.AddSingleton<IAssementService, AssementService>();

//builder.Services.AddHttpClient("AssessmentApp.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
//    .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

// Supply HttpClient instances that include access tokens when making requests to the server project
//builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("AssessmentApp.ServerAPI"));

//builder.Services.AddApiAuthorization();
builder.Services.AddMudServices();
builder.Services.AddBlazoredModal();

await builder.Build().RunAsync();
