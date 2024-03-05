var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//enabled routing
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    //add your end point

    endpoints.Map("files/{filename}.{extension}", async context =>
    {
        string? fileName = Convert.ToString(context.Request.RouteValues["filename"]);
        string? extension = Convert.ToString(context.Request.RouteValues["extension"]);

        await context.Response.WriteAsync($"In files - {fileName}.{extension}");
    });

    endpoints.Map("employee/profile/{EmployeeName=john}", async (context) =>
    {
        string? employeeName = Convert.ToString(context.Request.RouteValues["employeename"]);

        await context.Response.WriteAsync($"In Employee profile - {employeeName}");
    });

    endpoints.Map("products/details/{id:int?}", async (context) =>
    {
        if (context.Request.RouteValues.ContainsKey("id"))
        {
            int id = Convert.ToInt32(context.Request.RouteValues["id"]);

            await context.Response.WriteAsync($"Products details - {id}");
        }
        else
        {
            await context.Response.WriteAsync($"Products details - id is not supplied");
        }
    });

    endpoints.Map("daily-digest-report/{reportdate:datetime}", async context =>
    {
        DateTime reportDate = Convert.ToDateTime(context.Request.RouteValues["reportdate"]);
        await context.Response.WriteAsync($"In daily-digest-report - {reportDate.ToShortDateString()}");
    });

    endpoints.Map("cities/{cityid:guid}", async context =>
    {
        Guid cityId = Guid.Parse(Convert.ToString(context.Request.RouteValues["cityid"])!);
        await context.Response.WriteAsync($"City information - {cityId}");
    });
});


app.Run(async context =>
{
    await context.Response.WriteAsync($"Request recieved at / {context.Request.Path}");
});

app.Run();
