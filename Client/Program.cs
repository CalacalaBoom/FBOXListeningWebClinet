using Client;
using Client.Codes;
using Client.Models;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Net.Http;
using System.Net.Http.Json;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://127.0.0.1:8080/") });
builder.Services.AddAntDesign();
builder.Services.AddECharts();
var host =builder.Build();
var httpClient=host.Services.GetRequiredService<HttpClient>();
try
{
    if (httpClient == null) return;
    var url = "server/getboxgroup/";
    Caches.boxgroups = await httpClient.GetFromJsonAsync<List<box_groups>>(url) ?? new List<box_groups>();
    url = "server/getboxs";
    Caches.boxs = await httpClient.GetFromJsonAsync<List<box>>(url) ?? new List<box>();
    url = "server/getdmongroup/";
    Caches.dmonsgroups = await httpClient.GetFromJsonAsync<List<dmon_group>>(url) ?? new List<dmon_group>();
    url = "server/getDmons";
    Caches.dmons = await httpClient.GetFromJsonAsync<List<dmon>>(url) ?? new List<dmon>();
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

await host.RunAsync();
