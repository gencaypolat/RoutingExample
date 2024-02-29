var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//enabled routing
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    //add your end point
});

app.Run();
