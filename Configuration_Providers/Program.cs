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