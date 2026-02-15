using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);
// register options pattern
builder.Services.Configure<AppSettings>
    (builder.Configuration.GetSection(nameof(AppSettings)));


//builder.Services.AddOptions<AppSettings>().Bind(builder.Configuration.GetSection(nameof(AppSettings)));
var app = builder.Build();

/// work with options pattern 

app.MapGet("/option", (IOptions<AppSettings> options) => { 

    var appSettings = options.Value;  
     return appSettings;
});

app.MapGet("/option-Snapshot", (IOptionsSnapshot<AppSettings> options) => {

    var appSettings = options.Value;
    return appSettings;
});

app.MapGet("/option-Monitor", (IOptionsMonitor<AppSettings> options) => {

    var appSettings = options.CurrentValue;
    return appSettings;
});




app.MapGet("/getSingleValueByKey", (IConfiguration config ) =>
{
    return config["Services"];
});
// means nested config : 
app.MapGet("/getSingleValueByPath", (IConfiguration config) =>
{
    return config["ConnectionStrings:DefaultConnection"];
});

app.MapGet("/GetConnectionString", (IConfiguration config) =>
{
    return config.GetConnectionString("DefaultConnection");
});

app.MapGet("/GetValue", (IConfiguration config) =>
{
    // nested not supported :
    return config.GetValue<string>("Services");
});

app.MapGet("/GetSection", (IConfiguration config) =>
{
    // nested not supported :
    return config.GetSection("AppSettings").Get<AppSettings>();
});

app.MapGet("/Bind", (IConfiguration config) =>
{
    // nested not supported :
    AppSettings appSettings = new AppSettings();
    config.GetSection("AppSettings").Bind(appSettings);
    return appSettings;
});


// 

app.Run();
public class AppSettings
{
    public string ApplicationName { get; set; }
    public string Version { get; set; } 
    public   int MaxItemsPerPage { get; set; }

}