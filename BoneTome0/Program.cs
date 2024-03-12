using AspNetStatic;
using BoneTome0.Components;

namespace BoneTome0;

public class Program
{
    public static void Main(string[] args)
    {
        bool onlyServeStaticContent = "SHOW_STATIC_CONTENT_ONLY".Equals(
            Environment.GetEnvironmentVariable("CONTENT_MODE"),
            StringComparison.OrdinalIgnoreCase);

        bool runningInSsgMode = args.HasExitWhenDoneArg();
        
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

        if (!builder.Environment.IsDevelopment())
        {
            builder.WebHost.UseStaticWebAssets();
        }
        
        // Add services to the container.
        builder.Services.AddRazorComponents();

        if (!onlyServeStaticContent && runningInSsgMode)
        {
            builder.Services.AddSingleton<IStaticResourcesInfoProvider>(
                StaticResourcesInfo.GetProvider());
        }

        WebApplication app = builder.Build();

        if (onlyServeStaticContent)
        {
            app.UseDefaultFiles();
        }

        app.UseStaticFiles();

        if (!onlyServeStaticContent)
        {
            app.UseAntiforgery();

            app.MapRazorComponents<App>();

            if (runningInSsgMode)
            {
                const string OutputDirName = "docs";
                string ssgOutputDir = Path.Combine("..", OutputDirName);

                Directory.CreateDirectory(ssgOutputDir);
                
                app.GenerateStaticContent(
                    ssgOutputDir,
                    exitWhenDone: true);
            }
        }

        app.Run();
    }
}