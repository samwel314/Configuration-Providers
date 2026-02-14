var builder = WebApplication.CreateBuilder(args);
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