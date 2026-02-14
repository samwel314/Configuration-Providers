var builder = WebApplication.CreateBuilder(args);

// add json file as configuration provider 
// false => the file is not optional if it not exist the application will throw an exception
builder.Configuration.AddJsonFile("CutoSettings.json", false, true); 

var app = builder.Build();

//   this endpoint take a ( key ) and return value 
app.MapGet("/{key}", (string key , IConfiguration config ) =>
{
    var value = config[key];
    return "Key: " + key + " Value: " + value;
});
app.Run();

/*
 
 1 system environment variables 
  from cli >> setx key value    

BEFORE USE it you should set it 
 
 */

/*

2 project based environment variables
some of this variables are used by asp.net core framework to determine the environment of the application
and have a prefix of "ASPNETCORE_"
Like : aspnetcore_environment = development,production,staging


// how can add ? 
from lanchsettings.json file for local development

 */


/*
 3 - cli configuration providers
 
for testing purpose you can add configuration providers from cli
dotnet run --key=value   , --urls="https/...soon.."
 
 */

/*
 4 - file based configuration providers
 
example : json file , xml file , ini file
if file have key and another file have the same key the last one will override the first one
 
example : appsettings.json file , appsettings.development.json file

means sort is important if you add j

not save to store sensitive data
 
 */ 

