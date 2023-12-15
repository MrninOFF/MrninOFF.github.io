using AspNetStatic;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddSingleton<IStaticResourcesInfoProvider>(
  new StaticResourcesInfoProvider(
    new ResourceInfoBase[]
    {
      new PageResource("/"),
      new PageResource("/privacy"),
      //new PageResource("/blog/articles/posts/1") { OutFile = "blog/post-1.html" },
      //new PageResource("/blog/articles/posts/2") { OutFile = "blog/post-2-dark.html", Query = "?theme=dark" },
      new CssResource("/lib/bootstrap/dist/css/bootstrap.min.css") { OptimizerType = OptimizerType.None },
      new CssResource("/css/site.css"),
      new JsResource("/js/site.js"),
      new BinResource("/image.png"),
      new BinResource("/favicon.png")
    }));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.GenerateStaticContent(@"C:\Users\Mrnin\source\repos\MrninOFF.github.io");

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
